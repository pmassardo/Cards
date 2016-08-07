using System;

/**
 * Author:      A. Paul Massardo
 * Program:     Group Project
 * Date:        13-Feb-2015
 * Description: DurakDeck is a class that represent a deck of cards that is used for a game of Durack. 
 *              The DurakDeck class inherits Deck class.
 *
*/

// using-import-includes
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLibrary;

// namespace
namespace DurakLibrary
{
    /// <summary>
    ///  DurakDeck - inherits from the Deck class and represents a deck of cards used in a durek game
    /// </summary>
    public class DurakDeck : Deck
    {
        /// <summary>
        ///  ACE_HIGH_VALUE - the value of an ace for the durak game
        /// </summary>
        private const byte ACE_HIGH_VALUE = 14;

        /// <summary>
        ///  fieldDeckSize - instance variable to store the deck size selected
        /// </summary>
        private DeckSize fieldDeckSize;

        /// <summary>
        ///  DurakDeck parameterized constructor
        /// </summary>
        /// <param name="deckSize"></param>
        public DurakDeck(DeckSize deckSize)
        {

            // load the deck
            LoadDeck(deckSize);
        }

        /// <summary>
        /// LoadDeck - load the deck and tell it how big a deck you would like
        /// </summary>
        /// <param name="deckSize">DeckSize</param>
        public void LoadDeck(DeckSize deckSize = DeckSize.FiftyTwo)
        {
            // set the static value specific to
            // the game of durak
            Card.IsAceHigh = true;

            // are aces high
            Card.AceHighValue = ACE_HIGH_VALUE;
            
            // declare a new Card variable 
            Card card;

            // set the deck size
            fieldDeckSize = deckSize;

            // clear the deck
            base.Clear();

            //create the deck by iterating the suits and the then deck values and adding cards
            for (byte indexSuits = 0; indexSuits < Card.Suits.GetLength(0); indexSuits++)
            {
                // loop through the ranks
                for (byte indexRanks = 1; indexRanks < Card.Ranks.GetLength(0); indexRanks++)
                {
                    // create a new Durak Card pass it the 
                    // rank and suit to the constructor
                    card = new Card(indexRanks, indexSuits);

                    // add the card to the base
                    base.Add(card);

                    // if the current rank is 1 (Ace)
                    if (indexRanks == 1)
                    {
                        // increment the rank index by the
                        // decksize variable
                        indexRanks += (byte)fieldDeckSize;
                    }
                }
            }
        }
    }
}
