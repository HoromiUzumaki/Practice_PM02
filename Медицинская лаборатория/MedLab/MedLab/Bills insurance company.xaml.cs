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
    /// Логика взаимодействия для Bills_insurance_company.xaml
    /// </summary>
    public partial class Bills_insurance_company : Window
    {
        private ЛабораторияEntities8 db;
        public Bills_insurance_company()
        {
            InitializeComponent();
            db = new ЛабораторияEntities8();
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
    }
}
