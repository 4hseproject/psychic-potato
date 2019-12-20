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
    /// Логика взаимодействия для Change_password.xaml
    /// </summary>
    public partial class Change_password : Window
    {
        public bool hasBeenClicked { get; set; }
        public bool hasBeenClicked1 { get; set; }
        public bool hasBeenClicked2 { get; set; }
        public Change_password()
        {
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

        }
    }
}
