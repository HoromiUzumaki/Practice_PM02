using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Win32;
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
using Microsoft.Office.Interop.Word;

namespace MedLab
{
    /// <summary>
    /// Логика взаимодействия для generating_reports.xaml
    /// </summary>
    public partial class generating_reports : System.Windows.Window
    {
       
        private ЛабораторияEntities2 db;

        public generating_reports()
        {
            InitializeComponent();
            db = new ЛабораторияEntities2();
        }
       


        //отчет об оказанных услугах
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var data = db.Оказанные_услуги.Select(x => new { x.Код_оказанной_услуги, 
                x.Дата_оказания_услуги, x.Результат, x.Заказ.Код_заказа, x.Заказ.Пользователи.Фамилия, 
                x.Заказ.Пользователи.Имя, x.Заказ.Пользователи.Отчество, x.Услуга.Наименование_услуги,
                x.Услуга.Стоимость_услуги });
            dat3.ItemsSource = data.ToList();
        }

       

        //сохранение отчета об оказанных услугах
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var data = db.Оказанные_услуги.Select(x => new {
                x.Код_оказанной_услуги,
                x.Дата_оказания_услуги,
                x.Результат,
                x.Заказ.Код_заказа,
                x.Заказ.Пользователи.Фамилия,
                x.Заказ.Пользователи.Имя,
                x.Заказ.Пользователи.Отчество,
                x.Услуга.Наименование_услуги,
                x.Услуга.Стоимость_услуги
            });

            // создаем приложение Word
            var wordApp = new Microsoft.Office.Interop.Word.Application();

            // создаем новый документ
            var wordDoc = wordApp.Documents.Add();

            // пишем заголовок
            var параграф = wordDoc.Paragraphs.Add();
            параграф.Range.Text = "Отчет по оказанным услугам";
            параграф.Range.InsertParagraphAfter();

            // создаем таблицу
            var таблица = wordDoc.Tables.Add(параграф.Range, data.Count() + 1, 9);
            таблица.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            таблица.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;

            // заполняем заголовки таблицы
            таблица.Cell(1, 1).Range.Text = "Код услуги";
            таблица.Cell(1, 2).Range.Text = "Дата оказания";
            таблица.Cell(1, 3).Range.Text = "Результат";
            таблица.Cell(1, 4).Range.Text = "Код заказа";
            таблица.Cell(1, 5).Range.Text = "Фамилия";
            таблица.Cell(1, 6).Range.Text = "Имя";
            таблица.Cell(1, 7).Range.Text = "Отчество";
            таблица.Cell(1, 8).Range.Text = "Услуга";
            таблица.Cell(1, 9).Range.Text = "Стоимость";

            // заполняем данные в таблицу
            int rowIndex = 2;
            foreach (var item in data)
            {
                таблица.Cell(rowIndex, 1).Range.Text = item.Код_оказанной_услуги.ToString();
                таблица.Cell(rowIndex, 2).Range.Text = item.Дата_оказания_услуги.ToString();
                таблица.Cell(rowIndex, 3).Range.Text = item.Результат;
                таблица.Cell(rowIndex, 4).Range.Text = item.Код_заказа.ToString();
                таблица.Cell(rowIndex, 5).Range.Text = item.Фамилия;
                таблица.Cell(rowIndex, 6).Range.Text = item.Имя;
                таблица.Cell(rowIndex, 7).Range.Text = item.Отчество;
                таблица.Cell(rowIndex, 8).Range.Text = item.Наименование_услуги;
                таблица.Cell(rowIndex, 9).Range.Text = item.Стоимость_услуги.ToString();
                rowIndex++;
            }

            // сохраняем документ
            wordDoc.SaveAs2("Отчет по оказанным услугам.docx");

            // закрываем приложение Word
            wordApp.Quit();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var data = db.Услуга
    .GroupJoin(db.Оказанные_услуги, u => u.Код_услуги, o => o.Код_услуги, (u, os) => new
    {
        Услуга = u,
        Оказанные_услуги = os
    })
    .Select(x => new
    {
        Наименование_услуги = x.Услуга.Наименование_услуги,
        Количество_заказов = x.Оказанные_услуги.Count(),
        Общая_стоимость = x.Оказанные_услуги.Sum(o => o.Услуга.Стоимость_услуги)
    })
    .OrderByDescending(x => x.Количество_заказов);

            dat3.ItemsSource = data.ToList();

        }
    }
}
