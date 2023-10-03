using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rubik_s_cube
{
    class Cube
    {
        // Properties a cube should have
        public int size;
        public int delay;

        public TopFace top;     // 6 faces on the cube
        public BottomFace bottom;
        public LeftFace left;
        public RightFace right;
        public FrontFace front;
        public BackFace back;

        /// <summary>
        /// The contructor for the cube 
        /// </summary>
        /// <param name="size"></param> The size of the faces of the cube
        public Cube(int size) {
            top = new TopFace(size);    // Make the faces to the size given
            bottom = new BottomFace(size);
            left = new LeftFace(size);
            right = new RightFace(size);
            front = new FrontFace(size);
            back = new BackFace(size);

            this.size = size;
        }

        /// <summary>
        /// Rotate the cube
        /// </summary>
        /// <param name="direction"></param> The direction to rotate in
        public void rotate(string direction) {
            if (direction == "left")
            {
                //Front to left
                moveFace(front.boxes, left.lasts, false);
                //Left to back
                moveFace(left.boxes, back.lasts, false);
                //Back to right
                moveFace(back.boxes, right.lasts, false);
                //Right to front
                moveFace(right.boxes, front.lasts, false);
                //Top
                rotateFace(top.boxes, top.lasts, "l");
                //Bottom
                rotateFace(bottom.boxes, bottom.lasts, "r");
            }
            else if (direction == "right")
            {
                //Front to right
                moveFace(front.boxes, right.lasts, false);
                //Right to back
                moveFace(right.boxes, back.lasts, false);
                //Back to left
                moveFace(back.boxes, left.lasts, false);
                //Left to front
                moveFace(left.boxes, front.lasts, false);
                //Top
                rotateFace(top.boxes, top.lasts, "r");
                //Bottom
                rotateFace(bottom.boxes, bottom.lasts, "l");
            }
            else if (direction == "up")
            {
                //Front to bottom
                moveFace(front.boxes, bottom.lasts, false);
                //Top to front
                moveFace(top.boxes, front.lasts, false);
                //Back to top
                moveFace(back.boxes, top.lasts, true);
                //Bottom to back
                moveFace(bottom.boxes, back.lasts, true);
                //Left
                rotateFace(left.boxes, left.lasts, "l");
                //Right
                rotateFace(right.boxes, right.lasts, "r");
            }
            else if (direction == "down")
            {
                //Front to top
                moveFace(front.boxes, top.lasts, false);
                //Top to back
                moveFace(top.boxes, back.lasts, true);
                //Back to bottom
                moveFace(back.boxes, bottom.lasts, true);
                //Bottom to front
                moveFace(bottom.boxes, front.lasts, false);
                //Left
                rotateFace(left.boxes, left.lasts, "r");
                //Right
                rotateFace(right.boxes, right.lasts, "l");
            }
            updateLasts();
        }

        /// <summary>
        /// Swap a face with another face
        /// </summary>
        /// <param name="side"></param> The side to be replaced
        /// <param name="sideLasts"></param> The side replacing the side to be replaced
        /// <param name="back"></param> Whether the back face is involved
        public void moveFace(PictureBox[,] side, Color[,] sideLasts, bool back) {
            if (back == false)
            {
                for (int rows = 0; rows < size; rows++)
                {
                    for (int cols = 0; cols < size; cols++)
                    {
                        side[rows, cols].BackColor = sideLasts[rows, cols]; // Replace the face
                    }
                }
            }
            else
            {
                side[0, 0].BackColor = sideLasts[2, 2];
                side[0, 1].BackColor = sideLasts[2, 1];
                side[0, 2].BackColor = sideLasts[2, 0];
                side[1, 0].BackColor = sideLasts[1, 2];
                side[1, 1].BackColor = sideLasts[1, 1];
                side[1, 2].BackColor = sideLasts[1, 0];
                side[2, 0].BackColor = sideLasts[0, 2];
                side[2, 1].BackColor = sideLasts[0, 1];
                side[2, 2].BackColor = sideLasts[0, 0];
            }
        }

        /// <summary>
        /// Rotate one of the faces on the cube
        /// </summary>
        /// <param name="side"></param> The pictureboxes being rotated
        /// <param name="sideLasts"></param> The lasts variable for the side being rotated
        /// <param name="direction"></param> The direction the side is being rotated
        public void rotateFace(PictureBox[,] side, Color[,] sideLasts, string direction) {
            if (direction == "l")
            {
                // Corners
                side[0, 0].BackColor = sideLasts[0, 2];
                side[2, 0].BackColor = sideLasts[0, 0];
                side[2, 2].BackColor = sideLasts[2, 0];
                side[0, 2].BackColor = sideLasts[2, 2];

                // Edges
                side[0, 1].BackColor = sideLasts[1, 2];
                side[1, 0].BackColor = sideLasts[0, 1];
                side[2, 1].BackColor = sideLasts[1, 0];
                side[1, 2].BackColor = sideLasts[2, 1];
            }
            else
            {
                // Corners
                side[0, 0].BackColor = sideLasts[2, 0];
                side[2, 0].BackColor = sideLasts[2, 2];
                side[2, 2].BackColor = sideLasts[0, 2];
                side[0, 2].BackColor = sideLasts[0, 0];

                // Edges
                side[0, 1].BackColor = sideLasts[1, 0];
                side[1, 0].BackColor = sideLasts[2, 1];
                side[2, 1].BackColor = sideLasts[1, 2];
                side[1, 2].BackColor = sideLasts[0, 1];
            }
        }

        /// <summary>
        /// Update the lasts Variables without this the entire cube would fall apart
        /// </summary>
        public void updateLasts()
        {
            // Update the lasts variables
            updateLasts(top.lasts, top.boxes);
            updateLasts(front.lasts, front.boxes);
            updateLasts(back.lasts, back.boxes);
            updateLasts(left.lasts, left.boxes);
            updateLasts(right.lasts, right.boxes);
            updateLasts(bottom.lasts, bottom.boxes);

            // Delay the program
            System.Threading.Thread.Sleep(delay);
        }

        /// <summary>
        /// Updating the lasts variables using parameters to make the code less large
        /// </summary>
        /// <param name="sideLasts"></param> The side to be updated
        /// <param name="side"></param> The side to be updated
        private void updateLasts(Color[,] sideLasts, PictureBox[,] side) {
            for (int rows = 0; rows < top.boxes.GetLength(0); rows++)
            {
                for (int cols = 0; cols < top.boxes.GetLength(1); cols++)
                {
                    // Update and refresh the side
                    sideLasts[rows, cols] = side[rows, cols].BackColor;
                    side[rows, cols].Refresh();
                }
            }
        }

        /// <summary>
        /// Reset the cube to it's original state
        /// </summary>
        public void resetCube() {
            // Reset all the sides to the appropriate colour
            resetSide(top.boxes, Color.Yellow);
            resetSide(front.boxes, Color.Red);
            resetSide(back.boxes, Color.Orange);
            resetSide(left.boxes, Color.Blue);
            resetSide(right.boxes, Color.Green);
            resetSide(bottom.boxes, Color.White);
            
            updateLasts();
        }

        /// <summary>
        /// Sets a side to a colour
        /// </summary>
        /// <param name="side"></param> The side to be changed
        /// <param name="color"></param> The colour to change the side to
        public void resetSide(PictureBox[,] side, Color color) {
            for (int rows = 0; rows < top.boxes.GetLength(0); rows++)
            {
                for (int cols = 0; cols < top.boxes.GetLength(1); cols++)
                {
                    side[rows, cols].BackColor = color; // Update the colour of the picturebox to the appropriate colour
                }
            }
        }
    }
}
