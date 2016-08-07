/**
 * Author:      A. Paul Massardo
 * Program:     Group Project
 * Date:        13-Feb-2015
 * Description: Players class is a collection class that inherits from a typed list List<DurakPlayer>.
 * 
*/

// using-import-includesusing System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// namespace
namespace DurakLibrary
{
    /// <summary>
    /// Players class is a collection class that inherits from a typed list List<DurakPlayer>.
    /// </summary>
    public class Players : List<DurakPlayer>
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void Add(string name)
        {
            // create a new player using the parameterized constructor
            DurakPlayer newPlayer = new DurakPlayer(name);

            // add the player to the base
            base.Add(newPlayer);

        }
        
    }
}
