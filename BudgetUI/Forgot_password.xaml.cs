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

        private void Button_show_question_Click(object sender, RoutedEventArgs e)
        {
            if (calculations.Qestion_per_login(TextBox_login.Text.Trim()) != null)
            {
                TextBlock_question.Text = calculations.Qestion_per_login(TextBox_login.Text.Trim());
            }
            else
            {
                TextBlock_question.Text = "No user with this Login";
            }
            TextBox_login.Text = "";
        }
    }
}
