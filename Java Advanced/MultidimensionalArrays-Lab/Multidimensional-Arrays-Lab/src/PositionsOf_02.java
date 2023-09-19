import java.util.Arrays;
import java.util.Scanner;

public class PositionsOf_02 {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int[] sizeMatrix = Arrays.stream(scanner.nextLine().split("\\s+"))
                .mapToInt(Integer::parseInt)
                .toArray();
        int rows = sizeMatrix[0];
        int cols = sizeMatrix[1];

        int[][] matrix = new int[rows][cols];
        fillMatrix(matrix, scanner);

        int num = Integer.parseInt(scanner.nextLine());
        findIndexes(matrix, num);

    }

    private static void fillMatrix(int[][] matrix, Scanner scanner) {
        for (int row = 0; row < matrix.length; row++) {
            matrix[row] = Arrays.stream(scanner.nextLine().split("\\s+"))
                    .mapToInt(Integer::parseInt)
                    .toArray();
        }
    }

    private static void findIndexes(int[][] matrix, int num) {
        boolean notFInd = true;
        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {

                if (matrix[row][col] == num) {
                    System.out.println(row + " " + col);
                    notFInd = false;
                }
            }
        }
        if (notFInd) {
            System.out.println("not found");
        }
    }
}
