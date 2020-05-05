using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            updateBoard u = new updateBoard();
            char done;
            int i, j, input;

            char[,] board = new char[9, 9];
            char[] arr;
            string str;
            char decision;

            do
            {
                Console.Clear();

                for (i = 0; i < 9; i++)
                {
                    str = Console.ReadLine();
                    arr = str.ToCharArray(0, 9);
                    for (j = 0; j < 9; j++)
                    {
                        board[i, j] = arr[j];
                    }
                }

                do
                {
                    Console.WriteLine("Is this correct? 'y' or 'n'");
                    input = Console.Read();
                    done = Convert.ToChar(input);
                } while (done != 'y' && done != 'n');
            } while (done != 'y');
            str = Console.ReadLine();


            if (u.readInBoard(board))
            {
                u.solvePuzzle();
            } else
            {
                Console.WriteLine("Invalid puzzle");
            }


            str = Console.ReadLine();
        }
    }
}
