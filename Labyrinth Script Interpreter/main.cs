using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class main
    {
        private bool stop = false;

        private Form1 form;
        private logic l;
        private commands c;
        private data d;

        public main(Form1 f)
        {
            l = new logic(this);
            c = new commands(this);
            d = new data(this);
            form = f;
        }

        public void run()
        {
            string output = string.Empty;
            l.execute(c.getCurrent());
            while (c.hasNext() && !stop)
            {
                l.execute(c.getNext());
            }
        }

        public char[,] turnIntoArray(string s)
        {
            int maxX = 1;
            int maxY = 1;
            System.IO.StringReader reader = new System.IO.StringReader(s);
            string line = string.Empty;
            while (line != null)
            {
                line = reader.ReadLine();
                if(line != null)
                {
                    maxY++;
                    if(line.Length > maxX)
                    {
                        maxX = line.Length;
                    }
                }
            }

            char[,] commandArray = new char[maxX, maxY];

            reader = new System.IO.StringReader(s);
            line = string.Empty;
            
            for(int y = 0; y < maxY; y++)
            {
                line = reader.ReadLine();
                for (int x = 0; x < maxX; x++)
                {
                    if (line != null)
                    {
                        if (x < line.Length)
                        {
                            commandArray[x, y] = line[x];
                        }
                        else
                        {
                            commandArray[x, y] = ' ';
                        }
                    }
                }
            }
            return commandArray;
        }

        public void abort(String s)
        {
            form.toOutput(s);
            stop = true;
        }

        public void reset()
        {
            c.reset();
            l.reset();
            d.reset();
            stop = false;
        }

        public logic getLogic()
        {
            return l;
        }

        public data getData()
        {
            return d;
        }

        public commands getCommands()
        {
            return c;
        }

        public Form1 getForm()
        {
            return form;
        }
    }
}
