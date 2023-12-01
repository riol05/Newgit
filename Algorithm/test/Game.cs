﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Game
    {
        private bool Gameover = false;

        Scene curScene;
        InventoryScene inventoryScene;
        MainMenuScene mainMenuScene;
        MapScene mapScene;
        BattleScene battleScene;
        public void Run()
        {
            init();
            while(!Gameover)
            {
                Input();

                Render();

                Update();
            }
            Release();
        }
        private void init()
        {
            DataClass.Instance.Init();
            mainMenuScene = new MainMenuScene(this);
            mapScene = new MapScene(this);
            curScene = mainMenuScene;
            battleScene = new BattleScene(this);
            inventoryScene = new InventoryScene(this);
        }
        private void Render()
        {
            Console.Clear();
            curScene.Render();// 현재 씬의 렌더 호출
        }
        private void Input()
        {
            
        }
        private void Update()
        {
            curScene.Update();
        }
        private void Release()
        {

        }
        public void InvenOpen()
        {
            curScene = inventoryScene;
        }

        public void BattleStart(Monster monster)
        {
            curScene = battleScene;
            battleScene.StartBattle(monster);
        }
        public void Map()
        {
            curScene = mapScene;
        }
        public void GameStart()
        {
            mapScene.GenerateMap();
            curScene = mapScene;
        }
        public void GameOver()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(".");
            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("..");
            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("...");
            Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("....");
            Thread.Sleep(1500);
            Console.Clear();            
            Console.WriteLine();
            Console.WriteLine("게임을 종료 합니다");
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(1500);
            Gameover = true;
        }
    }

}
