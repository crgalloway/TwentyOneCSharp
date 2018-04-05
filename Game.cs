using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards
{
    class Game
    {
        List<Player> PlayerList;
        Deck twentyOne;
        public Game(){
            twentyOne = new Deck();
        }
        private void CreatePlayers()
        {
            Console.Clear();
            System.Console.WriteLine("Enter Player's name:");
            string newName = Console.ReadLine();
            Player newPlayer = new Player(newName);
            PlayerList.Add(newPlayer);
        }
        private void StartGame()
        {
            if (PlayerList.Count>1)
            {
                foreach(Player player in PlayerList)
                {
                    Console.Clear();
                    System.Console.WriteLine($"{player.name}'s turn, hit enter to continue.");
                    Console.ReadLine();
                    bool stillPlaying = true;
                    while(player.score <22 && stillPlaying)
                    {
                        Console.Clear();
                        System.Console.WriteLine($"{player.name}'s current hand value: {player.score}");
                        System.Console.WriteLine($"{player.name}'s current hand:");
                        foreach(Card card in player.hand)
                        {
                            System.Console.WriteLine($"{card.stringVal} of {card.suit}");
                        }
                        System.Console.WriteLine("Hit or Stand?");
                        string action = Console.ReadLine();
                        if(action == "Hit"||action == "hit"||action == "H"||action == "h")
                        {
                            player.Draw(twentyOne);
                        }
                        else if(action == "Stand"||action == "stand"||action == "S"||action == "s")
                        {
                            stillPlaying =false;
                        }
                    }
                    if(player.score > 21)
                    {
                        System.Console.WriteLine("Bust! You have been eliminated");
                        EliminatePlayer(player);
                        continue;
                    }
                }

            }
        }
        private void EliminatePlayer(Player loser)
        {
            PlayerList.Remove(loser);
        }
        private void EndGame(){
            Console.Clear();
            System.Console.WriteLine("Game Over! Here is the score");
            foreach(Player player in PlayerList)
            {
                System.Console.WriteLine($"{player.name} - {player.score}");
            }
            Player winner = PlayerList.OrderBy(player => player.score).Reverse().First();
        }
    }
}