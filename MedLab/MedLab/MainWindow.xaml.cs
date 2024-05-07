using System;
using System.Collections.Generic;
using System.Data;
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

        private void UpdateTime(int code)
        {
            using (var bd = new ЛабораторияEntities5())
            {
                var user = bd.Авторизация.Where(j => j.Код_пользователя == code).FirstOrDefault();
                user.Дата_и_время_входа = DateTime.Now;
                bd.SaveChanges();
            }   
        }
        private void authorization_Click(object sender, RoutedEventArgs e)
        {
            if (log.Text == "" || par.Password == "")
            {
                MessageBox.Show("Заполните поля");
                return;
            }

            using (var bd = new ЛабораторияEntities5())
            {
                
                var user = bd.Авторизация.FirstOrDefault(p => p.Логин == log.Text && p.Пароль == par.Password);
                if (user != null)
                {
                    if ((user.Время_блокировки != null) && (Convert.ToInt32((DateTime.Now - user.Время_блокировки).Value.TotalMinutes) <= 30))
                    {
                        MessageBox.Show($"Учетная запись временно заблокированна. До конца блокировки {30 - ((DateTime.Now - user.Время_блокировки).Value.Minutes)} минут.");
                        return;
                    }

                    var role = from pol in bd.Пользователи
                               join
                               rol in bd.Должность on pol.Код_должности equals rol.Код_должности
                               where (pol.Код_пользователя == user.Код_пользователя)
                               select rol.Наименование;
                    switch (role.FirstOrDefault())
                    {
                        case "Лаборант":
                            UpdateTime(Convert.ToInt32(user.Код_пользователя));
                            LabWindow la = new LabWindow();
                            la.Show();
                            this.Close();
                            break;

                        case "Лаборант-исследователь":
                            UpdateTime(Convert.ToInt32(user.Код_пользователя));
                            LabIslWindow lr = new LabIslWindow();
                            lr.Show();
                            this.Close();
                            break;

                        case "Бухгалтер":
                            UpdateTime(Convert.ToInt32(user.Код_пользователя));
                            BuhgalterWindow ac = new BuhgalterWindow();
                            ac.Show();
                            this.Close();
                            break;

                        case "Администратор":
                            UpdateTime(Convert.ToInt32(user.Код_пользователя));
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
