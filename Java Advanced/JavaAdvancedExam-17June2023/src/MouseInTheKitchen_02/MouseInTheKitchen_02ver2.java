package MouseInTheKitchen_02;

import java.util.Scanner;

public class MouseInTheKitchen_02ver2 {
    public static int currentRowMouse = 0;
    public static int currentColMouse = 0;

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

        String direction = scanner.nextLine();

        while (!direction.equals("danger")) {
            currentRowMouse = rowMouse;
            currentColMouse = colMouse;
            if (direction.equals("down")) {
                rowMouse++;
            } else if (direction.equals("up")) {
                rowMouse--;
            } else if (direction.equals("left")) {
                colMouse--;
            } else {
                colMouse++;
            }
            if (!isInBounds(matrix, rowMouse, colMouse)) {
                System.out.println("No more cheese for tonight!");
                break;
            }
            if (matrix[rowMouse][colMouse] == 'C') {
                matrix[rowMouse][colMouse] = 'M';
                matrix[currentRowMouse][currentColMouse] = '*';
                cheeseCount--;
                if (cheeseCount == 0) {
                    matrix[rowMouse][colMouse] = 'M';
                    System.out.println("Happy mouse! All the cheese is eaten, good night!");
                    break;
                }

            } else if (matrix[rowMouse][colMouse] == 'T') {
                matrix[rowMouse][colMouse] = 'M';
                matrix[currentRowMouse][currentColMouse] = '*';
                System.out.println("Mouse is trapped!");
                break;
            } else if (matrix[rowMouse][colMouse] == '*') {
                matrix[rowMouse][colMouse] = 'M';
                matrix[currentRowMouse][currentColMouse] = '*';
            } else if (matrix[rowMouse][colMouse] == '@') {
                rowMouse = currentRowMouse;
                colMouse = currentColMouse;
            }

            direction = scanner.nextLine();
        }
        if (cheeseCount > 0 && direction.equals("danger")){
            System.out.println("Mouse will come back later!");
        }
        printMatrix(matrix);
    }

    private static void fillMatrix(char[][] matrix, Scanner scanner) {
        for (int row = 0; row < matrix.length; row++) {
            String line = scanner.nextLine();
            matrix[row] = line.toCharArray();

            int index = line.indexOf('M');

            if (index != -1) {
                rowMouse = row;
                colMouse = index;
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
