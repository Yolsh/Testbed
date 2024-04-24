using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CGOL_forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void DrawGrid(int[,] Board)
        {
            int CellHeight = this.Height / Board.GetLength(0);
            int CellWidth = this.Width / Board.GetLength(1);

            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    PictureBox Cell = new PictureBox();
                    Cell.Location = new Point(j * CellWidth, i * CellHeight);
                    lbl.Text = Cell.Location.Y.ToString();
                    Cell.Height = CellHeight;
                    Cell.Width = CellWidth;
                    Cell.BorderStyle = BorderStyle.FixedSingle;

                    if (Board[i, j] == 1)
                    {
                        Cell.BackColor = Color.White;
                    }
                    else
                    {
                        Cell.BackColor = Color.Black;
                    }

                    this.Controls.Add(Cell);
                }
            }
        }
    }
}
