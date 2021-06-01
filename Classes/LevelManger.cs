using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows;
using System.Collections.Generic;

namespace SpaceWar.Classes
{
    class LevelManger
    {
        public int Level { get; set; }
        public List<Enemy> Enemies { get; set; }
        Canvas _gameBoard;

        public LevelManger(Canvas gameBoard)
        {
            Level = 1;
            _gameBoard = gameBoard;
            Enemies = new List<Enemy>();
        }

        

        public void CreateEnemy()
        {
            Enemies.Add( new Enemy(_gameBoard, 0, 100, 1));
        }
    }
}
