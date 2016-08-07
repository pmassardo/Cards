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

namespace Durak
{
    public partial class frmGetPlayerData : Form
    {

        private const string MESSAGE_BOX_TITLE = "Get Information Error!!" ;
        private const string MESSAGE_BOX_MESSAGE = "\nIf you wish to continue and enter a name click OK.\n If you wish to not enter a name and end the game Cancel.";

        /// <summary>
        /// fieldPlayer - player object that will be validate and is set when this form is called
        ///               in the constructor
        /// </summary>
        private DurakPlayer fieldPlayer = null;

        /// <summary>
        /// isFieldEndGame - instance variable to determine if the game should end.
        /// </summary>
        private bool isFieldEndGame = false;

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
        /// frmGetPlayerData - parameterized constructor passing in a player object
        /// </summary>
        /// <param name="player"></param>
        internal frmGetPlayerData(DurakPlayer player)
        {

            // set the player object from the calling form 
            this.fieldPlayer = player;

            InitializeComponent();
        }

        private void frmGetPlayerData_Load(object sender, EventArgs e)
        {
            txtName.Text = fieldPlayer.Name;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {

            try // initiate try
            {
                // assign the value in the textbox to the name property
                fieldPlayer.Name = txtName.Text;

                // and close this form returning control to the calling form
                this.Close();

            }
            catch (Exception exception)
            {               

                // if an exception is thrown show it to the user to make a decision
                if (MessageBox.Show(this, exception.Message + MESSAGE_BOX_MESSAGE, MESSAGE_BOX_TITLE, MessageBoxButtons.OKCancel)== DialogResult.Cancel)
                {
                    // if the player opts to cancel

                    // set the isFieldEndGame to end the game when control is 
                    // returned to the calling form
                    isFieldEndGame =true;

                    // and close this form returning control to the calling form
                    this.Close();
                }          
            }
        }
    }
}
