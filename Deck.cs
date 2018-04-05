using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Deck
    {
        public List<Card> Cards = new List<Card>();
        public List<Card> discardedCards = new List<Card>();
        public Deck()
        {
            Initialize();
        }
        private void Initialize()
        {
            string[] values = {"Ace","2","3","4","5","6","7","8","9","10","Jack","Queen","King"};
            string[] suits = {"Diamonds","Hearts","Clubs","Spades"};

            foreach(string suit in suits)
            {
                string unicodeSuit;
                if (suit == "Diamonds")
                {
                    unicodeSuit = "\u2666";
                }
                else if (suit == "Hearts")
                {
                    unicodeSuit = "\u2665";
                }
                else if (suit == "Clubs")
                {
                    unicodeSuit = "\u2663";
                }
                else
                {
                    unicodeSuit = "\u2660";
                }
                foreach(string value in values)
                {
                    string unicodeValue;
                    if (value == "Ace")
                    {
                        unicodeValue = "1";
                    }
                    else if ( value == "10")
                    {
                        unicodeValue = "A";
                    }
                    else if ( value == "Jack")
                    {
                        unicodeValue = "B";
                    }
                    else if ( value == "Queen")
                    {
                        unicodeValue = "D";
                    }
                    else if ( value == "King")
                    {
                        unicodeValue = "E";
                    }
                    else{
                        unicodeValue = value;
                    }
                    
                    string unicode = unicodeSuit;
                    
                    Card newCard = new Card(value, suit, unicode);
                    Cards.Add(newCard);
                    
                }
            }
        }
        public Card Deal()
        {
            if(Cards.Count==0)
            {
                Shuffle();
            }
            Card dealt = Cards[0];
            Cards.RemoveAt(0);
            return dealt;
        }
        public void Shuffle()
        {
            Random rand = new Random();
            while(discardedCards.Count>0)
            {
                Cards.Add(discardedCards[0]);
                discardedCards.RemoveAt(0);
            }
            for(int i=0;i<Cards.Count;i++)
            {
                int idx = rand.Next(0,Cards.Count);
                Card tempCard = Cards[i];
                Cards[i] = Cards[idx];
                Cards[idx] = tempCard;
            }
        }
        public void Reset()
        {
            Initialize();
            discardedCards.Clear();
        }
    }
}