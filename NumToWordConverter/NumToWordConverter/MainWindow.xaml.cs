using System;
using System.Windows;

namespace NumToWordConverter
{
    /// <summary>
    /// Interaction for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tb2.Text = NumberToWordConverter(Convert.ToInt64(tb1.Text));
        }

        public string NumberToWordConverter(long num)
        {
            if (num == 0)
                return "Zero";

            string numWords = "";

            if ((num / 1000000) > 0)
            {
                numWords += NumberToWordConverter(num / 1000000) + " Million ";
                num %= 1000000;
            }

            if ((num / 1000) > 0)
            {
                numWords += NumberToWordConverter(num / 1000) + " Thousand ";
                num %= 1000;
            }

            if ((num / 100) > 0)
            {
                numWords += NumberToWordConverter(num / 100) + " Hundred ";
                num %= 100;
            }

            if (num > 0)
            {
                if (numWords != "")
                    numWords += "and ";

                var NumCollections = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var TensNumCollections = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (num < 20)
                    numWords += NumCollections[num];
                else
                {
                    numWords += TensNumCollections[num / 10];
                    if ((num % 10) > 0)
                        numWords += " " + NumCollections[num % 10];
                }
            }

            return numWords;
        }
    }
}
