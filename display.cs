using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class display
    {
        public void displayBoard(char[,] board)
        {
            int i, j, k;

            for (i = 0; i < 9; i++)
            {
                if (i == 3 || i == 6)
                {
                    for (k = 0; k < 23; k++)
                    {
                        if (k == 7 || k == 15)
                        {
                            Console.Write('|');
                        }
                        else
                        {
                            Console.Write('_');
                        }
                    }
                    Console.Write("\n");
                    Console.Write("       |       |" + "\n");
                }
                for (j = 0; j < 9; j++)
                {
                    
                    if (j == 3 || j == 6)
                    {
                        Console.Write(' ');
                        Console.Write('|');
                        
                    }
                    Console.Write(' ');
                    Console.Write(board[i, j]);
                }
                Console.Write("\n");
            }
        }
    }
}
