using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerLibrary
{
    public class Player
    {
        public string Name { get; set; }
        public Card[] Cards { get; set; }
        public enumCardRank Rank { get; set; }
        public ISpecialCases SpecialCase { get; set; }
    }
}
