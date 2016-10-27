import javafx.application.Application;
import javafx.embed.swing.JFXPanel;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Group;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Menu;
import javafx.scene.control.MenuBar;
import javafx.scene.control.MenuItem;
import javafx.scene.control.TextArea;
import javafx.scene.layout.GridPane;
import javafx.stage.FileChooser;
import javafx.stage.Stage;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.PrintWriter;
import java.io.UnsupportedEncodingException;
import java.util.Scanner;

/**
 * Created by Mees on 27-Oct-16.
 */
public class window extends Application {

    private File file = null;
    private static TextArea output;
    private File currentFile = null;

    public static void main(String[] args) {
        launch(args);
    }

    @Override
    public void start(Stage stage) {
        stage.setTitle("Labyrinth Script");
        output = new TextArea();

        FileChooser fileChooser = new FileChooser();
        Group root = new Group();
        Scene scene = new Scene(root, 880, 750);
        root.setId("root");

        GridPane grid = new GridPane();
        grid.setAlignment(Pos.CENTER);
        grid.setHgap(10);
        grid.setVgap(10);
        grid.setPadding(new Insets(25, 5, 5, 5));

        TextArea input = new TextArea();
        input.setId("input");
        grid.add(input, 1, 1);

        output.setEditable(false);
        output.setId("output");
        grid.add(output, 1, 3);

        Button button = new Button();
        button.setText("run");
        button.setId("button");

        button.setOnAction(event -> {
            main.reset();
            commands.setCommand(main.turnIntoArray(input.getText()));
            main.run();
        });
        grid.add(button, 1, 2);

        MenuBar menuBar = new MenuBar();
        Menu menuFile = new Menu("File");

        MenuItem open = new MenuItem("Open...");
        open.setOnAction(event -> {
            file = fileChooser.showOpenDialog(stage);
            if(file != null) {
                currentFile = file;
                input.setText(readFile(file));
            }
        });

        MenuItem saveAs = new MenuItem("Save as...");
        saveAs.setOnAction(event -> {
            file = fileChooser.showSaveDialog(stage);
            if(file != null) {
                currentFile = file;
                saveFile(input.getText(), file);
            }
        });

        MenuItem save = new MenuItem("Save");
        save.setOnAction(event -> {
            if(currentFile != null) {
                saveFile(input.getText(), currentFile);
            } else {
                file = fileChooser.showSaveDialog(stage);
                if(file != null) {
                    currentFile = file;
                    saveFile(input.getText(), file);
                }
            }
        });

        menuFile.getItems().addAll(open, saveAs, save);

        menuBar.getMenus().add(menuFile);
        menuBar.prefWidthProperty().bind(stage.widthProperty());

        root.getChildren().addAll(grid, menuBar);

        stage.setScene(scene);
        scene.getStylesheets().add(this.getClass().getResource("style.css").toExternalForm());

        stage.show();
    }

    private String readFile(File file){
        try {
            Scanner sc = new Scanner(file);
            String text = "";
            while(sc.hasNextLine()){
                text += sc.nextLine();
                text += "\n";
            }
            sc.close();
            return text;
        } catch (FileNotFoundException e) {
            System.out.println(e);
        }
        return null;
    }

    private void saveFile(String s, File f){
        try {
            PrintWriter pw = new PrintWriter(f, "UTF-8");
            pw.write(s);
            pw.flush();
            pw.close();
        } catch (FileNotFoundException e) {
            System.out.println(e);
        } catch (UnsupportedEncodingException e){
            System.out.println(e);
        }
    }

    public static void toOutput(String s){
        output.setText(output.getText() + s);
    }

    public static void toOutput(char s){
        output.setText(output.getText() + s);
    }

    public static void toOutput(long s){
        output.setText(output.getText() + s);
    }

    public static void reset(){
        output.setText("");
    }
}