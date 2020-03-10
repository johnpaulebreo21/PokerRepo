using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerLibrary
{
    public static class HandCheck
    {
        private static Dictionary<string, int> _dictionaryLowA = new Dictionary<string, int>() { 
        {"A",1}, 
        {"2",2},
        {"3",3},
        {"4",4},
        {"5",5},
        {"6",6},
        {"7",7},
        {"8",8},
        {"9",9},
        {"10",10},
        {"J",11},
        {"Q",12},
        {"K",13},  
        };

        private static Dictionary<string, int> _dictionaryHighA = new Dictionary<string, int>() { 
         
        {"2",2},
        {"3",3},
        {"4",4},
        {"5",5},
        {"6",6},
        {"7",7},
        {"8",8},
        {"9",9},
        {"10",10},
        {"J",11},
        {"Q",12},
        {"K",13},  
        {"A",14}, 

        };

        private class Group
        {
            public int Num { get; set; }
            public int count { get; set; }
        }

        private static bool isSameSuit(Card[] cards)
        {
            var checkSuits = cards.Select(c => c.Suit).Distinct().Count();
            return (checkSuits == 1 ? true : false);

        }

        private static IEnumerable<Group> groupNums(int[] nums)
        {
            var group = nums.GroupBy(n => n)
                      .Select(n => new Group()
                      {
                          Num = n.Key,
                          count = n.Count()
                      }).OrderByDescending(n => n.count);
            return group;

        }
        private static int[] arrayNums(Card[] cards, Dictionary<string, int> cardOrder)
        {
            var cardNums = cards.Select(n => n.Number).ToArray();
            var nums = new int[cardNums.Count()];

            for (int x = 0; x < cardNums.Count(); x++)
                nums[x] = cardOrder[cardNums[x]];

            var orderedNums = nums.OrderBy(n => n).ToArray();

            return orderedNums;

        }

        // list of cardChecks
        public static bool isRoyalFlush(Card[] cards)
        {
            if (!isSameSuit(cards))
                return false;

            string[] RoyalFlush = { "A", "K", "Q", "J", "10" };
            var numbers = cards.Select(c => c.Number).ToArray();

            var tempRoyalFlush = RoyalFlush.OrderBy(n => n).ToArray();
            var tempNumbers = numbers.OrderBy(n => n).ToArray();

            for (int x = 0; x < tempRoyalFlush.Length; x++)
                if (!tempRoyalFlush[x].Equals(tempNumbers[x]))
                    return false;

            return true;


        }

        public static bool isStraightFlush(Card[] cards, out ISpecialCases specialCase)
        {
            var highestNum = 0;
            specialCase = new FlushCase();
            if (!isSameSuit(cards))
                return false;

            int[] nums;
            nums = arrayNums(cards, _dictionaryLowA);

            for (int x = 0; x <= nums.Length - 2; x++)
                if (nums[x] + 1 != nums[x + 1])
                    return false;

            highestNum = nums[nums.Length - 1];
            specialCase = new FlushCase() { HighestNumber = highestNum };

            return true;
        }

        public static bool isFourofaKind(Card[] cards, out ISpecialCases specialCase)
        {
            specialCase = new FourofaKindCase();
            var four = 0;
            var kicker = 0;
            var nums = arrayNums(cards, _dictionaryHighA);

            var group = groupNums(nums).ToArray();

            foreach (var grp in group)
                if (grp.count == 4)
                {
                    four = grp.Num;
                    kicker = group[1].Num;
                    specialCase = new FourofaKindCase() { Four = four, Kicker = kicker };
                    return true;
                }

            return false;
        }

        public static bool isFullHouse(Card[] cards, out ISpecialCases specialCase)
        {

            var three = 0;
            var two = 0;
            specialCase = new FullHouseCase();

            var nums = arrayNums(cards, _dictionaryHighA);

            var group = groupNums(nums).ToArray();

            if (group.Count() != 2)
                return false;

            foreach (var grp in group)
                if (grp.count == 3)
                {
                    three = grp.Num;
                    two = group[1].Num;
                    specialCase = new FullHouseCase() { Three = three, Two = two };
                    return true;
                }

            return false;

        }

        public static bool isFlush(Card[] cards, out ISpecialCases specialCase)
        {
            specialCase = new FlushCase();
            var highestNum = 0;
            if (!isSameSuit(cards))
                return false;

            var nums = arrayNums(cards, _dictionaryHighA);
            highestNum = nums[nums.Length - 1];
            specialCase = new FlushCase() { HighestNumber = highestNum };
            return true;
        }


    }


}
