using SpaceWar.Classes;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace SpaceWar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();      
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (((Button)sender).Content.ToString())
            {
                case "HOME":
                    home.Visibility = Visibility.Visible;
                    shop.Visibility = Visibility.Hidden;
                    play.Visibility = Visibility.Hidden;
                    break;
                case "PLAY":
                    home.Visibility = Visibility.Hidden;
                    play.Visibility = Visibility.Visible;
                    shop.Visibility = Visibility.Hidden;
                    break;
                case "SHOP":
                    home.Visibility = Visibility.Hidden;
                    shop.Visibility = Visibility.Visible;
                    play.Visibility = Visibility.Hidden;
                    break;
                default:
                    break;
            }


        }

        private void play_LostFocus(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(play);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();       
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                this.WindowState = WindowState.Normal;
            else
                this.WindowState = WindowState.Maximized;

            
        }
    }
}
