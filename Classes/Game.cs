using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using SpaceWar.views;
using System.Windows.Input;

namespace SpaceWar.Classes
{
    class Game : Update
    {
        private Ship _ship;
        private List<Enemy> _enemies;
        private Canvas _gameBoard;
        private TextBlock _live, _level, _enemy, _shipLevel;
        private int level;
        private bool _gameRun;
        private Rectangle _attackPrg;
        private int _cash;
        private Control _control;
        private GameScreen window;
        private Player _player;

        public Game(Control control)
        {
            window = (GameScreen)control;
            _player = new Player().ReadFromJsonFile("test.json");
            _cash = 0;
            _gameRun = true;
            _live = window.liveText;
            _enemy = window.enemeyText;
            _level = window.levelText;
            _gameBoard = window.gameBoard;
            _shipLevel = window.shipLvelText;
            _ship = new Ship(_player.UseShip, _gameBoard, control);
            _enemies = new List<Enemy>();
            level = 1;
            _attackPrg = window.attackPrg;
            control.KeyUp += KeyPressUp;
            _control = control;
            
        }

        private void KeyPressUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Pause();
                var result = MessageBox.Show("You want to resume?","Pause",MessageBoxButton.YesNo);
                if (result.ToString() == "Yes")
                {
                    Resume();
                }
                else
                {
                    _player.WriteToJsonFile("test.json");
                    window.Close();
                    Application.Current.MainWindow.Visibility = Visibility.Visible;
                }
            }
        }

        public override void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            int x = _enemies.Count;
            _enemy.Text = "Cash: " + _cash.ToString();
            _live.Text = "Live: " + _ship.Live.ToString();
            //_enemy.Text = "Enemy In Map: " + _enemies.Count.ToString();
            _level.Text = "Level: " + level.ToString();
            _shipLevel.Text = "Ship Level: " + _ship.Level.ToString();

            _attackPrg.Width = _ship.AttackSlow > 15 ? _ship.AttackSlow : 0;
            if (_gameRun)

                if (IsLevelEnd())
                {
                    for (int j = 0; j < 2; j++)
                    {
                        for (int i = 0; i <= level / 2; i++)
                        {
                            _enemies.Add(new Enemy(_gameBoard, -80 * i, 100 + 160 * j, 5));
                            _enemies.Add(new Enemy(_gameBoard, (int)_control.ActualWidth + 80 * i, 180 + 160 * j, 5));

                        }
                    }

                    //for (int i = 0; i < level + 5; i++)
                    //    _enemies.Add(new Enemy(_gameBoard, rand.Next(-600, -10), rand.Next(100, (int)_control.ActualWidth / 3),rand.Next(1,5)));
                    //for (int i = 0; i < level + 5; i++)
                }


            if (_ship.Live == 0)
            {
                if (_player.BestLevel < level)
                {
                    _player.BestLevel = level;
                }
                Pause();
                _gameRun = false;
                dispatcherTimer.Tick -= dispatcherTimer_Tick;
                dispatcherTimer.Stop();
                _player.Cash += _cash;
                _player.WriteToJsonFile("test.json");
                MessageBoxResult result = MessageBox.Show("You want to play again?", "Game Over!", MessageBoxButton.YesNo, MessageBoxImage.Question);
                window.Close();
                if (result.ToString() == "Yes")
                {
                    new GameScreen().Show();
                }
                else
                {
                    Application.Current.MainWindow.Visibility = Visibility.Visible;
                }
                
            }
        }


        public void Resume()
        {
            _gameRun = true;
            _ship.dispatcherTimer.Start();
            foreach (var enemy in _enemies)
                enemy.dispatcherTimer.Start();
        }

        public void Pause()
        {
            _gameRun = false;
            _ship.dispatcherTimer.Stop();
            foreach (var enemy in _enemies)
                enemy.dispatcherTimer.Stop();
        }

        private bool IsLevelEnd()
        {
            for (int i = 0; i < _enemies.Count; i++)
                if (!_gameBoard.Children.Contains(_enemies[i].Avatar))
                {
                    _enemies.Remove(_enemies[i]);
                    _cash += 500;
                }

            if (_enemies.Count > 0)
                return false;
            else
            {
                level++;
                return true;
            }
        }
    }
}
