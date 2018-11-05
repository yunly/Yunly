using System;
using System.Linq;
using System.Collections.Generic;

namespace Yunly.Learning.CodeWars
{
    /*
     A famous casino is suddenly faced with a sharp decline of their revenues. They decide to offer Texas hold'em also online. Can you help them by writing an algorithm that can rank poker hands?

Task:

Create a poker hand that has a method to compare itself to another poker hand:
    Result PokerHand.CompareWith(PokerHand hand);
A poker hand has a constructor that accepts a string containing 5 cards:
    PokerHand hand = new PokerHand("KS 2H 5C JD TD");
The characteristics of the string of cards are:
A space is used as card seperator
Each card consists of two characters
The first character is the value of the card, valid characters are: 
2, 3, 4, 5, 6, 7, 8, 9, T(en), J(ack), Q(ueen), K(ing), A(ce)
The second character represents the suit, valid characters are: 
S(pades), H(earts), D(iamonds), C(lubs)

The result of your poker hand compare can be one of these 3 options:
    public enum Result 
    { 
        Win, 
        Loss, 
        Tie 
    }
Apply the Texas Hold'em rules for ranking the cards.
There is no ranking for the suits.
    */
    public enum Result
    {
        Win,
        Loss,
        Tie
    }

    public class PokerHand
    {
        public PokerHand(string hand)
        {
            Cards = hand.ToString().Split(' ')
                                   .Select(Card.Parse)
                                   .OrderByDescending(x => x.Rank)
                                   .ToList();

            CardsByRank = Cards.GroupBy(x => x.Rank)
                               .ToDictionary(x => x.Key, x => x.ToList());

            IsSameSuite = Cards.All(x => x.Suite == Cards[0].Suite);

            //check if a array is  sequencial
            IsSequence = Cards.TakeWhile((x, i) => i < 4 && x.Rank == Cards[i + 1].Rank + 1)
                              .Count() == 4;
            //check if a array is  sequencial
            IsSequence = Cards.Zip(Cards.Skip(1), (first, second) => first.Rank - 1 == second.Rank).All(x => x);

            
        }

        public List<Card> Cards { get; private set; }
        public Dictionary<int, List<Card>> CardsByRank { get; private set; }

        public bool IsSameSuite { get; private set; }
        public bool IsSequence { get; private set; }

        public Result CompareWith(PokerHand hand)
        {
            var r1 = Ranker.Rank(this);
            var r2 = Ranker.Rank(hand);
            if (r1 > r2) return Result.Win;
            if (r1 < r2) return Result.Loss;
            return Result.Tie;
        }
    }

    public class Ranker
    {
        private static List<Func<PokerHand, bool>> _ranks = new List<Func<PokerHand, bool>>
        {
       x => x.IsSameSuite && x.IsSequence && x.Cards[0].Name == 'A',  // royal flush
       x => x.IsSequence && x.IsSameSuite,                            // straight flush
       x => x.CardsByRank.Any(g => g.Value.Count == 4),               // four of the kind
       x => x.CardsByRank.Any(g => g.Value.Count == 3) &&
            x.CardsByRank.Any(g => g.Value.Count == 2),               // full house
       x => x.IsSameSuite,                                            // flush    
       x => x.IsSequence,                                             // straight    
       x => x.CardsByRank.Any(g => g.Value.Count == 3),               // three of the kind
       x => x.CardsByRank.Count(g => g.Value.Count == 2) == 2,        // two pairs
       x => x.CardsByRank.Any(g => g.Value.Count == 2),               // pair
       _ => true
        };

        public static double Rank(PokerHand hand)
        {
            var rank = Math.Pow(10, _ranks.Count - _ranks.FindIndex(x => x(hand)));
            var baseScore = hand.Cards.Select((x, i) => (x.Rank + 1) / Math.Pow(10, i)).Sum();
            return rank + baseScore;
        }
    }

    public class Card
    {
        public char Name { get; private set; }
        public char Suite { get; private set; }
        public int Rank { get; private set; }

        public static readonly Func<string, Card> Parse = card => new Card()
        {
            Name = card[0],
            Suite = card[1],
            Rank = "23456789TJQKA".IndexOf(card[0])
        };
    }
}
