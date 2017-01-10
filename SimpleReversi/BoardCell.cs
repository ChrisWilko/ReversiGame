using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleReversi
{
    class BoardCell : PictureBox
    {
        int[] myCell = new int[2];

        public BoardCell(int row, int col)
        {
            myCell[0] = row;
            myCell[1] = col;
        }

        public int[] Cell {get { return myCell; } }
    }
}
