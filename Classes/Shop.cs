using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace SpaceWar.Classes
{
    class Shop
    {
        public List<Spaceship> Ships { get; private set; }
        public Player Player { get;private set; }
        public Shop()
        {
            Player = new Player().ReadFromJsonFile("test.json");
            Ships = new List<Spaceship>();
            Ships.Add(new Spaceship("rocket1"));
            Ships.Add(new Spaceship("rocket2"));
            Ships.Add(new Spaceship("rocket3"));
            Ships.Add(new Spaceship("rocket4"));
            Ships.Add(new Spaceship("rocket5"));
            Ships.Add(new Spaceship("rocket6"));
        }

        public void Deploy(Grid grid)
        {
            int index = 0;
            foreach (var child in grid.Children)
            {
                if (child is StackPanel stackPanel)
                {
                    if (stackPanel.Uid == "ship")
                    {
                        var img = ((Border)stackPanel.Children[0]).Child as Rectangle;
                        var imgFromPath = new ImageBrush();
                        imgFromPath.ImageSource = new BitmapImage(new Uri(Ships[index].ImgPath));
                        img.Fill = imgFromPath;
                        ((Button)stackPanel.Children[1]).Content = Ships[index].Price.ToString();

                        foreach (var ship in Player.Ships)
                            if (ship.ID == Ships[index].ID)
                            {
                                ((Border)stackPanel.Children[0]).Background = Brushes.White;
                                ((Button)stackPanel.Children[1]).Content = "Use";
                            }

                        if (Player.UseShip.ID == Ships[index].ID)
                        {
                            ((Button)stackPanel.Children[1]).Content = "Choosen";
                        }
                        index++;
                    }
                    if (stackPanel.Uid == "cash")
                    {
                        ((TextBlock)stackPanel.Children[1]).Text = Player.Cash.ToString();
                    }
                }
            }
        }

        private bool CheckShips(int id)
        {
            foreach (Spaceship ship in Player.Ships)
                if (ship.Equals(Ships[id]))
                    return true;

            return false;
        }



        public void SellShip(int id)
        {
            if (CheckShips(id))
                Player.UseShip = Ships[id];

            else
            {
                if (Player.Cash >= Ships[id].Price)
                {
                    Player.Ships.Add(Ships[id]);
                    Player.Cash -= Ships[id].Price;
                }
                else
                {
                    MessageBox.Show("You dont have enough money");
                }
            }
            Player.WriteToJsonFile("test.json");
        }


    }
}
