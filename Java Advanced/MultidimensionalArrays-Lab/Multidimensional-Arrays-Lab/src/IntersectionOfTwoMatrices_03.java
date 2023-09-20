import java.util.Scanner;

public class IntersectionOfTwoMatrices_03 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int rows = Integer.parseInt(scanner.nextLine());
        int cols = Integer.parseInt(scanner.nextLine());

        char[][] matrixA = new char[rows][cols];
        char[][] matrixB = new char[rows][cols];
        fillMatrix(matrixA, scanner);
        fillMatrix(matrixB, scanner);

        for (int row = 0; row < matrixA.length; row++) {
            for (int col = 0; col < matrixA[row].length; col++) {
                char outputSymbol = '*';
                if (matrixA[row][col] == matrixB[row][col]) {
                    outputSymbol = matrixA[row][col];
                }
                System.out.print(outputSymbol);
            }
            System.out.println();
        }

    }

    private static void fillMatrix(char[][] matrix, Scanner scanner) {
        for (int row = 0; row < matrix.length; row++) {
            String line = scanner.nextLine();
            matrix[row] = line.toCharArray();
        }
    }

//    private static void printMatrix(char[][] matrix) {
//        for (int row = 0; row < matrix.length; row++) {
//            for (int col = 0; col < matrix[row].length; col++) {
//                System.out.print(matrix[row][col]);
//            }
//            System.out.println();
//        }
//    }
}
