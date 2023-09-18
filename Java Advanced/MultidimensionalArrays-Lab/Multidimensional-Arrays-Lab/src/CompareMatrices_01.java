import java.util.Arrays;
import java.util.Scanner;

public class CompareMatrices_01 {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int[] dimensions = getArr(scanner, "\\s++");

        int matrixOneRows = dimensions[0];
        int matrixOneCols = dimensions[1];

        int[][] matrixOne = new int[matrixOneRows][matrixOneCols];

        readMatrix(matrixOneRows, scanner, matrixOne);

        dimensions = getArr(scanner, "\\s++");

        int matrixTwoRows = dimensions[0];
        int matrixTwoCols = dimensions[1];

        int[][] matrixTwo = new int[matrixTwoRows][matrixTwoCols];

        readMatrix(matrixOneRows, scanner, matrixTwo);

        if (matricesAreEqual(matrixOne, matrixTwo)) {
            System.out.println("equal");
        } else {
            System.out.println("not equal");
        }
    }

    private static void readMatrix(int matrixOneRows, Scanner scanner, int[][] matrixOne) {
        for (int i = 0; i < matrixOneRows; i++) {
            int[] arr = getArr(scanner, "\\s+");

            matrixOne[i] = arr;
        }
    }

    private static int[] getArr(Scanner scanner, String regex) {
        int[] arr = Arrays.stream(scanner.nextLine().split(regex))
                .mapToInt(Integer::parseInt)
                .toArray();
        return arr;
    }

    private static boolean matricesAreEqual(int[][] matrixOne, int[][] matrixTwo) {
        if (matrixOne.length != matrixTwo.length) {
            return false;
        }
        for (int row = 0; row < matrixOne.length; row++) {
            if (matrixOne[row].length != matrixTwo[row].length) {
                return false;
            }
            for (int col = 0; col < matrixOne[row].length; col++) {
                if (matrixOne[row][col] != matrixTwo[row][col]) {
                    return false;
                }
            }
        }
        return true;
    }
}
