using LENGUAJES.LB1.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LENGUAJES.LB1.Entities
{
    public class BattleBox
    {
        private int width;
        private int height;
        private Color color;
        private Material material;
        private List<Robot> robots;
        private List<Obstacle> obstacles;

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public Material Material
        {
            get { return material; }
            set { material = value; }
        }

        public BattleBox(Color color = Color.Gray, Material material = Material.Steel)
        {
            this.color = color;
            this.material = material;
            this.width = ConstantHelpers.MAP.MAX_X;
            this.height = ConstantHelpers.MAP.MAX_Y;
            this.robots = new List<Robot>();
            this.obstacles = new List<Obstacle>();
        }

        public void GenerateRobots()
        {
            var robot1 = new Robot("wall-e", 10, 10, 5, Helpers.Color.Blue);
            var robot2 = new Robot("eva", 5, 4, 5, Helpers.Color.Yellow);
            robots.Add(robot1);
            robots.Add(robot2);
        }

        public void GenerateRobot(string name, float weight, float size, int lifesQty, Helpers.Color color)
        {
            var robot = new Robot(name, weight, size, lifesQty, color);
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

            for (var i = 0; i < width; ++i)
            {
                for (var j = 0; j < height; ++j)
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

        public void DrawRobotsInformation()
        {
            for (var i = 0; i < robots.Count; ++i)
            {
                Console.ForegroundColor = robots[i].Color.ToConsoleColor();
                Console.SetCursorPosition(ConstantHelpers.MAP.MAX_X * 3 + 10, i*5);
                Console.Write($"Nombre: {robots[i].Name}");
                Console.SetCursorPosition(ConstantHelpers.MAP.MAX_X * 3 + 10, i*5+1);
                Console.Write($"Peso: {robots[i].Weight}");
                Console.SetCursorPosition(ConstantHelpers.MAP.MAX_X * 3 + 10, i*5+2);
                Console.Write($"Vidas: {robots[i].LifesQty}");
                Console.SetCursorPosition(ConstantHelpers.MAP.MAX_X * 3 + 10, i*5+3);
                Console.Write($"Posición: ({robots[i].Position.X}, {robots[i].Position.Y})");
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
