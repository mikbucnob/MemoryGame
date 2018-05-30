using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DataStructures;

namespace MemoryGame
{
    public partial class Table : Form
    {
        public Model model;
        //public Client client;

        private PictureBox firstChosen = null;
        public int choice1 = -1;
        public int choice2 = -1;
        private object sender1, sender2;

        private HashMap<int, Image> imageMap;

        public Table()
        {
            InitializeComponent();
            imageMap=new HashMap<int, Image>();
            //client connect to server
        }

        private void cardOnTable_Click(object sender, EventArgs e)
        {//server sent message (get card number, client save message then done)
            int cardNumber = ((int)((Control)sender).TabIndex);
            int cardNumber2
                //clicked on card number 13, server said ok and turn card over
            if (sender == sender2 || sender == sender1)
                return;

            DisplayCardFace(sender, cardNumber);
            this.Refresh();

            if (model.FirstTurn)//if to server is it the firstturn
            {
                sender1 = sender;
                choice1 = cardNumber;
            }
            else
            {
                sender2 = sender;
                choice2 = cardNumber;
                model.GameLogic();//
                sender1 = -1;
                sender2 = -1;
            }

            moveCounter.Text = model.MovesLabelUpdate();

            model.FirstTurn = !model.FirstTurn;
        }

        private void DisplayCardFace(object sender, int cardNumber)
        {
            ((PictureBox)sender).Image = imageMap.Get(cardNumber);
        }

        public void TurnBackCards()
        {
            foreach (Control control in Controls)
            {
                int i = 0;
                if ((control as PictureBox) != null)
                {
                    ((PictureBox) control).Image = MemoryGame.Properties.Resources.backcard;
                    i++;
                }
            }

            moveCounter.Text = model.MovesLabelUpdate();
        }


        public void PlaceCard(int index, string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            try
            {
                //***two ways to get Image file***
                //Stream s = assembly.GetManifestResourceStream("MemoryGame.Resources." + fileName + ".jpg");
                //Image fileTester = Image.FromStream(s);
                //***OR***
                Image fileTester = MemoryGame.Properties.Resources.ResourceManager.GetObject(fileName) as Bitmap;
                //tell client open this file,server shouldnt know anything about image
                imageMap.Add(index, fileTester);
            }
            catch (Exception e)
            {
                MessageBox.Show("File not found\n" + e.ToString());
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileWrite filing=new FileWrite(model,this);//saving server side
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileRead filing = new FileRead(model, this);//reading server side
        }

        private void Table_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();//shut down client first,then close
        }
        
    }
}