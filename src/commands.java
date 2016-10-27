
/**
 * Created by Mees on 24-Oct-16.
 */
public class commands {

    static int indexX = 0;
    static int indexY = 0;
    private static char[][] commands = new char[100][100];

    public enum direction {
        UP, DOWN, LEFT, RIGHT;
    }

    private static direction dir = direction.RIGHT;

    public static void setCommand(char[][] c) {
        commands = c;
    }

    public static char getNext() {
        updateIndex(dir);
        return commands[indexX][indexY];
    }

    public static char getPrevious() {
        updateIndex(getOpposite(dir));
        return commands[indexX][indexY];
    }

    public static char getCurrent() {
        return commands[indexX][indexY];
    }

    public static direction getOpposite(direction d) {
        switch (d) {
            case UP:
                return direction.DOWN;
            case DOWN:
                return direction.UP;
            case LEFT:
                return direction.RIGHT;
            case RIGHT:
                return direction.LEFT;
        }
        return null;
    }

    public static void closeLoop() {
        int counted = 0;
        while (true) {
            getPrevious();
            if (getCurrent() == 'l' || getCurrent() == 'r') {
                logic.execute(getCurrent());
                logic.execute(getCurrent());
                logic.execute(getCurrent());
            }
            if (getCurrent() == '?') {
                if (hasFollowing(getOpposite(dir)) && directionNotEmpty(getOpposite(dir))) {
                    continue;
                } else {
                    turnLeft();
                }
            }
            if (commands[indexX][indexY] == ']') {
                counted++;
            }
            if (commands[indexX][indexY] == '[') {
                if (counted == 0) {
                    break;
                } else {
                    counted--;
                }
            }
        }
    }

    public static void openLoop() {
        int counted = 0;
        while (true) {
            getNext();
            if (getCurrent() == 'l' || getCurrent() == 'r') {
                logic.execute(getCurrent());
            }
            if (commands[indexX][indexY] == '[') {
                counted++;
            }
            if (commands[indexX][indexY] == ']') {
                if (counted == 0) {
                    break;
                } else {
                    counted--;
                }
            }
        }
    }

    public static void turnRight() {
        switch (dir) {
            case UP:
                dir = direction.RIGHT;
                break;
            case DOWN:
                dir = direction.LEFT;
                break;
            case LEFT:
                dir = direction.UP;
                break;
            case RIGHT:
                dir = direction.DOWN;
                break;
        }
    }

    public static void turnLeft() {
        switch (dir) {
            case UP:
                dir = direction.LEFT;
                break;
            case DOWN:
                dir = direction.RIGHT;
                break;
            case LEFT:
                dir = direction.DOWN;
                break;
            case RIGHT:
                dir = direction.UP;
                break;
        }
    }

    public static boolean hasNext() {
        return hasFollowing(dir);
    }

    public static boolean hasPrevious() {
        return hasFollowing(getOpposite(dir));
    }

    public static boolean hasFollowing(direction d) {
        switch (d) {
            case RIGHT:
                if (indexX >= commands.length - 1 && !hasFollowing(direction.DOWN))
                    return false;
                break;
            case LEFT:
                if (indexX <= 0 && !hasFollowing(direction.UP)) {
                    return false;
                }
                break;
            case DOWN:
                if (indexY >= commands[0].length - 1)
                    return false;
                break;
            case UP:
                if (indexY <= 0)
                    return false;
                break;
        }
        return true;
    }

    private static void updateIndex(direction d) {
        switch (d) {
            case RIGHT:
                if (hasFollowing(d) && indexX < commands.length - 1) {
                    indexX++;
                } else {
                    if (hasFollowing(direction.DOWN)) {
                        indexX = 0;
                        indexY++;
                    } else {
                        main.abort("(" + indexX + ", " + indexY + ") Commands does not exist.");
                    }
                }
                break;
            case LEFT:
                if (hasFollowing(d) && indexX > 0) {
                    indexX--;
                } else {
                    if (hasFollowing(direction.UP)) {
                        indexX = commands.length - 1;
                        indexY--;
                    } else {
                        main.abort("(" + indexX + ", " + indexY + ") Commands does not exist.");
                    }
                }
                break;
            case DOWN:
                if (hasFollowing(d)) {
                    indexY++;
                } else {
                    main.abort("(" + indexX + ", " + indexY + ") Commands does not exist.");
                }
                break;
            case UP:
                if (hasFollowing(d)) {
                    indexY--;
                } else {
                    main.abort("(" + indexX + ", " + indexY + ") Commands does not exist.");
                }
                break;
        }
    }

    private static boolean directionNotEmpty(direction d) {
        switch (d) {
            case UP:
                if (indexY > 0 && commands[indexX][indexY - 1] != ' ') {
                    return true;
                }
                break;
            case DOWN:
                if (indexY < commands[0].length - 1 && commands[indexX][indexY + 1] != ' ')
                    return true;
                break;
            case RIGHT:
                if (indexX < commands.length - 1 && commands[indexX + 1][indexY] != ' ')
                    return true;
                break;
            case LEFT:
                if (indexX > 0 && commands[indexX - 1][indexY] != ' ')
                    return true;
                break;
        }
        return false;
    }

    public static void reset(){
        dir = direction.RIGHT;
        indexY = 0;
        indexX = 0;
        commands = new char[100][100];
    }
}
