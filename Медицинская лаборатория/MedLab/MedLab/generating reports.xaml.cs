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


namespace MedLab
{
    /// <summary>
    /// Логика взаимодействия для generating_reports.xaml
    /// </summary>
    public partial class generating_reports : Window
    {

        public generating_reports()
        {
            InitializeComponent();
        }
       



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ЛабораторияEntities8())
            {
                var rw = context.Работа_с_биоматериалами.ToList(); 

                data2.ItemsSource = rw; 
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           // using (var context = new ЛабораторияEntities8())
            //{
              //  var rw = context.Работа_с_биоматериалами.ToList();
              
            //}

         
            //var wordApp = new Microsoft.Office.Interop.Word.Application();
            //var wordDoc = wordApp.Documents.Add();

          
            //wordDoc.Paragraphs.Add();
           // wordDoc.Paragraphs[1].Range.Text = "Отчет по работе с биоматериалами";
           // wordDoc.Paragraphs[1].Range.Font.Bold = true;
           // wordDoc.Paragraphs[1].Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

           // wordDoc.Paragraphs.Add();
           // wordDoc.Paragraphs[2].Range.Text = ""; 

          
           // var saveFileDialog = new SaveFileDialog();
           // saveFileDialog.Filter = "Файл Word (*.docx)|*.docx";
           // if (saveFileDialog.ShowDialog() == true)
           // {
            //    wordDoc.SaveAs2(saveFileDialog.FileName);
           // }

           
            //wordDoc.Close();
           // wordApp.Quit();
        }
    }
}
