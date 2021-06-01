using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SpaceWar.Classes
{
    class EnemyAttack : Update
    {
        private DispatcherTimer expoldeTimer;
        public Rectangle Avatar { get; private set; }
        public int Speed { get; set; }

        Canvas _gameBoard;

        public EnemyAttack(Canvas gameBoard,double x,double y)
        {
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/enemyAtt.png"));
            Avatar = new Rectangle
            {
                Tag = "enemy",
                Height = 40,
                Width = 40,
                Fill = img
            };
            Speed = 15;
            Canvas.SetLeft(Avatar, x);
            Canvas.SetTop(Avatar, y);
            _gameBoard = gameBoard;
        }

        public override void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Canvas.SetTop(Avatar, Canvas.GetTop(Avatar) + 6);

            if (Canvas.GetTop(Avatar) > _gameBoard.ActualHeight - 100 || Avatar.Width > 40)
                Explode();               
            
        }

        private void RemoveAttack(object sender, EventArgs e)
        {
            _gameBoard.Children.Remove(Avatar);
            expoldeTimer.Tick -= RemoveAttack;
            expoldeTimer.Stop();
        }

        private void Explode()
        {
            expoldeTimer = new DispatcherTimer();
            expoldeTimer.Interval = TimeSpan.FromSeconds(0.5);
            expoldeTimer.Tick += RemoveAttack;
            expoldeTimer.Start();
            ImageBrush img = new ImageBrush();
            img.ImageSource = new BitmapImage(new Uri("pack://application:,,,/images/boom2.png"));
            Avatar.Fill = img;
            Avatar.Tag = "explode";
            dispatcherTimer.Tick -= dispatcherTimer_Tick;
            dispatcherTimer.Stop();

        }

    }
}
