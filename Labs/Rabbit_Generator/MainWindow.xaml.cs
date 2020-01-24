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

namespace Rabbit_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static List<Rabbit> RabbitList = new List<Rabbit>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button100Rabbits_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                var rabbit = new Rabbit();
                rabbit.Name = "Rabbit" + " " + i;
                RabbitList.Add(rabbit);
            }

            foreach (var rabbit in RabbitList)
            {
                ListBox100Rabbits.Items.Add(rabbit.Name+" "+rabbit.Age);
            }
        }

       

        private void ButtonAge100Rabbits_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                RabbitAge(RabbitList);
            }

            void RabbitAge(List<Rabbit> r)
            {
                r.ForEach(item => item.Age++);
            }

            foreach (var rabbit in RabbitList)
            {
                ListBoxAgeRabbits.Items.Add($"{rabbit.Name} is {rabbit.Age} years old");
            }
        }
        

        private void ButtonBreedRabbits_Click(object sender, RoutedEventArgs e)
        {

        }

        class Rabbit
        {
            public int Age { get; set; }
            public string Name { get; set; }
        }





    }
}
