using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rubik_s_cube
{
    class Side
    {
        public Color[,] lasts;  // A side has 2 arrays the pictureboxes and the lasts
        public PictureBox[,] boxes;

        /// <summary>
        /// The constructor for a side
        /// </summary>
        /// <param name="size"></param> The size of the side
        public Side(int size) {
            lasts = new Color[size, size];  // Initialize the arrays to the size given
            boxes = new PictureBox[size, size];      
        }

        /// <summary>
        /// Rotate the face
        /// </summary>
        /// <param name="direction"></param> The direction to rotate it in
        public void rotate(string direction) {
            if (direction == "l")
            {
                // Corners
                boxes[0, 0].BackColor = lasts[0, 2];
                boxes[2, 0].BackColor = lasts[0, 0];
                boxes[2, 2].BackColor = lasts[2, 0];
                boxes[0, 2].BackColor = lasts[2, 2];

                // Edges
                boxes[0, 1].BackColor = lasts[1, 2];
                boxes[1, 0].BackColor = lasts[0, 1];
                boxes[2, 1].BackColor = lasts[1, 0];
                boxes[1, 2].BackColor = lasts[2, 1];
            }
            else
            {
                // Corners
                boxes[0, 0].BackColor = lasts[2, 0];
                boxes[2, 0].BackColor = lasts[2, 2];
                boxes[2, 2].BackColor = lasts[0, 2];
                boxes[0, 2].BackColor = lasts[0, 0];

                // Edges
                boxes[0, 1].BackColor = lasts[1, 0];
                boxes[1, 0].BackColor = lasts[2, 1];
                boxes[2, 1].BackColor = lasts[1, 2];
                boxes[1, 2].BackColor = lasts[0, 1];
            }          
        }
    }
}
