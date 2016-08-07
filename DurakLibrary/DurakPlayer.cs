/**
 * Author:      A. Paul Massardo
 * Program:     Group Project
 * Date:        13-Feb-2015
 * Description: Player class represents a Durak Player in a game of cards
 * 
*/

// using-import-includes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLibrary;

// namespace
namespace DurakLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class DurakPlayer : Player
    {

        /// <summary>
        /// fieldHand - instance variable to hold if the player's hand
        /// </summary>
        private DurakHand fieldHand;

        /// <summary>
        /// Player - default constructor - set the dealer and creates a Durak Hand
        /// </summary>
        public DurakPlayer()
        {

            // set the current person to is dealer false 
            base.IsDealer = false;

            // create a new Durakhand
            fieldHand = new DurakHand();

        }

        /// <summary>
        /// DurakPlayer - parameterized constructor that calls the base default constructor default constructor
        /// </summary>
        /// <param name="name">string</param>
        public DurakPlayer(string name)
            : base(name)
        {         

            // create a new Durakhand
            fieldHand = new DurakHand();

        }

        /// <summary>
        /// Hand - property procedure for that returns the players hand
        /// </summary>
        public new DurakHand Hand
        {
            // get - accessor function
            get
            {
                // return the current hand
                return fieldHand;
            }
        }
    }
}
