
using System.Runtime.Remoting.Channels;
using System.Threading;
using System.Windows.Forms;

namespace MemoryGame
{
    public class Model
    {
        //private Table table; needs to go through server
        public Deck<Card> deck;
        public Server server;

        public bool FirstTurn = true;
        public int pairsFound = 0;
        private int choice1, choice2 = -1;

        private int moves;
        private int Moves
        {
            get { return moves; }
            set { moves = value; }
        }

        public Model(Server server)
        {
            this.server = server;
            Moves = 0;
            deck = new Deck<Card>(Card.CreateDeck());
            deck.Shuffle();
            //must be build in constructor, put rest into method
            
        }

        public void StartGame()
        {
            for (int index = 0; index <= 51; index++)
            {
                server.Send(new PlaceCardMessage(index,deck[index].ToString()));
            }
            
        }

        public void GameLogic(object sender1, object sender2)
        {
            if (choice2 != -1)
            {
                if ((deck[choice1] == deck[choice2]))
                {
                    return;
                }
            }

            if ((!FirstTurn) && (MatchFound(choice1, choice2)))
            {
                //MatchFoundBox();//tell client match found
                pairsFound++;
                
            }
            else
            {
                /*table.Enabled = false;//table; will send message to client
                 tell client to turn cards back*/
                Thread.Sleep(1500);//
                table.TurnBackCards();//
                table.Enabled = true;//*/
                choice2 = -1;
            }

            if (pairsFound == 26)
            {
                GameEnds();
            }
        }

        public string MovesLabelUpdate()
        {
            if (FirstTurn) //same thing
            {
                Moves++;
            }
            return Moves + " moves";
        }
        

    private void GameEnds()
        {
            Moves++;
            MessageBox.Show("All Pairs Found, Well Done\nTook " + Moves + " Moves");
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
