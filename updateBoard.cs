using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver
{
    class updateBoard : sBoard
    {
        public void solvePuzzle()
        {

            _checkForConfirmedValues();
            if (!e.isDone(_horizBoard))
            {
                _solvePuzzle(0, 0);
            }
            d.displayBoard(_horizBoard);
        }

        private void _checkForConfirmedValues()
        {
            int i, j;
            int y = 0, x = 0;
            int trueValues;
            char value;
            bool changeMade, confirmedValue;
            bool[] openValues = new bool[10];
            do
            {
                changeMade = false;

                for (y = 0; y < 9; y++)
                {
                    for (x = 0; x < 9; x++)
                    {
                        if (_horizBoard[y, x] != '0')
                        {
                            continue;
                        }
                        trueValues = 0;
                        confirmedValue = false;
                        openValues = availableValues(y, x);
                        for (i = 1; i < 10; i++)
                        {
                            if (openValues[i])
                            {
                                trueValues++;
                            }

                        }
                        if (trueValues == 1)
                        {
                            for (i = 1; i < 10; i++)
                            {
                                if (openValues[i])
                                {
                                    value = (char)(i + 48);
                                    editList(y, x, value);
                                    changeMade = true;
                                }
                            }
                        }
                    }
                }


            } while (changeMade);
        }

        private bool _solvePuzzle(int y, int x)
        {
            int i, j;
            int nextY, nextX;
            nextX = (x + 1) % 9;
            if (nextX == 0)
            {
                nextY = (y + 1) % 9;
            }
            else
            {
                nextY = y;
            }
            char value;
            bool[] openValues = availableValues(y, x);
            bool lastCheck = true;
            if (_horizBoard[y, x] != '0')
            {
                if (nextY == 0 && nextX == 0)
                {
                    return true;
                }
                else
                {

                    lastCheck = _solvePuzzle(nextY, nextX);
                    return lastCheck;
                }
            }
            else if (!openValues.Contains(true))
            {
                return false;
            }
            else
            {
                for (i = 1; i < 10; i++)
                {
                    if (openValues[i] == true)
                    {
                        lastCheck = true;
                        value = (char)(i + 48);
                        editList(y, x, value);
                        if (nextY == 0 && nextX == 0)
                        {
                            return true;
                        }
                        else
                        {
                            if (_solvePuzzle(nextY, nextX))
                            {
                                return true;
                            }
                            else
                            {
                                editList(y, x, '0');
                                lastCheck = false;
                            }
                        }
                    }
                }
                if (!lastCheck)
                {

                    return false;
                }
            }
            return true;
        }


        public bool[] availableValues(int y, int x)
        {

            bool[] openValues = new bool[10];
            int i, j;
            int boxNum, boxVal;
            char value;
            int intValue;

            for (i = 1; i < 10; i++)
            {
                openValues[i] = true;
            }

            if (y >= 0 && y < 3)
            {
                boxNum = 0;
            }
            else if (y >= 3 && y < 6)
            {
                boxNum = 3;
            }
            else
            {
                boxNum = 6;
            }

            if (x >= 3 && x < 6)
            {
                boxNum += 1;
            }
            else if (x >= 6 && x < 9)
            {
                boxNum += 2;
            }



            for (i = 0; i < 9; i++)
            {
                if (_horizBoard[y, i] != '0')
                {
                    value = _horizBoard[y, i];
                    intValue = value - '0';
                    openValues[intValue] = false;
                }

                if (_vertBoard[x, i] != '0')
                {
                    value = _vertBoard[x, i];
                    intValue = value - '0';
                    openValues[intValue] = false;
                }

                if (_box[boxNum, i] != '0')
                {
                    value = _box[boxNum, i];
                    intValue = value - '0';
                    openValues[intValue] = false;
                }
            }

            return openValues;
        }


        public void editList(int y, int x, char value)
        {


            int boxNum, boxPlacement;

            if (y >= 0 && y < 3)
            {
                boxNum = 0;
            }
            else if (y >= 3 && y < 6)
            {
                boxNum = 3;
            }
            else
            {
                boxNum = 6;
            }

            if (x >= 3 && x < 6)
            {
                boxNum += 1;
            }
            else if (x >= 6 && x < 9)
            {
                boxNum += 2;
            }

            boxPlacement = 3 * (y % 3) + (x % 3);

            _horizBoard[y, x] = value;
            _vertBoard[x, y] = value;
            _box[boxNum, boxPlacement] = value;
        }

    }
}
