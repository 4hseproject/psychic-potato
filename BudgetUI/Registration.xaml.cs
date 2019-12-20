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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        //IAppData appData = Factory.Instance.GetAppData();
        //Calculations calculations = Factory.Instance.GetCalculations();
        public Registration()
        {
            InitializeComponent();
            
        }

        private void Button_Enter_Click(object sender, RoutedEventArgs e)
        {
            Calculations calculations = Factory.Instance.GetCalculations();
            if (TextBox_name.Text.Length > 0) 
            {
                if (PasswordBox_password.Password.Length > 0)
                {
                    if (Decimal.TryParse(TextBox_budget.Text, out decimal budget))
                    {

                        if (calculations.AddUser(TextBox_name.Text, PasswordBox_password.Password, budget))
                        {
                            Login lw = new Login();
                            lw.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("User already exists");
                        }
                    }
                    else
                        MessageBox.Show("Please input your budget properly", "Type Error");
                }
                else
                    MessageBox.Show("Password cannot be empty");
                
            }
            else
                MessageBox.Show("Login cannot be empty");
        }

        private void TextBox_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox_name.Text = '';

        }
    }
}
