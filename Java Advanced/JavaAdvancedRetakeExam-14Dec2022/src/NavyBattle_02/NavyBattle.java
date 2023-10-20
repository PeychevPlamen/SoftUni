package NavyBattle_02;

import java.util.Scanner;

public class NavyBattle {
    public static int startRow;
    public static int startCol;
    public static int minesHit;
    public static int cruiserCount;

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int size = Integer.parseInt(scanner.nextLine());

        String[][] matrix = new String[size][size];
        fillMatrix(matrix, scanner);

        String direction = scanner.nextLine();

        while (true) {

            if (direction.equals("down")) {
                move(matrix, startRow + 1, startCol);

            } else if (direction.equals("up")) {
                move(matrix, startRow - 1, startCol);

            } else if (direction.equals("left")) {
                move(matrix, startRow, startCol - 1);

            } else if (direction.equals("right")) {
                move(matrix, startRow, startCol + 1);
            }

            if (minesHit == 3 || cruiserCount == 3) {
                break;
            }
            direction = scanner.nextLine();
        }
        printMatrix(matrix);
    }

    private static void move(String[][] matrix, int nextRow, int nextCol) {

        if (matrix[nextRow][nextCol].equals("-")) {
            matrix[nextRow][nextCol] = "S";
            matrix[startRow][startCol] = "-";

        } else if (matrix[nextRow][nextCol].equals("*")) {
            minesHit++;
            matrix[nextRow][nextCol] = "S";
            matrix[startRow][startCol] = "-";

            if (minesHit == 3) {
                System.out.printf("Mission failed, U-9 disappeared! Last known coordinates [%d, %d]!\n", nextRow, nextCol);
            }

        } else if (matrix[nextRow][nextCol].equals("C")) {
            matrix[nextRow][nextCol] = "S";
            matrix[startRow][startCol] = "-";
            cruiserCount++;
            if (cruiserCount == 3) {
                System.out.println("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");

            }
        }

        startRow = nextRow;
        startCol = nextCol;

    }

    private static void fillMatrix(String[][] matrix, Scanner scanner) {
        for (int row = 0; row < matrix.length; row++) {
            String[] line = scanner.nextLine().split("");
            matrix[row] = line;
        }
        findStartIndexes(matrix);
    }

    private static void findStartIndexes(String[][] matrix) {
        for (int r = 0; r < matrix.length; r++) {
            for (int c = 0; c < matrix[r].length; c++) {
                if (matrix[r][c].equals("S")) {
                    startRow = r;
                    startCol = c;
                }
            }
        }
    }

    private static void printMatrix(String[][] matrix) {
        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {
                System.out.print(matrix[row][col]);
            }
            System.out.println();
        }
    }

    private static boolean isInBounds(String[][] matrix, int r, int c) {
        return r >= 0 && r < matrix.length && c >= 0 && c < matrix[r].length;
    }
}
