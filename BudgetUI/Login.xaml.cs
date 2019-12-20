using Budget2._0;
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
        AppData appData = Factory.Instance.GetAppData();
        Calculations calculations = Factory.Instance.GetCalculations();
        public bool hasBeenClicked { get; set; }
        public Login()
        {
            InitializeComponent();
            hasBeenClicked = false;
        }

        private void Button_sign_in_Click(object sender, RoutedEventArgs e)
        {
            var user = new User();
            user = calculations.CheckLogin(TextBox_login.Text.Trim(), PasswordBox_password.Password);
            if (user != null)
            {
                MainWindow mw = new MainWindow(user);
                mw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("wrong login or password", "Authentication Error");
            }
        }

        private void Button_sign_up_Click(object sender, RoutedEventArgs e)
        {
            Registration rw = new Registration();
            rw.Show();
            this.Close();
        }

        private void Button_forgot_password_Click(object sender, RoutedEventArgs e)
        {
            Mary_tries_graphs maryw = new Mary_tries_graphs();
            maryw.Show();
            this.Close();
        }
        private void TextBox_login_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked = true;
            }
        }
    }
}
