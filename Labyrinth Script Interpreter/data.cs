using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class data
    {
        private static int size = 100;

        private static int indexX = 0;
        private static int indexY = 0;
        private static long[,] memory = new long[size, size];

        private static long global;

        public static long getData()
        {
            return memory[indexX, indexY];
        }

        public static void setData(long l)
        {
            memory[indexX, indexY] = l;
        }

        public static void increaseX()
        {
            if (indexX >= size - 1)
            {
                main.abort("(" + (indexX + 1) + ", " + indexY + ") Data does not exist.");
            }
            indexX++;
        }

        public static void decreaseX()
        {
            if (indexX <= 0)
            {
                main.abort("(" + (indexX - 1) + ", " + indexY + ") Data does not exist.");
            }
            indexX--;
        }

        public static void increaseY()
        {
            if (indexY >= size - 1)
            {
                main.abort("(" + indexX + ", " + (indexY + 1) + ") Data does not exist.");
            }
            indexY++;
        }

        public static void decreaseY()
        {
            if (indexY <= 0)
            {
                main.abort("(" + indexX + ", " + (indexY - 1) + ") Data does not exist.");
            }
            indexY--;
        }

        public static void setGlobal(long l)
        {
            global = l;
        }

        public static long getGlobal()
        {
            return global;
        }

        public static void reset()
        {
            indexX = 0;
            indexY = 0;
            memory = new long[size, size];
        }
    }
}
