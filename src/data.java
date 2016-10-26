/**
 * Created by Mees on 24-Oct-16.
 */
public class data {

    private static final int size = 100;

    private static int indexX = 0;
    private static int indexY = 0;
    private static long[][] data = new long[size][size];

    private static long global;

    public static long getData() {
        return data[indexX][indexY];
    }

    public static void setData(long l) {
        data[indexX][indexY] = l;
    }

    public static void increaseX() {
        if (indexX >= size - 1)
            main.abort("(" + (indexX + 1) + ", " + indexY + ") Data does not exist.");
        indexX++;
    }

    public static void decreaseX() {
        if (indexX <= 0)
            main.abort("(" + (indexX - 1) + ", " + indexY + ") Data does not exist.");
        indexX--;
    }

    public static void increaseY() {
        if (indexY >= size - 1)
            main.abort("(" + indexX + ", " + (indexY + 1) + ") Data does not exist.");
        indexY++;
    }

    public static void decreaseY() {
        if (indexY >= 0)
            main.abort("(" + indexX + ", " + (indexY - 1)+ ") Data does not exist.");
        indexY--;
    }

    public static void setGlobal(long l) {
        global = l;
    }

    public static long getGlobal() {
        return global;
    }


}
