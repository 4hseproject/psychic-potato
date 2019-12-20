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
    /// Логика взаимодействия для Settings_window.xaml
    /// </summary>
    public partial class Settings_window : Window
    {
        AppData appData = Factory.Instance.GetAppData();
        Calculations calculations = Factory.Instance.GetCalculations();
        public bool hasBeenClicked { get; set; }
        public bool hasBeenClicked1 { get; set; }
        public User User { get; set; }
        public Settings_window(User user)
        {
            this.User = user;
            InitializeComponent();
            hasBeenClicked = false;
            hasBeenClicked1 = false;
        }

        private void Button_MainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(User);
            mw.Show();
            this.Close();
        }

        private void Button_ok_Click(object sender, RoutedEventArgs e)
        {
            decimal amount;
            if (TextBox_Name.Text.Length > 0)
            {
                if (!Decimal.TryParse(TextBox_Budget.Text, out amount))
                {
                    MessageBox.Show("Wrong budget", "BUdGET");
                }
                else
                {
                    User = calculations.Changebudgetname(User, TextBox_Budget.Text.Trim(), amount);
                    MainWindow mw = new MainWindow(User);
                    mw.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Enter name", "ERRRRRRORR");
                return;
            }
        }

        private void TextBox_Name_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked = true;
            }
        }

        private void TextBox_Budget_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked1)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked1 = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Change_password cp = new Change_password(User);
            cp.Show();
            this.Close();
        }
    }
}
