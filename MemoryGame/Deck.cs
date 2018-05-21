using System;

namespace MemoryGame
{
    public class Deck<T>
    {
        public ArrayList<T> deck;
        
        public Deck(ArrayList<T> cards)
        {
            deck = cards;
            Shuffle();
        }

        public T this[int i]
        {
            get { return deck[i]; }
            set { deck[i] = value; }
        }

        public void PrintDeck()
        {
            foreach (T t in deck)
            {
                Console.WriteLine(t.ToString());
            }
            Console.ReadLine();
        }

        

        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < deck.Count; i++)
            {
                int j = random.Next(1, deck.Count);
                T temp = deck[j];
                deck[j] = deck[i];
                deck[i] = temp;

            }
        }
    }
}
