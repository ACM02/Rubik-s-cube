using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rubik_s_cube
{
    class BackFace : Side
    {
        /// <summary>
        /// The constructor for this face
        /// </summary>
        /// <param name="size"></param> The size of the face
        public BackFace(int size) : base(size) {
        }

        /// <summary>
        /// Rotates this face and the corresponding faces touching it
        /// </summary>
        /// <param name="direction"></param> The direction to turn
        /// <param name="left"></param> Some of this face will be rotated with the face being rotated
        /// <param name="leftLasts"></param> The lasts of the parameter before it
        /// <param name="top"></param> Some of this face will be rotated with the face being rotated
        /// <param name="topLasts"></param> The lasts of the parameter before it
        /// <param name="right"></param> Some of this face will be rotated with the face being rotated
        /// <param name="rightLasts"></param> The lasts of the parameter before it
        /// <param name="bottom"></param> Some of this face will be rotated with the face being rotated
        /// <param name="bottomLasts"></param> The lasts of the parameter before it
        public void rotate(string direction,
            PictureBox[,] left, Color[,] leftLasts,
            PictureBox[,] top, Color[,] topLasts,
            PictureBox[,] right, Color[,] rightLasts,
            PictureBox[,] bottom, Color[,] bottomLasts)
        {

            if (direction == "l")
            {
                base.rotate(direction);
                // Top
                top[0, 0].BackColor = leftLasts[2, 0];
                top[0, 1].BackColor = leftLasts[1, 0];
                top[0, 2].BackColor = leftLasts[0, 0];
                // Left
                left[0, 0].BackColor = bottomLasts[2, 0];
                left[1, 0].BackColor = bottomLasts[2, 1];
                left[2, 0].BackColor = bottomLasts[2, 2];
                // Bottom
                bottom[2, 0].BackColor = rightLasts[2, 2];
                bottom[2, 1].BackColor = rightLasts[1, 2];
                bottom[2, 2].BackColor = rightLasts[0, 2];
                // Right
                right[0, 2].BackColor = topLasts[0, 0];
                right[1, 2].BackColor = topLasts[0, 1];
                right[2, 2].BackColor = topLasts[0, 2];
            }
            else
            {
                base.rotate(direction);
                // Top
                top[0, 0].BackColor = rightLasts[0, 2];
                top[0, 1].BackColor = rightLasts[1, 2];
                top[0, 2].BackColor = rightLasts[2, 2];
                // Left
                left[0, 0].BackColor = topLasts[0, 2];
                left[1, 0].BackColor = topLasts[0, 1];
                left[2, 0].BackColor = topLasts[0, 0];
                // Bottom
                bottom[2, 0].BackColor = leftLasts[0, 0];
                bottom[2, 1].BackColor = leftLasts[1, 0];
                bottom[2, 2].BackColor = leftLasts[2, 0];
                // Right
                right[0, 2].BackColor = bottomLasts[2, 2];
                right[1, 2].BackColor = bottomLasts[2, 1];
                right[2, 2].BackColor = bottomLasts[2, 0];
            }
        }
    }
}
