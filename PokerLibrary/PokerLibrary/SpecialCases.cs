using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerLibrary
{
    public interface ISpecialCases {};
     
    public class FourofaKindCase : ISpecialCases
    {
        public int Four { get; set; } 
        public int Kicker { get; set; } 
    }
    public class FullHouseCase : ISpecialCases
    {
        public int Three { get; set; }
        public int Two { get; set; }  
    }
    public class FlushCase : ISpecialCases
    {
        public int HighestNumber { get; set; }
    }

}
