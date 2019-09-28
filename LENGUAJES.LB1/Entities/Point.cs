using System;
using System.Collections.Generic;
using System.Text;

namespace LENGUAJES.LB1.Entities
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y) => (X, Y) = (x, y);
    }
}
