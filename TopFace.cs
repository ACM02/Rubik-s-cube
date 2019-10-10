using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rubik_s_cube
{
    class TopFace : Side
    {
        /// <summary>
        /// The constructor for this face
        /// </summary>
        /// <param name="size"></param> The size of the face
        public TopFace(int size) : base(size) {
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
            PictureBox[,] back, Color[,] backLasts)
        {
            if (direction == "l")
            {
                base.rotate("l");
                // Front
                front[0, 0].BackColor = leftLasts[0, 0];
                front[0, 1].BackColor = leftLasts[0, 1];
                front[0, 2].BackColor = leftLasts[0, 2];
                // Left
                left[0, 0].BackColor = backLasts[0, 0];
                left[0, 1].BackColor = backLasts[0, 1];
                left[0, 2].BackColor = backLasts[0, 2];
                // Back
                back[0, 0].BackColor = rightLasts[0, 0];
                back[0, 1].BackColor = rightLasts[0, 1];
                back[0, 2].BackColor = rightLasts[0, 2];
                // Right
                right[0, 0].BackColor = frontLasts[0, 0];
                right[0, 1].BackColor = frontLasts[0, 1];
                right[0, 2].BackColor = frontLasts[0, 2];
            }
            else
            {
                base.rotate("r");
                // Front
                front[0, 0].BackColor = rightLasts[0, 0];
                front[0, 1].BackColor = rightLasts[0, 1];
                front[0, 2].BackColor = rightLasts[0, 2];
                // Left
                left[0, 0].BackColor = frontLasts[0, 0];
                left[0, 1].BackColor = frontLasts[0, 1];
                left[0, 2].BackColor = frontLasts[0, 2];
                // Back
                back[0, 0].BackColor = leftLasts[0, 0];
                back[0, 1].BackColor = leftLasts[0, 1];
                back[0, 2].BackColor = leftLasts[0, 2];
                // Right
                right[0, 0].BackColor = backLasts[0, 0];
                right[0, 1].BackColor = backLasts[0, 1];
                right[0, 2].BackColor = backLasts[0, 2];
            }
        }
    }
}
