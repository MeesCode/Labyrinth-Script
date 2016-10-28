using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class data
    {
        private int size = 100;

        private int indexX = 0;
        private int indexY = 0;
        private long[,] memory;

        private long global;
        private main m;

        public data(main ma)
        {
            m = ma;
            memory = new long[size, size];
        }

        public long getData()
        {
            return memory[indexX, indexY];
        }

        public void setData(long l)
        {
            memory[indexX, indexY] = l;
        }

        public void increaseX()
        {
            if (indexX >= size - 1)
            {
                m.abort("(" + (indexX + 1) + ", " + indexY + ") Data does not exist.");
            }
            indexX++;
        }

        public void decreaseX()
        {
            if (indexX <= 0)
            {
                m.abort("(" + (indexX - 1) + ", " + indexY + ") Data does not exist.");
            }
            indexX--;
        }

        public void increaseY()
        {
            if (indexY >= size - 1)
            {
                m.abort("(" + indexX + ", " + (indexY + 1) + ") Data does not exist.");
            }
            indexY++;
        }

        public void decreaseY()
        {
            if (indexY <= 0)
            {
                m.abort("(" + indexX + ", " + (indexY - 1) + ") Data does not exist.");
            }
            indexY--;
        }

        public void setGlobal(long l)
        {
            global = l;
        }

        public long getGlobal()
        {
            return global;
        }

        public void reset()
        {
            indexX = 0;
            indexY = 0;
            memory = new long[size, size];
        }
    }
}
