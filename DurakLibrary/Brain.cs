

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardLibrary;

namespace DurakLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Brain
    {

        private bool isAdvanced;

        public Brain(bool isAdvanced)
        {

            this.isAdvanced = isAdvanced;

        }


        /// <summary>
        /// Attack - the following will compare the cards in the table list
        /// to the card in the player's hand and if a car is found that matches
        /// the RankValue of a card in the table then it will be the card that is 
        /// layed down next by the attacker and in this case it adds it to the table
        /// in the attack function
        /// </summary>
        /// <param name="table"></param>
        /// <param name="hand"></param>
        /// <returns></returns>
        public bool Attack(List<Card> battleField, DurakHand hand)
        {
            Card tempCard = null;
            bool isFound = false;
            bool isAdvanceCheck;


            // sort the hand it should
            // help improve performance
            hand.Sort();

            if (isAdvanced)
            {
               isAdvanceCheck= PickUpOrDiscard(battleField, hand);
            }
            else
            {
                isAdvanceCheck =true;
            }

            if (isAdvanceCheck)
            {

                //iterate through the hand
                for (int indexHand = 0; indexHand < hand.Count; indexHand++)
                {

                    // use the rules to determine if the card to be used
                    // is okay to attack with
                    if (DurakRules.IsOkAttackCard(battleField, hand[indexHand]))
                    {

                        // set the temp card to the 
                        // current card in the hand
                        tempCard = hand[indexHand];

                        // remove the card from the card
                        hand.Remove(tempCard);

                        // add the card to the table
                        battleField.Add(tempCard);

                        // set the indexHand to stop the outer loop
                        indexHand = hand.Count;

                        // set the return
                        isFound = true;

                    }
                }
            }
            else
            {

                // the attack has been successful
                isFound = false;

            }

            // return
            return isFound;

        }

        // consider that you can pickup trump and high cards
        // can you beat the card layed down
        /// <summary>
        ///  Defend - checks to see if the hand has a card that can defeat the latest card
        ///           laydown by the opponent.
        /// </summary>
        /// <param name="battleField">cards laydown on the table during bout</param>
        /// <param name="hand">DurakHand</param>
        /// <returns></returns>
        public bool Defend(List<Card> battleField, DurakHand hand)
        {

            //
            bool isSuccess = false;
            bool isAdvanceCheck;

            if (isAdvanced)
            {
                isAdvanceCheck = PickUpOrDiscard(battleField, hand);
            }
            else
            {
                isAdvanceCheck = true;
            }

            if (isAdvanceCheck)
            {

                // sort the hand so the lowest possible will be used
                hand.Sort();

                // find a card that is greater then the card 
                // laydown by the opponent
                for (int handIndex = 0; handIndex < hand.Count; handIndex++)
                {

                    // if the card is ok to defend with
                    if (DurakRules.IsOkDefendCard(battleField[battleField.Count - 1], hand[handIndex]))
                    {

                        // add the card to the battleField
                        battleField.Add(hand[handIndex]);

                        // remove the card from the hand
                        hand.Remove(hand[handIndex]);

                        // set the index to the hand count
                        // to end the loop
                        handIndex = hand.Count;

                        // the defence has been successful
                        isSuccess = true;

                    }

                }

            }
            else
            {

                // the defence has been successful
                isSuccess = false;

            }

            // return
            return isSuccess;
        }

        /// <summary>
        /// PickupOrDiscard - will make decision on whether a play should be made of id the table card/battlefield should be picked up
        /// </summary>
        /// <param name="battleField"></param>
        /// <param name="hand"></param>
        /// <returns></returns>
        public bool PickUpOrDiscard(List<Card> battleField, DurakHand hand)
        {

            // Constants
            const int POINTS_MAX_SINGLE_CARD = 100;
            const int POINTS_TRUMP = 50;
            const int POINTS_RANK = 20;
            const int POINTS_MATCH = 5;
            const int POINTS_MATCH_RANK = 10;
            const double POINTS_PERCENTAGE_TO_PICKUP = .30;

            // the higest a card can be worth is 100
            // broken down as follows
            // POINTS_TRUMP points if your are trump 0 if you are not
            // POINTS_RANK points if you are the highest card based on the folowing formula
            // POINTS_MATCH to 15 points for matching cards within the table/battleField
            // 5 to 15 points for matching cards between the hand and the table/battleField

            // variable declarations
            int count = 0;
            double score = 0.0;
            bool returnValue = true;

            // loop through the table and see how many trump cards
            // and assign points to the variable score which is 
            // scoring the cards on the table compared to the hand

            // POINTS_TRUMP comes from being a trump card if not 0
            // POINTS_RANK is used to calculate a percentage based
            // on the cards rank in a suit            
            foreach (Card card in battleField)
            {
                // count the number of cards to be used as
                // a demominator later
                count += POINTS_MAX_SINGLE_CARD;

                // if the card is trump assign 50 to the score
                score += ((Card.TrumpSuit == card.SuitValue) ? POINTS_TRUMP : 0);

                // assign a value to the score based on the value of the card
                // since trump already has been accounted for this is based
                // just on the card value and not the fact that it is trump
                // this is weighted based on the cards value in a suit
                score += ((double)(POINTS_RANK) * ((double)(card.RankValue) - ((Card.TrumpSuit == card.SuitValue) ? Card.Ranks.Length : 0)) / Card.Ranks.Length);
                
            }

            // temp cards to be used in the
            // matching loops below
            Card outerCard;
            Card innerCard;
            byte outerValue = 0;
            byte innerValue = 0;

            // create a temp list based on the cards on the table
            List<Card> tempBattleField = new List<Card>(battleField);

            // look for matching ranks cards within the table/battlefield
            // loop the temp battle field
            for (int indexOuter = 0; indexOuter < tempBattleField.Count; indexOuter++)
            {
                // set a outer card
                outerCard = tempBattleField[indexOuter];

                // get the value of the current outer card
                outerValue = ((outerCard.SuitValue == Card.TrumpSuit) ? (byte)(outerCard.RankValue - Card.Ranks.Length) : outerCard.RankValue);

                // remove the card from the field so it 
                // cannot match itself in the inner loop
                tempBattleField.Remove(outerCard);

                // loop the tempBattleField again with the tempcard removed
                for (int indexInner = 0; indexInner < tempBattleField.Count; indexInner++)
                {

                    // set a inner card
                    innerCard = tempBattleField[indexInner];

                    // get the value of the current inner card
                    innerValue = ((innerCard.SuitValue == Card.TrumpSuit) ? (byte)(innerCard.RankValue - Card.Ranks.Length) : innerCard.RankValue);

                    // if the current card value matches any of the other cards
                    // on the table/battleField then assign a value for it
                    // based on POINTS_MATCH_RANK for the match and POINTS_MATCH_RANK 
                    // by the wieght of the rank compared to other ranks in the suit
                    //.So, matching low cards are worth less than matching high cards.
                    if (outerValue == innerValue)
                    {

                        // POINTS_MATCH + POINTS_MATCH_RANK * (the wieght of the card compared to the other cards in the same suit)
                        score += POINTS_MATCH + ((double)(POINTS_MATCH_RANK) * (innerValue / Card.Ranks.Length));
                        
                        // if it is found remove it so 
                        // if will not be compared to again
                        tempBattleField.Remove(innerCard);

                        // decrement the indexInner
                        indexInner--;

                    }
                }

                // decrement the indexOuter
                indexOuter--;
            }

            // compare the player hand to the table/battleField
            // if the table/battleField matches the cards in the hand
            // POINTS_MATCH_RANK for the match plus (POINTS_MATCH_RANK
            // by the wieght of the rank) compared to other ranks in the suit
            //.So, matching low cards are worth less than matching high cards.
            for (int indexOuter = 0; indexOuter < hand.Count; indexOuter++)
            {

                // get the value of the current outer card
                outerValue = ((hand[indexOuter].SuitValue == Card.TrumpSuit) ? (byte)(hand[indexOuter].RankValue - Card.Ranks.Length) : hand[indexOuter].RankValue);

                //loop the table/battleField cards
                for (int indexInner = 0; indexInner < battleField.Count; indexInner++)
                {

                    // get the value of the current inner card
                    innerValue = ((battleField[indexInner].SuitValue == Card.TrumpSuit) ? (byte)(battleField[indexInner].RankValue - Card.Ranks.Length) : battleField[indexInner].RankValue);
                    
                    // if there is a match
                    if (outerValue == innerValue)
                    {
                        // POINTS_MATCH + POINTS_MATCH_RANK * (the wieght of the card compared to the other cards in the same suit)
                        score += POINTS_MATCH + ((double)(POINTS_MATCH_RANK) * (innerValue / Card.Ranks.Length));
                    }
                }
            }

            // if the  table average is greater than
            // the given amount then do not allow play
            // which will force the player to pick up
            if ((score / count) >= POINTS_PERCENTAGE_TO_PICKUP)
            {

                returnValue = false;

            }

            // return value
            return returnValue;
        }
    }
}
