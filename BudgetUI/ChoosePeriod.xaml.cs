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
            foreach(Category el in appData.categories)
            {
                ComboBox_ChooseCategory.Items.Add(el.Name);
            }
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
            if (!DateTime.TryParse(TextBox_Start.Text, out result) || !DateTime.TryParse(TextBox_End.Text, out result2))
            {
                MessageBox.Show("Please enter the dates in correct format", "Incorrect Input");
                return;
            }
            result = result.Date;
            result2 = result2.Date;
            if (ComboBox_ChooseCategory.SelectedIndex != -1)
            { 
                category = calculations.GetCategory(ComboBox_ChooseCategory.SelectedItem.ToString());
                Category_table cw = new Category_table(User, result, result2,category);
                cw.Show();
                this.Close();
            }
            else
            {
                category = null;
                Data_Window dw = new Data_Window(User, result, result2);
                dw.Show();
                this.Close();
            }
                
            // todo check that while part works correctly
            
            
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
