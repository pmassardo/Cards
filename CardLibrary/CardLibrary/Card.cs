/**
 * Author:      A. Paul Massardo
 * Program:     Group Project
 * Date:        13-Feb-2015
 * Description: Card is a class that represent a playing card that could be use for a variety of card games
 * 
*/

// using-import-includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

// namespace
namespace CardLibrary
{

    /// <summary>
    ///  Card is a class that represent a class that could be use for a variety of card games
    /// </summary>
    public class Card
    {       

        /// <summary>
        /// FACE_DOWN_IMAGE - constant - name the image of the back image of the card
        /// </summary>
        protected const string FACE_DOWN_IMAGE = @"CB";

          /// <summary>
        /// AcesHighValue - static - if aces are high what value should be used.
        /// </summary>
        private static byte aceHighValue = 11;

        ///// <summary>
        ///// Suits - static - possible suits in the deck
        ///// </summary>
        public static readonly string[] Suits = { "Hearts", "Spades", "Clubs", "Diamonds" };

        ///// <summary>
        ///// Ranks - static - possible ranks in the deck
        ///// </summary>
        public static readonly string[] Ranks = { "", "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

        /// <summary>
        /// fieldBackImage - static - the image to use for this card
        /// </summary>
        private static Image fieldBackImage = null; 

        /// <summary>
        /// isFieldAcesHigh - static - determines if aces are consider high or low.
        /// </summary>
        private static bool isFieldAcesHigh = false;

        /// <summary>
        /// isFieldFaceWorthTen - static - determines if aces are worth there raw value or ten.
        /// </summary>
        private static bool isFieldFaceWorthTen = false;

        /// <summary>
        /// fieldTrumpSuit - static - which suit value is trump
        /// </summary>
        private static byte fieldTrumpSuit = 100;

        ///// <summary>
        ///// fieldTrumpWieght - static - weight given to trump
        ///// </summary>
        //private static byte fieldTrumpWieght = 2;

        /// <summary>
        /// fieldRank - instance variables represents the cards rank
        /// </summary>
        protected byte fieldRank = 0;

        /// <summary>
        /// fieldSuit - instance variables represents the cards suit
        /// </summary>
        protected byte fieldSuit = 0;

        /// <summary>
        /// isFieldFaceUp - instance variables show the face or not
        /// </summary>
        private bool isFieldFaceUp = false;

        /// <summary>
        /// fieldImage - instance variable of the image to use for the card
        /// </summary>
        private Image fieldImage;

        /// <summary>
        /// fieldImage - instance variable of the image to use for the card
        /// </summary>
        private byte fieldCardPosition;

        /// <summary>
        /// Card - Parameterized Constructor
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="suit"></param>
        public Card(byte rank, byte suit)
        {
            fieldRank = rank;
            fieldSuit = suit;

            fieldImage = (Image) Properties.Resources.ResourceManager.GetObject(Suits[suit].ToString() + Ranks[rank].ToString());

            if (fieldBackImage==null)
            {
                fieldBackImage = (Image)Properties.Resources.ResourceManager.GetObject(FACE_DOWN_IMAGE);
            }
            
            fieldCardPosition = (byte)((int)rank + ((int)suit * (Card.Ranks.Length - 1)));

        }

        /// <summary>
        ///  SuitPosition - represents the position of the card in an suit in an unshuffled deck. 
        ///               - the ace's position is adjusted to compensate for the fact that it can
        ///               - be a 1 or an 11, but is usually position after kings in a hand
        /// </summary>
        public virtual byte SuitPosition
        {
            get
            {
                byte trumpWeight = (Card.TrumpSuit == fieldSuit) ? GetHighestCardValue() : (byte)(0);

                // determine if this is an ACE by the position 1, 14, 27, 40
                // if so if aces are used at a high value then return the aces
                // high value
                return (((int)(fieldCardPosition) % (Card.Ranks.Length - 1)) == 1 && isFieldAcesHigh) ? (byte)(Card.AceHighValue + trumpWeight) : (byte)(fieldRank + trumpWeight); 
            }
        }

        ///<summary>
        /// Represent the rank/numeric value of an of a card 
        ///</summary>
        public string Rank
        {
            get
            {
                return Ranks[fieldRank];
            }
        }

        ///<summary>
        /// Represent the rank/numeric value of an of a card. The ace can either be represented as 1 or an 11 depending
        ///           the game. So, if isFieldAcesHigh is set to true ace is worth 11 else it is worth 1. Face cards in
        ///           some  games can all be worth 10 an in other games jack is more than ten, etc.
        ///</summary>
        public byte RankValue
        {
            get
            {
                byte returnValue =0;

                // if the current card is trump then calculate
                // the weight based on whatever may be the highest
                // card and add it to the rank when passing back 
                // the rank value. So, if trump is clubs and the 
                // normal value for a two of clubs is 2 get the 
                // highest ranked card in a suit and add it to
                // the rank value so if an ace is worth 14 and
                // the king is worth 13, 14 will be added to the
                // 2 of clubs making it a 16, then the three of clubs
                // will be a 17. So trump will always beat everything
                // else but we still maintain the heirarchy with the
                // trump suit
                byte trumpWeight = (Card.TrumpSuit == fieldSuit) ? GetHighestCardValue() : (byte)(0);

                // An ACE (rank value 1) will be 11
                if ((int)(fieldRank) == 1)
                {
                    // if IsAcesHigh then
                    if ((isFieldAcesHigh == true))
                    {
                        returnValue =(byte)(Card.AceHighValue + trumpWeight);
                    }
                    else
                    {
                        // return the actual value
                        returnValue = (byte)(fieldRank + trumpWeight);
                    }
                }
                else if (isFieldFaceWorthTen & ((int)(fieldRank) == 11 || (int)(fieldRank) == 12 || (int)(fieldRank) == 13))
                {
                    returnValue = (byte)(10 + trumpWeight);
                }
                else
                {
                    returnValue = (byte)(fieldRank + trumpWeight);
                }

                return returnValue;

            }
        }

        /// <summary>
        /// FaceValue - returns the face value of the card
        /// regardless of what suit trump is or if ace are
        /// high or not
        /// </summary>
        public byte FaceValue
        {
            get
            {
                return fieldRank;
            }

        }


        ///<summary>
        /// Represent the suite of the card
        ///</summary>
        public string Suit
        {
            get
            {
                return Suits[fieldSuit];
            }
        }

        ///<summary>
        /// Represent the suite value of the card
        ///</summary>
        public byte SuitValue
        {
            get
            {
                return fieldSuit;
            }
        }

        ///<summary>
        /// IsFaceUp - represents if the card is face up or not
        ///</summary>
        public bool IsFaceUp
        {
            get
            {
                return isFieldFaceUp;
            }

            set
            {
                isFieldFaceUp = value;
            }
        }

        ///<summary>
        /// IsFaceUp - represents if Aces are worth one or eleven
        ///</summary>
        public static bool IsAceHigh
        {
            get
            {
                return isFieldAcesHigh;
            }

            set
            {
                isFieldAcesHigh = value;
            }
        }

        ///<summary>
        /// AceHighValue - can be set or it is worth 11
        ///</summary>
        public static byte AceHighValue
        {
            get
            {
                return Card.aceHighValue;
            }
            set
            {
                Card.aceHighValue = value;
            }
        }

        ///<summary>
        /// IsFaceWorthTen - represents if the card is worth its raw value or ten.
        ///</summary>
        public static bool IsFaceWorthTen
        {
            get
            {
                return isFieldFaceWorthTen;
            }

            set
            {
                isFieldFaceWorthTen = value;
            }
        }

        ///<summary>
        /// TrumpSuit - static - represents the suit that is trump.
        ///</summary>
        public static byte TrumpSuit
        {
            get
            {
                return fieldTrumpSuit;
            }

            set
            {
                fieldTrumpSuit = value;
            }
        }

        /////<summary>
        ///// TrumpSuit - static - represents the suit that is trump.
        /////</summary>
        //public static byte TrumpWieght
        //{
        //    get
        //    {
        //        return fieldTrumpWieght;
        //    }

        //    set
        //    {
        //        TrumpWieght = value;
        //    }
        //}

        /// <summary>
        /// Represents the image to be used for the card
        /// If the card is face up it returns the face of the card
        /// If the card is face down it returns the back of the card
        /// </summary>
        public Image CardImage         
        {
            get
            {
                return isFieldFaceUp ? fieldImage : fieldBackImage; 
            }

        }

        /// <summary>
        /// ToString - overriden to return the rank and suit
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return this.Rank + " - " + this.Suit;
        }

        /// <summary>
        /// Compare - static method used in sort routine of the List<Card>
        /// (BEGINNING VISUAL C#® 2012 PROGRAMMING - Karli Watson)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int Compare(Card cardA, Card cardB)
        {
            // declare and initialize a return variable
            int returnValue = 0;

            // if card a is greater than card b
            if (cardA.SuitPosition > cardB.SuitPosition)
            {
                returnValue = 1;
            }// if card a is less than card b
            else if (cardA.SuitPosition < cardB.SuitPosition)
            {
                returnValue = -1;
            }
            else // if they are equal
            {
                returnValue = 0;
            }

            // return the value
            return returnValue;
        }

        /// <summary>
        /// GetHighestCardValue -highest ranked card in a suit and add it to
        /// the rank value so if an ace is worth 14 and the king is worth 13, 14
        /// will be return
        /// </summary>
        /// <returns></returns>
        public static byte GetHighestCardValue()
        {
            byte returnValue =0;

            if((Card.IsAceHigh==true) && (Card.AceHighValue > (byte)(Card.Ranks.Length)))
            {
                returnValue=Card.AceHighValue;
            }
            else
            {
                returnValue=(byte)Card.Ranks.Length;
            }

            return returnValue;

        }



    }
}
