using System;
using System.Diagnostics;

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
                Logger("Hello This is a Log Test");
            }
        }

        public static void Logger(String lines)
        {

            // Write the string to a file.append mode is enabled so that the log
            // lines get appended to  test.txt than wiping content and writing the log

            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt", true);
            file.WriteLine(lines);

            file.Close();

        }
    }
}
