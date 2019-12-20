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

        public bool hasBeenClicked { get; set; }
        public bool hasBeenClicked1 { get; set; }
        public bool hasBeenClicked2 { get; set; }
        public Registration()
        {
            InitializeComponent();
            hasBeenClicked = false;
            hasBeenClicked1 = false;
            hasBeenClicked2 = false;
            Combobox_questions.Items.Add("Вилкой раз или ...?");
            Combobox_questions.Items.Add("Есть 2 стула: какой выберешь?");
            Combobox_questions.Items.Add("Номер твоей мамы");
            

            TextBox_Answer.Text = "Answer";
            
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
                        if (Combobox_questions.SelectedIndex != -1)
                        {
                            if (TextBox_Answer.Text.Length > 0)
                            {
                                if (calculations.AddUser(TextBox_name.Text.Trim(), PasswordBox_password.Password, budget, TextBox_Answer.Text.Trim(), Combobox_questions.SelectedItem.ToString()))
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
                            {
                                MessageBox.Show("otvet zapili, horoshiy chelovek", "кря");
                            }
                        }
                        else
                        {
                            MessageBox.Show("chooce question", "кря");
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

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            Login lw = new Login();
            lw.Show();
            this.Close();
        }

        private void TextBox_name_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked = true;
            }
        }

        private void TextBox_budget_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked1)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked1 = true;
            }
        }

        private void TextBox_Answer_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked2)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked2 = true;
            }
        }


        //private void TextBox_Answer_Focus(object sender, RoutedEventArgs e)
        //{
        //if (!hasBeenClicked)
        // {
        //TextBox box = sender as TextBox;
        //  box.Text = String.Empty;
        //      hasBeenClicked = true;
        //}
        //}


    }
}
