﻿
using System.Runtime.Remoting.Channels;
using System.Threading;
using System.Windows.Forms;

namespace MemoryGame
{
    public class Model
    {
        //private Table table; needs to go through server
        public Deck<Card> deck;
        public Server server;//model on server side

        public bool FirstTurn = true;
        public int pairsFound = 0;
        private int choice1, choice2 = -1;

        private int moves;
        public int Moves
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
                server.Send(new PlaceCardMessage(index, deck[index].ToString()));
            }

        }



        public void Move(int cardClickedOn)
        {
            //
            if (FirstTurn)
            {
                //flip over card
                //store in class variable
            }
            else
            {
                //flip over card and check for match
                //is match Match message
                //not match NotMatch one
                //send a flipCard for both class variable and card chosen selected cards
                //check for game finished as last thing
                if ((!FirstTurn) && (MatchFound(choice1, choice2)))
                {
                    server.Send(new MatchMessage());
                    //tell client match found
                    pairsFound++;

                }
                else
                {
                    server.Send(new NotMatchMessage());
                    /*table.Enabled = false;//table; will send message to client
                     tell client to turn cards back*/
                }

                if (choice1 != choice2)
                {

                }

                if (pairsFound == 26)
                {
                    GameEnds();
                }

            }
            FirstTurn = !FirstTurn;
        }

        public string MovesLabelUpdate()
        {
            if (FirstTurn)
            {
                Moves++;
            }
            server.Send(new UpdateMoveLabel(Moves));

        }


        private void GameEnds()
        {
            Moves++;
            MessageBox.Show("All Pairs Found, Well Done\nTook " + Moves + " Moves");
            //should be in table
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
