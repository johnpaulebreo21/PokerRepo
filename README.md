# Poker

This is a code to determine which player or players win in a game of Poker.
 
#### Input:
    Collection of Players with PlayerName and Hand of Cards
#### Output:
    String of PlayerName with Hand of Cards and Winning Hand Rank

## Givens:
* Card Numbers: A, 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K
* Card Suits: H – Hearts, S – Spades, C – Clubs, D – Diamonds 
 
## Assumptions:
1. Cards are well distributed among all of the players.
2. No jokers/wild cards are distributed.
3. Only 5 Poker Hands are evaluated.\
 Listed below, Royal Flush being the highest hand.
* Royal Flush
* Straight Flush
* Four of a Kind
* Full House
* Flush
4. If winning players have identical hand regardless of suits, all of the winning players win. (Multiple Winners)
5. If winning players have the same Poker Hand, the one with the Highest Card wins regardless of suits (One Winner)

## How to Use (Unit Test)
1. PerHandTest\
Set of cards are evaluated to determine rank.
* RoyalFlush()
* StraightFlush()
* FourofaKind()
* FullHouse()
* Flush()
2. PokerTest\
Pass a collection of players with their own set of cards to determine which is the winner.
* LetsPlay()

 
##### Developer 
John Paul G. Ebreo\
Software Engineer
