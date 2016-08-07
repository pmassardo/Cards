/**
 * Author:      A. Paul Massardo
 * Program:     Group Project
 * Date:        14-Apr-2015
 * Description: frmDurakGame is the form that controls the majority of the game play for the Durak game.
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
using CardLibrary;

// namespace
namespace Durak
{
    public partial class frmDurakGame : Form
    {

        // class level vairable declarations

        // holds tha players
        Players fieldPlayers = new Players();

        // holds the current deck
        DurakDeck fieldDeck;

        // holds the current deck size
        DeckSize currentDeckSize;

        // holds the cards on the table
        List<Card> tableCards = new List<Card>();

        // holds the number of times a player has successfully defended
        int defendCount = 0;

        // holds the index of the current attacker
        int indexOfAttacker = -1;

        // holds the index of the current defender
        int indexOfDefender = -1;

        // constants
        // holds the index of the human player
        const int PLAYER_HUMAN = 0;

        // holds the index of the computer player
        const int PLAYER_COMPUTER = 1;

        /// <summary>
        /// frmDurakGame - default constructor
        /// </summary>
        public frmDurakGame()
        {
            InitializeComponent();
        }

        /// <summary>
        /// frmTest_Load - event that happens when the form first opens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTest_Load(object sender, EventArgs e)
        {

            // load the game settings
            // which will have a form
            // appear to ask the user
            // about the settings they
            // would like set
            LoadSettings();

            // deals the cards to the players
            Deal();

        }

        /// <summary>
        /// LoadSettings - loads the setting based on the data set by the user in the frmNewgame
        /// </summary>
        private void LoadSettings()
        {

            // create a new player
            DurakPlayer newPlayer = new DurakPlayer();

            // create a new instance of frmNewGame
            frmNewGame playerForm = new frmNewGame();

            // show the player form modally 
            // this is where the player data will be entered.
            playerForm.ShowDialog(this);

            // if the player has chosen to end the game
            if (playerForm.IsEndGame)
            {
                // then close the form
                this.Close();
            }

            // assign the deck size
            currentDeckSize = playerForm.CurrentDeckSize;

            // add the human to the players collection
            fieldPlayers.Add(playerForm.PlayerName);

            // add the computer  to the players collection
            fieldPlayers.Add(new ComputerPlayer("Mr. Computer", playerForm.isAdvanced));

            // set the lblAdvance to what the player selected
            lblAdvanced.Text = (playerForm.isAdvanced) ? "Advanced" : "Regular";

            // set the group tag to the appropriate
            // player index
            grpComputer.Tag = PLAYER_COMPUTER;
            grpPlayer.Tag = PLAYER_HUMAN;

            // set the group names
            grpComputer.Text = fieldPlayers[PLAYER_COMPUTER].Name;
            grpPlayer.Text = fieldPlayers[PLAYER_HUMAN].Name;

        }

        /// <summary>
        /// DistributeCards - iterates through the players and gives cards until the maximum
        ///                   for a Durak hand is reached
        /// </summary>
        private void DistributeCards()
        {

            // declare a new card
            Card currentCard;

            // loop for the total number of cards that can be in a durak hand
            for (int index = 0; index < DurakHand.HAND_CARD_MAXIMUM_DEALT; index++)
            {
                // for each player
                foreach (DurakPlayer player in fieldPlayers)
                {
                    // if the hand is not already full
                    if (!player.Hand.IsFieldHandFull)
                    {

                        // assign the value
                        currentCard = fieldDeck.DrawNext();

                        // check to see if the card is null
                        if (currentCard != null)
                        {
                            // deal the another card
                            player.Hand.Add(currentCard);
                        }
                        else
                        {
                            // if the talon still has the card and
                            // there are no other cards in the deck
                            // the talon card must be distributed
                            if (grpTalon.Controls.Count > 0)
                            {
                                // get the card from the control in the talon
                                currentCard = (CardLibrary.Card)grpTalon.Controls[0].Tag;

                                // add the card to the current players hand
                                player.Hand.Add(currentCard);

                                // remove the card and control from the talon group box
                                // remove the card from the talon
                                RemoveCardControl(currentCard, grpTalon);

                                // if the current player is the computer
                                if (player is ComputerPlayer)
                                {
                                    // load it into its group box
                                    LoadCardControl(currentCard, grpComputer, 6);
                                }
                                else
                                {
                                    // load it into the player's group box
                                    LoadCardControl(currentCard, grpPlayer, 6);
                                }
                            }
                        }
                    }
                }
            }

            // show the current card count to the user
            lblCount.Text = fieldDeck.Count.ToString() + " - Deck Card Count";

        }

        /// <summary>
        /// Deal - calls distribute to deal the cards then iterates through the cards
        ///        to detrmine the lowest to determine who will attack first. It also
        ///        shuffles the deck, and determines trump
        /// </summary>
        private void Deal()
        {

            // declare a new current player
            DurakPlayer currentPlayer;

            // declare a new current card
            Card currentCard;

            // declare and initialize a byte variable
            byte lowestCardValue = 100;
            
            // create a new deck
            fieldDeck = new DurakDeck(currentDeckSize);

            // shuffle
            fieldDeck.Shuffle();

            // initial deal
            DistributeCards();

            // set the trump
            Card cardTrump = fieldDeck.DrawNext();
            
            // load the trump card into the talon
            LoadCardControl(cardTrump, grpTalon,6);

            // show the user what suit is trump
            lblTrump.Text = cardTrump.Suit +" are trump.";

            // set the static variable
            Card.TrumpSuit = cardTrump.SuitValue;

            // iterate through each player
            for (int indexPlayer = 0; indexPlayer < fieldPlayers.Count; indexPlayer++)
            {

                // set the current player
                currentPlayer = fieldPlayers[indexPlayer];

                // call the sort method
                currentPlayer.Hand.Sort();

                // loop through the players hand
                for (int indexCard = 0; indexCard < currentPlayer.Hand.Count; indexCard++)
                {

                    // set the current card
                    currentCard = currentPlayer.Hand[indexCard];

                    // determine the lowest trump to 
                    // determine who attacks first
                    if ((Card.TrumpSuit == currentPlayer.Hand[indexCard].SuitValue) &&
                        (currentCard.RankValue < lowestCardValue))
                    {
                        //store the dealer index
                        indexOfAttacker = indexPlayer;
                        //set the lowest card
                        lowestCardValue = currentCard.RankValue;
                    }

                    // if the current player is the computer
                    if (currentPlayer is ComputerPlayer)
                    {
                        // load the grpComputer with the current card
                        LoadCardControl(currentCard, grpComputer, 6);
                    }
                    else
                    {
                        // load the grpPlayer with the current card
                        LoadCardControl(currentCard, grpPlayer, 6);
                    }
                }
            }

            // if the current attacker is the computer
            if (fieldPlayers[indexOfAttacker] is ComputerPlayer)
            {
                // set the defender as the human
                indexOfDefender = PLAYER_HUMAN;

                // set the control names
                setNames(indexOfAttacker, grpComputer, indexOfDefender, grpPlayer);

            }
            else
            {

                // set the defender as the computer
                indexOfDefender = PLAYER_COMPUTER;

                // set the control names
                setNames(indexOfAttacker, grpPlayer, indexOfDefender, grpComputer);
            }

            // show the current talon card  count
            lblCount.Text = fieldDeck.Count.ToString() + " - Deck Card Count";


        }

        /// <summary>
        /// setNames - set the name of the attacker and defender and if the attacker is
        ///            the computer it calls the attack method
        /// </summary>
        /// <param name="attacker"></param>
        /// <param name="grpAttacker"></param>
        /// <param name="defender"></param>
        /// <param name="grpDefender"></param>
        private void setNames(int attacker, GroupBox grpAttacker, int defender, GroupBox grpDefender)
        {

            // set the attacker name
            grpAttacker.Text = fieldPlayers[attacker].Name + " Attack";

            // set the defender name
            grpDefender.Text = fieldPlayers[defender].Name + " Defend";

            // if the attacker is the computer
            if (attacker == PLAYER_COMPUTER)
            {
                // ATTACK!!!
                Attack(null);
            }

        }

        /// <summary>
        /// btnRestart_Click - handles the click event for the btnRestart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestart_Click(object sender, EventArgs e)
        {

            // clears the computer player
            fieldPlayers[PLAYER_COMPUTER].Hand.Clear();

            // clears the human player
            fieldPlayers[PLAYER_HUMAN].Hand.Clear();

            // clears the table/grpBattleField
            grpBattleField.Controls.Clear();

            // clears the grpComputer
            grpComputer.Controls.Clear();

            // clears the grpTalon
            grpTalon.Controls.Clear();

            // clears the grpPlayer
            grpPlayer.Controls.Clear();

            // redeals the game
            Deal();

        }

        /// <summary>
        /// RemoveCardControl - uses the instance of a card to remove the control from the GroupBox in which it currently resides.
        /// </summary>
        /// <param name="card"></param>
        /// <param name="box"></param>
        private void RemoveCardControl(CardLibrary.Card card, GroupBox box)
        {

            // loop the controls in the group box
            for (int indexControl = 0; indexControl < box.Controls.Count; indexControl++)
            {

                // get the card from the CardDisplay tag
                CardLibrary.Card currentCard = (CardLibrary.Card) ((CardBox.CardDisplay)(box.Controls[indexControl])).Tag;

                // if the control contains the same object as the 
                // the one passed in remove the control
                if (currentCard.Equals(card))
                {
                    // remove the control
                    box.Controls.Remove(box.Controls[indexControl]);

                    // end the loop
                    indexControl = box.Controls.Count;

                }

            }

        }

        /// <summary>
        /// RemoveCardsControl - loops the list of cards and use each instance of a card to remove the control from the GroupBox in which it currently resides.
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="box"></param>
        private void RemoveCardsControl(List<Card> cards, GroupBox box)
        {

            // loop the hand
            foreach (Card card in cards)
            {
                // remove the card to the box
                // within its own control
                RemoveCardControl(card, box);

            }

            // clears the list
            cards.Clear();

        }

        /// <summary>
        /// LoadCardsControl - loops the list of cards and uses each instance of a card to load the control from the GroupBox
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="box"></param>
        private void LoadCardsControl(List<Card> cards, GroupBox box, int numberAcross)
        {

            // clear the group control
            box.Controls.Clear();

            // loop the hand
            foreach (Card card in cards)
            {
                // add the card to the box
                // within its own control
                LoadCardControl(card, box, numberAcross);

            }

        }

        /// <summary>
        /// LoadCardControl uses an instance of a card to load the control from the GroupBox
        /// </summary>
        /// <param name="card"></param>
        /// <param name="box"></param>
        private void LoadCardControl(CardLibrary.Card card, GroupBox box,int numberAcross)
        {
            // declare x and y variables
            int lastX = 0;
            int lastY = 0;
            
            // card width, height, and start position constants
            const int CARD_HEIGHT = 80;
            const int CARD_WIDTH = 50;
            const int CARD_START_POSITION = 15;

            // determine if the cards should be face up or down
            if ((box.Equals(grpComputer)))
            {
                // computer cards should not be shown
                card.IsFaceUp = false;
            }
            else
            {
                // player cards should be shown
                card.IsFaceUp = true;
            }

            // determine the current position in a row
            int position = (box.Controls.Count) % (numberAcross);

            // determine how much to shift a card down
            int shiftY = box.Controls.Count / (numberAcross );

            // if it is the first card/control
            if (box.Controls.Count == 0)
            {

                // set both x and y to CARD_START_POSITION
                lastX = CARD_START_POSITION;
                lastY = CARD_START_POSITION;

            }
            else
            {
                // if it is a new row position == 0
                if (position == 0)
                {
                    // set the x to the first control on the first row
                    lastX = ((CardBox.CardDisplay)box.Controls[0]).Location.X;
                    
                    // shift the card down by the first control on the first row
                    // plus 80 * the number of shifts
                    lastY = ((CardBox.CardDisplay)box.Controls[0]).Location.Y + (CARD_HEIGHT * shiftY);

                }
                else
                {
                    // move the card over on the same row
                    lastX = ((CardBox.CardDisplay)box.Controls[position - 1]).Location.X + CARD_WIDTH;
                    lastY = ((CardBox.CardDisplay)box.Controls[position - 1]).Location.Y + (CARD_HEIGHT * shiftY);
                }
            }

            // create a new CardDisplay user control
            CardBox.CardDisplay newCardDisplay = new CardBox.CardDisplay();

            // set the location
            newCardDisplay.Location = new Point(lastX, lastY);

            // set the size
            newCardDisplay.Size = new Size(CARD_WIDTH, CARD_HEIGHT);

            // set the suit
            newCardDisplay.Suit = (CardBox.Suit)card.SuitValue;

            // set the rank
            newCardDisplay.Rank = (CardBox.Rank)card.RankValue;

            // set the image
            newCardDisplay.CardImage = card.CardImage;

            // set the tag to the card object
            newCardDisplay.Tag = card;

            // select the card
            newCardDisplay.Select();

            // bring it to front (which does not work)
            newCardDisplay.BringToFront();
            
            // set the user controls click event
            newCardDisplay.Click += new System.EventHandler(this.SelectCardToPlay);

            // add the control to the current group box
            box.Controls.Add(newCardDisplay);

        }

        /// <summary>
        /// SelectCardToPlay - event handler for the CardDisplay user control click event. Check to see
        ///                    if the appropriate player group box has been clicked and the allow either
        ///                    the attack or defence
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectCardToPlay(object sender, EventArgs e)
        {

            // constant declaration
            const int ATTACK_CARD_MODULUS_RESULT = 0;

            //get the number of the player that clicked
            int playerClicked = (int)((CardBox.CardDisplay)(sender)).Parent.Tag;

            // check to see if this is an attack move
            // if the current count is even then it is
            // an attack
            if (tableCards.Count % 2 == ATTACK_CARD_MODULUS_RESULT)
            {
                // if the player is the attacker
                if (playerClicked == indexOfAttacker)
                {
                    // allow the attack
                    Attack((Card)((CardBox.CardDisplay)(sender)).Tag);
                }
            }
            else
            {
                // else it must be a defender
                // so if the player is the defender
                if (playerClicked == indexOfDefender)
                {
                    // allow a defence
                    Defend((Card)((CardBox.CardDisplay)(sender)).Tag);
                }
            }
        }

        /// <summary>
        /// Defend - this function handles the the GUI defence moves for both the human and conputer player
        /// </summary>
        /// <param name="currentCard"></param>
        private void Defend(Card currentCard)
        {

            // if the computer is the attacker
            if (fieldPlayers[indexOfDefender] is ComputerPlayer)
            {

                // if the computer has nothing to attack with or decides not to attack
                if (((ComputerPlayer)fieldPlayers[indexOfDefender]).Defend(tableCards) == false)
                {

                    // call the function toset the winner and loser of the current bout
                    DetermineHand(PLAYER_COMPUTER, grpComputer, PLAYER_HUMAN,grpPlayer);

                }
                else
                {

                    // increament the defendCount if it reaches 
                    // six the defender wins the bout
                    defendCount++;

                    // get the latest card played
                    currentCard = tableCards[tableCards.Count - 1];

                    // remove the card group control
                    RemoveCardControl(currentCard, grpComputer);

                    // show the card in the appropriate place
                    LoadCardControl(currentCard, grpBattleField,2);

                    // if the defendCount has reached DurakRules.MAX_BOUTS or
                    // the defender is out of cards
                    if ((defendCount == DurakRules.MAX_BOUTS) | (fieldPlayers[indexOfDefender].Hand.Count == 0))
                    {
                        // the defender/computer in this case has won
                        DetermineHand( PLAYER_HUMAN, grpPlayer,PLAYER_COMPUTER, grpComputer);
                    }

                }

            }
            else
            {

                // check to see if the card selected is okay to defend with
                if (DurakRules.IsOkDefendCard(tableCards[tableCards.Count - 1], currentCard) != true)
                {
                    // dsiplay a message to the user
                    MessageBox.Show("Please select another card, this one cannot be used to defend, or pickup the cards on the table.");
                }
                else
                {

                    defendCount++;

                    // remove the card from the attackers hand
                    fieldPlayers[indexOfDefender].Hand.Remove(currentCard);

                    // add the card to the table
                    tableCards.Add(currentCard);

                    RemoveCardControl(currentCard, grpPlayer);

                    // show the card in the appropriate place
                    LoadCardControl(currentCard, grpBattleField,2);

                    if ((defendCount == DurakRules.MAX_BOUTS) | (fieldPlayers[indexOfDefender].Hand.Count == 0))
                    {
                        // the defender/human in this case has won
                        DetermineHand(PLAYER_COMPUTER, grpComputer,PLAYER_HUMAN, grpPlayer);
                    }
                    else
                    {
                        // the computer will continue to attack
                        Attack(null);
                    }
                }

            }

        }

        /// <summary>
        /// Attack - this function handles the the GUI attack moves for both the human and conputer player
        /// </summary>
        /// <param name="currentCard"></param>
        private void Attack(Card currentCard)
        {

            // if the computer is the attacker
            if (fieldPlayers[indexOfAttacker] is ComputerPlayer)
            {

                // if the computer has nothing to attack with or decides not to attack
                if (((ComputerPlayer)fieldPlayers[indexOfAttacker]).Attack(tableCards) == false)
                {

                    // the defender/human has won the bout
                    DetermineHand(PLAYER_COMPUTER, grpComputer,PLAYER_HUMAN, grpPlayer);

                }
                else
                {

                    // get the latest card played
                    currentCard = tableCards[tableCards.Count - 1];

                    // remove the card group control
                    RemoveCardControl(currentCard, grpComputer);

                    // show the card in the appropriate place
                    LoadCardControl(currentCard, grpBattleField,2);
                    
                    // if the attacker has run out of cards
                    if (fieldPlayers[indexOfAttacker].Hand.Count==0)
                    {
                        // the attacker/computer has won the game
                        DetermineHand(PLAYER_HUMAN, grpPlayer,PLAYER_COMPUTER, grpComputer);
                    }

                }

            }
            else
            {   // human player


                // check to see if the card selected is okay to attack with
                if (DurakRules.IsOkAttackCard(tableCards, currentCard) != true)
                {
                    // dsiplay a message to the user
                    MessageBox.Show("Please select another card, this one cannot be used in an attack.");
                }
                else
                {

                    // remove the card from the human attackers hand
                    fieldPlayers[indexOfAttacker].Hand.Remove(currentCard);

                    // add the card to the table
                    tableCards.Add(currentCard);

                    // remove the card grpPlayer group control
                    RemoveCardControl(currentCard, grpPlayer);

                    // show the card in the grpBattleField (table) control
                    LoadCardControl(currentCard, grpBattleField,2);

                    // if the attacker/human has run out of cards
                    if (fieldPlayers[indexOfAttacker].Hand.Count == 0)
                    {
                        //  the attacker/human has won
                        DetermineHand(PLAYER_COMPUTER, grpComputer,PLAYER_HUMAN, grpPlayer);
                    }
                    else
                    {
                        // else allow the computer to attack
                        Defend(null);
                    }
                }

            }

        }

        /// <summary>
        /// btnPickUp_Click - event that allows the human player to pickup/discard the current table, depending on what
        ///                   status the human has, defender or attacker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPickUp_Click(object sender, EventArgs e)
        {

            // determine of the cards should be picked up or discarded
            DetermineHand(PLAYER_HUMAN,grpPlayer, PLAYER_COMPUTER,grpComputer);

        }

        /// <summary>
        /// DetermineHand - allows for a loser and a winner and the either discards and 
        /// </summary>
        /// <param name="playerToConcede"></param>
        /// <param name="playerToWin"></param>
        private void DetermineHand(int playerToConcede, GroupBox grpConcedeBox, int playerToWin, GroupBox grpWinBox)
        {

            // if the losing player is the defender
            if (playerToConcede == indexOfDefender)
            {
                // have the player pickup the cards
                PickUp(fieldPlayers[playerToConcede], grpBattleField, grpConcedeBox);
            }
            else
            {
                // discard the cards
                RemoveCardsControl(tableCards,grpBattleField);
            }

            // reset the the attacker and defender indexs
            indexOfAttacker = playerToWin;
            indexOfDefender = playerToConcede;

            // reload the hands
            DistributeCards();

            //  sort the winner's reloaded hand
            fieldPlayers[playerToWin].Hand.Sort();

            // reload the winner's group box control
            LoadCardsControl(fieldPlayers[playerToWin].Hand, grpWinBox, 6);

            // sort the loser's reloaded hand
            fieldPlayers[playerToConcede].Hand.Sort();

            // reload the loser's group box control
            LoadCardsControl(fieldPlayers[playerToConcede].Hand, grpConcedeBox, 6);

            // reset the names on the group boxes
            setNames(indexOfAttacker, grpWinBox, indexOfDefender, grpConcedeBox);

            // check to see if either the computer or the human has won
            if ((fieldPlayers[PLAYER_COMPUTER].Hand.Count == 0) | (fieldPlayers[PLAYER_HUMAN].Hand.Count == 0))
            {

                // display to the user who the winner is
                MessageBox.Show("The " + ((fieldPlayers[PLAYER_COMPUTER].Hand.Count == 0)? " computer " : " human ") + " has won ");

            }
        }
        
        /// <summary>
        /// PickUp - flip the cards from one group box to another and add them to the given players hand
        /// </summary>
        /// <param name="player"></param>
        /// <param name="grpOrigin"></param>
        /// <param name="grpDesination"></param>
        private void PickUp(DurakPlayer player, GroupBox grpOrigin, GroupBox grpDesination)
        {

            // pickup the table
            player.Hand.PickUp(tableCards);

            // remove cards from battle field
            RemoveCardsControl(tableCards, grpOrigin);

            player.Hand.Sort();

            // add cards to the computer group box
            LoadCardsControl(player.Hand, grpDesination,6);

        }

        /// <summary>
        /// btnLicence_Click click to display licence data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLicence_Click(object sender, EventArgs e)
        {
            // display licence data
            MessageBox.Show(this, CardBox.CardDisplay.ImageLicence, "Licence Data");
        }

        /// <summary>
        /// btnRules_Click click to display rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRules_Click(object sender, EventArgs e)
        {

            // display licence data
            MessageBox.Show(this, CardBox.CardDisplay.Rules, "Rules");

        }

    }

}
