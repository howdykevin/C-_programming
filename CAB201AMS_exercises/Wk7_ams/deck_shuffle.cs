// create a Deck class representing a deck of 52 playing cards.
// The deck will be made up of 52 regular playing cards and will not include any extra cards that may be found in a typical deck (such as jokers or rule cards).
// The 52 cards will be divided up into four suits of 13 cards each, with the suits named after the suits in a pack of Swiss German playing cards.
// The suit names are, in order: Roses, Bells, Acorns, Shields
// The names of the 13 cards are, in order: Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Knave, Knight, King.
// When a Deck is first created, before the cards in it are shuffled, the cards should be in a particular order. That order is that the 13 cards (in order from Ace to King) from the Roses suit should appear first, followed by the 13 cards from the Bells suit, followed by the Acorns, followed by the Shields suit. Therefore the first card in a newly created Deck should be the Ace of Roses, while the last card should be the King of Shields.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardDealer
{
    class Deck
    {
        // Include any private fields here
        // ...
        string[,] allcards = new string[,] { {"Ace","Roses" }, {"Two","Roses"}, { "Three", "Roses" }, { "Four", "Roses" },{ "Five", "Roses" }, { "Six", "Roses" }, { "Seven", "Roses" }, { "Eight", "Roses" }, { "Nine", "Roses" },{ "Ten", "Roses" },{ "Knave", "Roses" },{ "Knight", "Roses" }, { "King","Roses" },
                                  {"Ace","Bells" }, {"Two","Bells"}, { "Three", "Bells" }, { "Four", "Bells" },{ "Five", "Bells" }, { "Six", "Bells" }, { "Seven", "Bells" }, { "Eight", "Bells" }, { "Nine", "Bells" },{ "Ten", "Bells" },{ "Knave", "Bells" },{ "Knight", "Bells" }, { "King","Bells" },
                                {"Ace","Acorns" }, {"Two","Acorns"}, { "Three", "Acorns" }, { "Four", "Acorns" },{ "Five", "Acorns" }, { "Six", "Acorns" }, { "Seven", "Acorns" }, { "Eight", "Acorns" }, { "Nine", "Acorns" },{ "Ten", "Acorns" },{ "Knave", "Acorns" },{ "Knight", "Acorns" }, { "King","Acorns" },
                                {"Ace","Shields" }, {"Two","Shields"}, { "Three", "Shields" }, { "Four", "Shields" },{ "Five", "Shields" }, { "Six", "Shields" }, { "Seven", "Shields" }, { "Eight", "Shields" }, { "Nine", "Shields" },{ "Ten", "Shields" },{ "Knave", "Shields" },{ "Knight", "Shields" }, { "King","Shields" }};
        List<Tuple<string, string>> cards = new List<Tuple<string, string>>();
        private string result;
        Random rng = new Random();


        public Deck()
        {
            // Include your code here
            // allcards.Length/2 because it counts every element it doesnt count every tuple. A tuple just refers to a pair of data.
            for (int i = 0; i < allcards.Length/2; i++)
            {
                cards.Add(new Tuple<string, string>(allcards[i, 0], allcards[i, 1]));
            }
        }

        public void Shuffle()
        {
            // Include your code here
            // ...

            //cards.Clear();
            //for (int i = 0; i < allcards.Length / 2; i++)
            //{
            //    cards.Add(new Tuple<string, string>(allcards[i, 0], allcards[i, 1]));
            //}
            cards.Clear();
            for (int i = 0; i < allcards.Length / 2; i++)
            {
                cards.Add(new Tuple<string, string>(allcards[i, 0], allcards[i, 1]));
            }

            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Tuple<string, string> card = cards[k];
                cards[k] = cards[n];
                cards[n] = card;
            }
            
            
        }

        public string Deal()
        {


            if (cards.Count()<=0)
            {
                result = "All cards have been dealt";
            }
            else
            {
                Tuple<string, string> card = cards[0];
                result = card.Item1 + " of " + card.Item2;
                cards.RemoveAt(0);
            }

            return result;
            

        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Deck newDeck = new Deck();
            Console.WriteLine("Hello");
            Console.WriteLine(newDeck.Deal());
            newDeck.Shuffle();
            Console.WriteLine(newDeck.Deal());



        }
    }


}
