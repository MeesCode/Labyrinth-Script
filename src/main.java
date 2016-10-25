import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

/**
 * Created by Mees on 24-Oct-16.
 */
public class main {

    public static void main(String args[]) {

        try {
            commands.setCommand(loadFile(args[0]));
        } catch (FileNotFoundException e) {
            System.out.println(e);
        }

        logic.execute(commands.getCurrent());
        while (commands.hasNext()) {
            logic.execute(commands.getNext());
        }
    }

    private static char[][] loadFile(String path) throws FileNotFoundException {
        File file = new File(path);
        Scanner sc = new Scanner(file);

        int maxX = 0;
        int maxY = 0;

        while (sc.hasNextLine()) {
            maxY++;
            String line = sc.nextLine();
            if (line.length() > maxX) {
                maxX = line.length();
            }
        }
        sc = new Scanner(file);

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

        return commands;

    }

    public static void abort(String s) {
        System.out.println(s);
        System.exit(0);
    }

}