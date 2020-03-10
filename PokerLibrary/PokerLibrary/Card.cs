using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerLibrary
{
    public class Card
    {
        public string Number { get; set; }
        public char Suit { get; set; }
        public override string ToString()
        {
            return Number + Suit + ", ";


        }
    }
}
