using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class errorChecking
    {
        public bool checkIfValidBoard(char[,] h, char[,] v, char[,] b)
        {
            int i, j;
            bool isValid = true;
            char[] arr = new char[9];
            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    arr[j] = h[i, j];
                }
                isValid = checkArray(arr);
                if (!isValid)
                {
                    return false;
                }
            }

            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    arr[j] = v[i, j];
                }
                isValid = checkArray(arr);
                if (!isValid)
                {
                    return false;
                }
            }

            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    arr[j] = b[i, j];
                }
                isValid = checkArray(arr);
                if (!isValid)
                {
                    return false;
                }
            }

            

            return true;
        }


        public bool checkArray(char[] arr)
        {
            int i, j;
            char comparedValue;
            int timesRepeated;

            for (i = 0; i < 9; i++)
            {
                comparedValue = arr[i];
                if (comparedValue != '0')
                {
                    timesRepeated = 0;
                    for (j = i; j < 9; j++)
                    {
                        if (comparedValue == arr[j])
                        {
                            timesRepeated++;
                        }

                        if (timesRepeated > 1)
                        {
                            return false;
                        }
                    }
                }

            }

            return true;
        }

        public bool isDone(char[,] board)
        {
            int i, j;
            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    if (board[i, j] == '0')
                    {
                        return false;
                    }
                }
            }

            return true;
        }    
    }

}
