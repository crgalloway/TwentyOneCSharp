using System;

namespace DeckOfCards
{
    class Card
    {
        public string stringVal;
        public string suit;
        public string unicode;
        public int val;
        public Card(string stringVal,string suit, string unicode)
        {
            this.stringVal = stringVal;
            this.suit = suit;
            this.unicode = unicode;
            
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