package StickyFingers_02;

import java.util.Scanner;

public class StickyFingers {
    public static int rowDillinger;
    public static int colDillinger;
    public static int totalMoney;
    public static int tempMoney;
    public static boolean goToJail = false;

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int size = Integer.parseInt(scanner.nextLine());
        String[] directions = scanner.nextLine().split(",");
        String[][] matrix = new String[size][];
        fillMatrix(matrix, scanner);

        for (int i = 0; i < directions.length; i++) {
            if (directions[i].equals("down")) {
                move(matrix, rowDillinger + 1, colDillinger);

            } else if (directions[i].equals("up")) {
                move(matrix, rowDillinger - 1, colDillinger);

            } else if (directions[i].equals("left")) {
                move(matrix, rowDillinger, colDillinger - 1);

            } else if (directions[i].equals("right")) {
                move(matrix, rowDillinger, colDillinger + 1);
            }
            if (goToJail) {
                break;
            }
        }
        if (!goToJail) {
            System.out.printf("Your last theft has finished successfully with %d$ in your pocket.\n",totalMoney);
        }

        printMatrix(matrix);
    }

    private static void move(String[][] matrix, int nextRow, int nextCol) {
        if (!isInBounds(matrix, nextRow, nextCol)) {
            matrix[rowDillinger][colDillinger] = "D";
            nextRow = rowDillinger;
            nextCol = colDillinger;
            System.out.println("You cannot leave the town, there is police outside!");

        } else if (matrix[nextRow][nextCol].equals("$")) {
            matrix[nextRow][nextCol] = "D";
            matrix[rowDillinger][colDillinger] = "+";
            tempMoney = nextRow * nextCol;
            totalMoney += tempMoney;
            System.out.printf("You successfully stole %d$.\n", tempMoney);
        } else if (matrix[nextRow][nextCol].equals("P")) {
            System.out.printf("You got caught with %d$, and you are going to jail.\n", totalMoney);
            matrix[nextRow][nextCol] = "#";
            matrix[rowDillinger][colDillinger] = "+";
            goToJail = true;
        } else if (matrix[nextRow][nextCol].equals("+")) {
            matrix[nextRow][nextCol] = "D";
            matrix[rowDillinger][colDillinger] = "+";
        }

        rowDillinger = nextRow;
        colDillinger = nextCol;

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
                if (matrix[r][c].equals("D")) {
                    rowDillinger = r;
                    colDillinger = c;
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

