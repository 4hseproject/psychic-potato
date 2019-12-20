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
        public bool hasBeenClicked { get; set; }
        public Forgot_password()
        {
            InitializeComponent();
            hasBeenClicked = false;
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
            var answer = calculations.Answer_per_login(login);
            if (Textbox_answer.Text.Trim() == answer)
            {
                MessageBox.Show(calculations.Password_per_login(login), "your password");
                Login lgbt = new Login();
                lgbt.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong answer", "кря");
            }
        }

        private void TextBox_login_TextChanged(object sender, TextChangedEventArgs e)
        {

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
