using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace pr03
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static List<user> users = new List<user>();
        private static int[] inde = new int[5];



        public MainWindow()
        {
            InitializeComponent();
        }

        void Load() 
        {
            int v = 1;
            users.Add(new user
            {
                id = Convert.ToInt32(tx.Text),
                name = ta.Text,
                password = tb.Text,
            });
            inde[v] = Convert.ToInt32(tx.Text);

            v += 1;
        }

        public class user 
        { 
            public int id { get; set; }
            public string name { get; set; }
            public string password { get; set; }
        }

        private void ba_Click(object sender, RoutedEventArgs e)
        {
            Load();
            foreach (var item in users) 
            { 
                lia.Items.Add(item);
            }
        }
       


        private void ta_TextChanged(object sender, TextChangedEventArgs e)
        {

        }



        public static void Quicksort(int[] elements, int left, int right)
        {
            int i = left;
            int j = right;

            int pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }
                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }


                if (i <= j)
                {
                    // Swap
                    int tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }
            // Recursive calls
            if (left < j)
            {
                Quicksort(elements, left, j);
            }
            if (i < right)
            {
                Quicksort(elements, i, right);
            }
        }

        private void sfb_Click(object sender, RoutedEventArgs e)
        {
            Quicksort(inde, 0, inde.Length - 1);
            foreach (var item in inde.ToList())
            {
                lia.Items.Add(item);
            }
        }

        private void lia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
