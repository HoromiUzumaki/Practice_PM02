using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для Bills_insurance_company.xaml
    /// </summary>
    public partial class Bills_insurance_company : Window
    {
        private ЛабораторияEntities2 db;
        public Bills_insurance_company()
        {
            InitializeComponent();
            db = new ЛабораторияEntities2();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Получить значения из полей ввода
            int кодСчета = int.Parse(_1.Text);
            int кодЗаказа = int.Parse(_2.Text);
            int кодПользователяОформившегоЗаказ = int.Parse(_3.Text);
            int кодПользователяОтветственногоЗаказ = int.Parse(_4.Text);
            int кодСтраховойКомпании = int.Parse(_5.Text);
            decimal общаяСумма = decimal.Parse(_6.Text);

            // Создать новый объект Счета_страховым_компаниям
            var newRecord = new Счета_страховым_компаниям
            {
                Код_счета = кодСчета,
                Код_заказа = кодЗаказа,
                Код_пользователя_оформившего_заказ = кодПользователяОформившегоЗаказ,
                Код_пользователя_ответственного_за_заказ = кодПользователяОтветственногоЗаказ,
                Код_страховой_компании = кодСтраховойКомпании,
                Общая_сумма = общаяСумма
            };

            // Добавить новый объект в контекст базы данных
            db.Счета_страховым_компаниям.Add(newRecord);

            // Сохранить изменения в базе данных
            db.SaveChanges();

            // Отобразить сообщение об успехе
            MessageBox.Show("Данные успешно добавлены в базу данных!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Создаем объект StringBuilder для хранения данных CSV
            StringBuilder csvData = new StringBuilder();

            // Добавляем заголовки столбцов
            csvData.AppendLine("Код_счета,Код_заказа,Код_пользователя_оформившего_заказ,Код_сотрудника_ответственного_за_заказ,Код_страховой_компании_пользователя,Общая_сумма");

            // Получить введенные данные из элементов управления
            string кодСчета = _1.Text;
            string кодЗаказа = _2.Text;
            string кодПользователяОформившегоЗаказ = _3.Text;
            string кодПользователяОтветственногоЗаказ = _4.Text;
            string кодСтраховойКомпании = _5.Text;
            string общаяСумма = _6.Text;

            // Добавляем данные в строку CSV
            csvData.AppendLine($"{кодСчета},{кодЗаказа},{кодПользователяОформившегоЗаказ},{кодПользователяОтветственногоЗаказ},{кодСтраховойКомпании},{общаяСумма}");

            // Сохраняем данные CSV в файл
            using (StreamWriter writer = new StreamWriter("bills_insurance_company.csv"))
            {
                writer.Write(csvData.ToString());
                writer.Close();
            }

            // Выводим сообщение пользователю
            MessageBox.Show("Данные сохранены в файл bills_insurance_company.csv");
        }
    }
}
