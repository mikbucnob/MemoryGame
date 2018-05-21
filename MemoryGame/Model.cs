using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DataStructures;

namespace MemoryGame
{
    public class Model
    {
        private Table table;
        public Deck<Card> deck;
        public bool FirstTurn = true;
        public int pairsFound = 0;

        public bool bothChosen = false;
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
            //todo: adds entry to map
            //this method takes an integer and string
            //int comes from deck index
            //string cards tostring
            //use image string to load image file

        }

        public void MatchFoundBox()
        {

            MessageBox.Show("Found Match");
        }

        private bool SwapTurn()
        {

            return ((FirstTurn) ? false : true);

        }

        public void GameLogic(object sender1, object sender2)
        {
            if (table.choice2 != -1)
            {
                if ((deck[table.choice1] == deck[table.choice2]))
                {
                    //table.TurnBackCards();
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
            else //if ((Counter > 0) && (FirstTurn))
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

            //if first turn skip
            //if second & not pair found leave
            //if second & pair found take visability
            /* else if ((isFirstTurn)&&(sender2!=null))
             {
                 ((PictureBox)sender1).Image = MemoryGame.Properties.Resources.backcard;
                 ((PictureBox)sender2).Image = MemoryGame.Properties.Resources.backcard;
             }*/

            //}

            /*(bothFound) (Counter != 0){
                
            }*/
        }


        /*  
        }*/

        private void GameEnds()
        {
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
