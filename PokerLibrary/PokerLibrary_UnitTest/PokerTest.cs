using PokerLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PokerLibrary_UnitTest
{

    /// <summary>
    ///This is a test class for Class1Test and is intended
    ///to contain all Class1Test Unit Tests
    ///</summary>
    [TestClass()]
    public class PokerTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion



        [TestMethod()]
        public void LetsPlay()
        {

            var cards1 = new Card[]{
                new Card(){ Number = "A",Suit = 'D' },
                new Card(){ Number = "K",Suit = 'D' },
                new Card(){ Number = "Q",Suit = 'D' },
                new Card(){ Number = "J",Suit = 'D' },
                new Card(){ Number = "10",Suit = 'D' } 
            };
            var Player1 = new Player()
            {
                Name = "player 1",
                Cards = cards1
            };


            var cards2 = new Card[]{
                new Card(){ Number = "8",Suit = 'C' },
                new Card(){ Number = "7",Suit = 'C' },
                new Card(){ Number = "6",Suit = 'C' },
                new Card(){ Number = "5",Suit = 'C' },
                new Card(){ Number = "4",Suit = 'C' } 
            };
            var Player2 = new Player()
            {
                Name = "player 2",
                Cards = cards2
            };

            var cards3 = new Card[]{
                new Card(){ Number = "J",Suit = 'H' },
                new Card(){ Number = "J",Suit = 'D' },
                new Card(){ Number = "J",Suit = 'S' },
                new Card(){ Number = "J",Suit = 'C' },
                new Card(){ Number = "7",Suit = 'D' } 
            };
            var Player3 = new Player()
            {
                Name = "player 3",
                Cards = cards3
            };

            var cards4 = new Card[]{
                new Card(){ Number = "10",Suit = 'H' },
                new Card(){ Number = "10",Suit = 'D' },
                new Card(){ Number = "10",Suit = 'S' },
                new Card(){ Number = "9",Suit = 'C' },
                new Card(){ Number = "9",Suit = 'D' } 
            };
            var Player4 = new Player()
            {
                Name = "player 4",
                Cards = cards4
            };

            var cards5 = new Card[]{
                new Card(){ Number = "4",Suit = 'S' },
                new Card(){ Number = "J",Suit = 'S' },
                new Card(){ Number = "8",Suit = 'S' },
                new Card(){ Number = "2",Suit = 'S' },
                new Card(){ Number = "9",Suit = 'S' } 
            };
            var Player5 = new Player()
            {
                Name = "player 5",
                Cards = cards5
            };


            var players = new List<Player>()
            {
                Player1,Player2,Player3,Player4,Player5
            };


            var target = new Poker();
            Console.WriteLine(target.PlayPoker(players));


        }

    }
}
