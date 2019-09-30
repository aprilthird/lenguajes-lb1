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
                case Color.Magenta:
                    return ConsoleColor.Magenta;
                case Color.Cyan:
                    return ConsoleColor.Cyan;
                case Color.DarkCyan:
                    return ConsoleColor.DarkCyan;
                case Color.DarkRed:
                    return ConsoleColor.DarkRed;
                case Color.DarkBlue:
                    return ConsoleColor.DarkBlue;
                case Color.DarkYellow:
                    return ConsoleColor.DarkYellow;
                case Color.DarkMagenta:
                    return ConsoleColor.DarkMagenta;
                case Color.DarkGreen:
                    return ConsoleColor.DarkGreen;
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
                case "magenta":
                    return Color.Magenta;
                case "cyan":
                    return Color.Cyan;
                case "darkcyan":
                    return Color.DarkCyan;
                case "darkred":
                    return Color.DarkRed;
                case "darkblue":
                    return Color.DarkBlue;
                case "darkyellow":
                    return Color.DarkYellow;
                case "darkmagenta":
                    return Color.DarkMagenta;
                case "darkgreen":
                    return Color.DarkGreen;
                default:
                    return Color.Gray;
            }
        }

        public static bool NextBoolean(this Random random)
            => random.Next() > (int.MaxValue / 2);
    }
}
