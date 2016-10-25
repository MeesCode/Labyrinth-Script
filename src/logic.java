import java.io.IOException;

/**
 * Created by Mees on 24-Oct-16.
 */
public class logic {
    private static boolean arithmetic_modifier = false;

    public static void execute(char command) {
        switch (command) {
            case '>':
                data.increaseX();
                break;
            case '<':
                data.decreaseX();
                break;
            case '^':
                if (arithmetic_modifier) {
                    data.setData((long) Math.pow(data.getData(), data.getGlobal()));
                    arithmetic_modifier = false;
                } else
                    data.decreaseY();
                break;
            case 'v':
                data.increaseY();
                break;
            case '+':
                if (arithmetic_modifier) {
                    data.setData(data.getData() + data.getGlobal());
                    arithmetic_modifier = false;
                } else
                    data.setData(data.getData() + 1);
                break;
            case '-':
                if (arithmetic_modifier) {
                    data.setData(data.getData() - data.getGlobal());
                    arithmetic_modifier = false;
                } else
                    data.setData(data.getData() - 1);
                break;
            case '[':
                if (data.getData() == 0)
                    commands.openLoop();
                break;
            case ']':
                if (data.getData() != 0) {
                    commands.closeLoop();
                }
                break;
            case '.':
                System.out.print((char) data.getData());
                break;
            case ':':
                System.out.print(data.getData());
                break;
            case '\\':
                System.out.println();
                break;
            case ',':
                try {
                    data.setData(readInput());
                } catch (IOException e) {
                    System.out.println("cannot read input");
                }
                break;
            case '#':
                data.setGlobal(data.getData());
                break;
            case '@':
                data.setData(data.getGlobal());
                break;
            case 'l':
                commands.turnLeft();
                break;
            case 'r':
                commands.turnRight();
                break;
            case '?':
                if (data.getData() == 0) {
                    commands.turnRight();
                }
                break;
            case '*':
                if (arithmetic_modifier) {
                    data.setData(data.getData() * data.getGlobal());
                    arithmetic_modifier = false;
                } else
                    arithmetic_modifier = true;
                break;
            case '%':
                if (arithmetic_modifier) {
                    data.setData(data.getData() % data.getGlobal());
                    arithmetic_modifier = false;
                }
                break;
            case '~':
                main.abort("");
                break;
            default:
                break;
        }
    }

    private static int readInput() throws IOException {
        return System.in.read();
    }

}
