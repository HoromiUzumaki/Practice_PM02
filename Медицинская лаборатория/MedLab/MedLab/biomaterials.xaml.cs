using Aspose.BarCode.Generation;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Path = System.IO.Path;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using static MedLab.biomaterials;


namespace MedLab
{
    /// <summary>
    /// Логика взаимодействия для biomaterials.xaml
    /// </summary>
    public partial class biomaterials : Window
    {
        private ЛабораторияEntities2 db;
        public ObservableCollection<string> Items { get; set; }
        public class Barcode
        {
            public string Text { get; set; }

            public BaseEncodeType BarcodeType { get; set; }

            public BarCodeImageFormat ImageType { get; set; }
        }
        public biomaterials()
        {
            InitializeComponent();
            db = new ЛабораторияEntities2();
            Items = new ObservableCollection<string>
        {
            "Code128",
            "Code11",
            "Code32",
            "QR",
            "DataMatrix",
            "EAN13",
            "EAN8",
            "ITF14",
            "PDF417"

        };
            comboBarcodeType.ItemsSource = Items; // привязка коллекции к ComboBox
        }
    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Работа_с_биоматериалами newData = new Работа_с_биоматериалами
            {
                Код_взятия_материала = int.Parse(_1.Text),
                Код_пробирки = int.Parse(_6.Text),
                Дата_взятия = date.SelectedDate,
                Вид_биоматериала = _2.Text,
                Код_сотрудника_взявшего_биоматериал = int.Parse(_3.Text),
                Код_должности = int.Parse(_4.Text),
                Наименование = _5.Text
            };

            db.Работа_с_биоматериалами.Add(newData);
            db.SaveChanges();

            MessageBox.Show("Данные успешно добавлены в базу данных!");
        }
        public string GenerateBarcode(Barcode barcode)
        {
            // Путь к изображению
            string imagePath = comboBarcodeType.Text + "." + barcode.ImageType;

            // Инициализировать генератор штрих-кода
            BarcodeGenerator generator = new BarcodeGenerator(barcode.BarcodeType, barcode.Text);

            // Сохранить изображение
            generator.Save(imagePath, barcode.ImageType);

            return imagePath;
        }
        public string GenerateBarcodeWithOptions(Barcode barcode)
        {
            // Путь к изображению
            string imagePath = comboBarcodeType.Text + "." + barcode.ImageType;

            // Инициализировать генератор штрих-кода
            BarcodeGenerator generator = new BarcodeGenerator(barcode.BarcodeType, barcode.Text);

            if (barcode.BarcodeType == EncodeTypes.QR)
            {
                generator.Parameters.Barcode.XDimension.Pixels = 4;
                //установить автоматическую версию
                generator.Parameters.Barcode.QR.QrVersion = QRVersion.Auto;
                //Установите тип автоматического кодирования QR
                generator.Parameters.Barcode.QR.QrEncodeType = QREncodeType.Auto;
            }
            else if (barcode.BarcodeType == EncodeTypes.Pdf417)
            {
                generator.Parameters.Barcode.XDimension.Pixels = 2;
                generator.Parameters.Barcode.Pdf417.Columns = 3;
            }
            else if (barcode.BarcodeType == EncodeTypes.DataMatrix)
            {
                //установите DataMatrix ECC на 140
                generator.Parameters.Barcode.DataMatrix.DataMatrixEcc = DataMatrixEccType.Ecc200;
            }
            else if (barcode.BarcodeType == EncodeTypes.Code32)
            {
                generator.Parameters.Barcode.XDimension.Millimeters = 1f;
            }
            else
            {
                generator.Parameters.Barcode.XDimension.Pixels = 2;
                //установить BarHeight 40
                generator.Parameters.Barcode.BarHeight.Pixels = 40;
            }

            // Сохранить изображение
            generator.Save(imagePath, barcode.ImageType);

            return imagePath;
        }


        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            // Установить по умолчанию как PNG
            var imageType = "Png";

            // Получить выбранный пользователем формат изображения
            if (rbPng.IsChecked == true)
            {
                imageType = rbPng.Content.ToString();
            }
            else if (rbBmp.IsChecked == true)
            {
                imageType = rbBmp.Content.ToString();
            }
            else if (rbJpg.IsChecked == true)
            {
                imageType = rbJpg.Content.ToString();
            }

            // Получить формат изображения из перечисления
            var imageFormat = (BarCodeImageFormat)Enum.Parse(typeof(BarCodeImageFormat), imageType.ToString());

            // Установить по умолчанию как Code128
            var encodeType = EncodeTypes.Code128;

            // Получить выбранный пользователем тип штрих-кода
            if (!string.IsNullOrEmpty(comboBarcodeType.Text))
            {
                switch (comboBarcodeType.Text)
                {
                    case "Code128":
                        encodeType = EncodeTypes.Code128;
                        break;

                    case "ITF14":
                        encodeType = EncodeTypes.ITF14;
                        break;

                    case "EAN13":
                        encodeType = EncodeTypes.EAN13;
                        break;

                    case "Datamatrix":
                        encodeType = EncodeTypes.DataMatrix;
                        break;

                    case "Code32":
                        encodeType = EncodeTypes.Code32;
                        break;

                    case "Code11":
                        encodeType = EncodeTypes.Code11;
                        break;

                    case "PDF417":
                        encodeType = EncodeTypes.Pdf417;
                        break;

                    case "EAN8":
                        encodeType = EncodeTypes.EAN8;
                        break;

                    case "QR":
                        encodeType = EncodeTypes.QR;
                        break;
                }
            }

            // Инициализировать объект штрих-кода
            Barcode barcode = new Barcode();
            barcode.Text = _6.Text;
            barcode.BarcodeType = encodeType;
            barcode.ImageType = imageFormat;

            try
            {
                string imagePath = "";

                if (cbGenerateWithOptions.IsChecked == true)
                {
                    // Сгенерируйте штрих-код с дополнительными параметрами и получите путь к изображению
                    imagePath = GenerateBarcodeWithOptions(barcode);
                }
                else
                {
                    // Сгенерировать штрих-код и получить путь к изображению
                    imagePath = GenerateBarcode(barcode);
                }

                // Показать изображение
                Uri fileUri = new Uri(Path.GetFullPath(imagePath));
                imgDynamic.Source = new BitmapImage(fileUri);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string GenerateBarcode()
        {
            throw new NotImplementedException();
        }
    }
}
