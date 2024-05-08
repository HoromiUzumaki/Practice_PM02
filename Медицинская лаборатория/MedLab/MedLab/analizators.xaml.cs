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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MedLab
{
    /// <summary>
    /// Логика взаимодействия для analizators.xaml
    /// </summary>
    public partial class analizators : Window
    {
        public analizators()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ЛабораторияEntities8())
            {
                var analizatorData = context.Анализатор.ToList(); 

                data1.ItemsSource = analizatorData; 
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (var context = new ЛабораторияEntities8())
            {
                var analizatorworkData = context.Работа_анализатора.ToList();

                data1.ItemsSource = analizatorworkData;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            data1.IsReadOnly = false; // Разрешаем редактирование данных в таблице
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            data1.IsReadOnly = false; // Разрешаем редактирование данных в таблице
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            using (var context = new ЛабораторияEntities8())
            {
                foreach (var item in data1.Items)
                {
                    var analizator = item as Анализатор;
                    if (analizator != null)
                    {
                        var existingAnalizator = context.Анализатор.Find(analizator.Код_анализатора);
                        if (existingAnalizator != null)
                        {
                            context.Entry(existingAnalizator).CurrentValues.SetValues(analizator); // Обновляем значения записи
                        }
                    }
                }

                context.SaveChanges(); // Сохраняем изменения в базе данных
            }

            data1.IsReadOnly = true; // Запрещаем редактирование данных в таблице
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            using (var context = new ЛабораторияEntities8())
            {
                foreach (var item in data1.Items)
                {
                    var работаАнализатора = item as Работа_анализатора;
                    if (работаАнализатора != null)
                    {
                        var existingРаботаАнализатора = context.Работа_анализатора.Find(работаАнализатора.Дата_и_время_поступления_заказа_на_анализатор);
                        if (existingРаботаАнализатора != null)
                        {
                            context.Entry(existingРаботаАнализатора).CurrentValues.SetValues(работаАнализатора); // Обновляем значения записи
                        }
                    }
                }

                context.SaveChanges(); // Сохраняем изменения в базе данных
            }

            data1.IsReadOnly = true; // Запрещаем редактирование данных в таблице
        }
    }
}
