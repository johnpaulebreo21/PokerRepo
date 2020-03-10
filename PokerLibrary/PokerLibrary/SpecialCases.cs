using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerLibrary
{
    
    //Special cases pertains to Poker Hand's conditions in winning whenever there are multiple players having the same Poker Hand Rank

    public interface ISpecialCases {};
     
    public class FourofaKindCase : ISpecialCases
    {
        //Four of a Kind ranks players depending on the Highest Four then by the Highest Kicker
        public int Four { get; set; } 
        public int Kicker { get; set; } 
    }
    public class FullHouseCase : ISpecialCases
    {
        //Full House ranks players depending on the Highest Three then by the Highest Two
        public int Three { get; set; }
        public int Two { get; set; }  
    }
    public class FlushCase : ISpecialCases
    {
        //Flush/StraightFlush ranks players depending on the Highest Card Number
        public int HighestNumber { get; set; }
    }

}
