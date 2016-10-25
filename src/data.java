/**
 * Created by Mees on 24-Oct-16.
 */
public class data {

    private static int indexX = 0;
    private static int indexY = 0;
    private static long[][] data = new long[100][100];

    private static long global;

    public static long getData() {
        return data[indexX][indexY];
    }

    public static void setData(long l) {
        data[indexX][indexY] = l;
    }

    public static void increaseX() {
        indexX++;
    }

    public static void decreaseX() {
        indexX--;
    }

    public static void increaseY(){
        indexY++;
    }

    public static void decreaseY(){
        indexY--;
    }

    public static void setGlobal(long l){
        global = l;
    }

    public static long getGlobal(){
        return global;
    }


}
