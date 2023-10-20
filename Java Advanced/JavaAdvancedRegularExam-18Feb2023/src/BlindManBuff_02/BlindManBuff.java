package BlindManBuff_02;

import java.util.Scanner;

public class BlindManBuff {
    public static int startRow;
    public static int startCol;
    public static int countTouched;
    public static int moves;

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String[] size = scanner.nextLine().split("\\s+");
        int row = Integer.parseInt(size[0]);
        int col = Integer.parseInt(size[1]);

        String[][] matrix = new String[row][col];
        fillMatrix(matrix, scanner);

        String direction = scanner.nextLine();

        while (!direction.equals("Finish")) {
            if (direction.equals("down")) {
                move(matrix, startRow + 1, startCol);

            } else if (direction.equals("up")) {
                move(matrix, startRow - 1, startCol);

            } else if (direction.equals("left")) {
                move(matrix, startRow, startCol - 1);

            } else if (direction.equals("right")) {
                move(matrix, startRow, startCol + 1);
            }
            if (countTouched == 3) {
                break;
            }

            direction = scanner.nextLine();
        }
        System.out.println("Game over!");
        System.out.printf("Touched opponents: %d Moves made: %d", countTouched, moves);

    }

    private static void move(String[][] matrix, int nextRow, int nextCol) {

        matrix[startRow][startCol] = "-"; // clean "B" position in the matrix

        if (!isInBounds(matrix, nextRow, nextCol)) {
            matrix[startRow][startCol] = "B";
            nextRow = startRow;
            nextCol = startCol;

        } else if (matrix[nextRow][nextCol].equals("O")) {
            matrix[startRow][startCol] = "B";
            nextRow = startRow;
            nextCol = startCol;

        } else if (matrix[nextRow][nextCol].equals("P")) {
            moves++;
            countTouched++;
            matrix[nextRow][nextCol] = "-";

        } else if (matrix[nextRow][nextCol].equals("-")) {
            moves++;
        }

        startRow = nextRow;
        startCol = nextCol;

    }

    private static void fillMatrix(String[][] matrix, Scanner scanner) {
        for (int row = 0; row < matrix.length; row++) {
            String[] line = scanner.nextLine().split("\\s+");
            matrix[row] = line;
        }
        findStartIndexes(matrix);
    }

    private static void findStartIndexes(String[][] matrix) {
        for (int r = 0; r < matrix.length; r++) {
            for (int c = 0; c < matrix[r].length; c++) {
                if (matrix[r][c].equals("B")) {
                    startRow = r;
                    startCol = c;
                }
            }
        }
    }

    private static void printMatrix(String[][] matrix) {
        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {
                System.out.print(matrix[row][col] + " ");
            }
            System.out.println();
        }
    }

    private static boolean isInBounds(String[][] matrix, int r, int c) {
        return r >= 0 && r < matrix.length && c >= 0 && c < matrix[r].length;
    }
}
