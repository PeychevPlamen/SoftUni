package ThroneConquering_02;

import java.util.Scanner;

public class ThroneConquering {
    public static int rowParis;
    public static int colParis;
    public static int parisEnergy;
    public static boolean isDead = false;
    public static boolean isReachHelen = false;

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        parisEnergy = Integer.parseInt(scanner.nextLine());
        int rowsSize = Integer.parseInt(scanner.nextLine());
        char[][] matrix = new char[rowsSize][];

        fillMatrix(matrix, scanner);

        while (!isDead && !isReachHelen) {
            String[] line = scanner.nextLine().split("\\s+");
            String direction = line[0];
            int rowSpawn = Integer.parseInt(line[1]);
            int colSpawn = Integer.parseInt(line[2]);
            matrix[rowSpawn][colSpawn] = 'S';

            if (direction.equals("down")) {
                move(matrix, rowParis + 1, colParis);

            } else if (direction.equals("up")) {
                move(matrix, rowParis - 1, colParis);

            } else if (direction.equals("left")) {
                move(matrix, rowParis, colParis - 1);

            } else {
                move(matrix, rowParis, colParis + 1);
            }

        }

        if (isDead) {
            System.out.printf("Paris died at %d;%d.\n", rowParis, colParis);
        } else {
            System.out.printf("Paris has successfully abducted Helen! Energy left: %d\n", parisEnergy);
        }
        printMatrix(matrix);

    }

    private static void move(char[][] matrix, int nextRow, int nextCol) {
        parisEnergy--;
        if (!isInBounds(matrix, nextRow, nextCol)) {
            matrix[rowParis][colParis] = 'P';
            nextRow = rowParis;
            nextCol = colParis;

        } else if (matrix[nextRow][nextCol] == 'S') {
            if (parisEnergy > 2) {
                matrix[nextRow][nextCol] = 'P';
                matrix[rowParis][colParis] = '-';
            } else {
                isDead = true;
            }
            parisEnergy -= 2;
        } else if (matrix[nextRow][nextCol] == '-') {
            matrix[nextRow][nextCol] = 'P';
            matrix[rowParis][colParis] = '-';
        }
        if (parisEnergy <= 0) {
            matrix[nextRow][nextCol] = 'X';
            matrix[rowParis][colParis] = '-';
            isDead = true;
        } else {
            if (matrix[nextRow][nextCol] == 'H') {
                matrix[nextRow][nextCol] = '-';
                matrix[rowParis][colParis] = '-';
                isReachHelen = true;
            }
        }
        rowParis = nextRow;
        colParis = nextCol;

    }

    private static void fillMatrix(char[][] matrix, Scanner scanner) {
        for (int row = 0; row < matrix.length; row++) {
            String line = scanner.nextLine();
            matrix[row] = line.toCharArray();

            int indexParis = line.indexOf('P');

            if (indexParis != -1) {
                rowParis = row;
                colParis = indexParis;
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
