using LENGUAJES.LB1.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LENGUAJES.LB1.Entities
{
    public class Obstacle
    {
        public string Name { get; set; }
        public float Weight { get; set; }

        public int Damage { get; set; }

        public Color Color { get; set; }

        public Point Position { get; }

        public bool IsOn { get; private set; } = false;

        public Obstacle(string name, float weight, int damage, Color color)
        {
            this.Name = name;
            this.Weight = weight;
            this.Damage = damage;
            this.Color = color;
            var r = new Random();
            this.Position = new Point(r.Next(0, ConstantHelpers.MAP.MAX_X), r.Next(0, ConstantHelpers.MAP.MAX_Y));
        }

        public Obstacle(string name, float weight, int damage, Color color, Point position)
            => (this.Name, this.Weight, this.Damage, this.Color, this.Position)
                = (name, weight, damage, color, position);

        public void Hit(Robot robot)
        {
            robot.ReceiveDamage(Damage);
        }

        public void On() => IsOn = true;

        public void Off() => IsOn = false;
    }
}
