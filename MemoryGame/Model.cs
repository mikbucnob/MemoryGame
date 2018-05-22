
using System.Threading;
using System.Windows.Forms;

namespace MemoryGame
{
    public class Model
    {
        private Table table;
        public Deck<Card> deck;
        public bool FirstTurn = true;
        public int pairsFound = 0;

        public int counter;
        public int Counter
        {
            get { return counter; }
            set { counter = value; }
        }

        public Model(Table table)
        {
            Counter = 0;
            this.table = table;
            deck = new Deck<Card>(Card.CreateDeck());
            deck.Shuffle();
            for (int index = 0; index <= 51; index++)
            {
                table.PlaceCard(index, deck[index].ToString());
            }
        }

        public void MatchFoundBox()
        {
            MessageBox.Show("Found Match");
        }

        public void GameLogic(object sender1, object sender2)
        {
            if (table.choice2 != -1)
            {
                if ((deck[table.choice1] == deck[table.choice2]))
                {
                    return;
                }
            }

            if ((!FirstTurn) && (MatchFound(table.choice1, table.choice2)))
            {
                MatchFoundBox();
                pairsFound++;
                Thread.Sleep(500);
                ((PictureBox)sender1).Visible = false;
                ((PictureBox)sender2).Visible = false;
            }
            else
            {
                table.Enabled = false;
                Thread.Sleep(1500);
                table.TurnBackCards();
                table.Enabled = true;
                table.choice2 = -1;
            }

            if (pairsFound == 26)
            {
                GameEnds();
            }
        }
        
        private void GameEnds()
        {
            Counter++;
            MessageBox.Show("All Pairs Found, Well Done\nTook " + Counter + " Moves");
        }


        private bool MatchFound(int choice1, int choice2)
        {
            if (deck[choice1].face == deck[choice2].face)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
