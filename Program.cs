﻿using System;
using System.Text;


namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck newDeck = new Deck();
            newDeck.Shuffle();
            Player player1 = new Player("Craig");
            player1.Draw(newDeck);
            player1.Draw(newDeck);
            player1.Draw(newDeck);
            player1.Draw(newDeck);
            player1.Draw(newDeck);
            System.Console.WriteLine(player1.name+"'s Hand:");
            foreach (Card card in player1.hand)
            {

            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("{1} of {0} {2}", card.unicode, card.stringVal, card.suit);
     
            }
            // player1.Discard(newDeck,1);
            // player1.Discard(newDeck,0);
            // player1.Discard(newDeck,3);
            // player1.Discard(newDeck,0);
            // player1.Draw(newDeck);
            // player1.Draw(newDeck);
            // player1.Draw(newDeck);
            // player1.Draw(newDeck);
            // System.Console.WriteLine("Currently discarded cards:");
            // foreach (Card card in newDeck.discardedCards)
            // {
            //     System.Console.WriteLine("{0} of {1}",card.stringVal,card.suit);
            // }
            // System.Console.WriteLine(player1.name+"'s new Hand:");
            // foreach (Card card in player1.hand)
            // {
            //     System.Console.WriteLine("{0} of {1}",card.stringVal,card.suit);
            // }
        }
    }
}
