import java.util.Arrays;
import java.util.Scanner;

public class DiagonalDifference_03 {
    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);

        int matrixSize = Integer.parseInt(sc.nextLine());
        int[][] matrix = new int[matrixSize][];

        fillMatrix(matrix, sc);

        int result = Math.abs(primaryDiagonalSum(matrix) - secondaryDiagonalSum(matrix));

        System.out.println(result);
    }

    private static int primaryDiagonalSum(int[][] matrix) {
        int sumPrimary = 0;
        for (int i = 0; i < matrix.length; i++) {
            sumPrimary += matrix[i][i];
        }

        return sumPrimary;
    }

    private static int secondaryDiagonalSum(int[][] matrix) {
        int sumSecondary = 0;
        for (int i = 0; i < matrix.length; i++) {
            sumSecondary += matrix[matrix.length - 1 - i][i];
        }

        return sumSecondary;
    }

    private static void fillMatrix(int[][] matrix, Scanner scanner) {
        for (int row = 0; row < matrix.length; row++) {
            int[] line = Arrays.stream(scanner.nextLine().split("\\s+"))
                    .mapToInt(Integer::parseInt)
                    .toArray();

            matrix[row] = line;
        }
    }
}
