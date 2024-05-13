using Microsoft.Kiota.Abstractions;
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
using System.Data.Entity.Core.Objects;


namespace MedLab
{
    /// <summary>
    /// Логика взаимодействия для Patients.xaml
    /// </summary>
    public partial class Patients : Window
    {

        public Patients()
        {
            InitializeComponent();
           
        }

        //создание  и изменение пациентов
        private void save_Click(object sender, RoutedEventArgs e)
        {
            using (var bd = new ЛабораторияEntities2())
            {
                bool exists = bd.Пользователи.Any(p => p.Код_пользователя == Convert.ToInt32(_1.Text));

                if (exists) // редактируем пользователя
                {
                    var polzovatel = bd.Пользователи.FirstOrDefault(p => p.Код_пользователя == Convert.ToInt32(_1.Text));
                    polzovatel.Фамилия = _2.Text;
                    polzovatel.Имя = _3.Text;
                    polzovatel.Отчество = _4.Text;
                    bd.SaveChanges();

                    //сохраняем дополнительную информацию
                    var DopInf = bd.Дополнительная_информация.FirstOrDefault(d => d.Код_дополнительной_информации == Convert.ToInt32(_5.Text));
                    DopInf.Серия_паспорта = Convert.ToInt32(_6.Text);
                    DopInf.Номер_паспорта = Convert.ToInt32(_7.Text);
                    DopInf.Номер_телефона = _8.Text;
                    DopInf.Email = _9.Text;
                    DopInf.Номер_страховой_компании = Convert.ToInt32(_10.Text);
                    DopInf.Номер_страхового_полиса = _11.Text;
                    bd.SaveChanges();
                }
                else // создаем нового пользователя
                {
                    var polzovatel = new Пользователи();
                    polzovatel.Код_пользователя = Convert.ToInt32(_1.Text);
                    polzovatel.Фамилия = _2.Text;
                    polzovatel.Имя = _3.Text;
                    polzovatel.Отчество = _4.Text;
                    bd.Пользователи.Add(polzovatel);

                    var DopInf = new Дополнительная_информация();
                    DopInf.Код_дополнительной_информации = Convert.ToInt32(_5.Text);
                    DopInf.Код_пользователя = Convert.ToInt32(_1.Text);
                    DopInf.Серия_паспорта = Convert.ToInt32(_6.Text);
                    DopInf.Номер_паспорта = Convert.ToInt32(_7.Text);
                    DopInf.Номер_телефона = _8.Text;
                    DopInf.Email = _9.Text;
                    DopInf.Номер_страховой_компании = Convert.ToInt32(_10.Text);
                    DopInf.Номер_страхового_полиса = _11.Text;
                    bd.Дополнительная_информация.Add(DopInf);

                    bd.SaveChanges();
                }

                MessageBox.Show("Данные успешно сохранены!");
            }

        }
       




        
    }
}

