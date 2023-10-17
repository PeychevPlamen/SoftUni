package PresentDelivery_02;

import java.util.Arrays;
import java.util.Scanner;

public class PresentDelivery {
    public static int rowSanta;
    public static int colSanta;
    public static int happyKids;
    public static int niceKidsNoPresent;
    public static int countOfPresents;

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        countOfPresents = Integer.parseInt(scanner.nextLine());
        int matrixSize = Integer.parseInt(scanner.nextLine());

        String[][] matrix = new String[matrixSize][];
        fillMatrix(matrix, scanner);


        while (countOfPresents != 0 && niceKidsNoPresent != 0) {
            String direction = scanner.nextLine();
            if (direction.equals("Christmas morning")) {
                break;
            }
            if (direction.equals("down")) {
                move(matrix, rowSanta + 1, colSanta);

            } else if (direction.equals("up")) {
                move(matrix, rowSanta - 1, colSanta);

            } else if (direction.equals("left")) {
                move(matrix, rowSanta, colSanta - 1);

            } else {
                move(matrix, rowSanta, colSanta + 1);

            }

        }

        if (countOfPresents == 0) {
            System.out.println("Santa ran out of presents!");
        }
        printMatrix(matrix);
        if (niceKidsNoPresent == 0) {
            System.out.printf("Good job, Santa! %d happy nice kid/s.", happyKids);
        } else {
            System.out.printf("No presents for %d nice kid/s.", niceKidsNoPresent);
        }

    }

    private static void move(String[][] matrix, int nextRow, int nextCol) {

        if (matrix[nextRow][nextCol].equals("V")) {
            happyKids++;
            niceKidsNoPresent--;
            countOfPresents--;
            matrix[nextRow][nextCol] = "S";
        } else if (matrix[nextRow][nextCol].equals("X")) {
            matrix[nextRow][nextCol] = "S";
        } else if (matrix[nextRow][nextCol].equals("-")) {
            matrix[nextRow][nextCol] = "S";
        } else if (matrix[nextRow][nextCol].equals("C")) {
            if (matrix[nextRow + 1][nextCol].equals("X")) {
                if (countOfPresents > 0){
                    countOfPresents--;
                }

                matrix[nextRow + 1][nextCol] = "-";
            }
            if (matrix[nextRow - 1][nextCol].equals("X")) {
                if (countOfPresents > 0){
                    countOfPresents--;
                }
                matrix[nextRow - 1][nextCol] = "-";
            }
            if (matrix[nextRow][nextCol + 1].equals("X")) {
                if (countOfPresents > 0){
                    countOfPresents--;
                }
                matrix[nextRow][nextCol + 1] = "-";
            }
            if (matrix[nextRow][nextCol - 1].equals("X")) {
                if (countOfPresents > 0){
                    countOfPresents--;
                }
                matrix[nextRow][nextCol - 1] = "-";
            }
            if (matrix[nextRow + 1][nextCol].equals("V")) {
                countOfPresents--;
                if (niceKidsNoPresent > 0 ){
                    happyKids++;
                    niceKidsNoPresent--;
                }
                matrix[nextRow + 1][nextCol] = "-";
            }
            if (matrix[nextRow - 1][nextCol].equals("V")) {
                countOfPresents--;
                if (niceKidsNoPresent > 0 ){
                    happyKids++;
                    niceKidsNoPresent--;
                }
                matrix[nextRow - 1][nextCol] = "-";
            }
            if (matrix[nextRow][nextCol + 1].equals("V")) {
                countOfPresents--;
                if (niceKidsNoPresent > 0 ){
                    happyKids++;
                    niceKidsNoPresent--;
                }

                matrix[nextRow][nextCol + 1] = "-";
            }
            if (matrix[nextRow][nextCol - 1].equals("V")) {
                countOfPresents--;
                if (niceKidsNoPresent > 0 ){
                    happyKids++;
                    niceKidsNoPresent--;
                }
                matrix[nextRow][nextCol - 1] = "-";
            }
        }
        matrix[nextRow][nextCol] = "S";
        matrix[rowSanta][colSanta] = "-";
        rowSanta = nextRow;
        colSanta = nextCol;

    }

    private static void fillMatrix(String[][] matrix, Scanner scanner) {
        for (int row = 0; row < matrix.length; row++) {
            matrix[row] = scanner.nextLine().split("\\s+");
        }
        for (int r = 0; r < matrix.length; r++) {
            for (int c = 0; c < matrix[r].length; c++) {
                if (matrix[r][c].equals("S")) {
                    rowSanta = r;
                    colSanta = c;
                }
            }
        }
        niceKids(matrix);
    }

    private static int niceKids(String[][] matrix) {

        for (int r = 0; r < matrix.length; r++) {
            for (int c = 0; c < matrix[r].length; c++) {
                if (matrix[r][c].equals("V")) {
                    niceKidsNoPresent++;
                }
            }
        }
        return niceKidsNoPresent;
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
