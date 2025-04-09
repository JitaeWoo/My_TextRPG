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
        public static BaseScene CurScene => _curScene;
        private static string _prevSceneName;
        public static string PrevSceneName => _prevSceneName;

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
                _curScene.Result();
                Console.WriteLine();
            }

            PrintGameOver();
        }

        private static void Start()
        {
            Console.CursorVisible = false;

            _sceneDic["Title"] = new TitleScene();
            _sceneDic["Town"] = new TownScene();
            _sceneDic["TownShop"] = new TownShopScene();
            _sceneDic["TestField"] = new TestFieldScene();
            _sceneDic["TestField2"] = new TestFieldScene2();

            _curScene = _sceneDic["Title"];

            _player = new Player();

            _gameOver = false;
        }

        public static void ChangeScene(string scene)
        {
            _prevSceneName = _curScene.Name;

            _curScene.End();
            _curScene = _sceneDic[scene];
            _curScene.Enter();
        }

        public static void ChangeScene(BaseScene scene)
        {
            _prevSceneName = _curScene.Name;

            _curScene.End();
            _curScene = scene;
            _curScene.Enter();
        }

        public static void GameOver()
        {
            _gameOver = true;
        }

        private static void PrintGameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over!");
        }
    }
}
