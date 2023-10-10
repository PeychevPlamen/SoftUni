package FillPrintMatrix;

import java.util.Arrays;
import java.util.Scanner;

public class StringMatrix {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int[] dimensions = Arrays.stream(sc.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .toArray();

        int rows = dimensions[0];
        int cols = dimensions[1];

        String[][] matrix = new String[rows][cols];

        fillMatrix(matrix);
        printMatrix(matrix);

    }
    private static void fillMatrix(String[][] matrix) {
        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {

                char outsideSymbol = (char) ('a' + row);
                char midSymbol = (char) (outsideSymbol + col);

                matrix[row][col] = String.valueOf(new char[]{outsideSymbol, midSymbol, outsideSymbol});
            }
        }
    }

    private static void fillStringMatrix(String[][] matrix, Scanner scanner) {
        for (int row = 0; row < matrix.length; row++) {
           String[] input = scanner.nextLine().split("\\s+");
           matrix[row] = input;
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
