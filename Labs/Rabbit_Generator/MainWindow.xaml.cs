using System.Collections.Generic;
using System.Windows;

namespace Rabbit_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static List<Rabbit> RabbitList = new List<Rabbit>();
        static List<Rabbit> RabbitList2 = new List<Rabbit>();
        static List<Rabbit> RabbitList3 = new List<Rabbit>();
        static List<Rabbit> RabbitList4 = new List<Rabbit>();

        public MainWindow()
        {
            InitializeComponent();

            Rabbit firstRabbit = new Rabbit();
            Rabbit firstRabbit1 = new Rabbit();

            firstRabbit.Age = 0;
            firstRabbit.Name = "Rabbit" + 1;
            RabbitList3.Add(firstRabbit);

            firstRabbit1.Age = 0;
            firstRabbit1.Name = "Rabbit" + 1;
            RabbitList4.Add(firstRabbit1);

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
                ListBox100Rabbits.Items.Add(rabbit.Name);
            }
        }



        private void ButtonAge100Rabbits_Click(object sender, RoutedEventArgs e)
        {
            ListBoxAgeRabbits.Items.Clear();
            BreedRabbits.Items.Clear();
            RabbitsBreedAtThree.Items.Clear();

            if (RabbitList2.Count < 100)
            {

                for (int i = 0; i < 100; i++)
                {
                    var rabbit = new Rabbit();
                    rabbit.Age = 0;
                    rabbit.Name = "Rabbit" + i.ToString();
                    RabbitList2.Add(rabbit);
                }

            }
            for (int i = 0; i < 1; i++)
            {
                foreach (var item in RabbitList2)
                {
                    item.Age++;
                }
            }

            foreach (var rabbit in RabbitList2)
            {
                ListBoxAgeRabbits.Items.Add($"{rabbit.Name} is {rabbit.Age} years old");
            }
        }


        private void ButtonBreedRabbits_Click(object sender, RoutedEventArgs e)
        {
            ListBoxAgeRabbits.Items.Clear();
            BreedRabbits.Items.Clear();
            RabbitsBreedAtThree.Items.Clear();

            if (RabbitList3.Count < 65)
            {

                foreach (var item in RabbitList3)
                {
                    item.Age++;
                }

                foreach (var rabbit in RabbitList3.ToArray())
                {
                    var breedRabbit = new Rabbit();
                    breedRabbit.Age = 0;
                    breedRabbit.Name = "New Rabbit" + (RabbitList3.Count + 1);
                    RabbitList3.Add(breedRabbit);
                }
            }

            foreach (var item in RabbitList3)
            {
                BreedRabbits.Items.Add(item.Name + $" is {item.Age} years old");
            }
        }

        private void ButtonRabbitsBreedAtThree_Click(object sender, RoutedEventArgs e)
        {
            ListBoxAgeRabbits.Items.Clear();
            BreedRabbits.Items.Clear();
            RabbitsBreedAtThree.Items.Clear();

            foreach (var item in RabbitList4.ToArray())
            {
                item.Age++;
            }

            foreach (var item1 in RabbitList4.ToArray())
            {
                if (item1.Age > 2)
                {
                    var rabbit = new Rabbit();
                    rabbit.Age = 0;
                    rabbit.Name = "New Rabbit" + (RabbitList4.Count + 1);
                    RabbitList4.Add(rabbit);
                }
            }

            foreach (var newitem in RabbitList4)
            {
                RabbitsBreedAtThree.Items.Add(newitem.Name + " is " + newitem.Age + " years old");
            }
        }

        class Rabbit
        {
            public int Age { get; set; }
            public string Name { get; set; }
        }
    }
}
