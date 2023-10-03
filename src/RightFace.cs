using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rubik_s_cube
{
    class RightFace : Side
    {
        /// <summary>
        /// The constructor for this face
        /// </summary>
        /// <param name="size"></param> The size of the face
        public RightFace(int size) : base(size) {
        }

        /// <summary>
        /// Rotates this face and the corresponding faces touching it
        /// </summary>
        /// <param name="direction"></param> The direction to turn
        /// <param name="top"></param> Some of this face will be rotated with the face being rotated
        /// <param name="topLasts"></param> The lasts of the parameter before it
        /// <param name="front"></param> Some of this face will be rotated with the face being rotated
        /// <param name="frontLasts"></param> The lasts of the parameter before it
        /// <param name="bottom"></param> Some of this face will be rotated with the face being rotated
        /// <param name="bottomLasts"></param> The lasts of the parameter before it
        /// <param name="back"></param> Some of this face will be rotated with the face being rotated
        /// <param name="backLasts"></param> The lasts of the parameter before it
        public void rotate(String direction,
            PictureBox[,] top, Color[,] topLasts,
            PictureBox[,] front, Color[,] frontLasts,
            PictureBox[,] bottom, Color[,] bottomLasts,
            PictureBox[,] back, Color[,] backLasts)
        {
            if (direction == "l")
            {
                base.rotate("l");
                // Top
                top[0, 2].BackColor = backLasts[2, 0];
                top[1, 2].BackColor = backLasts[1, 0];
                top[2, 2].BackColor = backLasts[0, 0];
                // Back
                back[0, 0].BackColor = bottomLasts[2, 2];
                back[1, 0].BackColor = bottomLasts[1, 2];
                back[2, 0].BackColor = bottomLasts[0, 2];
                // Bottom
                bottom[0, 2].BackColor = frontLasts[0, 2];
                bottom[1, 2].BackColor = frontLasts[1, 2];
                bottom[2, 2].BackColor = frontLasts[2, 2];
                // Front
                front[0, 2].BackColor = topLasts[0, 2];
                front[1, 2].BackColor = topLasts[1, 2];
                front[2, 2].BackColor = topLasts[2, 2];
            }
            else
            {
                base.rotate("r");
                // Top
                top[0, 2].BackColor = frontLasts[0, 2];
                top[1, 2].BackColor = frontLasts[1, 2];
                top[2, 2].BackColor = frontLasts[2, 2];
                // Back
                back[0, 0].BackColor = topLasts[2, 2];
                back[1, 0].BackColor = topLasts[1, 2];
                back[2, 0].BackColor = topLasts[0, 2];
                // Bottom
                bottom[0, 2].BackColor = backLasts[2, 0];
                bottom[1, 2].BackColor = backLasts[1, 0];
                bottom[2, 2].BackColor = backLasts[0, 0];
                // Front
                front[0, 2].BackColor = bottomLasts[0, 2];
                front[1, 2].BackColor = bottomLasts[1, 2];
                front[2, 2].BackColor = bottomLasts[2, 2];
            }
        }
    }
}
