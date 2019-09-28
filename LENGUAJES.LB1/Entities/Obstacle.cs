using LENGUAJES.LB1.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LENGUAJES.LB1.Entities
{
    public class Obstacle
    {
        private string name;
        private float weight;
        private int damage;
        private Point position;
        private Color color;
        private bool isOn = false;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public float Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public Point Position
        {
            get { return position; }
        }

        public bool IsOn
        {
            get { return isOn; }
        }

        public Obstacle(string name, float weight, int damage, Color color)
        {
            this.name = name;
            this.weight = weight;
            this.damage = damage;
            this.color = color;
            var r = new Random();
            this.position = new Point(r.Next(0, ConstantHelpers.MAP.MAX_X), r.Next(0, ConstantHelpers.MAP.MAX_Y));
        }

        public Obstacle(string name, float weight, int damage, Color color, Point position)
            => (this.name, this.weight, this.damage, this.color, this.position)
                = (name, weight, damage, color, position);

        public void Hit(Robot robot)
        {
            robot.ReceiveDamage(damage);
        }

        public void On() => isOn = true;

        public void Off() => isOn = false;
    }
}
