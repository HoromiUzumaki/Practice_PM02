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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            generating_reports gr = new generating_reports();
            gr.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            using (var context = new ЛабораторияEntities8()) 
            {
                var authorizationData = context.Авторизация.ToList(); // Получаем все данные из таблицы "Авторизация"

                data.ItemsSource = authorizationData; // Устанавливаем источник данных для DataGrid
            }
        }
    }
}
