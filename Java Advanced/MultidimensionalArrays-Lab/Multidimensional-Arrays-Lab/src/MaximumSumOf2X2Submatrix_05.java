import java.util.Arrays;
import java.util.Scanner;

public class MaximumSumOf2X2Submatrix_05 {

    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);

        int[] sizeMatrix = Arrays.stream(sc.nextLine().split(", "))
                .mapToInt(Integer::parseInt)
                .toArray();
        int rows = sizeMatrix[0];
        int cols = sizeMatrix[1];

        int[][] matrix = new int[rows][cols];

        fillMatrix(matrix, sc);

        int rowIndex = 0;
        int colIndex = 0;

        int maxSum = Integer.MIN_VALUE;

        for (int row = 0; row < matrix.length - 1; row++) {
            for (int col = 0; col < matrix[row].length - 1; col++) {
                int sum = matrix[row][col] + matrix[row + 1][col] + matrix[row][col + 1] + matrix[row + 1][col + 1];
                if (sum > maxSum) {
                    maxSum = sum;
                    rowIndex = row;
                    colIndex = col;
                }
            }
        }

        printMatrix(matrix, rowIndex, colIndex);
        System.out.println(maxSum);
    }

    private static void fillMatrix(int[][] matrix, Scanner scanner) {
        for (int row = 0; row < matrix.length; row++) {
            int[] line = Arrays.stream(scanner.nextLine().split(", "))
                    .mapToInt(Integer::parseInt)
                    .toArray();

            matrix[row] = line;
        }
    }

    private static void printMatrix(int[][] matrix, int rowIndex, int colIndex) {
        for (int row = rowIndex; row <= rowIndex + 1; row++) {
            for (int col = colIndex; col <= colIndex + 1; col++) {
                System.out.print(matrix[row][col] + " ");
            }
            System.out.println();
        }
    }
}
