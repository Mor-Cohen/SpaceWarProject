using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO.Packaging;
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
using SpaceWar.Classes;
using System.Windows.Threading;

namespace SpaceWar.views
{
    /// <summary>
    /// Interaction logic for Play.xaml
    /// </summary>
    ///         public delegate void createGame();

    public partial class Play : UserControl
    {

        Player player;
        public Play()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new GameScreen().Show();
            Application.Current.MainWindow.Visibility = Visibility.Hidden;
        }

        private void s_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            player = new Player().ReadFromJsonFile("test.json");
            bestLevel.Text = player.BestLevel.ToString();
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri(player.UseShip.ImgPath));
            ship.Fill = img;
        }
    }
}
