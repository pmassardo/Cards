/**
 * Author:      A. Paul Massardo
 * Program:     CardBox CardDisplay
 * Date:        23-Mar-2015
 * Description: CardDisplay is a user control that has the appropriate properties and controls to
 *                          display playing card that could be use for a variety of card games.
 * 
*/

// using-import-includes
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// namespace
namespace CardBox
{
    /// <summary>
    ///  CardDisplay is a user control that has the appropriate properties and controls to display playing card that could be use for a variety of card games.
    /// </summary>
    public partial class CardDisplay: UserControl
    {
        /// <summary>
        /// CARD_BACK - card back image name
        /// </summary> 
        private const string CARD_BACK = "CB";

        /// <summary>
        /// Click Event - occurs when the usercontrol is clicked
        /// </summary>
        public new event EventHandler Click;

        /// <summary>
        /// CardFlipped - occurs when a card is flipped
        /// </summary>
        public event EventHandler CardFlipped;

        /// <summary>
        /// mySuit - class level variable to hold the suit
        /// </summary>
        Suit mySuit;

        /// <summary>
        /// myRank - class level variable to hold the rank
        /// </summary>
        Rank myRank;

        /// <summary>
        /// isFaceUp - class level variable to hold the card disposition
        /// </summary>
        bool isFaceUp;

        /// <summary>
        /// CardDisplay - default constructor that initializes the field level variables
        /// </summary>
        public CardDisplay()
        {
            InitializeComponent();

            // initialize the class level variable for the suit
            mySuit = Suit.Hearts;

            // initialize the class level variable for the rank
            myRank = Rank.Ace;

            // initialize the class level variable for the isFaceUp
            isFaceUp = false;

            // update the card image
            updateCard();
           
            // did not use the attribute accessor because it would fire the updateCard multiple times

        }

        /// <summary>
        /// Suit - field instance accessor and mutator for the cards suit.
        /// </summary>
        public Suit Suit
        {
            get { return mySuit; }
            set { mySuit = value; //updateCard(); 
            }
        }
        
        /// <summary>
        /// Rank - field instance accessor and mutator for the cards rank.
        /// </summary>
        public Rank Rank
        {
            get { return myRank; }
            set { myRank = value; //updateCard(); 
            }
        }

        /// <summary>
        /// IsFaceUp - field instance accessor and mutator whether the card is face up or down.
        /// </summary>
        public bool IsFaceUp
        {
            get { return isFaceUp; }
            set
            {
                // if the value has changed
                if (isFaceUp != value)
                {
                    // set the value
                    isFaceUp = value;

                    // update the image
                    updateCard();

                    // if the CardFlipped event is not null
                    if (CardFlipped != null)
                    {
                        // raise the CardFlipped event
                        CardFlipped(this, EventArgs.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// updateCard - private method to update the card image based on the local field variables
        /// </summary>
        private void updateCard()
        {
            // if the card is face up
            if (isFaceUp == true)
            {

                // get the image based on the rank and suit
                pbxPictureBox.Image = Properties.Resources.ResourceManager.GetObject(mySuit.ToString() + myRank.ToString()) as Image;
            }
            else
            {
                // or, set the image to the card back
                pbxPictureBox.Image = Properties.Resources.ResourceManager.GetObject(CARD_BACK) as Image;
            }

        }

        /// <summary>
        /// ToolTip - access tool tip message
        /// </summary>
        public string ToolTip
        {
            get
            {
                return CardDisplayToolTip.GetToolTip(pbxPictureBox);
            }
            set
            {
                CardDisplayToolTip.SetToolTip(pbxPictureBox, value);
            }
        }


        /// <summary>
        /// ToolTip - access tool tip message
        /// </summary>
        public Image CardImage
        {
            get
            {
                return pbxPictureBox.Image;
            }
            set
            {
                pbxPictureBox.Image= value;
            }
        }



        /// <summary>
        /// ImageLicence - access image licence
        /// </summary>
        public static string ImageLicence
        {
            get
            {
                return (string)Properties.Resources.ResourceManager.GetObject("Licence");
            }
        }

        /// <summary>
        /// Rules - access Durak Rules
        /// </summary>
        public static string Rules
        {
            get
            {
                return (string)Properties.Resources.ResourceManager.GetObject("Rules");
            }
        }

        /// <summary>
        ///  pbxPictureBox_Click - private event that will raise the user controls click event
        /// </summary>
        /// <param name="sender">object</param>
        /// <param name="e">EventArgs</param>
        private void pbxPictureBox_Click(object sender, EventArgs e)
        {
            // if the Click event is not null
            if (Click != null)
            {
                // raise the event
                Click(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// ToString - overrides the bases class ToString to display a card's state
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // initialize the variable to the card down state
            string returnvalue = "Face Down";

            // if the card is face up
            if (IsFaceUp == true)
            {
                // set the variable to the rank and suit
                returnvalue = this.Rank.ToString() + " of " + this.Suit.ToString();
            }

            // return the value
            return returnvalue;

        }
    }
}
