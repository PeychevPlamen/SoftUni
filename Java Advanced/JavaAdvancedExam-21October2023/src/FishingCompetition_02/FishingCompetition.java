package FishingCompetition_02;

import java.util.Scanner;

public class FishingCompetition {
    public static int startRow;
    public static int startCol;
    public static int sum;
    public static boolean isSank = false;

    public static int oldRow;
    public static int oldCol;


    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        int size = Integer.parseInt(scanner.nextLine());
        char[][] matrix = new char[size][size];
        fillMatrix(matrix, scanner);

        String commands = scanner.nextLine();

        while (!commands.equals("collect the nets")) {
            if (commands.equals("down")) {
                if (!isInBounds(matrix, startRow + 1, startCol)) {
                    oldRow = startRow;
                    oldCol = startCol;
                    startRow = 0;

                    move(matrix, startRow, startCol);

                } else {
                    move(matrix, startRow + 1, startCol);
                }

            } else if (commands.equals("up")) {
                if (!isInBounds(matrix, startRow - 1, startCol)) {
                    oldRow = startRow;
                    oldCol = startCol;
                    startRow = matrix.length - 1;

                    move(matrix, startRow, startCol);

                } else {
                    move(matrix, startRow - 1, startCol);
                }


            } else if (commands.equals("left")) {
                if (!isInBounds(matrix, startRow, startCol - 1)) {
                    oldRow = startRow;
                    oldCol = startCol;
                    startCol = matrix.length - 1;

                    move(matrix, startRow, startCol);

                } else {
                    move(matrix, startRow, startCol - 1);
                }


            } else if (commands.equals("right")) {
                if (!isInBounds(matrix, startRow, startCol + 1)) {
                    oldRow = startRow;
                    oldCol = startCol;
                    startCol = 0;
                    move(matrix, startRow, startCol);

                } else {
                    move(matrix, startRow, startCol + 1);
                }

            }
            commands = scanner.nextLine();
        }
        if (!isSank) {
            if (sum >= 20) {
                System.out.println("Success! You managed to reach the quota!");
            } else {
                System.out.print("You didn't catch enough fish and didn't reach the quota! ");
                System.out.printf("You need %d tons of fish more.\n", 20 - sum);
            }
            if (sum > 0) {
                System.out.printf("Amount of fish caught: %d tons.\n", sum);
            }
            printMatrix(matrix);
        }


    }

    private static void move(char[][] matrix, int nextRow, int nextCol) {

        // clean "S" position in the matrix

        if (Character.isDigit(matrix[nextRow][nextCol])) {

            sum += Character.getNumericValue(matrix[nextRow][nextCol]);
            matrix[nextRow][nextCol] = 'S';
//            nextRow = startRow;
//            nextCol = startCol;
            matrix[startRow][startCol] = '-';
            matrix[oldRow][oldCol] = '-';

        } else if (matrix[nextRow][nextCol] == 'W') {
            sum = 0;
            System.out.printf("You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [%d,%d]", nextRow, nextCol);
            isSank = true;
            //return;
        } else if (matrix[nextRow][nextCol] == '-') {
            matrix[nextRow][nextCol] = 'S';
            matrix[startRow][startCol] = '-';
            matrix[oldRow][oldCol] = '-';
        }

        startRow = nextRow;
        startCol = nextCol;

    }

    private static void fillMatrix(char[][] matrix, Scanner scanner) {
        for (int row = 0; row < matrix.length; row++) {
            String line = scanner.nextLine();
            matrix[row] = line.toCharArray();

            int index = line.indexOf('S');

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
