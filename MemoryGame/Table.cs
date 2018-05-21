using System;
using System.Resources;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataStructures;
using MemoryGame.Properties;

namespace MemoryGame
{
    public partial class Table : Form
    {
        public Model model;

        private PictureBox firstChosen = null;
        public int choice1 = -1;
        public int choice2 = -1;
        private object sender1, sender2;

        private HashMap<int, Image> imageMap;

        public Table()
        {
            InitializeComponent();
            imageMap=new HashMap<int, Image>();
            model = new Model(this);
            //todo: adds entry to map
            //this method takes an integer and string
            //int comes from deck index
            //string cards tostring
            //use image string to load image file

        }

        private void cardOnTable_Click(object sender, EventArgs e)
        {
            int cardNumber = ((int)((Control)sender).TabIndex);


            if (sender == sender2 || sender == sender1)
                return;

            DisplayCardFace(sender, cardNumber);
            this.Refresh();

            if (model.FirstTurn)
            {
                sender1 = sender;
                choice1 = cardNumber;
            }
            else
            {
                sender2 = sender;
                choice2 = cardNumber;
                model.GameLogic(sender1, sender2);
                sender1 = -1;
                sender2 = -1;
            }

            if (!model.FirstTurn)
            {
                model.Counter++;
                // model.GameLogic(sender1, sender2);
            }

            model.FirstTurn = !model.FirstTurn;



            //todo:if two cards don't match turn them back around
            //display turns taken
            //detect when game is finished and say well done

        }

        private void DisplayCardFace(object sender, int cardNumber)
        {
            ((PictureBox)sender).Image = imageMap.Get(cardNumber);
        }

        public void TurnBackCards()
        {
            foreach (Control control in Controls)
            {
                if( (control as PictureBox) != null)
                    ((PictureBox)control).Image = MemoryGame.Properties.Resources.backcard;
            }
        }


        public void PlaceCard(int index, string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            try
            {
                //two ways to get Image file
                //Stream s = assembly.GetManifestResourceStream("MemoryGame.Resources." + fileName + ".jpg");
                //Image fileTester = Image.FromStream(s);

                Image fileTester = MemoryGame.Properties.Resources.ResourceManager.GetObject(fileName) as Bitmap;
                imageMap.Add(index, fileTester);
            }
            catch (Exception e)
            {
                MessageBox.Show("File not found\n" + e.ToString());
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileWrite filing=new FileWrite(model,this);
            //save menu option
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileRead filing = new FileRead(model, this);
            //load menu option
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //exit menu option
            this.Close();
        }
        
    }


}