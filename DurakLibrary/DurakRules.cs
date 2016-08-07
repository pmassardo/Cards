/**
 * Author:      A. Paul Massardo
 * Program:     Group Project
 * Date:        13-Feb-2015
 * Description: DurakRules static class that houses the rules for the Durak game.
 * 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardLibrary;

namespace DurakLibrary
{

    public static class DurakRules
    {

        public const byte MAX_BOUTS = 6;

        /// <summary>
        /// IsOkAttackCard - validate if the Attack card pproposed to be played 
        /// by the human/Dural Player is okay to play. Based on the card 
        /// being of the same rank of another card in the deck or being 
        /// the same card.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="hand"></param>
        /// <returns></returns>
        public static bool IsOkAttackCard(List<Card> battleField, Card card)
        {
            // if this is the first card being payed down 
            // then there is nothing to compare to so any
            // rank may be layed down
            bool isFound = (battleField.Count == 0) ? true : false;

            // check to see if the card being attacked with
            // matches the rank of any other card that has
            // already been played and is sitting on the 
            // table. The rank must be presnt on the table
            // to be able to play it again.
            for (int index = 0; index < battleField.Count; index++)
            {

                // if the rank is found
                if (battleField[index].FaceValue == card.FaceValue)
               {
                   // then the card maybe played
                    isFound = true;
               }

            }

            return isFound;
        }


        /// <summary>
        /// IsOkDefendCard - card of a higher value of the same suit must be used or a the trump
        /// to beat the card the attacker layed down
        /// </summary>
        /// <param name="attackCard"></param>
        /// <param name="defendCard"></param>
        /// <returns></returns>
        public static bool IsOkDefendCard(Card attackCard, Card defendCard)
        {
            bool isValid = true;

            // if the cards are the same suit and
            // the attacker is greater than or equal 
            // to the defender
            if ((attackCard.SuitValue == defendCard.SuitValue)&&(attackCard.RankValue >= defendCard.RankValue))
            {

                // then this card 
                // cannot be played
                isValid = false;

            }
            else if ((attackCard.SuitValue != defendCard.SuitValue) && (Card.TrumpSuit != defendCard.SuitValue))
            {

                // then this card 
                // cannot be played
                isValid = false;

            }

            // return the value
            return isValid;
        }
    }
}
