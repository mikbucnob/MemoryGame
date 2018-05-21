using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    public class Card
    {
        public enum Face { Ace = 1, Two=2, Three=3, Four=4, Five=5, Six=6, Seven=7, Eight=8, Nine=9, Ten=10, Jack=11, Queen=12, King=13 };
        public enum Suit { Spades = 1, Clubs=2, Diamonds=3, Hearts=4 };

        public Face face { get; set; }
        public Suit suit { get; set; }
        public Card(Face faceValue, Suit suitValue)
        {
            face = faceValue;
            suit = suitValue;
        }

        public static ArrayList<Card> CreateDeck()
        {
            Array faceValues = Enum.GetValues(typeof(Card.Face));
            Array suitValues = Enum.GetValues(typeof(Card.Suit));
            ArrayList<Card> cards=new ArrayList<Card>();

            foreach (Card.Suit suit in suitValues)
            {
                foreach (Card.Face face in faceValues)
                {
                    cards.Add(new Card(face, suit));
                }
            }

            return cards;
        }

        public override string ToString()
        {
            return face.ToString() + "_"+suit.ToString();
            
            //return face.ToString() + " of " + suit.ToString();
        }
    }
}
