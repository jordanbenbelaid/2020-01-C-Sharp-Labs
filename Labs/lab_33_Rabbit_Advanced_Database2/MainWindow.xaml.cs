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

namespace lab_33_Rabbit_Advanced_Database2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static List<RabbitTable> rabbit = new List<RabbitTable>();
        static RabbitTable showrabbitdata = new RabbitTable();
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        void Initialize()
        {
            using (var db = new RabbitDatabaseEntities())
            {
                rabbit = db.RabbitTable.ToList();
            }
            //display rabbits

        }

        private void ButtonShowRabbits_Click(object sender, RoutedEventArgs e)
        {
            ListViewRabbits.ItemsSource = rabbit;
        }

        private void ListViewRabbits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //select rabbit by casting to RabbitTable type the object in ListView
            showrabbitdata = (RabbitTable)ListViewRabbits.SelectedItem;

            TextBoxRabbitId.Text = showrabbitdata.RabbitTableId.ToString();
            TextBoxRabbitName.Text = showrabbitdata.RabbitName;
            TextBoxRabbitAge.Text = showrabbitdata.RabbitAge.ToString();
        }

        private void ListViewRabbits_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (rabbit != null)
            {
                using (var db = new RabbitDatabaseEntities())
                {
                    //find in the database the rabbnit which has an ID the same as the selected rabbit
                    var rabbitToDelete = db.RabbitTable.Find(showrabbitdata.RabbitTableId);

                    var result = MessageBox.Show($"Delete Rabbit{rabbitToDelete.RabbitTableId}? Confirm", "Warning", MessageBoxButton.YesNoCancel);
                    if (result == MessageBoxResult.Yes)
                    {
                        db.RabbitTable.Remove(rabbitToDelete);
                        db.SaveChanges();
                        ListViewRabbits.ItemsSource = null;   //set to zero
                        rabbit = db.RabbitTable.ToList(); //refresh rabbits
                        ListViewRabbits.ItemsSource = rabbit;    //refresh view
                    }

                }
            }
        }

        //private void ListViewRabbits_MouseRightButtonUp(object sender, SelectionChangedEventArgs e)
        //{
        //    if (rabbit != null)
        //    {
        //        using (var db = new RabbitDatabaseEntities())
        //        {
        //            //find in the database the rabbnit which has an ID the same as the selected rabbit
        //            var rabbitToDelete = db.RabbitTables.Find(rabbit.RabbitTableId);

        //            var result = MessageBox.Show($"Delete Rabbit{rabbit.rabbitId}? Confirm", "Warning", MessageBoxButton.YesNoCancel);
        //            if (result == MessageBoxResult.Yes)
        //            {
        //                db.rabbittables.Remove(rabbitToDelete);
        //                db.SaveChanges();
        //                ListView1.ItemsSource = null;   //set to zero
        //                rabbits = db.rabbittables.ToList(); //refresh rabbits
        //                ListView1.ItemsSource = rabbits;    //refresh view
        //            }

        //        }
        //    }
        //}
    }
}
