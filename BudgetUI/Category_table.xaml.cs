using Budget2._0;
using Budget2._0.models;
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
    /// Логика взаимодействия для Category_table.xaml
    /// </summary>
    public partial class Category_table : Window
    {
        public DateTime StartDt { get; set; }
        AppData appData = Factory.Instance.GetAppData();
        Calculations calculations = Factory.Instance.GetCalculations();
        public DateTime EndDt { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
        public Category_table(User User, DateTime start, DateTime end, Category category)
        {
            InitializeComponent();
            this.StartDt = start;
            this.EndDt = end;
            this.Category = category;
            this.User = User;
            TextBlock_start.Text = start.Date.ToString();
            TextBlock_end.Text = end.Date.ToString();
            List<DataVisualisationGeneral> dataVisualisations = new List<DataVisualisationGeneral>();
            if (Category.Name == "Income")
            {
                foreach (Income el in appData.gains)
                {
                    if (User.UID == el.UID && DateTime.Compare(el.TransactionDt, start) >= 0 && DateTime.Compare(el.TransactionDt, end) <= 0)
                    {
                        var datainc = new DataVisualisationGeneral();
                        datainc.Amount = el.Amount.ToString();
                        datainc.Date = el.TransactionDt.Date;
                        datainc.Comment = el.Comment;
                        dataVisualisations.Add(datainc);
                    }
                }
            }
            else {
                foreach (Spending el in appData.losses)
                {
                    if (User.UID == el.UID && DateTime.Compare(el.TransactionDt, start) >= 0 && DateTime.Compare(el.TransactionDt, end) <= 0 && el.Category == category)
                    {
                        var data = new DataVisualisationGeneral();
                        data.Amount = el.Amount.ToString();
                        data.Date = el.TransactionDt.Date;
                        data.Comment = el.Comment;
                        dataVisualisations.Add(data);
                    }
                }
            }
            calculations.SortByDate2(dataVisualisations);
            spendingsList.ItemsSource = dataVisualisations;
        }

        private void Button_main_menu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_main_menu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
