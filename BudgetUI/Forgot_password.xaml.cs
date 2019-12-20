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
    /// Логика взаимодействия для Forgot_password.xaml
    /// </summary>
    public partial class Forgot_password : Window
    {
        public Forgot_password()
        {
            InitializeComponent();
        }

        private void Button_login_back_Click(object sender, RoutedEventArgs e)
        {
            Login lgbt = new Login();
            lgbt.Show();
            this.Close();
        }
    }
}
