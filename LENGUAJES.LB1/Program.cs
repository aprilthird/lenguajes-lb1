using LENGUAJES.LB1.Entities;
using System;

namespace LENGUAJES.LB1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.SetWindowPosition(50, 50);
            Console.SetWindowSize(200, 50);
            RunGame();
            Console.Clear();
        }

        static void RunGame()
        {
            Console.Clear();
            ShowMenu();
            var key = ReadOption();
            switch(key.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    var battleBox = new BattleBox();
                    battleBox.GenerateRobots();
                    battleBox.GenerateObstacles(4);
                    StartGame(battleBox);
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("Presione [ENTER] para salir...");
                    Console.ReadLine();
                    break;
                default:
                    RunGame();
                    break;
            }
        }

        static void StartGame(BattleBox battleBox)
        {
            battleBox.DrawAll();
            Console.SetCursorPosition(0, Helpers.ConstantHelpers.MAP.MAX_Y*2 + 1);
            //Console.WriteLine("\nPresione [+] para agregar robot...");
            Console.WriteLine("\nPresione [ESC] para salir...");
            var key2 = Console.ReadKey();
            switch (key2.Key)
            {
                case ConsoleKey.OemPlus:
                    break;
                case ConsoleKey.Escape:
                    return;
                default:
                    StartGame(battleBox);
                    break;
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("=== MENU ===");
            Console.WriteLine("[1] Iniciar Juego");
            Console.WriteLine("[2] Salir");
        }

        static ConsoleKeyInfo ReadOption()
        {
            var key = Console.ReadKey();
            Console.WriteLine("\nSu opción es [" + key.KeyChar + "]...");
            return key;
        }
    }
}
