using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class main
    {
        private static bool stop = false;

        public static string run()
        {
            string output = string.Empty;
            output += logic.execute(commands.getCurrent());
            while (commands.hasNext() && !stop)
            {
                output += logic.execute(commands.getNext());
            }
            return output;
        }

        public static char[,] turnIntoArray(string s)
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

        public static void abort(String s)
        {
            stop = true;
        }

        public static void reset()
        {
            commands.reset();
            logic.reset();
            data.reset();
            stop = false;
        }
    }
}
