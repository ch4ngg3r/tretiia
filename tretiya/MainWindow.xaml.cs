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

namespace tretiya
{
    public partial class MainWindow : Window
    {
        private static List<user> users = new List<user>();
        //private static int[] inde = new int[5];
        public MainWindow()
        {
            InitializeComponent();
        }

        void Load()
        {
            users.Add(new user
            {
                id = Convert.ToInt32(i.Text),
                name = nam.Text,
                password = passwor.Text,
            });
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
            lia.Items.Clear();
            foreach (var item in users)
            {
                lia.Items.Add(item);
            }
        }

       
        private void ShakeSort(List<user> arr)
        {
            int left = 0;
            int right = arr.Count - 1;
            bool swapped;

            do
            {
                swapped = false;
                for (int i = left; i < right; i++)
                {
                    if (arr[i].id > arr[i + 1].id)
                    {
                        Swap(arr, i, i + 1);
                        swapped = true;
                    }
                }
                right--;

                if (swapped)
                {
                    swapped = false;
                    for (int i = right; i > left; i--)
                    {
                        if (arr[i].id < arr[i - 1].id)
                        {
                            Swap(arr, i, i - 1);
                            swapped = true;
                        }
                    }
                    left++;
                }
            } while (swapped);
        }


        private void QuickSort(List<user> arr, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(arr, left, right);
                QuickSort(arr, left, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, right);
            }
        }


        private int Partition(List<user> arr, int left, int right)
        {
            int pivot = arr[right].id;
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (arr[j].id <= pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, right);
            return i + 1;
        }

        private void Swap(List<user> arr, int i, int j)
        {
            user temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private void btn_SortShake_Click(object sender, RoutedEventArgs e)
        {
            ShakeSort(users);
            lia.Items.Clear();
            foreach (var item in users)
            {
                lia.Items.Add(item);
            }
        }

        private void btn_SortQuick_Click(object sender, RoutedEventArgs e)
        {
            QuickSort(users, 0, users.Count - 1);
            lia.Items.Clear();
            foreach (var item in users)
            {
                lia.Items.Add(item);
            }
        }
    }
}
