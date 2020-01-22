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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        long number1 = 0;
        long number2 = 0;
        string operation = "";


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {

            if (operation == "")
            {
                number1 = (number1 * 10) + 1;
                textDisplay.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + 1;
                textDisplay.Text = number1.ToString();
            }

        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {

            if (operation == "")
            {
                number1 = (number1 * 10) + 2;
                textDisplay.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + 2;
                textDisplay.Text = number1.ToString();
            }

        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {

            if (operation == "")
            {
                number1 = (number1 * 10) + 3;
                textDisplay.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + 3;
                textDisplay.Text = number1.ToString();
            }

        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {

            if (operation == "")
            {
                number1 = (number1 * 10) + 4;
                textDisplay.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + 4;
                textDisplay.Text = number1.ToString();
            }

        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {

            if (operation == "")
            {
                number1 = (number1 * 10) + 5;
                textDisplay.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + 5;
                textDisplay.Text = number1.ToString();
            }

        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {

            if (operation == "")
            {
                number1 = (number1 * 10) + 6;
                textDisplay.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + 6;
                textDisplay.Text = number1.ToString();
            }

        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {

            if (operation == "")
            {
                number1 = (number1 * 10) + 7;
                textDisplay.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + 7;
                textDisplay.Text = number1.ToString();
            }

        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {

            if (operation == "")
            {
                number1 = (number1 * 10) + 8;
                textDisplay.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + 8;
                textDisplay.Text = number1.ToString();
            }

        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {

            if (operation == "")
            {
                number1 = (number1 * 10) + 9;
                textDisplay.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10) + 9;
                textDisplay.Text = number1.ToString();
            }

        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {

            if (operation == "")
            {
                number1 = (number1 * 10);
                textDisplay.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 * 10);
                textDisplay.Text = number1.ToString();
            }

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            operation = "+";
            textDisplay.Text = "";
        }

        private void ButtonSubtract_Click(object sender, RoutedEventArgs e)
        {
            operation = "-";
            textDisplay.Text = "";
        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            operation = "*";
            textDisplay.Text = "";
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            operation = "/";
            textDisplay.Text = "";
        }

        private void ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            switch (operation)
            {
                case "+":
                    textDisplay.Text = (number1 + number2).ToString();
                    break;

                case "-":
                    textDisplay.Text = (number1 - number2).ToString();
                    break;

                case "*":
                    textDisplay.Text = (number1 * number2).ToString();
                    break;

                case "/":
                    textDisplay.Text = (number1 / number2).ToString();
                    break;

            }
        }

        private void ButtonClearEntry_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 = 0;
                textDisplay.Text = "0";
            }
            else
            {
                number2 = 0;
            }
            textDisplay.Text = "0";
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            number1 = 0;
            number2 = 0;
            operation = "";
            textDisplay.Text = "0";
        }

        private void ButtonBackspace_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 = (number1 / 10);
                textDisplay.Text = number1.ToString();
            }
            else
            {
                number2 = (number2 / 10);
                textDisplay.Text = number1.ToString();
            }
        }

        private void ButtonPositiveNegative_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 *= -1;
                textDisplay.Text = number1.ToString();
            }
            else
            {
                number2 *= -1;
                textDisplay.Text = number1.ToString();
            }
        }
    }
}
