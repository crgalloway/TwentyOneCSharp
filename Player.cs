using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Player
    {
        public string name;
        public List<Card> hand = new List<Card>();
        public int score;
        public Player(string name)
        {
            this.name = name;
        }
        public Card Draw(Deck activeDeck)
        {
            Card dealtCard = activeDeck.Deal();
            hand.Add(dealtCard);
            AdjustScore();
            return dealtCard;
        }
        public Card Discard(Deck activeDeck, int idx)
        {
            if(idx >= hand.Count)
            {
                return null;
            }
            else
            {
                Card cardDiscarded = hand[idx];
                activeDeck.discardedCards.Add(cardDiscarded);
                hand.RemoveAt(idx);
                return cardDiscarded;
            }
        }
        private void AdjustScore()
        {
            score = 0;
            bool hasAce = false;
            foreach(Card card in hand)
            {
                score += card.val;
                if (card.val == 11)
                {
                    hasAce = true;
                }
            }
            if (score > 21 && hasAce)
            {
                score -= 10;
            }
        }
    }
}