using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTextRPG
{
    public static class Game
    {
        private static Dictionary<string, BaseScene> _sceneDic = new Dictionary<string, BaseScene>();
        private static BaseScene _curScene;
        private static bool _gameOver;
        public static void Run()
        {
            _gameOver = false;

            while (!_gameOver)
            {
                Console.Clear();
                _curScene.Render();
                Console.WriteLine();
                _curScene.Input();
                Console.WriteLine();
                _curScene.Result();
                Console.WriteLine();
            }

            PrintGameOver();
        }

        public static void ChangeScene(BaseScene scene)
        {
            _curScene = scene;
        }

        public static void GameOver()
        {
            _gameOver = false;
        }

        private static void PrintGameOver()
        {
            Console.WriteLine("Game Over!");
        }
    }
}
