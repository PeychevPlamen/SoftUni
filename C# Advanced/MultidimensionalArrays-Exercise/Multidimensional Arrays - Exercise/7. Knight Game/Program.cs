using System;
using System.Linq;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] chessBoard = new char[size, size];

            fillMatrix(chessBoard);

            int countReplacedKnight = 0;


            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    if (chessBoard[row, col] == 'K')
                    {
                        if (IsInside(chessBoard, row + 1, col + 2))
                        {
                            if (chessBoard[row + 1, col + 2] == 'K')
                            {
                                countReplacedKnight++;

                                chessBoard[row + 1, col + 2] = '0';
                            }
                        }
                        if (IsInside(chessBoard, row + 1, col - 2))
                        {
                            if (chessBoard[row + 1, col - 2] == 'K')
                            {
                                countReplacedKnight++;

                                chessBoard[row + 1, col - 2] = '0';
                            }
                        }
                        if (IsInside(chessBoard, row + 2, col - 1))
                        {
                            if (chessBoard[row + 2, col - 1] == 'K')
                            {
                                countReplacedKnight++;

                                chessBoard[row + 2, col - 1] = '0';
                            }
                        }
                        if (IsInside(chessBoard, row + 2, col + 1))
                        {
                            if (chessBoard[row + 2, col + 1] == 'K')
                            {
                                countReplacedKnight++;

                                chessBoard[row + 2, col + 1] = '0';
                            }
                        }
                        if (IsInside(chessBoard, row - 1, col + 2))
                        {
                            if (chessBoard[row - 1, col + 2] == 'K')
                            {
                                countReplacedKnight++;

                                chessBoard[row - 1, col + 2] = '0';
                            }
                        }
                        if (IsInside(chessBoard, row - 1, col - 2))
                        {
                            if (chessBoard[row - 1, col - 2] == 'K')
                            {
                                countReplacedKnight++;

                                chessBoard[row - 1, col - 2] = '0';
                            }
                        }
                        if (IsInside(chessBoard, row - 2, col - 1))
                        {
                            if (chessBoard[row - 2, col - 1] == 'K')
                            {
                                countReplacedKnight++;

                                chessBoard[row - 2, col - 1] = '0';
                            }
                        }
                        if (IsInside(chessBoard, row - 2, col + 1))
                        {
                            if (chessBoard[row - 2, col + 1] == 'K')
                            {
                                countReplacedKnight++;

                                chessBoard[row - 2, col + 1] = '0';
                            }
                        }
                       
                    }
                }
            }
            Console.WriteLine(countReplacedKnight);

        }
        private static void printMatrix(char[,] chessBoard)
        {
            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    Console.Write(chessBoard[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void fillMatrix(char[,] chessBoard)
        {
            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    chessBoard[row, col] = input[col];
                }
            }
        }
        private static bool IsInside(char[,] chessBoard, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < chessBoard.GetLength(0)
            && targetCol >= 0 && targetCol < chessBoard.GetLength(1);
        }
    }
}
