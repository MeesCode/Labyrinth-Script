import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

/**
 * Created by Mees on 24-Oct-16.
 */
public class main {

    private static boolean stop = false;

    public static void main(String args[]) {

        try {
            commands.setCommand(loadFile(args[0]));
        } catch (FileNotFoundException e) {
            abort("cannot open file");
        }

        run();
    }

    public static void run(){
        //System.out.println("run commands");
        logic.execute(commands.getCurrent());
        while (commands.hasNext() && !stop) {
            //System.out.println("has next command");
            logic.execute(commands.getNext());
        }
    }

    private static char[][] loadFile(String path) throws FileNotFoundException {
        File file = new File(path);
        Scanner sc = new Scanner(file);
        String text = "";

        while(sc.hasNextLine()){
            text += sc.nextLine();
            text += "\n";
        }
        sc.close();

        return turnIntoArray(text);

    }

    public static char[][] turnIntoArray(String string){
        //System.out.println("turn into array");
        Scanner sc = new Scanner(string);

        int maxX = 0;
        int maxY = 0;

        while (sc.hasNextLine()) {
            maxY++;
            String line = sc.nextLine();
            if (line.length() > maxX) {
                maxX = line.length();
            }
        }
        sc = new Scanner(string);

        char[][] commands = new char[maxX][maxY];

        for (int y = 0; y < maxY; y++) {
            String line = sc.nextLine();
            for (int x = 0; x < maxX; x++) {
                if (x < line.length())
                    commands[x][y] = line.charAt(x);
                else
                    commands[x][y] = ' ';
            }
        }
        sc.close();
        return commands;
    }

    public static void abort(String s) {
        System.out.println(s);
        window.toOutput(s + "\n");
        stop = true;
    }

    public static void reset(){
        commands.reset();
        logic.reset();
        data.reset();
        window.reset();
        stop = false;
    }

}