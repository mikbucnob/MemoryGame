using System.IO;
using System.Windows.Forms;

namespace MemoryGame
{
    public class FileWrite
    {
        const string fileName = "AppSettings.dat";

        public FileWrite(Model model,Table table)
        {
            WriteBinaryData(model,table);
        }

        public void WriteBinaryData(Model model,Table table)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                writer.Write(model.Moves);
                writer.Write(model.pairsFound);
                for (int i = 0; i < 52; i++)
                {
                    writer.Write((int)model.deck[i].face);
                    writer.Write((int)model.deck[i].suit);
                }
                foreach (Control control in table.Controls)
                {
                    if ((control as PictureBox) != null)
                        writer.Write(((PictureBox)control).Visible);
                }
            }
        }
    }
}
