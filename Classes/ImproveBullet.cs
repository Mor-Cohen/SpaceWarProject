using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows;

namespace SpaceWar.Classes
{
    class ImproveBullet : Update
    {
        public Rectangle Avatar { get; set; }
        private Canvas _gameBoard;
        public ImproveBullet(double x,double y,Canvas gameBoard)
        {
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/improveBall.png"));
            Avatar = new Rectangle
            {
                Tag = "improve",
                Height = 50,
                Width = 50,
                Fill = img,

            };
            _gameBoard = gameBoard;
            Canvas.SetLeft(Avatar, x);
            Canvas.SetTop(Avatar, y);
        }

        public override void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Canvas.SetTop(Avatar, Canvas.GetTop(Avatar) + 3);

            if (Canvas.GetTop(Avatar) > Application.Current.MainWindow.ActualHeight)
                RemoveImprove();

            if (!_gameBoard.Children.Contains(Avatar))
                RemoveImprove();

            
                
        }

        private void RemoveImprove()
        {
            _gameBoard.Children.Remove(Avatar);
            dispatcherTimer.Tick -= dispatcherTimer_Tick;
            dispatcherTimer.Stop();
        }

    }
}
