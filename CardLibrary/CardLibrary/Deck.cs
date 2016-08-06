/**
 * Author:      A. Paul Massardo
 * Program:     Group Project
 * Date:        13-Feb-2015
 * Description: Deck is a class that represent a deck of cards that could be use for a variety of card games. 
 *              The deck class inherits a typed List<Card> that is type with the Card class.
 * 
*/

// using-import-includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// namespace
namespace CardLibrary 
{

    /// <summary>
    /// Deck is a class that represent a deck of cards that could be use for a variety of card games. 
    /// The deck class inherits a typed List<Card> that is type with the Card class.
    /// </summary>
    public class Deck : List<Card>
    {

        /// <summary>
        /// LastCardDrawn - Event raised when the last card in the deck is drawn.
        /// </summary>
        public event EventHandler LastCard;

        // declare and instantiate a random object
        // to be used for shuffling
        private static Random fieldRandom = new Random();

        //private string fieldBackImagePath = string.Empty;

        /// <summary>
        /// Deck - parameterized constructor
        /// </summary>
        /// <param name="isAcesHigh"></param>
        /// <param name="isLoad"></param>
        public Deck(bool isLoad = false)
        {
            if (isLoad)
            {
                LoadDeck();
            }
        }

        /// <summary>
        /// LoadDeck - intializes the deck with 52 cards
        /// </summary>
        private void LoadDeck()
        {

            // declare a new Card variable 
            Card card;

            // clear the deck
            base.Clear();

            //create the deck by iterating the suits and the then deck values and adding cards
            for (byte indexSuits = 0; indexSuits < Card.Suits.GetLength(0); indexSuits++)
            {
                
                for (byte indexRanks = 1 ; indexRanks < Card.Ranks.GetLength(0); indexRanks++)
                {
                    card = new Card(indexRanks, indexSuits);
                    
                    base.Add(card);

                }
            }  

        }

        /// <summary>
        ///  Shuffle - shuffle the cards in the deck regardless of the number in the deck.
        /// </summary>
        public void Shuffle()
        {
            
            // variables
            int randIndex =0;
            Card tempCard;

            // iterate through the cards and swap the current index card
            // with the random card number
            for (int indexCard = 0; indexCard < base.Count - 1; indexCard++)
            {
                // get a random index
                randIndex = fieldRandom.Next(base.Count);

                // set the temp card to the current index
                tempCard = base[indexCard];

                // move the card at the random index
                // to the current index
                base[indexCard] = base[randIndex];

                // put the temp card into the random index
                base[randIndex] = tempCard;

            }
        }

        /// <summary>
        /// Cards  returns the card in the deck (current List<Card> object)
        /// </summary>
        public List<Card> Cards
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        ///  DrawNext - returns the top card on the deck
        /// </summary>
        /// <returns>Card - top card on the deck</returns>
        public Card DrawNext()
        {

            // declare a temp card
            Card tempCard = null;

            // if the base collection has cards
            if (base.Count > 0)
            {
                // set the top card of the deck
                // the the tempo card object
                tempCard = base[base.Count - 1];

                // remove the card from the deck
                base.RemoveAt(base.Count - 1);
            }

            // if the last card has been brawn it is
            // time to finish the game or it is to 
            // reinitialize and shuffle a new deck
            if ((base.Count == 0) && (tempCard != null))
            {
                // raise the event
                        
                if (LastCard != null)
                {

                    LastCard(this, EventArgs.Empty);
                }
            }

            // return the temp card
            return tempCard;
        }
    }
}
