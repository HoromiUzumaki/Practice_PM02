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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedLab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void authorization_Click(object sender, RoutedEventArgs e)
        {
            if (log.Text == "" || par.Text == "")
            {
                MessageBox.Show("Заполните поля");
                return;
            }

            using (var bd = new ЛабораторияEntities())
            {
                
                var user = bd.Авторизация.FirstOrDefault(p => p.Логин == log.Text && p.Пароль == par.Text);
                if (user != null)
                {
                   
                    var role = from pol in bd.Пользователи
                               join
                               rol in bd.Должность on pol.Код_должности equals rol.Код_должности
                               where (pol.Код_пользователя == user.Код_пользователя)
                               select rol.Наименование;
                    switch (role.FirstOrDefault())
                    {
                        case "Лаборант":
                            LabWindow la = new LabWindow();
                            la.Show();
                            this.Close();
                            break;

                        case "Лаборант-исследователь":
                            LabIslWindow lr = new LabIslWindow();
                            lr.Show();
                            this.Close();
                            break;

                        case "Бухгалтер":
                            BuhgalterWindow ac = new BuhgalterWindow();
                            ac.Show();
                            this.Close();
                            break;

                        case "Администратор":                         
                            AdminWindow ad = new AdminWindow();
                            ad.Show();
                            this.Close();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Логин или пароль указаны неверно");
                    return;
                }
            }
        }
    }
}
