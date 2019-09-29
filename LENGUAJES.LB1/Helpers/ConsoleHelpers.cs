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

        public static Color ToColor(this string str)
        {
            switch(str)
            {
                case "red":
                    return Color.Red;
                case "yellow":
                    return Color.Yellow;
                case "green":
                    return Color.Green;
                case "blue":
                    return Color.Blue;
                case "gray":
                    return Color.Gray;
                default:
                    return Color.Gray;
            }
        }
    }
}
