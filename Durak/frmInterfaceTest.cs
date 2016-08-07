using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardLibrary;
using DurakLibrary;

namespace Durak
{
    public partial class frmInterfaceTest : Form
    {
        public frmInterfaceTest()
        {
            InitializeComponent();
        }

        private void frmInterfaceTest_Load(object sender, EventArgs e)
        {
            Players fieldPlayers = new Players();
            DurakDeck fieldDeck = new DurakDeck(DeckSize.ThirtySix);
            fieldDeck.Shuffle();
            Card cardTrump;
            #region get trump
            // set the trump
            cardTrump = fieldDeck.DrawNext();
            // set the static variable
            Card.TrumpSuit = cardTrump.SuitValue;
            cardTrump.IsFaceUp = true;
            PictureBox newPictureBox;
            newPictureBox = new PictureBox();
            newPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            newPictureBox.Location = new Point(20, 210);
            newPictureBox.Size = new Size(100, 150);
            newPictureBox.Image = cardTrump.CardImage;
            newPictureBox.Tag = cardTrump;

            this.Controls.Add(newPictureBox);
            newPictureBox.Select();
            newPictureBox.BringToFront();
            Label lblTrump = new Label();
            lblTrump.Location = new Point(20, 192);
            lblTrump.Text = "Trump Card:";
            this.Controls.Add(lblTrump);
            #endregion
            #region add player
            // create a new player
            DurakPlayer newPlayer = new DurakPlayer();
            newPlayer.Name = "TestGuy";
            // add the human to the players collection
            fieldPlayers.Add(newPlayer);
            List<Card> newHand = new List<Card>();
            int lastX = 330;
            int lastY = 430;
            for (int handIndex = 0; handIndex < 6; handIndex++)
            {
                Card theCard = fieldDeck.DrawNext();
                newHand.Add(theCard);
                theCard.IsFaceUp = true;

                newPictureBox = new PictureBox();
                newPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                newPictureBox.Location = new Point(lastX, lastY);
                newPictureBox.Size = new Size(100, 150);
                newPictureBox.Image = theCard.CardImage;
                newPictureBox.Tag = theCard;
                newPictureBox.MouseEnter += new System.EventHandler(this.MouseEnterCard);
                newPictureBox.MouseLeave += new System.EventHandler(this.MouseLeaveCard);
                newPictureBox.Click      += new System.EventHandler(this.MouseClickCard);

                this.Controls.Add(newPictureBox);
                lastX += 20;
                newPictureBox.Select();
                newPictureBox.BringToFront();
            }
            #endregion
            #region add computer
            // add the computer  to the players collection
            fieldPlayers.Add(new ComputerPlayer("Mr. Computer"));
            newHand = new List<Card>();
            lastX = 330;
            lastY = 30;
            for (int handIndex = 0; handIndex < 6; handIndex++)
            {
                Card theCard = fieldDeck.DrawNext();
                newHand.Add(theCard);
                theCard.IsFaceUp = false;

                newPictureBox = new PictureBox();
                newPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                newPictureBox.Location = new Point(lastX, lastY);
                newPictureBox.Size = new Size(100, 150);
                newPictureBox.Image = theCard.CardImage;
                newPictureBox.Tag = theCard;

                this.Controls.Add(newPictureBox);
                lastX += 20;
                newPictureBox.Select();
                newPictureBox.BringToFront();
            }
            #endregion
        }

        private void MouseEnterCard(object sender, EventArgs e) //moves a card up when the mouse leaves it
        {
            ((PictureBox)sender).Location = new Point(((PictureBox)sender).Location.X, ((PictureBox)sender).Location.Y - 10);
        }
        private void MouseLeaveCard(object sender, EventArgs e) //moves a card back down when the mouse leaves it
        {
            ((PictureBox)sender).Location = new Point(((PictureBox)sender).Location.X, ((PictureBox)sender).Location.Y + 10);
        }
        private void MouseClickCard(object sender, EventArgs e) //this should probably be used for when the player clicks on a card
        {
            
        }

        #region Menu events
        private void mnuNewGame_Click(object sender, EventArgs e)
        {
            frmNewGame newGameForm = new frmNewGame();
            newGameForm.Show(this);

        }
        private void mnuStatistics_Click(object sender, EventArgs e)
        {

        }
        private void mnuPlayLogs_Click(object sender, EventArgs e)
        {

        }
        private void mnuOptions_Click(object sender, EventArgs e)
        {

        }
        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void mnuHowToPlay_Click(object sender, EventArgs e)
        {

        }
        private void mnuAbout_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
