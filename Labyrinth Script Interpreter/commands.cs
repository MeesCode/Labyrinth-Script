using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class commands
    {
        main m;
        private int indexX = 0;
        private int indexY = 0;
        private char[,] commandArray = new char[100, 100];

        public commands(main ma)
        {
            m = ma;
        }

        public enum direction
        {
            UP, DOWN, LEFT, RIGHT
        };

        private direction dir = direction.RIGHT;

        public void setCommand(char[,] c)
        {
            commandArray = c;
        }

        public char getNext()
        {
            updateIndex(dir);
            return commandArray[indexX, indexY];
        }

        public char getPrevious()
        {
            updateIndex(getOpposite(dir));
            return commandArray[indexX, indexY];
        }

        public char getCurrent()
        {
            return commandArray[indexX, indexY];
        }

        public direction getOpposite(direction d)
        {
            switch (d)
            {
                case direction.UP:
                    return direction.DOWN;
                case direction.DOWN:
                    return direction.UP;
                case direction.LEFT:
                    return direction.RIGHT;
                case direction.RIGHT:
                    return direction.LEFT;
            }
            m.abort("direction not possible");
            return dir;
        }

        public void closeLoop()
        {
            int counted = 0;
            while (true)
            {
                getPrevious();
                if (getCurrent() == 'l' || getCurrent() == 'r')
                {
                    m.getLogic().execute(getCurrent());
                    m.getLogic().execute(getCurrent());
                    m.getLogic().execute(getCurrent());
                }
                if (getCurrent() == '?')
                {
                    if (hasFollowing(getOpposite(dir)) && directionNotEmpty(getOpposite(dir)))
                    {
                        continue;
                    }
                    else
                    {
                        turnLeft();
                    }
                }
                if (commandArray[indexX, indexY] == ']')
                {
                    counted++;
                }
                if (commandArray[indexX, indexY] == '[')
                {
                    if (counted == 0)
                    {
                        break;
                    }
                    else
                    {
                        counted--;
                    }
                }
            }
        }

        public void openLoop()
        {
            int counted = 0;
            while (true)
            {
                getNext();
                if (getCurrent() == 'l' || getCurrent() == 'r')
                {
                    m.getLogic().execute(getCurrent());
                }
                if (commandArray[indexX, indexY] == '[')
                {
                    counted++;
                }
                if (commandArray[indexX, indexY] == ']')
                {
                    if (counted == 0)
                    {
                        break;
                    }
                    else
                    {
                        counted--;
                    }
                }
            }
        }

        public void turnRight()
        {
            switch (dir)
            {
                case direction.UP:
                    dir = direction.RIGHT;
                    break;
                case direction.DOWN:
                    dir = direction.LEFT;
                    break;
                case direction.LEFT:
                    dir = direction.UP;
                    break;
                case direction.RIGHT:
                    dir = direction.DOWN;
                    break;
            }
        }

        public void turnLeft()
        {
            switch (dir)
            {
                case direction.UP:
                    dir = direction.LEFT;
                    break;
                case direction.DOWN:
                    dir = direction.RIGHT;
                    break;
                case direction.LEFT:
                    dir = direction.DOWN;
                    break;
                case direction.RIGHT:
                    dir = direction.UP;
                    break;
            }
        }

        public bool hasNext()
        {
            return hasFollowing(dir);
        }

        public bool hasPrevious()
        {
            return hasFollowing(getOpposite(dir));
        }

        public bool hasFollowing(direction d)
        {
            switch (d)
            {
                case direction.RIGHT:
                    if (indexX >= commandArray.GetLength(0) - 1 && !hasFollowing(direction.DOWN))
                        return false;
                    break;
                case direction.LEFT:
                    if (indexX <= 0 && !hasFollowing(direction.UP))
                    {
                        return false;
                    }
                    break;
                case direction.DOWN:
                    if (indexY >= commandArray.GetLength(1) - 1)
                        return false;
                    break;
                case direction.UP:
                    if (indexY <= 0)
                        return false;
                    break;
            }
            return true;
        }

        private void updateIndex(direction d)
        {
            switch (d)
            {
                case direction.RIGHT:
                    if (hasFollowing(d) && indexX < commandArray.GetLength(0) - 1)
                    {
                        indexX++;
                    }
                    else
                    {
                        if (hasFollowing(direction.DOWN))
                        {
                            indexX = 0;
                            indexY++;
                        }
                        else
                        {
                            m.abort("(" + indexX + ", " + indexY + ") Commands does not exist.");
                        }
                    }
                    break;
                case direction.LEFT:
                    if (hasFollowing(d) && indexX > 0)
                    {
                        indexX--;
                    }
                    else
                    {
                        if (hasFollowing(direction.UP))
                        {
                            indexX = commandArray.GetLength(0) - 1;
                            indexY--;
                        }
                        else
                        {
                            m.abort("(" + indexX + ", " + indexY + ") Commands does not exist.");
                        }
                    }
                    break;
                case direction.DOWN:
                    if (hasFollowing(d))
                    {
                        indexY++;
                    }
                    else
                    {
                        m.abort("(" + indexX + ", " + indexY + ") Commands does not exist.");
                    }
                    break;
                case direction.UP:
                    if (hasFollowing(d))
                    {
                        indexY--;
                    }
                    else
                    {
                        m.abort("(" + indexX + ", " + indexY + ") Commands does not exist.");
                    }
                    break;
            }
        }

        private bool directionNotEmpty(direction d)
        {
            switch (d)
            {
                case direction.UP:
                    if (indexY > 0 && commandArray[indexX, indexY - 1] != ' ')
                    {
                        return true;
                    }
                    break;
                case direction.DOWN:
                    if (indexY < commandArray.GetLength(1) - 1 && commandArray[indexX, indexY + 1] != ' ')
                        return true;
                    break;
                case direction.RIGHT:
                    if (indexX < commandArray.GetLength(0) - 1 && commandArray[indexX + 1, indexY] != ' ')
                        return true;
                    break;
                case direction.LEFT:
                    if (indexX > 0 && commandArray[indexX - 1, indexY] != ' ')
                        return true;
                    break;
            }
            return false;
        }

        public void reset()
        {
            dir = direction.RIGHT;
            indexY = 0;
            indexX = 0;
            commandArray = new char[100, 100];
        }
    }
}
