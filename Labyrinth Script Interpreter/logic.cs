using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class logic
    {
        private bool arithmetic_modifier = false;
        private main m;

        public logic(main ma)
        {
            m = ma;
        }

        public void execute(char command)
        {
            switch (command)
            {
                case '>':
                    m.getData().increaseX();
                    break;
                case '<':
                    m.getData().decreaseX();
                    break;
                case '^':
                    if (arithmetic_modifier)
                    {
                        m.getData().setData((long)Math.Pow(m.getData().getData(), m.getData().getGlobal()));
                        arithmetic_modifier = false;
                    }
                    else
                        m.getData().decreaseY();
                    break;
                case 'v':
                    m.getData().increaseY();
                    break;
                case '+':
                    if (arithmetic_modifier)
                    {
                        m.getData().setData(m.getData().getData() + m.getData().getGlobal());
                        arithmetic_modifier = false;
                    }
                    else
                        m.getData().setData(m.getData().getData() + 1);
                    break;
                case '-':
                    if (arithmetic_modifier)
                    {
                        m.getData().setData(m.getData().getData() - m.getData().getGlobal());
                        arithmetic_modifier = false;
                    }
                    else
                        m.getData().setData(m.getData().getData() - 1);
                    break;
                case '[':
                    if (m.getData().getData() == 0)
                        m.getCommands().openLoop();
                    break;
                case ']':
                    if (m.getData().getData() != 0)
                    {
                        m.getCommands().closeLoop();
                    }
                    break;
                case '.':
                    m.getForm().toOutput(((char) m.getData().getData() ).ToString());
                    break;
                case ':':
                    m.getForm().toOutput(m.getData().getData().ToString());
                    break;
                case '\\':
                    m.getForm().toOutput("\r\n");
                    break;
                case '#':
                    m.getData().setGlobal(m.getData().getData());
                    break;
                case '@':
                    m.getData().setData(m.getData().getGlobal());
                    break;
                case 'l':
                    m.getCommands().turnLeft();
                    break;
                case 'r':
                    m.getCommands().turnRight();
                    break;
                case '?':
                    if (m.getData().getData() == 0)
                    {
                        m.getCommands().turnRight();
                    }
                    break;
                case '*':
                    if (arithmetic_modifier)
                    {
                        m.getData().setData(m.getData().getData() * m.getData().getGlobal());
                        arithmetic_modifier = false;
                    }
                    else
                        arithmetic_modifier = true;
                    break;
                case '%':
                    if (arithmetic_modifier)
                    {
                        m.getData().setData(m.getData().getData() % m.getData().getGlobal());
                        arithmetic_modifier = false;
                    }
                    break;
                case '~':
                    m.abort("");
                    break;
                default:
                    break;
            }
        }

        public void reset()
        {
            arithmetic_modifier = false;
        }
    }
}
