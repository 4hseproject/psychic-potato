﻿using Budget2._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BudgetUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppData appData = Factory.Instance.GetAppData();
        Calculations calculations = Factory.Instance.GetCalculations();
        public User User { get; set; }
        public MainWindow(User user)
        {
            InitializeComponent();
            this.User = user;
            foreach (Category el in appData.categories)
            {
                Category_box.Items.Add(el.Name);
            }
            Balance_box.Text = User.OverallBalance.ToString();
            Inc_Spend.Items.Add("Spending");
            Inc_Spend.Items.Add("Income");
            //Login lg = new Login();
            // lg.Show();
            //this.Close();
        }

        private void More_info_Button_Click(object sender, RoutedEventArgs e)
        {
            ChoosePeriod chw = new ChoosePeriod(User);
            chw.Show();
            this.Close();
        }

        private void Category_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            decimal amount;
            bool isSpending;
            string comment;
            comment = Comment_box.Text;
            Category category = new Category();
            while (
            !Decimal.TryParse(Sum_box.Text,out amount))
            {
                MessageBox.Show("Please use apropriate format", "Wrong format");
            }
            
            category.Name = Category_box.SelectedItem.ToString();
            foreach (Category el in appData.categories)
            {
                if (el.Name == category.Name)
                    category = el;
            }
            if (Inc_Spend.SelectedItem.ToString().ToLower() == "spending")
            { isSpending = true; }
            else { isSpending = false; }
            calculations.AddFlow(amount, category,comment,isSpending, User);
            Balance_box.Text = calculations.CalculateBalance(Decimal.Parse(Balance_box.Text), Decimal.Parse(Sum_box.Text), isSpending).ToString();
            Sum_box.Text = "";
            Comment_box.Text = "";
            Inc_Spend.SelectedIndex = -1;
            Category_box.SelectedIndex = -1;
        }
    }
}
