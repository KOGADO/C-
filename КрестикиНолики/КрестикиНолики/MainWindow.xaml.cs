using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace КрестикиНолики
{
    public partial class MainWindow : Window
    {
        int player;
        private Button[] but;
        public MainWindow()
        {
            InitializeComponent();
            print.Text = "Ход крестиков";
            but = new Button[9] { b1, b2, b3, b4, b5, b6, b7, b8, b9 };
            player = 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (player)
            {
                case 1:
                    sender.GetType().GetProperty("Content").SetValue(sender, "x");
                    sender.GetType().GetProperty("IsEnabled").SetValue(sender, false);
                    Bot("o");
                    print.Text = "Ход крестиков";
                    break;
                case 2:
                    sender.GetType().GetProperty("Content").SetValue(sender, "o");
                    sender.GetType().GetProperty("IsEnabled").SetValue(sender, false);
                    Bot("x");
                    print.Text = "Ход ноликов";
                    break;
            }
            pobedaORloseORdraw(sender, e);
        }
        private void Start(object sender, RoutedEventArgs e)
        {
            b1.IsEnabled = true;
            b2.IsEnabled = true;
            b3.IsEnabled = true;
            b4.IsEnabled = true;
            b5.IsEnabled = true;
            b6.IsEnabled = true;
            b7.IsEnabled = true;
            b8.IsEnabled = true;
            b9.IsEnabled = true;
            restart.IsEnabled = true;
            start.IsEnabled = false;

        }
        private void Restart(object sender, RoutedEventArgs e)
        {
            b1.IsEnabled = true;
            b2.IsEnabled = true;
            b3.IsEnabled = true;
            b4.IsEnabled = true;
            b5.IsEnabled = true;
            b6.IsEnabled = true;
            b7.IsEnabled = true;
            b8.IsEnabled = true;
            b9.IsEnabled = true;
            b1.Content = " ";
            b2.Content = " ";
            b3.Content = " ";
            b4.Content = " ";
            b5.Content = " ";
            b6.Content = " ";
            b7.Content = " ";
            b8.Content = " ";
            b9.Content = " ";

        }
        public void block()
        {
            b1.IsEnabled = false;
            b2.IsEnabled = false;
            b3.IsEnabled = false;
            b4.IsEnabled = false;
            b5.IsEnabled = false;
            b6.IsEnabled = false;
            b7.IsEnabled = false;
            b8.IsEnabled = false;
            b9.IsEnabled = false;
        }
        public void pobedaORloseORdraw(object sender, RoutedEventArgs e)
        {
            if (but.All(but => but.IsEnabled == false))
            {
                print.Text = "Ничья";
            }
            if (b1.Content == b2.Content && b2.Content == b3.Content && b3.Content.ToString() == "o" || b4.Content == b5.Content && b5.Content == b6.Content && b6.Content.ToString() == "o" || b7.Content == b8.Content && b8.Content == b9.Content && b9.Content.ToString() == "o" || b1.Content == b5.Content && b5.Content == b9.Content && b9.Content.ToString() == "o" || b3.Content == b5.Content && b5.Content == b7.Content && b7.Content.ToString() == "o" || b1.Content == b4.Content && b4.Content == b7.Content && b7.Content.ToString() == "o" || b2.Content == b5.Content && b8.Content == b5.Content && b5.Content.ToString() == "o" || b3.Content == b6.Content && b6.Content == b9.Content && b9.Content.ToString() == "o")
            {
                block();
                print.Text = "Победили нолики";
                player = 1;
            }
            if (b1.Content == b2.Content && b2.Content == b3.Content && b3.Content.ToString() == "x" || b4.Content == b5.Content && b5.Content == b6.Content && b6.Content.ToString() == "x" || b7.Content == b8.Content && b8.Content == b9.Content && b9.Content.ToString() == "x" || b1.Content == b5.Content && b5.Content == b9.Content && b9.Content.ToString() == "x" || b3.Content == b5.Content && b5.Content == b7.Content && b7.Content.ToString() == "x" || b1.Content == b4.Content && b4.Content == b7.Content && b7.Content.ToString() == "x" || b2.Content == b5.Content && b8.Content == b5.Content && b5.Content.ToString() == "x" || b3.Content == b6.Content && b6.Content == b9.Content && b9.Content.ToString() == "x")
            {
                block();
                print.Text = "Победили крестики";
                player = 2;
            }
        }
        public void Bot(string player)
        {
            Random random = new Random();
            int hod = random.Next(1, 9);

            while (but[hod].IsEnabled == false)
                hod = random.Next(1, 9);
            
            Debug.WriteLine(hod);
            but[hod].Content = player;
            but[hod].IsEnabled = false;
        }
    }
}
