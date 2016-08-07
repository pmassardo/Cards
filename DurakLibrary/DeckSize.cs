/**
 * Author:      A. Paul Massardo
 * Program:     Group Project
 * Date:        13-Feb-2015
 * Description: DeckSize enumerator used to specify the deck size.
 * 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DurakLibrary
{
    /// <summary>
    ///  is an enumerator used to specify the deck size without 
    ///  allowing the user/developer to select something that would 
    ///  not make sense. The deck sizes are restricted to 20, 36, 
    ///  and 52
    /// </summary>
    public enum DeckSize : byte
    {
        Twenty=8,
        ThirtySix=4,
        FiftyTwo=0
    };
}
