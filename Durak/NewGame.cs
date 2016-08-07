/**
 * Author:      A. Paul Massardo
 * Program:     Group Project
 * Date:        14-Apr-2015
 * Description: frmNewGame is the form that controls the Durak game's settings for play.
 * 
*/

// using-import-includes
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DurakLibrary;

// namespace
namespace Durak
{
    public partial class frmNewGame : Form
    {

        // private message constants
        private const string MESSAGE_BOX_TITLE = "Get Information Error!!";
        private const string MESSAGE_BOX_MESSAGE = "\nIf you wish to continue and enter a name click OK.\n If you wish to not enter a name and end the game Cancel.";

        /// <summary>
        /// isFieldEndGame - instance variable to hold the current deck size.
        /// </summary>
        DeckSize currentDeckSize;

        /// <summary>
        /// isFieldEndGame - instance variable to hold the player's name.
        /// </summary>
        string playerName = string.Empty;

        /// <summary>
        /// isFieldEndGame - instance variable to determine if the game should be advanced.
        /// </summary>
        bool advanced = false;

        /// <summary>
        /// isFieldEndGame - instance variable to determine if the game should end.
        /// </summary>
        private bool isFieldEndGame = false;

        /// <summary>
        ///  isAdvanced - is the game advanced or not
        /// </summary>
        public bool isAdvanced
        {
            get { return advanced; }
        }

        /// <summary>
        /// PlayerName - property to return the player's name
        /// </summary>
        public string PlayerName
        {
            get { return playerName; }

        }

        /// <summary>
        /// IsEndGame - property procedure to tell the calling form if the game should continue.
        /// </summary>
        internal bool IsEndGame
        {
            get
            {
                return isFieldEndGame;
            }

        }

        /// <summary>
        /// CurrentDeckSize - property to return the current deck size
        /// </summary>
        public DeckSize CurrentDeckSize
        {
            get { return currentDeckSize; }
        }

        /// <summary>
        /// frmNewGame -default constructor
        /// </summary>
        public frmNewGame()
        {
            InitializeComponent();
        }

        /// <summary>
        /// btnStartGame_Click - event to set the properties and return to the calling form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartGame_Click(object sender, EventArgs e)
        {

            // set the currentDeckSize field
            currentDeckSize = (DeckSize) cboDeckSize.SelectedValue;

            // set the playerName field
            playerName = txtPlayerName.Text;

            // set the advanced field
            advanced = chkAdvanced.Checked;
            
            // cloase the form
            this.Close();

        }

        /// <summary>
        /// frmNewGame_Load - event that load the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmNewGame_Load(object sender, EventArgs e)
        {

            // load the cboRank combo box
            cboDeckSize.DataSource = Enum.GetValues(typeof(DeckSize));

        }

        private void frmNewGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            // check to see if anything has been entered for the name
            if (playerName.Trim().Length == 0)
            {
                // display the message box
                if (MessageBox.Show(this, MESSAGE_BOX_MESSAGE, MESSAGE_BOX_TITLE, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    // if the player opts to cancel

                    // set the isFieldEndGame to end the game when control is 
                    // returned to the calling form
                    isFieldEndGame = true;

                    // and close this form returning control to the calling form
                    e.Cancel = false;

                }
                else
                {

                    // set the isFieldEndGame to end the game when control is 
                    // returned to the calling form
                    isFieldEndGame = true;

                    // select the textbox
                    txtPlayerName.Select();

                    // cancel the close
                    e.Cancel = true;
                }
            }
        }
    }
}
