﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11CardLib
{
    public class Card : ICloneable
    {
        /// <summary>
        /// Flag for trump usage. If true, trumps are valued higher
        /// than cards of other suits.
        /// </summary>
        public static bool useTrumps = false;
        /// <summary>
        /// Trump suit to use if useTrumps is true.
        /// </summary>
        public static Suit trump = Suit.Club;
        /// <summary>
        /// Flag that determines whether aces are higher than kings or lower
        /// than deuces.
        /// </summary>
        public static bool isAceHigh = true;

        public object Clone() => MemberwiseClone();
        public readonly Suit suit;
        public readonly Rank rank;
        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }
        private Card() { }
        public override string ToString() => "The " + rank + " of " + suit + "s";

        public static bool operator ==(Card card1, Card card2)
             => (card1?.suit == card2?.suit) && (card1?.rank == card2?.rank);
        public static bool operator !=(Card card1, Card card2)
             => !(card1 == card2);
        public override bool Equals(object card) => this == (Card)card;
        public override int GetHashCode()
                      => 13 * (int) suit + (int) rank;
        public static bool operator >(Card card1, Card card2)
        {
            if (card1.suit == card2.suit)
            {
                if (card1.rank == Rank.Ace)
                {
                    if (card2.rank == Rank.Ace)
                    {    return false;}
                    else
                    {    return isAceHigh;}
                }
                else
                {   return (card1.rank > card2.rank);}
            }
            else
            {
                if (useTrumps && (card2.suit == Card.trump))
                {    return false;}
                else
                {    return true;}
            }
        }
        public static bool operator <(Card card1, Card card2)
               => !(card1 >= card2);
        public static bool operator >=(Card card1, Card card2)
        {
            if (card1.suit == card2.suit)
            {
                if (isAceHigh)
                {
                    if (card1.rank == Rank.Ace)
                    {   return true;}
                    else if (card2.rank == Rank.Ace)
                    {   return false;}
                    else
                    {   return (card1.rank >= card2.rank);}
                }
                else
                {   return (card1.rank >= card2.rank);}
            }
            else
            {
                if (useTrumps && (card2.suit == Card.trump))
                {    return false;}
                else
                {    return true;}
            }
        }
        public static bool operator <=(Card card1, Card card2)
               => !(card1 > card2);
    }
}
