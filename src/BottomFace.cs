using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rubik_s_cube
{
    class BottomFace : Side
    {
        /// <summary>
        /// The constructor for this face
        /// </summary>
        /// <param name="size"></param> The size of the face
        public BottomFace(int size) : base(size) {
        }

        /// <summary>
        /// Rotates this face and the corresponding faces touching it
        /// </summary>
        /// <param name="direction"></param> The direction to turn
        /// <param name="left"></param> Some of this face will be rotated with the face being rotated
        /// <param name="leftLasts"></param> The lasts of the parameter before it
        /// <param name="front"></param> Some of this face will be rotated with the face being rotated
        /// <param name="frontLasts"></param> The lasts of the parameter before it
        /// <param name="right"></param> Some of this face will be rotated with the face being rotated
        /// <param name="rightLasts"></param> The lasts of the parameter before it
        /// <param name="back"></param> Some of this face will be rotated with the face being rotated
        /// <param name="backLasts"></param> The lasts of the parameter before it
        public void rotate(String direction,
            PictureBox[,] left, Color[,] leftLasts,
            PictureBox[,] front, Color[,] frontLasts,
            PictureBox[,] right, Color[,] rightLasts,
            PictureBox[,] back, Color[,] backLasts) {

            if (direction == "l")
            {
                base.rotate("l");
                // Front
                front[2, 0].BackColor = rightLasts[2, 0];
                front[2, 1].BackColor = rightLasts[2, 1];
                front[2, 2].BackColor = rightLasts[2, 2];
                // Left
                left[2, 0].BackColor = frontLasts[2, 0];
                left[2, 1].BackColor = frontLasts[2, 1];
                left[2, 2].BackColor = frontLasts[2, 2];
                // Back
                back[2, 0].BackColor = leftLasts[2, 0];
                back[2, 1].BackColor = leftLasts[2, 1];
                back[2, 2].BackColor = leftLasts[2, 2];
                // Right
                right[2, 0].BackColor = backLasts[2, 0];
                right[2, 1].BackColor = backLasts[2, 1];
                right[2, 2].BackColor = backLasts[2, 2];
            }
            else
            {
                base.rotate("r");
                // Front
                front[2, 0].BackColor = leftLasts[2, 0];
                front[2, 1].BackColor = leftLasts[2, 1];
                front[2, 2].BackColor = leftLasts[2, 2];
                // Left
                left[2, 0].BackColor = backLasts[2, 0];
                left[2, 1].BackColor = backLasts[2, 1];
                left[2, 2].BackColor = backLasts[2, 2];
                // Back
                back[2, 0].BackColor = rightLasts[2, 0];
                back[2, 1].BackColor = rightLasts[2, 1];
                back[2, 2].BackColor = rightLasts[2, 2];
                // Right
                right[2, 0].BackColor = frontLasts[2, 0];
                right[2, 1].BackColor = frontLasts[2, 1];
                right[2, 2].BackColor = frontLasts[2, 2];
            }
        }
    }
}
