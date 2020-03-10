using PokerLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace PokerLibrary_UnitTest
{
    [TestClass]
    public class PerHandTest
    {
        /// <summary>
        ///A test for Class1 Constructor
        ///</summary>
        [TestMethod()]
        public void RoyalFlush()
        {

            var cards = new Card[]{
                new Card(){ Number = "A",Suit = 'D' },
                new Card(){ Number = "K",Suit = 'D' },
                new Card(){ Number = "Q",Suit = 'D' },
                new Card(){ Number = "J",Suit = 'D' },
                new Card(){ Number = "10",Suit = 'D' }
            
            };

            var value = HandCheck.isRoyalFlush(cards);

            Assert.AreEqual(value, true);
        }

        [TestMethod()]
        public void StraighFlush()
        {

            var cards = new Card[]{
                new Card(){ Number = "8",Suit = 'C' },
                new Card(){ Number = "7",Suit = 'C' },
                new Card(){ Number = "6",Suit = 'C' },
                new Card(){ Number = "5",Suit = 'C' },
                new Card(){ Number = "4",Suit = 'C' }
            
            };
            ISpecialCases specialCase;
            var value = HandCheck.isStraightFlush(cards, out specialCase);

            Assert.AreEqual(value, true);
        }

        [TestMethod()]
        public void FourofaKind()
        {
            Poker target = new Poker();
            var cards = new Card[]{
                new Card(){ Number = "J",Suit = 'H' },
                new Card(){ Number = "J",Suit = 'D' },
                new Card(){ Number = "J",Suit = 'S' },
                new Card(){ Number = "J",Suit = 'C' },
                new Card(){ Number = "7",Suit = 'D' }
            
            };

            ISpecialCases specialCase;
            var value = HandCheck.isFourofaKind(cards, out specialCase);

            Assert.AreEqual(value, true);

        }

        [TestMethod()]
        public void FullHouse()
        {
            Poker target = new Poker();
            var cards = new Card[]{
                new Card(){ Number = "10",Suit = 'H' },
                new Card(){ Number = "10",Suit = 'D' },
                new Card(){ Number = "10",Suit = 'S' },
                new Card(){ Number = "9",Suit = 'C' },
                new Card(){ Number = "9",Suit = 'D' }
            
            };
            ISpecialCases specialCase;
            var value = HandCheck.isFullHouse(cards, out specialCase);

            Assert.AreEqual(value, true);

        }

        [TestMethod()]
        public void Flush()
        {
            var cards = new Card[]{
                new Card(){ Number = "4",Suit = 'S' },
                new Card(){ Number = "J",Suit = 'S' },
                new Card(){ Number = "8",Suit = 'S' },
                new Card(){ Number = "2",Suit = 'S' },
                new Card(){ Number = "9",Suit = 'S' }
            
            };
            ISpecialCases specialCase;
            var value = HandCheck.isFlush(cards, out specialCase);

            Assert.AreEqual(value, true);

        }
    }
}
