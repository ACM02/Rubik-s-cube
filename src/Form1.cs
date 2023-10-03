using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rubik_s_cube
{
    /// <summary>
    /// This program simulates a rubik's cube that the user can solve or the computer can solve
    /// it also tracks the moves made by either the computer or user with an explination to the 
    /// abreviations used, the user can also get the computer to scramble to cube for a certain 
    /// mount of moves and choose the speed at which the computer both solves and scrambles the
    /// cube
    /// </summary>
    public partial class frmRubiks : Form
    {
        Cube cube = new Cube(3);    // New cube!

        // Globals
        int fast = 0;   // The fast setting for the delay (ms)
        int slow = 50;  // The slow setting for the delay (ms)
        int scrambleCounter = 10;   // Keeps how many moves to scramble
        string currentMove = "";    // The move happening 

        public frmRubiks(){
            InitializeComponent();
        }

        private void frmRubiks_Load(object sender, EventArgs e){

            cube.delay = fast;  // Set the delay to fast

            // Populate the cube's arrays with pictureboxes
            cube.top.boxes[0, 0] = picTopTopLeft;
            cube.top.boxes[0, 1] = picTopTopCenter;
            cube.top.boxes[0, 2] = picTopTopRight;
            cube.top.boxes[1, 0] = picTopCenterLeft;
            cube.top.boxes[1, 1] = picTopCenter;
            cube.top.boxes[1, 2] = picTopCenterRight;
            cube.top.boxes[2, 0] = picTopBottomLeft;
            cube.top.boxes[2, 1] = picTopBottomCenter;
            cube.top.boxes[2, 2] = picTopBottomRight;

            cube.front.boxes[0, 0] = picFrontTopLeft;
            cube.front.boxes[0, 1] = picFrontTopCenter;
            cube.front.boxes[0, 2] = picFrontTopRight;
            cube.front.boxes[1, 0] = picFrontCenterLeft;
            cube.front.boxes[1, 1] = picFrontCenter;
            cube.front.boxes[1, 2] = picFrontCenterRight;
            cube.front.boxes[2, 0] = picFrontBottomLeft;
            cube.front.boxes[2, 1] = picFrontBottomCenter;
            cube.front.boxes[2, 2] = picFrontBottomRight;

            cube.back.boxes[0, 0] = picBackTopLeft;
            cube.back.boxes[0, 1] = picBackTopCenter;
            cube.back.boxes[0, 2] = picBackTopRight;
            cube.back.boxes[1, 0] = picBackCenterLeft;
            cube.back.boxes[1, 1] = picBackCenter;
            cube.back.boxes[1, 2] = picBackCenterRight;
            cube.back.boxes[2, 0] = picBackBottomLeft;
            cube.back.boxes[2, 1] = picBackBottomCenter;
            cube.back.boxes[2, 2] = picBackBottomRight;

            cube.left.boxes[0, 0] = picLeftTopLeft;
            cube.left.boxes[0, 1] = picLeftTopCenter;
            cube.left.boxes[0, 2] = picLeftTopRight;
            cube.left.boxes[1, 0] = picLeftCenterLeft;
            cube.left.boxes[1, 1] = picLeftCenter;
            cube.left.boxes[1, 2] = picLeftCenterRight;
            cube.left.boxes[2, 0] = picLeftBottomLeft;
            cube.left.boxes[2, 1] = picLeftBottomCenter;
            cube.left.boxes[2, 2] = picLeftBottomRight;

            cube.right.boxes[0, 0] = picRightTopLeft;
            cube.right.boxes[0, 1] = picRightTopCenter;
            cube.right.boxes[0, 2] = picRightTopRight;
            cube.right.boxes[1, 0] = picRightCenterLeft;
            cube.right.boxes[1, 1] = picRightCenter;
            cube.right.boxes[1, 2] = picRightCenterRight;
            cube.right.boxes[2, 0] = picRightBottomLeft;
            cube.right.boxes[2, 1] = picRightBottomCenter;
            cube.right.boxes[2, 2] = picRightBottomRight;

            cube.bottom.boxes[0, 0] = picBottomTopLeft;
            cube.bottom.boxes[0, 1] = picBottomTopCenter;
            cube.bottom.boxes[0, 2] = picBottomTopRight;
            cube.bottom.boxes[1, 0] = picBottomCenterLeft;
            cube.bottom.boxes[1, 1] = picBottomCenter;
            cube.bottom.boxes[1, 2] = picBottomCenterRight;
            cube.bottom.boxes[2, 0] = picBottomBottomLeft;
            cube.bottom.boxes[2, 1] = picBottomBottomCenter;
            cube.bottom.boxes[2, 2] = picBottomBottomRight;

            cube.updateLasts(); // Update the lasts array in the cube
        }

        // Face rotation buttons
        private void btnTopLeft_Click(object sender, EventArgs e) {
            topLeft();
        }
        private void btnTopRight_Click(object sender, EventArgs e) {
            topRight();
        }
        private void btnBackLeft_Click(object sender, EventArgs e) {
            backLeft();
        }
        private void btnBackRight_Click(object sender, EventArgs e) {
            backRight();
        }
        private void btnBottomLeft_Click(object sender, EventArgs e) {
            bottomLeft();
        }
        private void btnBottomRight_Click(object sender, EventArgs e) {
            bottomRight();
        }
        private void btnFrontLeft_Click(object sender, EventArgs e) {
            frontLeft();
        }
        private void btnFrontRight_Click(object sender, EventArgs e) {
            frontRight();
        }
        private void btnLeftLeft_Click(object sender, EventArgs e) {
            leftLeft();
        }
        private void btnLeftRight_Click(object sender, EventArgs e) {
            leftRight();
        }
        private void btnRightLeft_Click(object sender, EventArgs e) {
            rightLeft();
        }
        private void btnRightRight_Click(object sender, EventArgs e) {
            rightRight();
        }
        private void btnCubeLeft_Click(object sender, EventArgs e) {
            cube.rotate("left");
        }
        private void btnCubeRight_Click(object sender, EventArgs e) {
            cube.rotate("right");
        }
        private void btnCubeUp_Click(object sender, EventArgs e) {
            cube.rotate("up");
        }
        private void btnCubeDown_Click(object sender, EventArgs e) {
            cube.rotate("down");
        }      
        private void btnReset_Click(object sender, EventArgs e) {
            cube.resetCube();
            lstboxMoves.Items.Clear();
        }
        // End of face rotation button

        // Face rotation methods

        /// <summary>
        /// Rotate the top face counter-clockwise
        /// </summary>
        private void topLeft() {
            cube.top.rotate("l",
            cube.left.boxes, cube.left.lasts,
            cube.front.boxes, cube.front.lasts,
            cube.right.boxes, cube.right.lasts,
            cube.back.boxes, cube.back.lasts);

            // Set the current move to top ounter-clockwise
            currentMove = " T'";
            updateMoves();

            cube.updateLasts();
        }

        /// <summary>
        /// Rotate the top face clockwise
        /// </summary>
        private void topRight() {
            cube.top.rotate("r",
            cube.left.boxes, cube.left.lasts,
            cube.front.boxes, cube.front.lasts,
            cube.right.boxes, cube.right.lasts,
            cube.back.boxes, cube.back.lasts);

            // Set the current move to top clockwise
            currentMove = " T"; 
            updateMoves();

            cube.updateLasts();
        }

        /// <summary>
        /// Rotate the back face counter-clockwise
        /// </summary>
        private void backLeft() {
            cube.back.rotate("l",
            cube.left.boxes, cube.left.lasts,
            cube.top.boxes, cube.top.lasts,
            cube.right.boxes, cube.right.lasts,
            cube.bottom.boxes, cube.bottom.lasts);

            // Set the current move to back counter-clockwise
            currentMove = " b'";
            updateMoves();

            cube.updateLasts();
        }

        /// <summary>
        /// Rotate the back face colckwise
        /// </summary>
        private void backRight() {
            cube.back.rotate("r",
            cube.left.boxes, cube.left.lasts,
            cube.top.boxes, cube.top.lasts,
            cube.right.boxes, cube.right.lasts,
            cube.bottom.boxes, cube.bottom.lasts);

            // Set the current move to back clockwise
            currentMove = " b";
            updateMoves();
            
            cube.updateLasts();
        }

        /// <summary>
        /// Rotate the bottom face counter-colckwise
        /// </summary>
        private void bottomLeft() {
            cube.bottom.rotate("l",
            cube.left.boxes, cube.left.lasts,
            cube.front.boxes, cube.front.lasts,
            cube.right.boxes, cube.right.lasts,
             cube.back.boxes, cube.back.lasts);

            // Set the current move to bottom counter-clockwise
            currentMove = " B'";
            updateMoves();

            cube.updateLasts();
        }

        /// <summary>
        /// Rotate the bottom face colckwise
        /// </summary>
        private void bottomRight() {
            cube.bottom.rotate("r",
            cube.left.boxes, cube.left.lasts,
            cube.front.boxes, cube.front.lasts,
            cube.right.boxes, cube.right.lasts,
            cube.back.boxes, cube.back.lasts);

            // Set the current move to bottom clockwise
            currentMove = " B";
            updateMoves();

            cube.updateLasts();
        }

        /// <summary>
        /// Rotate the front face counter-colckwise
        /// </summary>
        private void frontLeft() {
            cube.front.rotate("l",
            cube.left.boxes, cube.left.lasts,
            cube.top.boxes, cube.top.lasts,
            cube.right.boxes, cube.right.lasts,
            cube.bottom.boxes, cube.bottom.lasts);

            // Set the current move to front counter-clockwise
            currentMove = " F'";
            updateMoves();

            cube.updateLasts();
        }

        /// <summary>
        /// Rotate the front face colckwise
        /// </summary>
        private void frontRight() {
            cube.front.rotate("r",
            cube.left.boxes, cube.left.lasts,
            cube.top.boxes, cube.top.lasts,
            cube.right.boxes, cube.right.lasts,
            cube.bottom.boxes, cube.bottom.lasts);

            // Set the current move to front clockwise
            currentMove = " F";
            updateMoves();

            cube.updateLasts();
        }

        /// <summary>
        /// Rotate the left face counter-colckwise
        /// </summary>
        private void leftLeft() {
            cube.left.rotate("l",
            cube.top.boxes, cube.top.lasts,
            cube.front.boxes, cube.front.lasts,
            cube.bottom.boxes, cube.bottom.lasts,
            cube.back.boxes, cube.back.lasts);

            // Set the current move to left counter-clockwise
            currentMove = " L'";
            updateMoves();

            cube.updateLasts();
        }

        /// <summary>
        /// Rotate the left face colckwise
        /// </summary>
        private void leftRight() {
            cube.left.rotate("r",
            cube.top.boxes, cube.top.lasts,
            cube.front.boxes, cube.front.lasts,
            cube.bottom.boxes, cube.bottom.lasts,
            cube.back.boxes, cube.back.lasts);

            // Set the current move to left clockwise
            currentMove = " L";
            updateMoves();

            cube.updateLasts();
        }

        /// <summary>
        /// Rotate the right face counter-colckwise
        /// </summary>
        private void rightLeft() {
            cube.right.rotate("l",
            cube.top.boxes, cube.top.lasts,
            cube.front.boxes, cube.front.lasts,
            cube.bottom.boxes, cube.bottom.lasts,
            cube.back.boxes, cube.back.lasts);

            // Set the current move to right counter-clockwise
            currentMove = " R'";
            updateMoves();

            cube.updateLasts();
        }

        /// <summary>
        /// Rotate the right face colckwise
        /// </summary>
        private void rightRight() {
            cube.right.rotate("r",
            cube.top.boxes, cube.top.lasts,
            cube.front.boxes, cube.front.lasts,
            cube.bottom.boxes, cube.bottom.lasts,
            cube.back.boxes, cube.back.lasts);

            // Set the current move to right clockwise
            currentMove = " R";
            updateMoves();

            cube.updateLasts();
        }

        // End of face rotation methods

        /// <summary>
        /// An algorithm used in solving the middle layer of the cube
        /// </summary>
        private void edgeLeft() {           
            topLeft();
            leftLeft();
            topRight();
            leftRight();
            topRight();
            frontRight();
            topLeft();
            frontLeft();          
        }

        /// <summary>
        /// An algorithm used in solving the middle layer of the cube
        /// </summary>
        private void edgeRight() {           
            topRight();
            rightRight();
            topLeft();
            rightLeft();
            topLeft();
            frontLeft();
            topRight();
            frontRight();           
        }

        /// <summary>
        /// An algorithm used in solving the top cross of the cube
        /// </summary>
        private void yellowCross() {           
            frontRight();
            topRight();
            rightRight();
            topLeft();
            rightLeft();
            frontLeft();           
        }

        /// <summary>
        /// An algorithm used in solving the top face of the cube
        /// </summary>
        private void yellowFace() {        
            rightRight();
            topRight();
            rightLeft();
            topRight();
            rightRight();
            topRight();
            topRight();
            rightLeft();           
        }

        /// <summary>
        /// An algorithm used in solving the top edge of the cube
        /// </summary>
        private void topEdge1() {         
            rightLeft();
            frontRight();
            rightLeft();
            backRight();
            backRight();
            rightRight();
            frontLeft();
            rightLeft();
            backRight();
            backRight();
            rightLeft();
            rightLeft();
            topLeft();           
        }

        /// <summary>
        /// An algorithm used in solving the top edge of the cube
        /// </summary>
        private void topEdge2Left() {           
            frontRight();
            frontRight();
            topRight();
            rightLeft();
            leftRight();
            frontRight();
            frontRight();
            rightRight();
            leftLeft();
            topRight();
            frontRight();
            frontRight();           
        }

        /// <summary>
        /// An algorithm used in solving the top edge of the cube
        /// </summary>
        private void topEdge2Right() {            
            frontRight();
            frontRight();
            topLeft();
            rightLeft();
            leftRight();
            frontRight();
            frontRight();
            rightRight();
            leftLeft();
            topLeft();
            frontRight();
            frontRight();            
        }


        // Solving button mothods
        private void btnTopEdgeAll_Click(object sender, EventArgs e) {
            solveTopEdge();
        }

        private void btnYellowFaceAll_Click(object sender, EventArgs e)
        {
            solveTopFace();
        }

        private void btnYellowCrossAll_Click(object sender, EventArgs e)
        {
            solveTopCross();
        }

        private void btnEdgesAll_Click(object sender, EventArgs e)
        {
            solveEdges();
        }

        private void btnBottomCross_Click(object sender, EventArgs e)
        {
            solveBottomCross();
        }

        private void btnBottomFace_Click(object sender, EventArgs e)
        {
            solveBottomFace();
        }

        private void btnSolveAll_Click(object sender, EventArgs e)
        {
            solveBottomCross();
            solveBottomFace();
            solveEdges();
            solveTopCross();
            solveTopFace();
            solveTopEdge();
        }
        // End of solving button methods

        /// <summary>
        /// Solves the top edge of the cube
        /// </summary>
        private void solveTopEdge() {
            cube.delay = slow;  // Go slow so the user can see what's happening
            // Alogorithm 1 top edge
            if (cube.front.boxes[0, 0].BackColor == cube.front.boxes[0, 2].BackColor &&
                cube.left.boxes[0, 0].BackColor == cube.left.boxes[0, 2].BackColor ||
                cube.front.boxes[0, 0].BackColor == cube.front.boxes[0, 2].BackColor &&
                cube.right.boxes[0, 0].BackColor == cube.right.boxes[0, 2].BackColor ||
                cube.left.boxes[0, 0].BackColor == cube.left.boxes[0, 2].BackColor &&
                cube.back.boxes[0, 0].BackColor == cube.back.boxes[0, 2].BackColor ||
                cube.right.boxes[0, 0].BackColor == cube.right.boxes[0, 2].BackColor &&
                cube.back.boxes[0, 0].BackColor == cube.back.boxes[0, 2].BackColor
                )   // If this algorithm needs to be done right off the bat due to additional cases that are more complicated
            {
                topEdge1();
            }
            while (cube.front.boxes[0, 0].BackColor != cube.front.boxes[1, 1].BackColor ||
                cube.front.boxes[0, 2].BackColor != cube.front.boxes[1, 1].BackColor
                )   // While the front top corners don't match the center
            {
                if (cube.front.boxes[0, 0].BackColor == cube.front.boxes[0, 2].BackColor)
                {   // If the corners match
                    topLeft();  // Rotate the top
                    cube.rotate("right");   // Rotate the cube
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (cube.front.boxes[0, 0].BackColor != cube.front.boxes[0, 2].BackColor)
                        {   // If the  corners don't match
                            topLeft();
                        }
                        else
                        {   // Keep going
                            i = 6;
                        }
                        if (i == 4)
                        {   // If it's gone through enough times do the algorithm anyway
                            topEdge1();
                        }
                    }
                }
            }
            cube.rotate("right");   // Move the matched corners to the back
            cube.rotate("right");
            topEdge1(); // Do the algorithm

            // Second algorithm in solving the top edge
            int counter = 0;

            while (cube.front.boxes[0, 1].BackColor != cube.front.boxes[1, 1].BackColor ||
                cube.left.boxes[0, 1].BackColor != cube.left.boxes[1, 1].BackColor ||
                cube.back.boxes[0, 1].BackColor != cube.back.boxes[1, 1].BackColor ||
                cube.right.boxes[0, 1].BackColor != cube.right.boxes[1, 1].BackColor)
            {   // While this step isn't done
                while (cube.front.boxes[0, 1].BackColor != cube.front.boxes[1, 1].BackColor)
                {   // While the matched corners don't match the center
                    cube.rotate("right");   // Rotate the cube around 
                    counter++;  // Add to the counter
                    if (counter > 4)
                    {   // If they don't watch
                        topEdge2Left();     // Do the algorithm
                        counter = 0;
                    }
                }
                cube.rotate("right");   // Flip the matched corners and center to the back
                cube.rotate("right");
                if (cube.front.boxes[0, 1].BackColor == cube.left.boxes[1, 1].BackColor)
                {   // If the top center needs to go left
                    topEdge2Left();
                }
                else
                {   // If the top center needs to go right
                    topEdge2Right();
                }
            }

            cube.delay = fast;  // Go fast again
        }

        /// <summary>
        /// Solves the top face of the cube
        /// </summary>
        private void solveTopFace() {
            cube.delay = slow;  // Go slow so the user can see
            while (cube.top.boxes[0, 0].BackColor != cube.top.boxes[1, 1].BackColor ||
                cube.top.boxes[0, 2].BackColor != cube.top.boxes[1, 1].BackColor ||
                cube.top.boxes[2, 0].BackColor != cube.top.boxes[1, 1].BackColor ||
                cube.top.boxes[2, 2].BackColor != cube.top.boxes[1, 1].BackColor
                )
            {   // While this step isn't done

                // Go through certain cases to place the top in the right place for the algorithm to solve it
                if (cube.top.boxes[0, 0].BackColor != cube.top.boxes[1, 1].BackColor &&
                cube.top.boxes[0, 2].BackColor != cube.top.boxes[1, 1].BackColor &&
                cube.top.boxes[2, 0].BackColor != cube.top.boxes[1, 1].BackColor &&
                cube.top.boxes[2, 2].BackColor == cube.top.boxes[1, 1].BackColor)
                {
                    topRight();
                }
                else if (cube.top.boxes[0, 0].BackColor != cube.top.boxes[1, 1].BackColor &&
                cube.top.boxes[0, 2].BackColor == cube.top.boxes[1, 1].BackColor &&
                cube.top.boxes[2, 0].BackColor != cube.top.boxes[1, 1].BackColor &&
                cube.top.boxes[2, 2].BackColor != cube.top.boxes[1, 1].BackColor)
                {
                    topRight();
                    topRight();
                }
                else if (cube.top.boxes[0, 0].BackColor == cube.top.boxes[1, 1].BackColor &&
                cube.top.boxes[0, 2].BackColor != cube.top.boxes[1, 1].BackColor &&
                cube.top.boxes[2, 0].BackColor != cube.top.boxes[1, 1].BackColor &&
                cube.top.boxes[2, 2].BackColor != cube.top.boxes[1, 1].BackColor)
                {
                    topLeft();
                }
                else if (cube.top.boxes[0, 0].BackColor == cube.top.boxes[1, 1].BackColor &&
                cube.top.boxes[0, 2].BackColor == cube.top.boxes[1, 1].BackColor &&
                cube.top.boxes[2, 2].BackColor != cube.top.boxes[1, 1].BackColor &&
                cube.top.boxes[2, 0].BackColor != cube.top.boxes[1, 1].BackColor)
                {
                    topRight();
                }
                else if (cube.top.boxes[0, 0].BackColor == cube.top.boxes[1, 1].BackColor &&
                cube.top.boxes[0, 2].BackColor != cube.top.boxes[1, 1].BackColor &&
                cube.top.boxes[2, 2].BackColor != cube.top.boxes[1, 1].BackColor &&
                cube.top.boxes[2, 0].BackColor == cube.top.boxes[1, 1].BackColor)
                {
                    topRight();
                    topRight();
                }
                // The peices will be in the right position for the algorithm now 
                yellowFace();
            }
            cube.delay = fast;  // Go fast again 
        }

        /// <summary>
        /// Solves the top cross of the cube
        /// </summary>
        private void solveTopCross() {
            cube.delay = slow;  // Go slow so the user can see
            while (cube.top.boxes[0, 1].BackColor != cube.top.boxes[1, 1].BackColor ||
                cube.top.boxes[1, 0].BackColor != cube.top.boxes[1, 1].BackColor ||
                cube.top.boxes[1, 2].BackColor != cube.top.boxes[1, 1].BackColor ||
                cube.top.boxes[2, 1].BackColor != cube.top.boxes[1, 1].BackColor)
            {   // While this step isn't done

                // Run through some of the possible cases and align them for the algoritm
                if (cube.top.boxes[0, 1].BackColor == cube.top.boxes[1, 1].BackColor &&
                    cube.top.boxes[1, 2].BackColor == cube.top.boxes[1, 1].BackColor)
                {
                    topLeft();
                }
                else if (cube.top.boxes[1, 2].BackColor == cube.top.boxes[1, 1].BackColor &&
                    cube.top.boxes[2, 1].BackColor == cube.top.boxes[1, 1].BackColor)
                {
                    topLeft();
                    topLeft();
                }
                else if (cube.top.boxes[1, 0].BackColor == cube.top.boxes[1, 1].BackColor &&
                    cube.top.boxes[2, 1].BackColor == cube.top.boxes[1, 1].BackColor)
                {
                    topRight();
                }
                // Now that everything is in place do the algorithm
                yellowCross();
            }
            cube.delay = fast;  // Go fast again
        }

        /// <summary>
        /// Solves the middle layer of the cube
        /// </summary>
        private void solveEdges() {
            cube.delay = slow;  // Go slow so the user can see
            while (cube.front.boxes[1, 0].BackColor != cube.front.boxes[1, 1].BackColor ||
                cube.front.boxes[1, 2].BackColor != cube.front.boxes[1, 1].BackColor ||
                cube.left.boxes[1, 0].BackColor != cube.left.boxes[1, 1].BackColor ||
                cube.left.boxes[1, 2].BackColor != cube.left.boxes[1, 1].BackColor ||
                cube.back.boxes[1, 0].BackColor != cube.back.boxes[1, 1].BackColor ||
                cube.back.boxes[1, 2].BackColor != cube.back.boxes[1, 1].BackColor ||
                cube.right.boxes[1, 0].BackColor != cube.right.boxes[1, 1].BackColor ||
                cube.right.boxes[1, 2].BackColor != cube.right.boxes[1, 1].BackColor)
            {   // While this step isn't solved
                for (int x = 0; x < 4; x++)
                {   // 4 sides needing solving
                    for (int i = 0; i < 4; i++)
                    {   // 4 sides with possible peices to move
                        if (cube.front.boxes[0, 1].BackColor == cube.front.boxes[1, 1].BackColor)
                        {   // If the front top center matches the center
                            if (cube.top.boxes[2, 1].BackColor == cube.left.boxes[1, 1].BackColor)
                            {   // If it needs to go left
                                edgeLeft(); // Put it in place
                                i--;    // Keep running through the sides because the algorithm can mess it up
                            }
                            else if (cube.top.boxes[2, 1].BackColor == cube.right.boxes[1, 1].BackColor)
                            {   // If it needs to go right
                                edgeRight();    // Put it in place
                                i--;    // Keep running through the sides because the algorithm can mess it up
                            }
                            else if (cube.top.boxes[2, 1].BackColor == cube.top.boxes[1, 1].BackColor)
                            {   // If the edge that matches the center is on top
                                if (cube.front.boxes[1, 0].BackColor != cube.front.boxes[1, 1].BackColor &&
                                    cube.left.boxes[1, 2].BackColor != cube.left.boxes[1, 1].BackColor)
                                {   // If it also matches the left
                                    edgeLeft(); // Put ut in place
                                    topRight();
                                }
                                else if (cube.front.boxes[1, 2].BackColor != cube.front.boxes[1, 1].BackColor &&
                                    cube.right.boxes[1, 0].BackColor != cube.left.boxes[1, 1].BackColor)
                                {   // If it also matches the right
                                    edgeRight();    // Put it in place
                                    topLeft();
                                }
                            }
                        }   // End if
                        topLeft();  // Go to the next face that will have edges that need to be placed
                    }   // End for
                    cube.rotate("right");   // Go to the next face 
                }   // End for
            }   // End while
            cube.delay = fast;  // Go fast again
        }

        /// <summary>
        /// Solves the bottom cross of the cube
        /// </summary>
        private void solveBottomCross() {
            int counter = 0;
            cube.delay = slow;  // Go slow so the user can see
            while (cube.bottom.boxes[0, 1].BackColor != cube.bottom.boxes[1, 1].BackColor ||
                cube.bottom.boxes[1, 0].BackColor != cube.bottom.boxes[1, 1].BackColor ||
                cube.bottom.boxes[1, 2].BackColor != cube.bottom.boxes[1, 1].BackColor ||
                cube.bottom.boxes[2, 1].BackColor != cube.bottom.boxes[1, 1].BackColor)
            {   // While this step isn't done
                for (int x = 0; x < 4; x++)
                {   // Go through each case and place the edge in the appropriate place for the place edge method
                    if (cube.front.boxes[0, 1].BackColor == cube.bottom.boxes[1, 1].BackColor)
                    {
                        frontRight();
                        rightRight();
                        frontLeft();
                        topLeft();
                        rightLeft();
                        frontLeft();
                        placeEdge();
                    }
                    else if (cube.front.boxes[1, 0].BackColor == cube.bottom.boxes[1, 1].BackColor)
                    {
                        leftLeft();
                        topRight();
                        leftRight();
                        placeEdge();
                    }
                    else if (cube.front.boxes[1, 2].BackColor == cube.bottom.boxes[1, 1].BackColor)
                    {
                        rightRight();
                        topLeft();
                        rightLeft();
                        placeEdge();
                    }
                    else if (cube.front.boxes[2, 1].BackColor == cube.bottom.boxes[1, 1].BackColor)
                    {
                        frontRight();
                        leftLeft();
                        topRight();
                        leftRight();
                        frontLeft();
                        placeEdge();
                    }
                }   // End for
                cube.rotate("right");   // Next face
                counter++;
                if (counter > 16)   // If it's gone through all the possibilities except the top
                {
                    placeEdge();
                    counter = 0;    
                }
            }   // End while
            cube.delay = fast;  // Go fast again
        }

        /// <summary>
        /// Places an edge that is on the top to the bottom in the correct spot
        /// </summary>
        private void placeEdge() {
            while (cube.top.boxes[2, 1].BackColor != cube.bottom.boxes[1, 1].BackColor)
            {   // Get the  edge on top in the right place
                topLeft();
            }
            while (cube.front.boxes[0, 1].BackColor != cube.front.boxes[1, 1].BackColor)
            {   // Match the edge with it's center
                topLeft();
                cube.rotate("right");
            }
            frontLeft();    // Place the edge
            frontLeft();
        }

        /// <summary>
        /// Solves the bottom face of the cube
        /// </summary>
        private void solveBottomFace() {
            cube.delay = slow;  // Go slow so the user can see
            while (cube.bottom.boxes[0, 0].BackColor != cube.bottom.boxes[1, 1].BackColor ||
                cube.bottom.boxes[0, 2].BackColor != cube.bottom.boxes[1, 1].BackColor ||
                cube.bottom.boxes[2, 0].BackColor != cube.bottom.boxes[1, 1].BackColor ||
                cube.bottom.boxes[2, 2].BackColor != cube.bottom.boxes[1, 1].BackColor)
            {   // While this step isn't solved
                for (int x = 0; x < 5; x++)
                {   // Go through all the faces except the bottom
                    if (cube.front.boxes[0, 0].BackColor == cube.bottom.boxes[1, 1].BackColor)
                    {   // First case
                        if (cube.left.boxes[0, 2].BackColor == cube.front.boxes[1, 1].BackColor)
                        {   // Variation 1
                            topLeft();  // Place the corner
                            rightRight();
                            topRight();
                            rightLeft();
                        }
                        else if (cube.left.boxes[0, 2].BackColor == cube.left.boxes[1, 1].BackColor)
                        {   // Variation 2
                            frontRight();  // Place the corner
                            topRight();
                            frontLeft();
                        }
                        else if (cube.left.boxes[0, 2].BackColor == cube.right.boxes[1, 1].BackColor)
                        {   // Variation 3
                            topLeft();  // Place the corner
                            topLeft();
                            backRight();
                            topRight();
                            backLeft();
                        }
                        else if (cube.left.boxes[0, 2].BackColor == cube.back.boxes[1, 1].BackColor)
                        {   // Variation 4
                            topRight();  // Place the corner
                            leftRight();
                            topRight();
                            leftLeft();
                        }
                    }   // End first case
                    else if (cube.front.boxes[0, 2].BackColor == cube.bottom.boxes[1, 1].BackColor)
                    {   // Second case
                        if (cube.right.boxes[0, 0].BackColor == cube.front.boxes[1, 1].BackColor)
                        {   // Variation 1
                            topRight();  // Place the corner
                            leftLeft();
                            topLeft();
                            leftRight();
                        }
                        else if (cube.right.boxes[0, 0].BackColor == cube.left.boxes[1, 1].BackColor)
                        {   // Variation 2
                            topRight();  // Place the corner
                            topRight();
                            backLeft();
                            topLeft();
                            backRight();
                        }
                        else if (cube.right.boxes[0, 0].BackColor == cube.right.boxes[1, 1].BackColor)
                        {   // Variation 3
                            frontLeft();  // Place the corner
                            topLeft();
                            frontRight();
                        }
                        else if (cube.right.boxes[0, 0].BackColor == cube.back.boxes[1, 1].BackColor)
                        {   // Variation 4
                            topLeft();  // Place the corner
                            rightLeft();
                            topLeft();
                            rightRight();
                        }
                    }   // End second case
                    else if (cube.front.boxes[2, 0].BackColor == cube.bottom.boxes[1, 1].BackColor)
                    {   // Thrid case
                        frontRight();   // Change it to the fisrt or second case
                        topRight();
                        frontLeft();
                    }
                    else if (cube.front.boxes[2, 2].BackColor == cube.bottom.boxes[1, 1].BackColor)
                    {   // Fourth case
                        frontLeft();   // Change it to the fisrt or second case
                        topLeft();
                        frontRight();
                    }
                    else if (cube.top.boxes[2, 0].BackColor == cube.bottom.boxes[1, 1].BackColor)
                    {   // Fifth case
                        while (cube.bottom.boxes[0, 0].BackColor == cube.top.boxes[2, 0].BackColor)
                        {   // Place the peice in the right spot
                            topLeft();
                            cube.rotate("right");
                        }
                        leftLeft(); // Place the corner on the bottom face
                        topRight();
                        leftRight();
                    }
                    cube.rotate("right");
                }   // End for
            }   // End while
            cube.delay = fast;  // Go fast again
        }

        private void NudSpeed_ValueChanged(object sender, EventArgs e) {
            slow = (int)nudSpeed.Value;
        }

        /// <summary>
        /// Scramble the cube
        /// </summary>
        /// <param name="length"></param>   How many moves to do when scrambling
        public void scramble(int length)
        {
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {   // Repeat for the number of moves given
                int move = random.Next(1, 17);  // Generate a random number

                // According to the number generated do a move
                if (move == 1)
                {
                    topLeft();
                }
                else if (move == 2)
                {
                    topRight();
                }
                else if (move == 3)
                {
                    frontLeft();
                }
                else if (move == 4)
                {
                    frontRight();
                }
                else if (move == 5)
                {
                    leftLeft();
                }
                else if (move == 6)
                {
                    leftRight();
                }
                else if (move == 7)
                {
                    rightLeft();
                }
                else if (move == 8)
                {
                    rightRight();
                }
                else if (move == 9)
                {
                    backLeft();
                }
                else if (move == 10)
                {
                    backRight();
                }
                else if (move == 11)
                {
                    bottomLeft();
                }
                else if (move == 12)
                {
                    bottomRight();
                }
                else if (move == 13)
                {
                    cube.rotate("up");
                }
                else if (move == 14)
                {
                    cube.rotate("down");
                }
                else if (move == 15)
                {
                    cube.rotate("left");
                }
                else if (move == 16)
                {
                    cube.rotate("right");
                }
            }
        }

        private void nudScramble_ValueChanged(object sender, EventArgs e) {
            scrambleCounter = (int)nudScramble.Value;
        }

        private void btnScramble_Click(object sender, EventArgs e) {
            cube.delay = slow;
            scramble(scrambleCounter);
            cube.delay = fast;
        }

        /// <summary>
        /// Update the listbox with the newest move
        /// </summary>
        private void updateMoves() {
            lstboxMoves.Items.Add(currentMove); // Add the newest move to the listbox
            lstboxMoves.Refresh();  // Refresh the listbox
        }

        private void BtnInfo_Click(object sender, EventArgs e) {
            frmMoves frmMoves = new frmMoves();
            frmMoves.Show();
        }
    }
}