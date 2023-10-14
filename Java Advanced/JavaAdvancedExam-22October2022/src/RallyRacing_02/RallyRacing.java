package RallyRacing_02;

import java.util.Scanner;

public class RallyRacing {
    private static int kmPassed = 0;
    private static boolean isFinished = false;
    private static int firstTRow;
    private static int firstTCol;
    private static int secondTRow = 0;
    private static int secondTCol = 0;
    private static int startRow = 0;
    private static int startCol = 0;

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);
        int matrixSize = Integer.parseInt(scanner.nextLine());
        String car = scanner.nextLine();

        String[][] matrix = new String[matrixSize][matrixSize];
        fillMatrix(matrix, scanner);

        String command = scanner.nextLine();

        while (!command.equals("End")) {
            if (isFinished) {
                break;
            }
            if (command.equals("left")) {
                move(matrix, startRow, startCol - 1);
            } else if (command.equals("right")) {
                move(matrix, startRow, startCol + 1);
            } else if (command.equals("up")) {
                move(matrix, startRow - 1, startCol);
            } else {
                move(matrix, startRow + 1, startCol);
            }

            command = scanner.nextLine();
        }
        if (isFinished) {
            System.out.printf("Racing car %s finished the stage!%n", car);
        } else {
            System.out.printf("Racing car %s DNF.%n", car);
        }
        System.out.printf("Distance covered %d km.%n", kmPassed);
        printMatrix(matrix);
    }

    private static void move(String[][] matrix, int nextRow, int nextCol) {

        if (matrix[nextRow][nextCol].equals(".")) {
            matrix[nextRow][nextCol] = "C";
            matrix[startRow][startCol] = ".";
            kmPassed += 10;

        } else if (matrix[nextRow][nextCol].equals("F")) {
            matrix[nextRow][nextCol] = "C";
            matrix[startRow][startCol] = ".";
            kmPassed += 10;
            isFinished = true;
            return;

        } else if (matrix[nextRow][nextCol].equals("T")) {
            matrix[startRow][startCol] = ".";
            matrix[nextRow][nextCol] = ".";
            for (int r = 0; r < matrix.length; r++) {
                for (int c = 0; c < matrix[r].length; c++) {
                    if (matrix[r][c].equals("T")) {
                        secondTRow = r;
                        secondTCol = c;
                    }
                }
            }

            nextRow = secondTRow;
            nextCol = secondTCol;
            matrix[nextRow][nextCol] = ".";
            kmPassed += 30;
        }

        startRow = nextRow;
        startCol = nextCol;

    }

    private static void fillMatrix(String[][] matrix, Scanner scanner) {
        for (int row = 0; row < matrix.length; row++) {
            String[] line = scanner.nextLine().split("\\s+");
            matrix[row] = line;
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

}
