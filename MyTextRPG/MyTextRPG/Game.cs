using MyTextRPG.Scenes;
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
        private static Player _player;
        public static Player Player => _player;
        public static void Run()
        {
            Start();

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

        private static void Start()
        {
            _sceneDic["Title"] = new TitleScene();
            _sceneDic["TestField"] = new TestFieldScene();

            _curScene = _sceneDic["Title"];

            _player = new Player();

            _gameOver = false;
        }

        public static void ChangeScene(string scene)
        {
            _curScene.End();
            _curScene = _sceneDic[scene];
            _curScene.Enter();
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
