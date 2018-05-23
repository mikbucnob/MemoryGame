using System.IO;
using System.Windows.Forms;

namespace MemoryGame
{
    public class FileRead
    {
        const string fileName = "AppSettings.dat";

        public FileRead(Model model, Table table)
        {
            ReadBinaryData(model, table);
        }

        public void ReadBinaryData(Model model, Table table)
        {
            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    model.Counter = reader.ReadInt32();//works
                    model.pairsFound = reader.ReadInt32();//works
                    for (int i = 0; i < 52; i++)
                    {
                        model.deck[i].face = (Card.Face)reader.ReadInt32();
                        model.deck[i].suit = (Card.Suit)reader.ReadInt32();
                    }

                    foreach (Control control in table.Controls)
                    {
                        if ((control as PictureBox) != null)
                            control.Visible = reader.ReadBoolean();
                    }

                    table.TurnBackCards();

                }

            }
        }
    }
}
