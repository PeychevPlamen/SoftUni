package MouseInTheKitchen_02;

import java.util.Scanner;

public class MouseInTheKitchen_02 {
    public static int startRow = 0;
    public static int startCol = 0;

    public static int rowMouse;
    public static int colMouse;
    public static int cheeseCount = 0;

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String[] matrixSize = scanner.nextLine().split(",");
        int row = Integer.parseInt(matrixSize[0]);
        int col = Integer.parseInt(matrixSize[1]);

        char[][] matrix = new char[row][col];
        fillMatrix(matrix, scanner);

        for (int r = 0; r < matrix.length; r++) {
            for (int c = 0; c < matrix[r].length; c++) {
                if (matrix[r][c] == 'C') {
                    cheeseCount++;
                }
            }
        }

        boolean mouseInProgress = true;
        String direction = scanner.nextLine();

        while (mouseInProgress && !direction.equals("danger")) {

            rowMouse = startRow;
            colMouse = startCol;

            if (direction.equals("down")) {
                mouseInProgress = move(matrix, rowMouse + 1, colMouse);

            } else if (direction.equals("up")) {
                mouseInProgress = move(matrix, rowMouse - 1, colMouse);

            } else if (direction.equals("left")) {
                mouseInProgress = move(matrix, rowMouse, colMouse - 1);

            } else {
                mouseInProgress = move(matrix, rowMouse, colMouse + 1);

            }
            direction = scanner.nextLine();
        }
        if (cheeseCount > 0 && direction.equals("danger")){
            System.out.println("Mouse will come back later!");
        }
        printMatrix(matrix);
    }

    private static boolean move(char[][] matrix, int nextRow, int nextCol) {

        if (!isInBounds(matrix, nextRow, nextCol)) {
            System.out.println("No more cheese for tonight!");
            return false;
        }

        startRow = nextRow;
        startCol = nextCol;

        if (matrix[nextRow][nextCol] == 'C') {
            matrix[nextRow][nextCol] = 'M';
            matrix[rowMouse][colMouse] = '*';
            cheeseCount--;
            if (cheeseCount == 0) {
                matrix[nextRow][nextCol] = 'M';
                System.out.println("Happy mouse! All the cheese is eaten, good night!");
                return false;
            }
            return true;
        } else if (matrix[nextRow][nextCol] == 'T') {
            matrix[nextRow][nextCol] = 'M';
            matrix[rowMouse][colMouse] = '*';
            System.out.println("Mouse is trapped!");
            return false;
        } else if (matrix[nextRow][nextCol] == '@') {
            startRow = rowMouse;
            startCol = colMouse;
            return true;
        } else if (matrix[nextRow][nextCol] == '*') {
            matrix[nextRow][nextCol] = 'M';
            matrix[rowMouse][colMouse] = '*';
            return true;
        }

        if (matrix[nextRow][nextCol] != 'M') {
            matrix[nextRow][nextCol] = '*';
        }
        return true;
    }

    private static void fillMatrix(char[][] matrix, Scanner scanner) {
        for (int row = 0; row < matrix.length; row++) {
            String line = scanner.nextLine();
            matrix[row] = line.toCharArray();

            int index = line.indexOf('M');

            if (index != -1) {
                startRow = row;
                startCol = index;
            }
        }
    }

    private static void printMatrix(char[][] matrix) {
        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {
                System.out.print(matrix[row][col]);
            }
            System.out.println();
        }
    }

    private static boolean isInBounds(char[][] matrix, int r, int c) {
        return r >= 0 && r < matrix.length && c >= 0 && c < matrix[r].length;
    }
}
