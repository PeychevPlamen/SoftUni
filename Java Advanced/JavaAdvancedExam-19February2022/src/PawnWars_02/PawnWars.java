package PawnWars_02;

import java.util.Scanner;

public class PawnWars {
    public static int whiteRow;
    public static int whiteCol;
    public static int blackRow;
    public static int blackCol;

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        char[][] chessBoard = new char[8][8];
        fillMatrix(chessBoard, scanner);
        int whiteRowTemp = 0;
        int blackRowTemp = 0;

        boolean isWhiteCaptured = false;
        boolean isBlackCaptured = false;
        boolean isWhiteQueen = false;
        boolean isBlackQueen = false;

        while (true) {
            if (isInBounds(chessBoard, whiteRow - 1, whiteCol - 1)) {
                if (chessBoard[whiteRow - 1][whiteCol - 1] == 'b') {
                    chessBoard[whiteRow - 1][whiteCol - 1] = 'w';
                    chessBoard[whiteRow][whiteCol] = '-';
                    isBlackCaptured = true;
                    whiteRow = whiteRow - 1;
                    whiteCol = whiteCol - 1;
                    break;
                }
            }
            if (isInBounds(chessBoard, whiteRow - 1, whiteCol + 1)) {
                if (chessBoard[whiteRow - 1][whiteCol + 1] == 'b') {
                    chessBoard[whiteRow - 1][whiteCol + 1] = 'w';
                    chessBoard[whiteRow][whiteCol] = '-';
                    isBlackCaptured = true;
                    whiteRow = whiteRow - 1;
                    whiteCol = whiteCol + 1;
                    break;
                }
            }
            whiteRowTemp = whiteRow;
            whiteRow--;
            chessBoard[whiteRow][whiteCol] = 'w';
            chessBoard[whiteRowTemp][whiteCol] = '-';

            if (chessBoard[whiteRow][whiteCol] == chessBoard[0][whiteCol]) {
                isWhiteQueen = true;
                break;
            }

            if (isInBounds(chessBoard, blackRow + 1, blackCol + 1)) {
                if (chessBoard[blackRow + 1][blackCol + 1] == 'w') {
                    chessBoard[blackRow + 1][blackCol + 1] = 'b';
                    chessBoard[blackRow][blackCol] = '-';
                    isWhiteCaptured = true;
                    blackRow = blackRow + 1;
                    blackCol = blackCol + 1;
                    break;
                }
            }
            if (isInBounds(chessBoard, blackRow + 1, blackCol - 1)) {
                if (chessBoard[blackRow + 1][blackCol - 1] == 'w') {
                    chessBoard[blackRow + 1][blackCol - 1] = 'b';
                    chessBoard[blackRow][blackCol] = '-';
                    isWhiteCaptured = true;
                    blackRow = blackRow + 1;
                    blackCol = blackCol - 1;
                    break;
                }
            }
            blackRowTemp = blackRow;
            blackRow++;
            chessBoard[blackRow][blackCol] = 'b';
            chessBoard[blackRowTemp][blackCol] = '-';

            if (chessBoard[blackRow][blackCol] == chessBoard[7][blackCol]) {
                isBlackQueen = true;
                break;
            }

        }
        int wRow = 8 - whiteRow;
        char wCol = (char) ('a' + whiteCol);
        int bRow = 8 - blackRow;
        char bCol = (char) ('a' + blackCol);

        if (isWhiteCaptured) {
            System.out.printf("Game over! Black capture on %c%d.", bCol, bRow);
        } else if (isBlackCaptured) {
            System.out.printf("Game over! White capture on %c%d.", wCol, wRow);
        } else if (isWhiteQueen) {
            System.out.printf("Game over! White pawn is promoted to a queen at %c%d.", wCol, wRow);
        } else if (isBlackQueen) {
            System.out.printf("Game over! Black pawn is promoted to a queen at %c%d.", bCol, bRow);
        }
    }

    private static void fillMatrix(char[][] matrix, Scanner scanner) {
        for (int row = 0; row < matrix.length; row++) {
            String line = scanner.nextLine();
            matrix[row] = line.toCharArray();

            int indexWhite = line.indexOf('w');

            if (indexWhite != -1) {
                whiteRow = row;
                whiteCol = indexWhite;
            }
            int indexBlack = line.indexOf('b');

            if (indexBlack != -1) {
                blackRow = row;
                blackCol = indexBlack;
            }
        }
    }

    private static boolean isInBounds(char[][] matrix, int r, int c) {
        return r >= 0 && r < matrix.length && c >= 0 && c < matrix[r].length;
    }
}
