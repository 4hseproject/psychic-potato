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
    /// Логика взаимодействия для ChoosePeriod.xaml
    /// </summary>
    public partial class ChoosePeriod : Window
    {
        public bool hasBeenClicked { get; set; }
        public bool hasBeenClicked1 { get; set; }
        AppData appData = Factory.Instance.GetAppData();
        Calculations calculations = Factory.Instance.GetCalculations();
        public User User { get; set; }
        public ChoosePeriod(User user)
        {
            InitializeComponent();
            this.User = user;
            hasBeenClicked = false;
            hasBeenClicked1 = false;
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(User);
            mw.Show();
            this.Close();
        }

        private void Go_Button_Click(object sender, RoutedEventArgs e)
        {
            var result = new DateTime();
            var result2 = new DateTime();
            var category = new Category();
            if (ComboBox_ChooseCategory.SelectedIndex != -1)
                category = calculations.GetCategory(ComboBox_ChooseCategory.SelectedItem.ToString());
            else
                category = null;
            // todo check that while part works correctly
            if (!DateTime.TryParse(TextBox_Start.Text, out result) || !DateTime.TryParse(TextBox_End.Text, out result2))
            {
                MessageBox.Show("Please enter the dates in correct format", "Incorrect Input");
                return;
            }

            Data_Window dw = new Data_Window(User,result, result2,category);
            dw.Show();
            this.Close();
        }

        private void TextBox_Start_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked = true;
            }
        }

        private void TextBox_End_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!hasBeenClicked1)
            {
                TextBox box = sender as TextBox;
                box.Text = String.Empty;
                hasBeenClicked1 = true;
            }
        }
    }
}
