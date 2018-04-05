using System;

namespace DeckOfCards
{
    class Card
    {
        public string stringVal;
        public string suit;
        public int val;
        public Card(string stringVal,string suit)
        {
            this.stringVal = stringVal;
            this.suit = suit;
            if (stringVal == "Ace")
            {
                this.val = 11;
            }
            else if (stringVal == "Jack")
            {
                this.val = 10;
            }
            else if (stringVal == "Queen")
            {
                this.val = 10;
            }
            else if (stringVal == "King")
            {
                this.val = 10;
            }
            else
            {
                this.val = Int32.Parse(stringVal);
            }
        }
    }
}