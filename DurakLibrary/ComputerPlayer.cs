/**
 * Author:      A. Paul Massardo
 * Program:     Group Project
 * Date:        13-Feb-2015
 * Description: ComputerPlayer class represents  the player that will play the human and will make decisions on how to play on its own.
 *              The ComputerPlayer inherits from the DurakPlayer class
*/

// using-import-includesusing System;using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardLibrary;

// namespace
namespace DurakLibrary
{
    /// <summary>
    /// ComputerPlayer class represents  the player that will play the human and will make decisions on how to play on its own.
    /// The ComputerPlayer inherits from the  DurakPlayer class
    /// </summary>
    public class ComputerPlayer : DurakPlayer
    {

        /// <summary>
        /// fieldPlayerBrain - instance variable to hold if the player's decision making
        /// </summary>
        private Brain fieldPlayerBrain;

        /// <summary>
        /// isAdvanced - instance variable to hold if advanced play should be used?
        /// </summary>
        private bool isAdvanced = true;

        /// <summary>
        ///  ComputerPlayer - parameterized constructor that call the base constructor
        ///                   and also instiates a brain
        /// </summary>
        /// <param name="name"></param>
        public ComputerPlayer(string name,bool isAdvanced) : base(name)
        {

            // instantiate a brain
            fieldPlayerBrain = new Brain(isAdvanced);

        }

        /// <summary>
        ///  PlayerBrain - is the object used to make decisions for the computer player
        /// </summary>
        public Brain PlayerBrain
        {
            get 
            { 
                return fieldPlayerBrain; 
            }
            set 
            { 
                fieldPlayerBrain = value; 
            }
        }

        public bool Attack(List<Card> battleField)
        {
            return fieldPlayerBrain.Attack(battleField, base.Hand);
        }

        public bool Defend(List<Card> battleField)
        {
            return fieldPlayerBrain.Defend(battleField, base.Hand);
        }

    }
}
