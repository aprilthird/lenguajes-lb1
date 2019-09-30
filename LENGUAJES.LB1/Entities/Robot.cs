using LENGUAJES.LB1.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LENGUAJES.LB1.Entities
{
    public class Robot
    {
        public string Name { get; set; }

        public float Weight { get; set; }

        public float Size { get; set; }

        public int LifesQty { get; set; }

        public Color Color { get; set; }

        public Point Position { get; private set; }

        public int Damage => (Weight >= 35) ? 2 : 1;

        public Robot(string name, float weight, float size, int lifesQty, Color color)
        {
            this.Name = name;
            this.Weight = weight;
            this.Size = size;
            this.LifesQty = lifesQty;
            this.Color = color;
            var r = new Random();
            this.Position = new Point(r.Next(0, ConstantHelpers.MAP.MAX_X), r.Next(0, ConstantHelpers.MAP.MAX_Y));
        }

        public Robot(string name, float weight, float size, int lifesQty, Color color, Point position)
            => (this.Name, this.Weight, this.Size, this.LifesQty, this.Color, this.Position) 
                = (name, weight, size, lifesQty, color, position);

        public void Move(int posX, int posY)
        {
            this.Position = new Point(posX, posY);
        }

        public void ReceiveDamage(int damage)
        {
            this.LifesQty -= damage;
        }

        public void Hit(Robot enemyRobot)
        {
            var damage = (Weight >= 35) ? 2 : 1;
            enemyRobot.ReceiveDamage(damage);
        }

        public override string ToString() => $"Nombre: {Name}\nPeso: {Weight}\nVidas: {LifesQty}\nPosición: ({Position.X}, {Position.Y})";
    }
}
