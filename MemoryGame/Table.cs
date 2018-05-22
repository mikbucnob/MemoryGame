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
                moveCounter.Text = model.Counter + " moves";
            }

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

            moveCounter.Text = model.Counter + " moves";
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
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileRead filing = new FileRead(model, this);
        }

        private void Table_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}