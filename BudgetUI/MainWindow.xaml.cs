using Budget2._0;
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
        IAppData appData = Factory.Instance.GetAppData();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void More_info_Button_Click(object sender, RoutedEventArgs e)
        {
            ChoosePeriod chw = new ChoosePeriod();
            chw.Show();
            this.Close();
        }

        private void Category_box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            
            Sum_box.Text
        }
    }
}
