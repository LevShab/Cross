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
using System.Text.RegularExpressions;

namespace Cross
{
    public partial class MainWindow : Window
    {
        static int amount;

        public MainWindow()
        {
            InitializeComponent();
        }

        public int[] num()
        {
            int[] amt = new int[amount];
            for (int i = 0; i < amount; i++)
            {
                amt[i] = i + 1;
            }
            return amt;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Postition.Content = "";
            amount =  Convert.ToInt32(Many.Text);
            Number.ItemsSource = num();
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            int number = Convert.ToInt32(Number.SelectedItem);
            string win="";
            if (number == 2) win = "Номер 2 прибежал 1, но выбыл";
            else if (number == 1) win = String.Format("Номер 1 прибежал {0}, но выйграл", num().Length);
            else if ((number % 2 == 0) && (number != 2)) win = String.Format("Номер {0} прибежал {1}, но выбыл", number, number - 1);
            else if ((number % 2 != 0) && (number != 1)) win = String.Format("Номер {0} прибежал {1}, но выйграл", number, number - 1);
            Postition.Content = win;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
