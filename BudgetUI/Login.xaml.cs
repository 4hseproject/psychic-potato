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
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_sign_in_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            //mw.Show(); <----вот тут оно ругается
            this.Close();
        }

        private void Button_sign_up_Click(object sender, RoutedEventArgs e)
        {
            Registration rw = new Registration();
            rw.Show();
            this.Close();
        }
    }
}
