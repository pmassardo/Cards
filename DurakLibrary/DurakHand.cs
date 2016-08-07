/**
 * Author:      A. Paul Massardo
 * Program:     Group Project
 * Date:        13-Feb-2015
 * Description: DurakHand is a class that represent a hand of cards that used for the Durak game. 
 *              The DurakHand class inherits Hand class.
 * 
*/

// using-import-includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardLibrary;

// namespace
namespace DurakLibrary
{
    /// <summary>
    /// DurakHand - inherits from the CardLibrary Hand
    /// </summary>
    public class DurakHand : Hand
    {

        /// <summary>
        /// Maximum number of cards a durak hand can be dealt
        /// it can have more but only if it needs to pick up
        /// after defending.
        /// </summary>
        public static byte HAND_CARD_MAXIMUM_DEALT = 6;

        ///// <summary>
        ///// isFieldHandFull - instance variable signifying that no more cards should be dealt
        ///// </summary>
        public bool IsFieldHandFull
        {
            get 
            {
                return (base.Count >= HAND_CARD_MAXIMUM_DEALT); 
            }
        }


        /// <summary>
        /// Add - adds a card to a hand, will throw an exception if the
        /// </summary>
        /// <param name="card"></param>
        /// <exception cref=""
        public new void Add(Card card)
        {
            // if the cards in the hand are less than HAND_CARD_MAXIMUM_DEALT
            if (base.Count < HAND_CARD_MAXIMUM_DEALT)
            {
                // add the card to the base
                base.Add(card);

                //// if the cards in the hand are now at HAND_CARD_MAXIMUM_DEALT
                //// set the the field so it will not accept any more cards from
                //// a deal
                //if (base.Count >= HAND_CARD_MAXIMUM_DEALT)
                //{
                //    // set this isFieldHandFull to true
                //    this.isFieldHandFull = true;
                //}

            }
            else
            {
                // if some is trying to add more cards
                throw new Exception("Durak hand can be dealt a maximum of " + HAND_CARD_MAXIMUM_DEALT + " cards");
            }
        }

        /// <summary>
        /// PickUp - method to add the cards that are obtained when defebding does not succeed.
        /// </summary>
        /// <param name="cards">List<Card></param>
        public void PickUp(List<Card> cards)
        {
            // add the cards to the current
            // set of cards
            base.AddRange(cards);
        }
    }
}
