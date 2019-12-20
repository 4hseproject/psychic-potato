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
    /// Логика взаимодействия для Change_password.xaml
    /// </summary>
    public partial class Change_password : Window
    {
        AppData appData = Factory.Instance.GetAppData();
        Calculations calculations = Factory.Instance.GetCalculations();
        public bool hasBeenClicked { get; set; }
        public bool hasBeenClicked1 { get; set; }
        public bool hasBeenClicked2 { get; set; }
        public User User { get; set; }
        public Change_password(User user)
        {
            this.User = user;
            InitializeComponent();
            hasBeenClicked = false;
            hasBeenClicked1 = false;
            hasBeenClicked2 = false;

        }

        private void TextBox_oldpassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked = true;
            }
        }

        private void TextBox_newpassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked1)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked1 = true;
            }
        }

        private void TextBox_repeatpassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked2)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked2 = true;
            }
        }

        private void Button_main_menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(User);
            mw.Show();
            this.Close();
        }

        private void Button_ok_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox_oldpassword.Text.Length > 0 & TextBox_newpassword.Text == TextBox_repeatpassword.Text & TextBox_repeatpassword.Text.Length >0) 
            {
                User = calculations.Changepassword(User, TextBox_newpassword.Text);
                MainWindow mw = new MainWindow(User);
                mw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong data entered");
            }
        }
    }
}
