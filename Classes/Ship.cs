using SpaceWar.views;
using System;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace SpaceWar.Classes
{
    class Ship : Update
    {
        public  Rectangle Avatar { get; private set; }
        private Spaceship spaceship;
        public int Speed { get; set; }
        public int Live { get; set; }
        public int Level { get; set; }
        private bool _left, _right, _up, _down;
        private Control _control;
        private Canvas _gameBoard;
        public int AttackSlow { get; private set; }
        private int _attackCost = 15;
        public Ship(Spaceship ship,Canvas gameBoard, Control control)
        {
            spaceship = ship;
            var imgFromPath = new ImageBrush();
            imgFromPath.ImageSource = new BitmapImage(new Uri(ship.ImgPath));

            Avatar = new Rectangle
            {
                Tag = "ship",
                Height = 100,
                Width = 80,
                Fill = imgFromPath
            };
            gameBoard.Children.Add(Avatar);
            Speed = 20;
            Live = 3;
            Level = 1;
            Canvas.SetLeft(Avatar, SystemParameters.PrimaryScreenWidth / 2 - 50);
            Canvas.SetTop(Avatar, SystemParameters.PrimaryScreenHeight - 200);
            _control = control;
            _control.KeyUp += KeyPressUp;
            _control.KeyDown += KeyPressDown;
            _gameBoard = gameBoard;
            AttackSlow = 130;

        }

        public override void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Rect shipHitBox = new Rect(Canvas.GetLeft(Avatar), Canvas.GetTop(Avatar), Avatar.Width, Avatar.Height);

            if (_left && Canvas.GetLeft(Avatar) > 0)
                Canvas.SetLeft(Avatar, Canvas.GetLeft(Avatar) - Speed);

            if (_right && Canvas.GetLeft(Avatar) <_gameBoard.ActualWidth - 100)
                Canvas.SetLeft(Avatar, Canvas.GetLeft(Avatar) + Speed);

            if (_up && Canvas.GetTop(Avatar) > 0)
                Canvas.SetTop(Avatar, Canvas.GetTop(Avatar) - Speed);

            if (_down && Canvas.GetTop(Avatar) < _gameBoard.ActualHeight - 100)
                Canvas.SetTop(Avatar, Canvas.GetTop(Avatar) + Speed);

            if (Hit(shipHitBox))
            {
                Live -= 1;
                if (Level > 1)
                    Level--;

            }

            if (GetImprove(shipHitBox))
            {
                AttackSlow = 130;
                if (Level < 4)
                    Level++;
            }

            if (AttackSlow < 130)
                AttackSlow++;

        }

        private bool GetImprove(Rect shipHitBox)
        {
            foreach (var item in _gameBoard.Children.OfType<Rectangle>())
                if ((string)item.Tag == "improve")
                {
                    Rect improveHitBox = new Rect(Canvas.GetLeft(item), Canvas.GetTop(item), item.Width, item.Height);
                    if (improveHitBox.IntersectsWith(shipHitBox))
                    {
                        _gameBoard.Children.Remove(item);
                        return true;
                    }
                }
            
            return false;
        }

        private bool Hit(Rect shipHitBox)
        {
            foreach (var item in _gameBoard.Children.OfType<Rectangle>())
                if ((string)item.Tag == "enemy" || (string)item.Tag == "enemyAttack")
                {
                    Rect enemyHitBox = new Rect(Canvas.GetLeft(item), Canvas.GetTop(item), item.Width, item.Height);
                    if (enemyHitBox.IntersectsWith(shipHitBox))
                    {
                        item.Width = item.Width + 5;
                        return true;
                    }
                }
            
            return false;
        }

        private void Attack()
        {
            //using (var soundPlayer = new SoundPlayer(AppDomain.CurrentDomain.BaseDirectory + "laser.wav"))
            //{
            //    soundPlayer.Play(); // can also use soundPlayer.PlaySync()
            //}
            var sound = new MediaPlayer();
            sound.Open(new Uri(@"C:\Users\edens\Desktop\WPF---game-master\WPF---game-master\WpfApplication2\laser.wav"));
            sound.Play();
            var bulletCenter = new Bullet(Canvas.GetLeft(Avatar) + Avatar.Width / 3, Canvas.GetTop(Avatar) - Avatar.Height / 2, spaceship.BulletPath,_gameBoard);
            var bullet1 = new Bullet(Canvas.GetLeft(Avatar) + Avatar.Width / 3 + 10, Canvas.GetTop(Avatar) - Avatar.Height / 2, spaceship.BulletPath, _gameBoard);
            bullet1.Avatar.RenderTransform = new RotateTransform(15);
            var bullet2 = new Bullet(Canvas.GetLeft(Avatar) + Avatar.Width / 3 - 10, Canvas.GetTop(Avatar) - Avatar.Height / 2 + 7, spaceship.BulletPath, _gameBoard);
            bullet2.Avatar.RenderTransform = new RotateTransform(-15);
            var bulletLevel2_1 = new Bullet(Canvas.GetLeft(Avatar) + Avatar.Width / 3 + 10, Canvas.GetTop(Avatar) - Avatar.Height / 2, spaceship.BulletPath, _gameBoard);
            var bulletLevel2 = new Bullet(Canvas.GetLeft(Avatar) + Avatar.Width / 3 - 10, Canvas.GetTop(Avatar) - Avatar.Height / 2, spaceship.BulletPath, _gameBoard);
            switch (Level)
            {
                case 1:
                    _gameBoard.Children.Add(bulletCenter.Avatar);
                    break;
                case 2:
                    _gameBoard.Children.Add(bulletLevel2.Avatar);
                    _gameBoard.Children.Add(bulletLevel2_1.Avatar);
                    break;
                case 3:
                    _gameBoard.Children.Add(bullet1.Avatar);
                    _gameBoard.Children.Add(bulletCenter.Avatar);
                    _gameBoard.Children.Add(bullet2.Avatar);
                    break;
                case 4:       
                    _gameBoard.Children.Add(bullet1.Avatar);
                    _gameBoard.Children.Add(bulletLevel2.Avatar);
                    _gameBoard.Children.Add(bulletLevel2_1.Avatar);
                    _gameBoard.Children.Add(bullet2.Avatar);
                    break;
                default:
                    break;
            }

            AttackSlow -= _attackCost;
        }

        private void KeyPressDown(object sender, KeyEventArgs e)
        {
            Move(e, true);
        }

        private void KeyPressUp(object sender, KeyEventArgs e)
        {
            Move(e, false);
            if (e.Key == Key.Space)
                if (AttackSlow > _attackCost)
                    Attack();
        }

        private void Move(KeyEventArgs e, bool isMove)
        {
            if (e.Key == Key.Left)
                _left = isMove;

            if (e.Key == Key.Right)
                _right = isMove;

            if (e.Key == Key.Up)
                _up = isMove;

            if (e.Key == Key.Down)
                _down = isMove;
        }

    }
}
