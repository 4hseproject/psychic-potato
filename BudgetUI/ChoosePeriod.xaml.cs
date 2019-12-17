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
        IAppData appData = Factory.Instance.GetAppData();
        Calculations calculations = Factory.Instance.GetCalculations();
        public ChoosePeriod()
        {
            InitializeComponent();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void Go_Button_Click(object sender, RoutedEventArgs e)
        {
            var result = new DateTime();
            var result2 = new DateTime();
            var category = new Category();
            category = calculations.GetCategory(ComboBox_ChooseCategory.SelectedItem.ToString());
            while (!DateTime.TryParse(TextBox_Start.Text, out result) || !DateTime.TryParse(TextBox_End.Text, out result2))
            {
                MessageBox.Show("Please enter the dates in correct format", "Incorrect Input");
            }
            Data_Window dw = new Data_Window(result, result2,category);
            dw.Show();
            this.Close();
        }
    }
}
