import java.util.Scanner;

public class FillTheMatrix_01 {
    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);

        String[] input = sc.nextLine().split(", ");

        int size = Integer.parseInt(input[0]);
        String type = input[1];

        int[][] matrix = new int[size][size];

        if (type.equals("A")) {
            fillMatrixA(matrix);
        } else if (type.equals("B")) {
            fillMatrixB(matrix);
        }

        printMatrix(matrix);

    }

    private static void fillMatrixA(int[][] matrix) {
        int num = 1;
        for (int col = 0; col < matrix.length; col++) {
            for (int row = 0; row < matrix.length; row++) {
                matrix[row][col] = num;
                num++;
            }
        }
    }

    private static void fillMatrixB(int[][] matrix) {
        int num = 1;
        for (int col = 0; col < matrix.length; col++) {
            if (col % 2 == 0) {
                for (int row = 0; row < matrix.length; row++) {
                    matrix[row][col] = num;
                    num++;
                }
            } else {
                for (int row = matrix.length - 1; row >= 0; row--) {
                    matrix[row][col] = num;
                    num++;
                }
            }
        }
    }

    private static void printMatrix(int[][] matrix) {
        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrix[row].length; col++) {
                System.out.print(matrix[row][col] + " ");
            }
            System.out.println();
        }
    }
}
