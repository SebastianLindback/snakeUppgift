﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GruppInlUpp2kelett
{
    class ConsoleRenderer
    {
        private GameWorld world = new GameWorld();
        private Position FoodPos;
        private bool matredo;

        public ConsoleRenderer(GameWorld gameWorld)
        {
            Console.Title = "Snake | Gruppuppgift";
            Console.CursorVisible = false;
            
            Console.SetWindowSize(50, 20);
            Console.SetBufferSize(50, 20);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;

            world = gameWorld;
            GameObject.SnakeObject.Add(new Position(GameObject.pos.X, GameObject.pos.Y));
        }

        public bool Render()
        {
            Console.Clear();

            try
            {
                Console.SetCursorPosition(GameObject.pos.X, GameObject.pos.Y);
            }
            catch
            {
                return false;
            }

            // Rendera Snake
            for (int i = 0; i < GameObject.SnakeObject.Count(); i++)
            {
                GameObject.SnakeObject[i].X = GameObject.pos.X;
                GameObject.SnakeObject[i].Y = GameObject.pos.Y;

                Console.SetCursorPosition(GameObject.SnakeObject[i].X, GameObject.SnakeObject[i].Y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("■");
                Console.SetCursorPosition(0, 0);
            }

            // Rendera Food
            
            if (GameObject.SnakeObject[0].X == GameObject.FoodPos.X && GameObject.SnakeObject[0].Y == GameObject.FoodPos.Y)
            {
                GameWorld.matredo = !GameWorld.matredo;
            }

            Console.SetCursorPosition(GameObject.FoodPos.X, GameObject.FoodPos.Y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("■");
            Console.SetCursorPosition(0, 0);

            return true;
        }
    }
}
