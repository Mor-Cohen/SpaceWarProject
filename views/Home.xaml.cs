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
using SpaceWar.Classes;

namespace SpaceWar.views
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : UserControl
    {
        Player player;
        public Home()
        {
            InitializeComponent();

            if (!File.Exists("test.json"))
                new Player().WriteToJsonFile("test.json");

            player = new Player().ReadFromJsonFile("test.json");
            cash.Text = player.Cash.ToString();
            bestLevel.Text = "Best Level " + player.BestLevel.ToString();
            var img = new BitmapImage(new Uri(player.UseShip.ImgPath));
            ship.Source = img;

        }

        private void bestLevel_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                player = new Player().ReadFromJsonFile("test.json");
                cash.Text = player.Cash.ToString();
                bestLevel.Text = "Best Level " + player.BestLevel.ToString();
                var img = new BitmapImage(new Uri(player.UseShip.ImgPath));
                ship.Source = img;
            }
        }
    }
}
