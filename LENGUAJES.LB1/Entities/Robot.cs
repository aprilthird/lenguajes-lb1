using LENGUAJES.LB1.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LENGUAJES.LB1.Entities
{
    public class Robot
    {
        private string name;
        private float weight;
        private float size;
        private int lifesQty;
        private Color color;
        private Point position;

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

        public float Size
        {
            get { return size; }
            set { size = value; }
        }

        public int LifesQty
        {
            get { return lifesQty; }
            set { lifesQty = value; }
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

        public Robot(string name, float weight, float size, int lifesQty, Color color)
        {
            this.name = name;
            this.weight = weight;
            this.size = size;
            this.lifesQty = lifesQty;
            this.color = color;
            var r = new Random();
            this.position = new Point(r.Next(0, ConstantHelpers.MAP.MAX_X), r.Next(0, ConstantHelpers.MAP.MAX_Y));
        }

        public Robot(string name, float weight, float size, int lifesQty, Color color, Point position)
            => (this.name, this.weight, this.size, this.lifesQty, this.color, this.position) 
                = (name, weight, size, lifesQty, color, position);

        public void Move(int posX, int posY)
        {
            this.position = new Point(posX, posY);
        }

        public void ReceiveDamage(int damage)
        {
            this.lifesQty -= damage;
        }

        public void Hit(Robot enemyRobot)
        {
            var damage = (weight >= 35) ? 2 : 1;
            enemyRobot.ReceiveDamage(damage);
        }

        public override string ToString() => $"Nombre: {name}\nPeso: {weight}\nVidas: {lifesQty}\nPosición: ({position.X}, {position.Y})";
    }
}
