
import java.util.Scanner;

public class MatrixShuffling_05 {

    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);

        String[] matrixSize = sc.nextLine().split("\\s+");
        int rows = Integer.parseInt(matrixSize[0]);
        int cols = Integer.parseInt(matrixSize[1]);

        String[][] matrix = new String[rows][cols];

        fillMatrix(matrix, sc);

        String input = sc.nextLine();

        while (!"END".equals(input)) {
            String tempNum = " ";
            String[] tokens = input.split("\\s+");
            String command = tokens[0];
            if ("swap".equals(command) && tokens.length == 5) {
                int row1 = Integer.parseInt(tokens[1]);
                int col1 = Integer.parseInt(tokens[2]);
                int row2 = Integer.parseInt(tokens[3]);
                int col2 = Integer.parseInt(tokens[4]);

                if (row1 <= rows && row2 <= rows && col1 <= cols && col2 <= cols) {
                    tempNum = matrix[row1][col1];
                    matrix[row1][col1] = matrix[row2][col2];
                    matrix[row2][col2] = tempNum;

                    printMatrix(matrix);

                } else {
                    System.out.println("Invalid input!");
                }


            } else {
                System.out.println("Invalid input!");
            }

            input = sc.nextLine();
        }
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
                System.out.print(matrix[row][col] + " ");
            }
            System.out.println();
        }
    }
}
