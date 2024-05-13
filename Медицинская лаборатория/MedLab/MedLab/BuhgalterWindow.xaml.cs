﻿using System;
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
    /// Логика взаимодействия для BuhgalterWindow.xaml
    /// </summary>
    public partial class BuhgalterWindow : Window
    {
        public BuhgalterWindow()
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
            Bills_insurance_company bw = new Bills_insurance_company();
            bw.Show();
            this.Close();
        }
    }
}
