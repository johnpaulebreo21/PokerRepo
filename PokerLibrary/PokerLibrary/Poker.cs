using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PokerLibrary
{
    public class Poker
    {

        public string PlayPoker(List<Player> players)
        {

            var playerCtr = 0;
            var tempPlayers = new List<Player>();
            foreach (Player player in players)
            {
                var tempPlayer = CheckCards(player);
                tempPlayers.Add(tempPlayer);
                playerCtr++;
            }

            var ranks = tempPlayers.OrderByDescending(p => p.Rank).Take(1).Select(p => p.Rank);
            enumCardRank highestRank = enumCardRank.noRank;
            foreach (var rank in ranks)
                highestRank = rank;

            if (highestRank == enumCardRank.noRank)
                return "No Winners";


            var finalWinners = PickWinners(highestRank, tempPlayers);
            var strWinner = "";
            foreach (var Winner in finalWinners)
            {
                strWinner += Winner.Name + ": ";
                foreach (var cards in Winner.Cards)
                    strWinner += cards.ToString();

                strWinner += "(" + highestRank + ")" + Environment.NewLine;
            }

            return strWinner.Replace(", (", " (");
 
        }

        private IEnumerable<Player> PickWinners(enumCardRank highestRank, IEnumerable<Player> tempPlayers)
        {
            var winners = tempPlayers.Where(p => p.Rank.Equals(highestRank));
            var topWinners = new List<Player>();

            switch (highestRank)
            {
                case enumCardRank.RoyalFlush:
                    return winners;
                case enumCardRank.StraightFlush:
                case enumCardRank.Flush:
                    var tempFlushWinners = winners.OrderByDescending(w => (((FlushCase)w.SpecialCase).HighestNumber)).ToArray();

                    topWinners.Add(tempFlushWinners[0]);
                    var highestNum = ((FlushCase)tempFlushWinners[0].SpecialCase).HighestNumber;

                    for (int x = 1; x < tempFlushWinners.Length; x++)
                    {
                        var num = ((FlushCase)tempFlushWinners[x].SpecialCase).HighestNumber;
                        if (num == highestNum)
                            topWinners.Add(tempFlushWinners[x]);
                    }
                    return topWinners;
                case enumCardRank.FourofaKind:
                    var tempFourWinners = winners.OrderByDescending(w => (((FourofaKindCase)w.SpecialCase).Four)).ThenByDescending(w => (((FourofaKindCase)w.SpecialCase).Kicker)).ToArray();

                    topWinners.Add(tempFourWinners[0]);
                    var four = ((FourofaKindCase)tempFourWinners[0].SpecialCase).Four;
                    var kicker = ((FourofaKindCase)tempFourWinners[0].SpecialCase).Kicker;

                    for (int x = 1; x < tempFourWinners.Length; x++)
                        if (four == ((FourofaKindCase)tempFourWinners[x].SpecialCase).Four && kicker == ((FourofaKindCase)tempFourWinners[x].SpecialCase).Kicker)
                            topWinners.Add(tempFourWinners[x]);

                    return topWinners;
                case enumCardRank.FullHouse:
                    var tempFullWinners = winners.OrderByDescending(w => (((FullHouseCase)w.SpecialCase).Three)).ThenByDescending(w => (((FullHouseCase)w.SpecialCase).Two)).ToArray();

                    topWinners.Add(tempFullWinners[0]);
                    var three = ((FullHouseCase)tempFullWinners[0].SpecialCase).Three;
                    var two = ((FullHouseCase)tempFullWinners[0].SpecialCase).Two;

                    for (int x = 1; x < tempFullWinners.Length; x++)
                        if (three == ((FullHouseCase)tempFullWinners[x].SpecialCase).Three && two == ((FullHouseCase)tempFullWinners[x].SpecialCase).Two)
                            topWinners.Add(tempFullWinners[x]);

                    return topWinners;
                default:
                    return winners;
            }


        }


        private Player CheckCards(Player player)
        {

            ISpecialCases specialCase;

            if (HandCheck.isRoyalFlush(player.Cards))
            {
                player.Rank = enumCardRank.RoyalFlush;
            }
            else if (HandCheck.isStraightFlush(player.Cards, out specialCase))
            {
                player.Rank = enumCardRank.StraightFlush;
                player.SpecialCase = specialCase;
            }
            else if (HandCheck.isFourofaKind(player.Cards, out specialCase))
            {
                player.Rank = enumCardRank.FourofaKind;
                player.SpecialCase = specialCase;
            }
            else if (HandCheck.isFullHouse(player.Cards, out specialCase))
            {
                player.Rank = enumCardRank.FullHouse;
                player.SpecialCase = specialCase;
            }
            else if (HandCheck.isFlush(player.Cards, out specialCase))
            {
                player.Rank = enumCardRank.Flush;
                player.SpecialCase = specialCase;
            }
            else
            {
                player.Rank = enumCardRank.noRank;
            }

            return player;

        }

    }


}
