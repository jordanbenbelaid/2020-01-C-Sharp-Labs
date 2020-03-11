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

namespace lab_65_WPF_panels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }
        
        void Initialise()
        {
            ListBoxCustomers.Items.Add("Customer List");
            ListBoxCustomers.Items.Add("=========");
            for (int i = 0; i < 20; i++)
            {
                ListBoxCustomers.Items.Add($"Customer {i}");
            }

            ListBoxProducts.Items.Add("Product List");
            ListBoxProducts.Items.Add("=========");
            for (int i = 0; i < 20; i++)
            {
                ListBoxProducts.Items.Add($"Product {i}");
            }

            //creating a few buttons
            for (int i = 0; i < 20; i++)
            {
                var b = new Button();
                b.Padding = new Thickness(7);
                b.Margin = new Thickness(5);
                b.Content = $"Button {i}";
                WrapPanel01.Children.Add(b);
            }
            ComboBox01.Items.Add("first");
            ComboBox01.Items.Add("second");
            ComboBox01.Items.Add("third");
        }

        private void ButtonTest01_Click(object sender, RoutedEventArgs e)
        {
            Label01.Content = "Hey, you clicked Button01!";
        }

        private void ButtonCustomers_Click(object sender, RoutedEventArgs e)
        {
            ScrollViewerCustomers.Visibility = Visibility.Visible;
            ScrollViewerProducts.Visibility = Visibility.Hidden;
            TabControl01.Visibility = Visibility.Hidden;
            WrapPanel01.Visibility = Visibility.Hidden;
        }

        private void ButtonProducts_Click(object sender, RoutedEventArgs e)
        {
            ScrollViewerProducts.Visibility = Visibility.Visible;
            ScrollViewerCustomers.Visibility = Visibility.Hidden;
            TabControl01.Visibility = Visibility.Hidden;
            WrapPanel01.Visibility = Visibility.Hidden;
        }

        private void ButtonNewWindow_Click(object sender, RoutedEventArgs e)
        {
            var NewWindow = new Window();
            NewWindow.Show();
        }

        private void ButtonTabPanel_Click(object sender, RoutedEventArgs e)
        {
            TabControl01.Visibility = Visibility.Visible;
            ScrollViewerCustomers.Visibility = Visibility.Hidden; 
            ScrollViewerProducts.Visibility = Visibility.Hidden;
            WrapPanel01.Visibility = Visibility.Hidden;
        }

        private void ButtonWrapPanel_Click(object sender, RoutedEventArgs e)
        {
            WrapPanel01.Visibility = Visibility.Visible;
            ScrollViewerCustomers.Visibility = Visibility.Hidden;
            ScrollViewerProducts.Visibility = Visibility.Hidden;
            TabControl01.Visibility = Visibility.Hidden;

        }

        private void RadioButton01_Checked(object sender, RoutedEventArgs e)
        {
            Label01.Content = RadioButton01.Content + " chosen is " + RadioButton01.IsChecked;
        }

        private void RadioButton02_Checked(object sender, RoutedEventArgs e)
        {
            Label01.Content = RadioButton02.Content + " chosen is " + RadioButton02.IsChecked;

        }

        private void CheckBox01_Checked(object sender, RoutedEventArgs e)
        {
            Label01.Content = "CheckBox01 is " + CheckBox01.IsChecked;
        }

        private void DatePicker01_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Label01.Content = DatePicker01.SelectedDate;
        }

        private void ComboBox01_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Label01.Content = ComboBox01.SelectedItem;
        }
    }
}
