using System;
using System.Collections.Generic;
using System.Linq;

namespace _02Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            string[] commandsInput = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries);

            int playerOneShips = 0;
            int playerTwoShips = 0;

            fillMatrix(matrix);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] == '<')
                    {
                        playerOneShips++;
                    }
                    if (matrix[i, j] == '>')
                    {
                        playerTwoShips++;
                    }
                }
            }
            int shipsPlayerOne = playerOneShips;
            int shipsPlayerTwo = playerTwoShips;

            int totalSunk = 0;

            for (int i = 0; i < commandsInput.Length; i++)
            {
                string cmd = commandsInput[i];

                int[] playerIndex = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int rowPlayer = playerIndex[0];
                int colPlayer = playerIndex[1];

                if (IsPositionValid(rowPlayer, colPlayer, size, size))
                {
                    if (i % 2 == 0)
                    {
                        if (matrix[rowPlayer, colPlayer] == '>')
                        {
                            totalSunk++;
                            playerTwoShips--;
                            matrix[rowPlayer, colPlayer] = 'X';
                        }
                        if (matrix[rowPlayer, colPlayer] == '#')
                        {
                            PositionValidOne(size, matrix, ref playerOneShips, ref playerTwoShips, ref totalSunk, rowPlayer, colPlayer);
                        }
                    }
                    else
                    {
                        if (matrix[rowPlayer, colPlayer] == '<')
                        {
                            totalSunk++;
                            playerOneShips--;
                            matrix[rowPlayer, colPlayer] = 'X';
                        }
                        if (matrix[rowPlayer, colPlayer] == '#')
                        {
                            PositionValidTwo(size, matrix, ref playerOneShips, ref playerTwoShips, ref totalSunk, rowPlayer, colPlayer);
                        }
                    }

                }
                if (playerOneShips <= 0 && playerTwoShips <= 0)
                {
                    break;
                }

            }

            if (playerOneShips <= 0)
            {
                Console.WriteLine($"Player Two has won the game! {totalSunk} ships have been sunk in the battle.");
            }
            else if (playerTwoShips <= 0)
            {
                Console.WriteLine($"Player One has won the game! {totalSunk} ships have been sunk in the battle.");
            }
            else
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShips} ships left. Player Two has {playerTwoShips} ships left.");
            }

        }

        private static void PositionValidOne(int size, char[,] matrix, ref int playerOneShips, ref int playerTwoShips, ref int totalSunk, int rowPlayer, int colPlayer)
        {
            if (IsPositionValid(rowPlayer - 1, colPlayer, size, size))
            {
                if (matrix[rowPlayer - 1, colPlayer] == '>')
                {
                    totalSunk++;
                    playerTwoShips--;
                    matrix[rowPlayer - 1, colPlayer] = 'X';
                }
                else if (matrix[rowPlayer - 1, colPlayer] == '<')
                {
                    totalSunk++;
                    playerOneShips--;
                    matrix[rowPlayer - 1, colPlayer] = 'X';
                }
            }
            if (IsPositionValid(rowPlayer - 1, colPlayer + 1, size, size))
            {
                if (matrix[rowPlayer - 1, colPlayer + 1] == '>')
                {
                    totalSunk++;
                    playerTwoShips--;
                    matrix[rowPlayer - 1, colPlayer + 1] = 'X';
                }
                else if (matrix[rowPlayer - 1, colPlayer + 1] == '<')
                {
                    totalSunk++;
                    playerOneShips--;
                    matrix[rowPlayer - 1, colPlayer + 1] = 'X';
                }
            }
            if (IsPositionValid(rowPlayer - 1, colPlayer - 1, size, size))
            {
                if (matrix[rowPlayer - 1, colPlayer - 1] == '>')
                {
                    totalSunk++;
                    playerTwoShips--;
                    matrix[rowPlayer - 1, colPlayer - 1] = 'X';
                }
                else if (matrix[rowPlayer - 1, colPlayer - 1] == '<')
                {
                    totalSunk++;
                    playerOneShips--;
                    matrix[rowPlayer - 1, colPlayer - 1] = 'X';
                }
            }
            if (IsPositionValid(rowPlayer + 1, colPlayer, size, size))
            {
                if (matrix[rowPlayer + 1, colPlayer] == '>')
                {
                    totalSunk++;
                    playerTwoShips--;
                    matrix[rowPlayer + 1, colPlayer] = 'X';
                }
                else if (matrix[rowPlayer + 1, colPlayer] == '<')
                {
                    totalSunk++;
                    playerOneShips--;
                    matrix[rowPlayer + 1, colPlayer] = 'X';
                }
            }
            if (IsPositionValid(rowPlayer + 1, colPlayer + 1, size, size))
            {
                if (matrix[rowPlayer + 1, colPlayer + 1] == '>')
                {
                    totalSunk++;
                    playerTwoShips--;
                    matrix[rowPlayer + 1, colPlayer + 1] = 'X';
                }
                else if (matrix[rowPlayer + 1, colPlayer + 1] == '<')
                {
                    totalSunk++;
                    playerOneShips--;
                    matrix[rowPlayer + 1, colPlayer + 1] = 'X';
                }
            }
            if (IsPositionValid(rowPlayer + 1, colPlayer - 1, size, size))
            {
                if (matrix[rowPlayer + 1, colPlayer - 1] == '>')
                {
                    totalSunk++;
                    playerTwoShips--;
                    matrix[rowPlayer + 1, colPlayer - 1] = 'X';
                }
                else if (matrix[rowPlayer + 1, colPlayer - 1] == '<')
                {
                    totalSunk++;
                    playerOneShips--;
                    matrix[rowPlayer + 1, colPlayer - 1] = 'X';
                }
            }
            if (IsPositionValid(rowPlayer, colPlayer - 1, size, size))
            {
                if (matrix[rowPlayer, colPlayer - 1] == '>')
                {
                    totalSunk++;
                    playerTwoShips--;
                    matrix[rowPlayer, colPlayer - 1] = 'X';
                }
                else if (matrix[rowPlayer, colPlayer - 1] == '<')
                {
                    totalSunk++;
                    playerOneShips--;
                    matrix[rowPlayer, colPlayer - 1] = 'X';
                }
            }
            if (IsPositionValid(rowPlayer, colPlayer + 1, size, size))
            {
                if (matrix[rowPlayer, colPlayer + 1] == '>')
                {
                    totalSunk++;
                    playerTwoShips--;
                    matrix[rowPlayer, colPlayer + 1] = 'X';
                }
                else if (matrix[rowPlayer, colPlayer + 1] == '<')
                {
                    totalSunk++;
                    playerOneShips--;
                    matrix[rowPlayer, colPlayer + 1] = 'X';
                }

            }
        }

        private static void PositionValidTwo(int size, char[,] matrix, ref int playerOneShips, ref int playerTwoShips, ref int totalSunk, int rowPlayer, int colPlayer)
        {
            if (IsPositionValid(rowPlayer - 1, colPlayer, size, size))
            {
                if (matrix[rowPlayer - 1, colPlayer] == '>')
                {
                    totalSunk++;
                    playerTwoShips--;
                    matrix[rowPlayer - 1, colPlayer] = 'X';
                }
                else if (matrix[rowPlayer - 1, colPlayer] == '<')
                {
                    totalSunk++;
                    playerOneShips--;
                    matrix[rowPlayer - 1, colPlayer] = 'X';
                }
            }
            if (IsPositionValid(rowPlayer - 1, colPlayer + 1, size, size))
            {
                if (matrix[rowPlayer - 1, colPlayer + 1] == '>')
                {
                    totalSunk++;
                    playerTwoShips--;
                    matrix[rowPlayer - 1, colPlayer + 1] = 'X';
                }
                else if (matrix[rowPlayer - 1, colPlayer + 1] == '<')
                {
                    totalSunk++;
                    playerOneShips--;
                    matrix[rowPlayer - 1, colPlayer + 1] = 'X';
                }
            }
            if (IsPositionValid(rowPlayer - 1, colPlayer - 1, size, size))
            {
                if (matrix[rowPlayer - 1, colPlayer - 1] == '>')
                {
                    totalSunk++;
                    playerTwoShips--;
                    matrix[rowPlayer - 1, colPlayer - 1] = 'X';
                }
                else if (matrix[rowPlayer - 1, colPlayer - 1] == '<')
                {
                    totalSunk++;
                    playerOneShips--;
                    matrix[rowPlayer - 1, colPlayer - 1] = 'X';
                }
            }
            if (IsPositionValid(rowPlayer + 1, colPlayer, size, size))
            {
                if (matrix[rowPlayer + 1, colPlayer] == '>')
                {
                    totalSunk++;
                    playerTwoShips--;
                    matrix[rowPlayer + 1, colPlayer] = 'X';
                }
                else if (matrix[rowPlayer + 1, colPlayer] == '<')
                {
                    totalSunk++;
                    playerOneShips--;
                    matrix[rowPlayer + 1, colPlayer] = 'X';
                }
            }
            if (IsPositionValid(rowPlayer + 1, colPlayer + 1, size, size))
            {
                if (matrix[rowPlayer + 1, colPlayer + 1] == '>')
                {
                    totalSunk++;
                    playerTwoShips--;
                    matrix[rowPlayer + 1, colPlayer + 1] = 'X';
                }
                else if (matrix[rowPlayer + 1, colPlayer + 1] == '<')
                {
                    totalSunk++;
                    playerOneShips--;
                    matrix[rowPlayer + 1, colPlayer + 1] = 'X';
                }
            }
            if (IsPositionValid(rowPlayer + 1, colPlayer - 1, size, size))
            {
                if (matrix[rowPlayer + 1, colPlayer - 1] == '>')
                {
                    totalSunk++;
                    playerTwoShips--;
                    matrix[rowPlayer + 1, colPlayer - 1] = 'X';
                }
                else if (matrix[rowPlayer + 1, colPlayer - 1] == '<')
                {
                    totalSunk++;
                    playerOneShips--;
                    matrix[rowPlayer + 1, colPlayer - 1] = 'X';
                }
            }
            if (IsPositionValid(rowPlayer, colPlayer - 1, size, size))
            {
                if (matrix[rowPlayer, colPlayer - 1] == '>')
                {
                    totalSunk++;
                    playerTwoShips--;
                    matrix[rowPlayer, colPlayer - 1] = 'X';
                }
                else if (matrix[rowPlayer, colPlayer - 1] == '<')
                {
                    totalSunk++;
                    playerOneShips--;
                    matrix[rowPlayer, colPlayer - 1] = 'X';
                }
            }
            if (IsPositionValid(rowPlayer, colPlayer + 1, size, size))
            {
                if (matrix[rowPlayer, colPlayer + 1] == '>')
                {
                    totalSunk++;
                    playerTwoShips--;
                    matrix[rowPlayer, colPlayer + 1] = 'X';
                }
                else if (matrix[rowPlayer, colPlayer + 1] == '<')
                {
                    totalSunk++;
                    playerOneShips--;
                    matrix[rowPlayer, colPlayer + 1] = 'X';
                }

            }
        }

        // fillMatrix char
        private static void fillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }

        public static bool IsPositionValid(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            if (col < 0 || col >= cols)
            {
                return false;
            }

            return true;
        }
    }
}
