using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BudgetUI
{
    /// <summary>
    /// Логика взаимодействия для ChoosePeriod.xaml
    /// </summary>
    public partial class ChoosePeriod : Window
    {
        public ChoosePeriod()
        {
            InitializeComponent();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Go_Button_Click(object sender, RoutedEventArgs e)
        {
            Data_Window dw = new Data_Window();
            dw.Show();
            this.Close();
        }
    }
}
