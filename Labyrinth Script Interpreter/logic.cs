using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class logic
    {
        private static bool arithmetic_modifier = false;
        public static string execute(char command)
        {
            switch (command)
            {
                case '>':
                    data.increaseX();
                    break;
                case '<':
                    data.decreaseX();
                    break;
                case '^':
                    if (arithmetic_modifier)
                    {
                        data.setData((long)Math.Pow(data.getData(), data.getGlobal()));
                        arithmetic_modifier = false;
                    }
                    else
                        data.decreaseY();
                    break;
                case 'v':
                    data.increaseY();
                    break;
                case '+':
                    if (arithmetic_modifier)
                    {
                        data.setData(data.getData() + data.getGlobal());
                        arithmetic_modifier = false;
                    }
                    else
                        data.setData(data.getData() + 1);
                    break;
                case '-':
                    if (arithmetic_modifier)
                    {
                        data.setData(data.getData() - data.getGlobal());
                        arithmetic_modifier = false;
                    }
                    else
                        data.setData(data.getData() - 1);
                    break;
                case '[':
                    if (data.getData() == 0)
                        commands.openLoop();
                    break;
                case ']':
                    if (data.getData() != 0)
                    {
                        commands.closeLoop();
                    }
                    break;
                case '.':
                    return ((char) data.getData()).ToString();
                case ':':
                    return data.getData().ToString();
                case '\\':
                    return "\r\n";
                case '#':
                    data.setGlobal(data.getData());
                    break;
                case '@':
                    data.setData(data.getGlobal());
                    break;
                case 'l':
                    commands.turnLeft();
                    break;
                case 'r':
                    commands.turnRight();
                    break;
                case '?':
                    if (data.getData() == 0)
                    {
                        commands.turnRight();
                    }
                    break;
                case '*':
                    if (arithmetic_modifier)
                    {
                        data.setData(data.getData() * data.getGlobal());
                        arithmetic_modifier = false;
                    }
                    else
                        arithmetic_modifier = true;
                    break;
                case '%':
                    if (arithmetic_modifier)
                    {
                        data.setData(data.getData() % data.getGlobal());
                        arithmetic_modifier = false;
                    }
                    break;
                case '~':
                    main.abort("");
                    break;
                default:
                    break;
            }
            return string.Empty;
        }

        public static void reset()
        {
            arithmetic_modifier = false;
        }
    }
}
