using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] board_A;
            const int COLUMNS = 25;
            const int ROWS = 80;
            board_A = SetupBoard(COLUMNS, ROWS);
            Random r = new Random();

            for (int i = 0; i < 500; i++)
            {
                board_A[(r.Next(0, 24)), (r.Next(0, 79))] = 1;
            }

            while (true)
            {
                Console.Clear();
                DrawBoard(board_A);
                board_A = BoardLogic(board_A);
                Thread.Sleep(750);
            }
        }

        static int[,] SetupBoard(int rows, int cols)
        {
            int[,] board = new int[rows, cols];
            return board;
        }

        static void DrawBoard(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 1)
                    {
                        Console.Write(" *");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }

        static int[,] BoardLogic(int[,] board_A)
        {
            int[,] board_B = new int[board_A.GetLength(0), board_A.GetLength(1)];
            for (int i = 0; i < board_A.GetLength(0); i++)
            {
                for (int j = 0; j < board_A.GetLength(1); j++)
                {
                    if (board_A[i, j] == 1)
                    {
                        if (HowManyFriends(i, j, board_A) == 2 || HowManyFriends(i, j, board_A) == 3)
                        {
                            board_B[i, j] = 1;
                        }
                        else
                        {
                            board_B[i, j] = 0;
                        }
                    }
                    else if (board_A[i, j] == 0)
                    {
                        if (HowManyFriends(i, j, board_A) == 3)
                        {
                            board_B[i, j] = 1;
                        }
                        else
                        {
                            board_B[i, j] = 0;
                        }
                    }
                }
            }
            return board_B;
        }

        static int HowManyFriends(int x, int y, int[,] board_A)
        {
            int number_of_friends = 0;

            if (x != 0 && y != 0 && ((board_A[x - 1, y - 1]) == 1))
            {
                number_of_friends++;
            }
            if (x != 0 && (board_A[x - 1, y]) == 1)
            {
                number_of_friends++;
            }
            if (x != 0 && (y < (board_A.GetLength(1) - 1) && (board_A[x - 1, y + 1]) == 1))
            {
                number_of_friends++;
            }
            if (y != 0 && (board_A[x, y - 1]) == 1)
            {
                number_of_friends++;
            }
            if ((y < (board_A.GetLength(1) - 1)) && ((board_A[x, y + 1]) == 1))
            {
                number_of_friends++;
            }
            if (x < (board_A.GetLength(0) - 1) && y != 0 && (board_A[x + 1, y - 1]) == 1)
            {
                number_of_friends++;
            }
            if (x < (board_A.GetLength(0) - 1) && (board_A[x + 1, y]) == 1)
            {
                number_of_friends++;
            }
            if (x < (board_A.GetLength(0) - 1) && (y < (board_A.GetLength(1) - 1)) && (board_A[x + 1, y + 1]) == 1)
            {
                number_of_friends++;
            }
            return number_of_friends;
        }
    }
}

