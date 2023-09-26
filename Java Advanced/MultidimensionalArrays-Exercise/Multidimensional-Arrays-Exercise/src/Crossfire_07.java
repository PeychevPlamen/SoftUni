import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

public class Crossfire_07 {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String[] size = scanner.nextLine().split("\\s+");
        int rows = Integer.parseInt(size[0]);
        int cols = Integer.parseInt(size[1]);

        List<List<Integer>> matrix = new ArrayList<>();

        fillMatrix(matrix, rows, cols);

        String input = scanner.nextLine();


        while (!input.equals("Nuke it from orbit")) {
            int[] target = Arrays.stream(input.split("\\s+"))
                    .mapToInt(Integer::parseInt)
                    .toArray();

            int targetRow = target[0];
            int targetCol = target[1];
            int radius = target[2];

            // destroying along the rows by the given radius
            for (int row = targetRow - radius; row <= targetRow + radius; row++) {
                if (isInside(matrix, row, targetCol)) {
                    matrix.get(row).set(targetCol, 0);
                }
            }
            for (int col = targetCol - radius; col <= targetCol + radius; col++) {
                if (isInside(matrix, targetRow, col)) {
                    matrix.get(targetRow).set(col, 0);
                }
            }

            ArrayList<Integer> toRemove = new ArrayList<>();
            toRemove.add(0);

            for (int row = 0; row < matrix.size(); row++) {
                // by removing all zeros on the row all remaining elements are shifted to the left
                matrix.get(row).removeAll(toRemove);
                // remove the row if there are no elements on it
                if (matrix.get(row).isEmpty()) {
                    matrix.remove(row);
                    row--;
                }
            }

            input = scanner.nextLine();
        }
        printMatrix(matrix);
    }

    private static boolean isInside(List<List<Integer>> matrix, int row, int col) {
        return row >= 0 && row < matrix.size() && col >= 0 && col < matrix.get(row).size();
    }

    private static void fillMatrix(List<List<Integer>> matrix, int rows, int cols) {
        int count = 1;
        for (int row = 0; row < rows; row++) {
            List<Integer> rowList = new ArrayList<>();
            for (int col = 0; col < cols; col++) {
                rowList.add(count++);
            }
            matrix.add(rowList);
        }
    }
    private static void printMatrix(List<List<Integer>> matrix) {
        for (List<Integer> row : matrix) {
            row.forEach(e -> System.out.print(e + " "));
            System.out.println();
        }
    }
}
