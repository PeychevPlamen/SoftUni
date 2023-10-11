package TheSquirrel_02;

import java.util.Scanner;

public class TheSquirrel {
    private static int startRow = 0;
    private static int startCol = 0;
    private static int hazelnutsCount = 0;
    private static boolean isTrue = false;

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int matrixSize = Integer.parseInt(scanner.nextLine());
        char[][] matrix = new char[matrixSize][matrixSize];
        String[] commands = scanner.nextLine().split(", ");

        fillMatrix(matrix, scanner);

        for (int i = 0; i < commands.length; i++) {
            if (isTrue) {
                break;
            }
            String command = commands[i];
            if (command.equals("left")) {
                move(matrix, startRow, startCol - 1);
            } else if (command.equals("right")) {
                move(matrix, startRow, startCol + 1);
            } else if (command.equals("up")) {
                move(matrix, startRow - 1, startCol);
            } else {
                move(matrix, startRow + 1, startCol);
            }
        }
        if (hazelnutsCount < 3 && !isTrue){
            System.out.println("There are more hazelnuts to collect.");
            System.out.println("Hazelnuts collected: " + hazelnutsCount);
        }

    }

    private static void move(char[][] matrix, int nextRow, int nextCol) {

        if (!isInBounds(matrix, nextRow, nextCol)) {
            matrix[startRow][startCol] = 's';
            System.out.println("The squirrel is out of the field.");
            System.out.println("Hazelnuts collected: " + hazelnutsCount);
            isTrue = true;
            return;
        }

        if (matrix[nextRow][nextCol] == '*') {
            matrix[nextRow][nextCol] = 's';

        } else if (matrix[nextRow][nextCol] == 'h') {
            matrix[nextRow][nextCol] = 's';
            hazelnutsCount++;
            if (hazelnutsCount == 3) {
                System.out.println("Good job! You have collected all hazelnuts!");
                System.out.println("Hazelnuts collected: " + hazelnutsCount);
                matrix[startRow][startCol] = '*';
                isTrue = true;
                return;
            }

        } else if (matrix[nextRow][nextCol] == 't') {
            matrix[startRow][startCol] = '*';
            matrix[nextRow][nextCol] = '*'; // ?????
            System.out.println("Unfortunately, the squirrel stepped on a trap...");
            System.out.println("Hazelnuts collected: " + hazelnutsCount);
            isTrue = true;
            return;
        }
        matrix[startRow][startCol] = '*';
        startRow = nextRow;
        startCol = nextCol;

    }


    private static void fillMatrix(char[][] matrix, Scanner scanner) {
        for (int row = 0; row < matrix.length; row++) {
            String line = scanner.nextLine();
            matrix[row] = line.toCharArray();

            int index = line.indexOf('s');

            if (index != -1) {
                startRow = row;
                startCol = index;
            }
        }
    }

    private static boolean isInBounds(char[][] matrix, int r, int c) {
        return r >= 0 && r < matrix.length && c >= 0 && c < matrix[r].length;
    }
}
