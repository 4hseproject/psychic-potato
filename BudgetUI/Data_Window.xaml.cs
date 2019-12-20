﻿using Budget2._0;
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
    /// Логика взаимодействия для Data_Window.xaml
    /// </summary>
    public partial class Data_Window : Window
    {
        public DateTime StartDt { get; set; }
        AppData appData = Factory.Instance.GetAppData();
        Calculations calculations = Factory.Instance.GetCalculations();
        public DateTime EndDt { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
        public Data_Window(User User, DateTime start, DateTime end, Category category)
        {
            
            InitializeComponent();
            this.StartDt = start;
            this.EndDt = end;
            this.Category = category;
            this.User = User;
            TextBlock_start.Text = start.ToString();
            TextBlock_end.Text = end.ToString();
            List<DataVisualisationNoCatSelection> dataVisualisations = new List<DataVisualisationNoCatSelection>();
            if(category == null)
            {
                foreach (Income el in appData.gains)
                {
                    if (DateTime.Compare(el.TransactionDt, start) >= 0 && DateTime.Compare(el.TransactionDt, end) <= 0 && el.Category != null)
                    {
                        var data = new DataVisualisationNoCatSelection(el.Amount.ToString(), el.TransactionDt, "Income", el.Category.Name);
                        data.CategoryName = el.Comment;
                        dataVisualisations.Add(data);
                    }
                }
                foreach (Spending el in appData.losses)
                {
                    if (DateTime.Compare(el.TransactionDt, start) >= 0 && DateTime.Compare(el.TransactionDt, end) <= 0 && el.Category != null)
                    {
                        var data = new DataVisualisationNoCatSelection(el.Amount.ToString(), el.TransactionDt, "Spending", el.Category.Name);
                        data.Comment = el.Comment;
                        dataVisualisations.Add(data);
                    }
                }
                calculations.SortByDate(dataVisualisations);
                spendingsList.ItemsSource = dataVisualisations;
                //TODO show results for all categories
            }
            /*
            else
            {
                foreach (Income el in appData.gains)
                {
                    if (DateTime.Compare(el.TransactionDt, start) >= 0 && DateTime.Compare(el.TransactionDt, end) <= 0 && el.Category == category)
                        flows.Add(el);
                }
                foreach (Spending el in appData.losses)
                {
                    if (DateTime.Compare(el.TransactionDt, start) >= 0 && DateTime.Compare(el.TransactionDt, end) <= 0 && el.Category == category)
                        flows.Add(el);
                }
                calculations.SortByDate(flows);
                spendingsList.ItemsSource = flows;
                //TODO show results for selected category
            }
            */
            /*List<IFlow> flows = new List<IFlow>();
            {
                foreach(Income el in appData.gains)
                {
                    if (DateTime.Compare(el.TransactionDt,start) >= 0 && DateTime.Compare(el.TransactionDt, end)<=0)
                        flows.Add(el);
                }
                foreach(Spending el in appData.losses)
                {
                    if (DateTime.Compare(el.TransactionDt, start) >= 0 && DateTime.Compare(el.TransactionDt, end) <= 0)
                        flows.Add(el);
                }
                calculations.SortByDate(flows);
                spendingsList.ItemsSource = flows;
                //TODO show results for all categories
            }
            else
            {
                foreach (Income el in appData.gains)
                {
                    if (DateTime.Compare(el.TransactionDt, start) >= 0 && DateTime.Compare(el.TransactionDt, end) <= 0 && el.Category == category)
                        flows.Add(el);
                }
                foreach (Spending el in appData.losses)
                {
                    if (DateTime.Compare(el.TransactionDt, start) >= 0 && DateTime.Compare(el.TransactionDt, end) <= 0 && el.Category == category)
                        flows.Add(el);
                }
                calculations.SortByDate(flows);
                spendingsList.ItemsSource = flows;
                //TODO show results for selected category
            }
            */

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void spendingsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
