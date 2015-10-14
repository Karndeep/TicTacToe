/*
 * Program Name: Assigment 2 Tic Tac Toe Game
 *
 * Purpose:This game is for 2 players and you play tic tac toe.
 * The first user is X and the second user is O.
 * Once the game is complete the user will be prompt to start a
 * new game.
 *
 * Created: Karndeep Kahlon Oct 2015
 * 
 * Revision history:
 * Karndeep Kahlon Oct 2015
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeKKAssigment
{
    public partial class Form1 : Form
    {
        //Declaration & Initialize
        int playerX = 1;
        int playerO = 2;
        int player;
        string endGameMessage  = "Tie Game!";
        int[] gridArray = new int[9];
        int[,] winningCombo = new int[,]{
                           {0,1,2},{3,4,5},{6,7,8},
                           {0,3,6},{1,4,7},{2,5,8},
                           {0,4,8},{2,4,6}};
        public Form1()
        {
            InitializeComponent();
            //Setting first Move to player X
            player = playerX;

        }

        private void picturebox_click(object sender, EventArgs e)
        {
            //PictureClick is the declared as the picture that was clicked
            PictureBox PictureClick = (PictureBox)sender;
            //Checks if image is blank if yes then error message(For double click)
            if (PictureClick.Image == null)
            {
                //Sets the image to x or o depending on the player value
                if (player == playerX)
                {
                    PictureClick.Image = Properties.Resources.x;
                    player = playerO;
                }
                else
                {
                    PictureClick.Image = Properties.Resources.o;
                    player = playerX;
                }
                //Calls methods
                insertIntoArray(getControlByName(PictureClick));
                gameResult();

            }
            else
            {
                MessageBox.Show("This box has already been clicked!", "Error!");
            }
        }
        //This method gets the control for picture by name
        private string getControlByName(Control ctrl)
        {
            return ctrl.Name;
        }
        //This method is to add a value to the 
        //array which is either 1 or 2 depending on player.
        private void insertIntoArray(string name)
        {
            //Use the name of my pictureBox which I named A1,A2,A3 etc
            switch (name)
            {
                case "A1":
                    gridArray[0] = player;
                    break;
                case "A2":
                    gridArray[1] = player;
                    break;
                case "A3":
                    gridArray[2] = player;
                    break;
                case "B1":
                    gridArray[3] = player;
                    break;
                case "B2":
                    gridArray[4] = player;
                    break;
                case "B3":
                    gridArray[5] = player;
                    break;
                case "C1":
                    gridArray[6] = player;
                    break;
                case "C2":
                    gridArray[7] = player;
                    break;
                case "C3":
                    gridArray[8] = player;
                    break;
            }
        }
        //This method is to find the game result if the user has won
        private void gameResult()
        {   //Loops 9 times for each row 
            for (int i = 0; i < winningCombo.GetLength(0); i++)
            {   //Counter to check if they won.
                int WinnerInput = 0;
                //Loops 3 times for each column
                for (int k = 0; k < winningCombo.GetLength(1); k++)
                {
                    //Game spot is the spot of the winning array
                   int gameSpot = winningCombo[i, k];
                    //Checks if grid array is equal to player value
                    if (gridArray[gameSpot] == player)
                    {
                        WinnerInput++;
                        //If counter hit 3 then user has won.
                        if (WinnerInput == 3)
                        {   //Determine which player has won
                            if(player == playerO)
                            {
                                endGameMessage = "Player X has won";
                            }
                            else if(player == playerX)
                            {
                                endGameMessage = "Player O has won";
                            }
                            //Calling method with string endGameMessage
                            showConfirmDialog(endGameMessage);
                        }                        
                    }
                }
            }
            //If no one has won then checks for tie
            tieCheck();
        }
        //Method for checking if tie
        private void tieCheck()
        {
            //Declaration & Initialize
            int count = 0;
                //For is going through each gridArray value but only 
                //adds to counter if gridArray has value.
                for (int i = 0; i < gridArray.Length; i++)
                {
                     if (gridArray[i] !=0)
                     {
                         count++;
                     }
                }  
            //If count is 9 then Game is tied.
            if (count >= 9)
            {
                showConfirmDialog(endGameMessage);
            }
        }
        //Method for Prompting the user
        private void showConfirmDialog(string results)
        {
            DialogResult result;

            result = MessageBox.Show(results, "Would you like to play again?", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {   //Calls method
                resetBoard();
            }
            else
            {
                Application.Exit();
            }
        }
        //Method that reset the player,endGameMessage array and picture image.
        private void resetBoard()
        {
            //Resets all images for PictureBoxes
            foreach (PictureBox pic in this.Controls)
            {
                pic.Image = null;
            }
            player = playerX;

            endGameMessage = "Game is Tied";

            //Reset Array and sets default values to 0;
            for (int i = 0; i < gridArray.Length; i++)
            {
                     gridArray[i] = 0;
            }
        }
    }
}
