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
using Budget2._0;

namespace BudgetUI
{
    /// <summary>
    /// Логика взаимодействия для Forgot_password.xaml
    /// </summary>
    public partial class Forgot_password : Window
    {
        
        AppData appData = Factory.Instance.GetAppData();
        Calculations calculations = Factory.Instance.GetCalculations();
        public string login;
        public Forgot_password()
        {
            InitializeComponent();
            Textbox_answer.Visibility = Visibility.Hidden;
            Button_show_password.Visibility = Visibility.Hidden;
        }

        private void Button_login_back_Click(object sender, RoutedEventArgs e)
        {
            Login lgbt = new Login();
            lgbt.Show();
            this.Close();
        }

        private void Button_show_question_Click(object sender, RoutedEventArgs e)
        {
            if (calculations.Qestion_per_login(TextBox_login.Text.Trim()) != null)
            {
                TextBlock_question.Text = calculations.Qestion_per_login(TextBox_login.Text.Trim());
                TextBox_login.Visibility = Visibility.Hidden;
                Button_show_question.Visibility = Visibility.Hidden;
                login = TextBox_login.Text.Trim();
                Textbox_answer.Visibility = Visibility.Visible;
                Button_show_password.Visibility = Visibility.Visible;
            }
            else
            {
                TextBlock_question.Text = "No user with this Login";
            }
            TextBox_login.Text = "";

        }

        private void Button_show_password_click(object sender, RoutedEventArgs e)
        {
            if (true)
            {

            }
            else
            {
                MessageBox.Show("Wrong answer", "кря");
            }
        }
    }
}
