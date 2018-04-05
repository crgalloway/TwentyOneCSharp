using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards
{
    class Game
    {
        List<Player> PlayerList = new List<Player>();
        Deck twentyOne;
        Player dealer;
        public Game(){
            twentyOne = new Deck();
            twentyOne.Shuffle();
            // Player Dealer = new Player("Dealer");
            // PlayerList.Add(Dealer);
            CreatePlayers();
            StartGame();
        }
        private void CreatePlayers()
        {
            Console.Clear();
            System.Console.WriteLine("Enter Player's name:");
            string newName = Console.ReadLine();
            Player newPlayer = new Player(newName);
            PlayerList.Add(newPlayer);
            System.Console.WriteLine("Create more players? Yes/No");
            string morePlayers = Console.ReadLine();
            if(morePlayers == "Yes"||morePlayers == "yes"||morePlayers == "Y"||morePlayers == "y")
            {
                CreatePlayers();
            }
        }
        private void StartGame()
        {
            while(PlayerList.Count<2)
            {
                Console.Clear();
                System.Console.WriteLine("You need more players first!");
                Console.ReadLine();
                CreatePlayers();
            }
            foreach(Player player in PlayerList)
            {
                player.Draw(twentyOne);
                player.Draw(twentyOne);
            }
            CoreGame();           
        }
        private void CoreGame(){
            foreach(Player player in PlayerList)
            {
                if (player == dealer)
                {
                    continue;
                }
                Console.Clear();
                System.Console.WriteLine($"{player.name}'s turn, hit enter to continue.");
                Console.ReadLine();
                bool stillPlaying = true;
                while(player.score <22 && stillPlaying)
                {
                    UpdateScreen(player);
                    System.Console.WriteLine("(H)it or (S)tand or (V)iew the other visible cards?");
                    string action = Console.ReadLine();
                    if(action == "Hit"||action == "hit"||action == "H"||action == "h")
                    {
                        player.Draw(twentyOne);
                        continue;
                    }
                    else if(action == "Stand"||action == "stand"||action == "S"||action == "s")
                    {
                        stillPlaying =false;
                    }
                    else if(action == "View"||action == "view"||action == "V"||action == "v")
                    {
                        ViewOtherCards(player);
                    }
                    else
                    {
                        System.Console.WriteLine("Just work with us here, you know what to enter.");
                        Console.ReadLine();
                        continue;
                    }
                }
                if(player.score > 21)
                {
                    UpdateScreen(player);
                    System.Console.WriteLine($"{player.name} Bust!");
                    // EliminatePlayer(player);
                    Console.ReadLine();
                    continue;
                }
            }
            System.Console.WriteLine("Is everyone done? (Y)es/(N)o");
            string done = Console.ReadLine();
            if(done == "Yes"||done == "yes"||done == "Y"||done == "y")
            {
                EndGame();
            }
            else if(done == "No"||done == "no"||done == "N"||done == "n")
            {
                CoreGame();
            }
        }
        private void EliminatePlayer(Player loser)
        {
            PlayerList.Remove(loser);
        }
        private void ViewOtherCards(Player player){
            foreach(Player otherPlayer in PlayerList)
            {
                if(otherPlayer.name == player.name)
                {
                    continue;
                }
                Console.Clear();
                System.Console.WriteLine($"{otherPlayer.name}'s cards:");
                System.Console.WriteLine("===================");
                System.Console.WriteLine("One face-down card");
                for(int i =1; i<otherPlayer.hand.Count;i++)
                {
                    Console.OutputEncoding = System.Text.Encoding.Unicode;
                    System.Console.WriteLine($"{otherPlayer.hand[i].stringVal} of {otherPlayer.hand[i].suit} {otherPlayer.hand[i].unicode}");
                }
                Console.ReadLine();
            }
        }
        private void UpdateScreen(Player player)
        {
            Console.Clear();
            System.Console.WriteLine($"{player.name}'s current hand value: {player.score}");
            System.Console.WriteLine($"{player.name}'s current hand:");
            foreach(Card card in player.hand)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                System.Console.WriteLine($"{card.stringVal} of {card.suit} {card.unicode}");
            }
        }
        private void EndGame()
        {
            Console.Clear();
            System.Console.WriteLine("Game Over! Here are the scores:");
            foreach(Player player in PlayerList)
            {
                System.Console.WriteLine($"{player.name} - {player.score}");
            }
            var scoreList = PlayerList.OrderBy(player =>player.score).Reverse().ToList();
            int highScore = scoreList[0].score;
            foreach(Player player in scoreList)
            {
                if(player.score >=22)
                {
                    continue;
                }
                highScore = player.score;
                break;
            }
            List<Player> winners = PlayerList.Where(player =>player.score == highScore).ToList();
            foreach(Player winner in winners)
            {
                System.Console.WriteLine($"{winner.name} wins!");
            }
        }
    }
}