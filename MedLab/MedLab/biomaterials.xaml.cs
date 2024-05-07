using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MedLab
{
    /// <summary>
    /// Логика взаимодействия для biomaterials.xaml
    /// </summary>
    public partial class biomaterials : Window
    {
        private ЛабораторияEntities5 db;
        public biomaterials()
        {
            InitializeComponent();
            db = new ЛабораторияEntities5();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Работа_с_биоматериалами newData = new Работа_с_биоматериалами
            {
                Код_взятия_материала = int.Parse(_1.Text),
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
    }
}
