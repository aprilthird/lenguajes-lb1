using LENGUAJES.LB1.Entities;
using LENGUAJES.LB1.Helpers;
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
            Console.Clear();
            battleBox.DrawAll();
            Console.SetCursorPosition(0, Helpers.ConstantHelpers.MAP.MAX_Y*2 + 1);
            Console.WriteLine("\nPresione [+] para agregar robot...");
            Console.WriteLine("\nPresione [ESC] para salir...");
            var key2 = Console.ReadKey();
            switch (key2.Key)
            {
                case ConsoleKey.OemPlus:
                    Console.Clear();
                    Console.WriteLine("INFORMACION DEL ROBOT");
                    Console.Write("Ingrese el nombre:");
                    var name = Console.ReadLine();
                    Console.Write("Ingrese el peso: ");
                    float.TryParse(Console.ReadLine(), out float weight);
                    Console.Write("Ingrese el tamaño: ");
                    float.TryParse(Console.ReadLine(), out float size);
                    Console.Write("Ingrese el # de vidas: ");
                    int.TryParse(Console.ReadLine(), out int lifes);
                    Console.Write("Ingrese el color (red/yellow/green/blue/gray): ");
                    var color = Console.ReadLine().ToColor();
                    var rand = new Random();
                    Console.Write($"Ingrese la posición X [de 0 a {ConstantHelpers.MAP.MAX_X - 1}] (vacío para que se genere aleatoriamente): ");
                    var r1 = int.TryParse(Console.ReadLine(), out int posX);
                    posX = r1 && posX < ConstantHelpers.MAP.MAX_X && posX >= 0 ? posX : rand.Next(0, ConstantHelpers.MAP.MAX_X);
                    Console.Write($"Ingrese la posición Y [de 0 a {ConstantHelpers.MAP.MAX_Y - 1}] (vacío para que se genere aleatoriamente): ");
                    var r2 = int.TryParse(Console.ReadLine(), out int posY);
                    posY = r2 && posY < ConstantHelpers.MAP.MAX_Y && posY >= 0 ? posY : rand.Next(0, ConstantHelpers.MAP.MAX_Y);
                    battleBox.GenerateRobot(name, weight, size, lifes, color, posX, posY);
                    Console.WriteLine("Robot Agregado...");
                    Console.WriteLine("Presione una tecla para regresar al juego");
                    Console.ReadKey();
                    StartGame(battleBox);
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
