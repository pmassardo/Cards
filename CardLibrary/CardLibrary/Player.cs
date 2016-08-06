/**
 * Author:      A. Paul Massardo
 * Program:     Group Project
 * Date:        13-Feb-2015
 * Description: Player class represents a generic player in a game of cards
 * 
*/

// using-import-includesusing System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// namespace
namespace CardLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Player 
    {

        /// <summary>
        /// Constants for the class
        /// </summary>
        /// MESSAGE_NAME_LENGTH - message to be thrown when nothing is entered for the player's name
        private const string MESSAGE_NAME_LENGTH = "Name length cannot be zero";

        /// <summary>
        /// fieldName - instance variable to hold the player name
        /// </summary>
        private string fieldName;

        /// <summary>
        /// isFieldDealer - instance variable to hold if the player is currently the one to deal
        /// </summary>
        private bool isFieldDealer;

        /// <summary>
        /// isFieldMyTurn - instance variable to holds whos turn in the game to lay down the card
        /// </summary>
        private bool isFieldMyTurn;

        /// <summary>
        /// fieldHand - instance variable to hold if the player's hand
        /// </summary>
        private Hand fieldHand;

        /// <summary>
        /// Player - default constructor
        /// </summary>
        public Player()
        {

            isFieldDealer = false;

            fieldHand = new Hand();

        }

        /// <summary>
        /// Player - parameterized constructor that calls the defualt constructor default constructor
        /// </summary>
        /// <param name="name">string</param>
        public Player(string name)
            : this()
        {
            // set the name property   
            this.Name = name;
        }

        /// <summary>
        /// Name - property procedure which sets and gets the player's name
        /// </summary>
        public string Name
        {
            // get - accessor function
            get
            {
                return fieldName;
            }
            // set - mutator method that validates if a non-emptiy string has been entered
            //      if not an exception is thrown whihc will need to be handled in the 
            //      presentation layer
            set
            {
                // validate that something has been entered
                // for the player name
                if (value.Trim().Length > 0)
                {
                    fieldName = value;
                }
                else
                {
                    // throw an exception
                    throw new Exception(MESSAGE_NAME_LENGTH);
                }
            }
        }

        /// <summary>
        /// Hand - property procedure for that returns the players hand
        /// </summary>
        public Hand Hand
        {
            // get - accessor function
            get
            {
                // return the current hand
                return fieldHand;
            }
        }

        /// <summary>
        /// IsDealer - will be the indicator if this player is currently the one dealing the cards
        /// </summary>
        public bool IsDealer
        {
            get
            {
                return isFieldDealer;
            }
            set
            {
                isFieldDealer = value;
            }
        }

        /// <summary>
        /// IsMyTurn - indicates whos turn it is
        /// </summary>
        public bool IsMyTurn
        {
            get 
            { 
                return isFieldMyTurn; 
            }
            set 
            { 
                isFieldMyTurn = value; 
            }
        }
    }
}

