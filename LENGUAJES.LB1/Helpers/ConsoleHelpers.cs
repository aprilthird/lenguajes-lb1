using System;
using System.Collections.Generic;
using System.Text;

namespace LENGUAJES.LB1.Helpers
{
    public static class ConsoleHelpers
    {
        public static ConsoleColor ToConsoleColor(this Color color)
        {
            switch (color)
            {
                case Color.Red:
                    return ConsoleColor.Red;
                case Color.Blue:
                    return ConsoleColor.Blue;
                case Color.Gray:
                    return ConsoleColor.Gray;
                case Color.Green:
                    return ConsoleColor.Green;
                case Color.Yellow:
                    return ConsoleColor.Yellow;
                default:
                    return ConsoleColor.Gray;
            }
        }
    }
}
