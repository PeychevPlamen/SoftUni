package DeliveryBoy_02;

import java.util.Scanner;

public class DeliveryBoy {
    public static int startRow;
    public static int startCol;
    public static int boyRow;
    public static int boyCol;
    public static boolean isOut = false;
    public static boolean isDelivered = false;

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String[] size = scanner.nextLine().split("\\s+");

        int row = Integer.parseInt(size[0]);
        int col = Integer.parseInt(size[1]);

        char[][] matrix = new char[row][col];
        fillMatrix(matrix, scanner);

        String direction = scanner.nextLine();
        while (true) {
            if (direction.equals("down")) {
                move(matrix, boyRow + 1, boyCol);
            } else if (direction.equals("up")) {
                move(matrix, boyRow - 1, boyCol);
            } else if (direction.equals("left")) {
                move(matrix, boyRow, boyCol - 1);
            } else {
                move(matrix, boyRow, boyCol + 1);
            }
            if (isOut) {
                break;
            }
            if (isDelivered) {
                break;
            }
            direction = scanner.nextLine();
        }

        printMatrix(matrix);

    }

    private static void move(char[][] matrix, int nextRow, int nextCol) {
        if (!isInBounds(matrix, nextRow, nextCol)) {
            matrix[startRow][startCol] = ' ';
            System.out.println("The delivery is late. Order is canceled.");
            isOut = true;
        } else if (matrix[nextRow][nextCol] == 'A') {
            matrix[nextRow][nextCol] = 'P';
            System.out.println("Pizza is delivered on time! Next order...");
            isDelivered = true;
        } else if (matrix[nextRow][nextCol] == '-' || matrix[nextRow][nextCol] == '.') {
            matrix[nextRow][nextCol] = '.';
        } else if (matrix[nextRow][nextCol] == 'P') {
            matrix[nextRow][nextCol] = 'R';
            System.out.println("Pizza is collected. 10 minutes for delivery.");
        } else if (matrix[nextRow][nextCol] == '*') {
            nextRow = boyRow;
            nextCol = boyCol;
        }

        boyRow = nextRow;
        boyCol = nextCol;

    }


    private static void fillMatrix(char[][] matrix, Scanner scanner) {
        for (int row = 0; row < matrix.length; row++) {
            String line = scanner.nextLine();
            matrix[row] = line.toCharArray();

            int index = line.indexOf('B');

            if (index != -1) {
                startRow = row;
                startCol = index;
            }
        }
        boyRow = startRow;
        boyCol = startCol;
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
