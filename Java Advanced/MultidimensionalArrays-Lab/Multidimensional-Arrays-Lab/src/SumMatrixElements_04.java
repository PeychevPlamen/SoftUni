import java.util.Arrays;
import java.util.Scanner;

public class SumMatrixElements_04 {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int[] sizeMatrix = Arrays.stream(scanner.nextLine().split(", "))
                .mapToInt(Integer::parseInt)
                .toArray();
        int rows = sizeMatrix[0];
        int cols = sizeMatrix[1];

        int[][] matrix = new int[rows][cols];

        System.out.println(rows);
        System.out.println(cols);

        fillMatrix(matrix, scanner);

        int sum = 0;

        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {
                sum+= matrix[row][col];
            }
        }
        System.out.println(sum);

    }

    private static void fillMatrix(int[][] matrix, Scanner scanner) {
        for (int row = 0; row < matrix.length; row++) {
            int[] line = Arrays.stream(scanner.nextLine().split(", "))
                    .mapToInt(Integer::parseInt)
                    .toArray();

            matrix[row] = line;
        }
    }

    private static void printMatrix(int[][] matrix) {
        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {
                System.out.print(matrix[row][col]);
            }
            System.out.println();
        }
    }
}
