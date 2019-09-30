using LENGUAJES.LB1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LENGUAJES.LB1.Entities
{
    public class BattleBox
    {
        private List<Robot> robots;
        private List<Obstacle> obstacles;

        public int Width { get; set; }

        public int Height { get; set; }

        public Color Color { get; set; }

        public Material Material { get; set; }

        public List<Tuple<string, ConsoleColor?>> Logs { get; set; }

        public BattleBox(Color color = Color.Gray, Material material = Material.Steel)
        {
            this.Color = color;
            this.Material = material;
            this.Width = ConstantHelpers.MAP.MAX_X;
            this.Height = ConstantHelpers.MAP.MAX_Y;
            this.robots = new List<Robot>();
            this.obstacles = new List<Obstacle>();
            this.Logs = new List<Tuple<string, ConsoleColor?>>();
        }

        public void GenerateRobots()
        {
            var robot1 = new Robot("wall-e", 10, 10, 5, Helpers.Color.Blue);
            var robot2 = new Robot("eva", 5, 4, 5, Helpers.Color.Yellow);
            robots.Add(robot1);
            robots.Add(robot2);
        }

        public void GenerateRobot(string name, float weight, float size, int lifesQty, Helpers.Color color, int? posX = null, int? posY = null)
        {
            if(robots.Any(r => r.Name == name))
            {
                Console.WriteLine("Ya existe otro robot con el mismo nombre...");
                return;
            }
            var robot = new Robot(name, weight, size, lifesQty, color);
            if (posX.HasValue)
                robot.Position.X = posX.Value;
            if (posY.HasValue)
                robot.Position.Y = posY.Value;
            robots.Add(robot);
        }

        public void GenerateObstacles(int maxObstacles)
        {
            var r = new Random();
            for (var i = 0; i < maxObstacles; ++i)
            {
                var o = new Obstacle("T", 20, r.Next(1, 5), Color.Red);
                obstacles.Add(o);
            }
        }

        public void DrawAll()
        {
            DrawArena();
            DrawRobots();
            DrawObstacles();
            DrawRobotsInformation();
            DrawObstaclesInformation();
            DrawLog();
        }

        public void MoveAll()
        {
            var rand = new Random();
            foreach (var r in robots)
            {
                var d = rand.NextBoolean() ? -1 : 1;
                if (rand.NextBoolean())
                {
                    if ((r.Position.X == ConstantHelpers.MAP.MAX_X - 1 && d > 0) ||
                        (r.Position.X == 0 && d < 0))
                        d *= -1;
                    r.Position.X += d;
                }
                else
                {
                    if ((r.Position.Y == ConstantHelpers.MAP.MAX_Y - 1 && d > 0) ||
                        (r.Position.Y == 0 && d < 0))
                        d *= -1;
                    r.Position.Y += d;
                }
            }
        }

        public void CheckForCollisions()
        {
            foreach (var r in robots)
            {
                var r1 = robots.Where(x => x.Name != r.Name).FirstOrDefault(x => x.Position.X == r.Position.X && x.Position.Y == r.Position.Y);
                if (r1 != null)
                {
                    r.Hit(r1);
                    Logs.Add(new Tuple<string, ConsoleColor?>(">robot ", null));
                    Logs.Add(new Tuple<string, ConsoleColor?>(r.Name, r.Color.ToConsoleColor()));
                    Logs.Add(new Tuple<string, ConsoleColor?>(" golpeó a ", null));
                    Logs.Add(new Tuple<string, ConsoleColor?>(r1.Name, r1.Color.ToConsoleColor()));
                    Logs.Add(new Tuple<string, ConsoleColor?>($" ({r.Damage} de daño)", null));
                    Logs.Add(new Tuple<string, ConsoleColor?>("\n", null));
                }
                var obs = obstacles.FirstOrDefault(x => x.Position.X == r.Position.X && x.Position.Y == r.Position.Y);
                if (obs != null)
                {
                    obs.Hit(r);
                    Logs.Add(new Tuple<string, ConsoleColor?>(">robot ", null));
                    Logs.Add(new Tuple<string, ConsoleColor?>(r.Name, r.Color.ToConsoleColor()));
                    Logs.Add(new Tuple<string, ConsoleColor?>(" fue golpeado por ", null));
                    Logs.Add(new Tuple<string, ConsoleColor?>(obs.Name, obs.Color.ToConsoleColor()));
                    Logs.Add(new Tuple<string, ConsoleColor?>($" ({obs.Damage} de daño)", null));
                    Logs.Add(new Tuple<string, ConsoleColor?>("\n", null));
                }
            }
        }

        public void DrawArena()
        {
            for(var i=0; i<ConstantHelpers.MAP.MAX_X; ++i)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(i * 3 + 3, 0);
                Console.Write(i);
            }

            for (var i = 0; i < ConstantHelpers.MAP.MAX_Y; ++i)
            {
                Console.SetCursorPosition(0, i * 2 + 2);
                Console.Write(i);
            }

            for (var i = 0; i < Width; ++i)
            {
                for (var j = 0; j < Height; ++j)
                {
                    Console.SetCursorPosition(i * 3 + 3, j * 2 + 2);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("o");
                }
            }
        }

        public void DrawRobots()
        {
            foreach(var robot in robots)
            {
                Console.SetCursorPosition(robot.Position.X * 3 + 3, robot.Position.Y * 2 + 2);
                Console.ForegroundColor = robot.Color.ToConsoleColor();
                Console.Write(robot.Name[0]);
            }
        }

        public void DrawLog()
        {
            Console.SetCursorPosition(0, Helpers.ConstantHelpers.MAP.MAX_Y * 2 + 6);
            foreach(var s in Logs)
            {
                Console.ForegroundColor = s.Item2 ?? ConsoleColor.White;
                Console.Write(s.Item1);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DrawRobotsInformation()
        {
            Console.SetCursorPosition(ConstantHelpers.MAP.MAX_X * 3 + 10, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("=== ROBOTS ===");
            for (var i = 0; i < robots.Count; ++i)
            {
                Console.ForegroundColor = robots[i].Color.ToConsoleColor();
                Console.SetCursorPosition(ConstantHelpers.MAP.MAX_X * 3 + 10, i * 5 + 2);
                Console.Write($"Nombre: {robots[i].Name}");
                Console.SetCursorPosition(ConstantHelpers.MAP.MAX_X * 3 + 10, i * 5 + 3);
                Console.Write($"Peso: {robots[i].Weight}");
                Console.SetCursorPosition(ConstantHelpers.MAP.MAX_X * 3 + 10, i * 5 + 4);
                Console.Write($"Vidas: {robots[i].LifesQty}");
                Console.SetCursorPosition(ConstantHelpers.MAP.MAX_X * 3 + 10, i * 5 + 5);
                Console.Write($"Posición: ({robots[i].Position.X}, {robots[i].Position.Y})");
            }
        }

        public void DrawObstaclesInformation()
        {
            Console.SetCursorPosition(ConstantHelpers.MAP.MAX_X * 3 + 50, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("=== OBSTACULOS ===");
            for (var i = 0; i < obstacles.Count; ++i)
            {
                Console.ForegroundColor = obstacles[i].Color.ToConsoleColor();
                Console.SetCursorPosition(ConstantHelpers.MAP.MAX_X * 3 + 50, i * 5 + 2);
                Console.Write($"Nombre: {obstacles[i].Name}");
                Console.SetCursorPosition(ConstantHelpers.MAP.MAX_X * 3 + 50, i * 5 + 3);
                Console.Write($"Peso: {obstacles[i].Weight}");
                Console.SetCursorPosition(ConstantHelpers.MAP.MAX_X * 3 + 50, i * 5 + 4);
                Console.Write($"Daño: {obstacles[i].Damage}");
                Console.SetCursorPosition(ConstantHelpers.MAP.MAX_X * 3 + 50, i * 5 + 5);
                Console.Write($"Posición: ({obstacles[i].Position.X}, {obstacles[i].Position.Y})");
            }
        }

        public void DrawObstacles()
        {
            foreach (var obstacle in obstacles)
            {
                Console.SetCursorPosition(obstacle.Position.X * 3 + 3, obstacle.Position.Y * 2 + 2);
                Console.ForegroundColor = obstacle.Color.ToConsoleColor();
                Console.Write(obstacle.Name[0]);
            }
        }
    }
}
