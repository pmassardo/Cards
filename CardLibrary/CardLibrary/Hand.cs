/**
 * Author:      A. Paul Massardo
 * Program:     Group Project
 * Date:        13-Feb-2015
 * Description: Hand is a class that represent a hand of cards that could be use for a variety of card games. 
 *              The Hand class inherits a typed List<Card> that is type with the Card class.
 * 
*/

// using-import-includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardLibrary 
{
    /// <summary>
    /// Hand is a class that represent a hand of cards that could be use for a variety of card games. 
    /// The Hand class inherits a typed List<Card> that is type with the Card class.
    /// </summary>
    public class Hand : List<Card>
    {
        /// <summary>
        /// Maximum number of cards a hand can be dealt
        /// it can have more but only if it needs to pick up
        /// after defending.
        /// </summary>
        //public static const byte HAND_CARD_MAXIMUM_DEALT = 5;

        public List<Card> Cards
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        ///  Sort - overides the List<> sort by passing it a method to use for the comparison
        /// </summary>
        public new void Sort()
        {

            // create a new instance of the method used to sort
            // the hand by passing the Comparison<> class the
            // Card.Compare function
            // we are telling the list what to compare when sorting
            Comparison<Card> sorter = new Comparison<Card>(Card.Compare);

            // call the sort and pass it the newlt created
            // comparison/sorter object
            this.Sort(sorter);
            
        }


    }
}
