using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SudokuSolver

{
    class sBoard
    {
        protected errorChecking e = new errorChecking();
        protected display d = new display();

        public bool readInBoard(char[,] board)
        {
            return _readInBoard(board);
        }

        public void readInBoard(char[,] hBoard, char[,] vBoard, char[,] bBoard)
        {
            _readInBoard(hBoard, vBoard, bBoard);
        }

        public bool _readInBoard(char[,] board)
        {
            int i, j, k, boxNum;
            bool isValid;
            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    _horizBoard[i, j] = board[i, j];
                    _vertBoard[i, j] = board[j, i];
                }
            }


            for (i = 0; i < 9; i++)
            {
                if (i >= 0 && i < 3)
                {
                    boxNum = 0;
                }
                else if (i >= 3 && i < 6)
                {
                    boxNum = 3;
                }
                else
                {
                    boxNum = 6;
                }
                for (j = 0; j < 9; j++)
                {
                    if (j != 0 && j % 3 == 0)
                    {
                        boxNum++;
                    }
                    k = 3 * (i % 3) + (j % 3);
                    _box[boxNum, k] = board[i, j];
                }
            }

            isValid = e.checkIfValidBoard(_horizBoard, _vertBoard, _box);

            if (isValid)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void _readInBoard(char[,] hBoard, char[,] vBoard, char[,] bBoard)
        {
            int i, j;

            for (i = 0; i < 9; i++)
            {
                for (j = 0; j < 9; j++)
                {
                    _horizBoard[i, j] = hBoard[i, j];
                    _solvedBoard[i, j] = hBoard[i, j];
                    _vertBoard[i, j] = vBoard[i, j];
                    _box[i, j] = bBoard[i, j];
                }
            }
        }

        public char[,] horizBoard
        {
            get {
                return _horizBoard;
            }
        }
        protected char[,] _horizBoard = new char[9, 9];
        protected char[,] _solvedBoard = new char[9, 9];
        protected char[,] _vertBoard = new char[9, 9];
        protected char[,] _box = new char[9, 9];
    }

}
