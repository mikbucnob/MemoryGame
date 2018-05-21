using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    public class FileRead
    {
        const string fileName = "AppSettings.dat";

        public FileRead(Model model,Table table)
        {
            ReadBinaryValues(model, table);
        }

        public static void ReadBinaryValues(Model model,Table table)
        {
            /*float aspectRatio;
            string tempDirectory;
            int autoSaveTime;
            bool showStatusBar;*/


            if (File.Exists(fileName))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                {
                    model.Counter = reader.ReadInt32();
                    model.pairsFound = reader.ReadInt32();
                    for (int i = 0; i < 52; i++)
                    {
                        
                        model.deck[i].face = (Card.Face) reader.ReadInt32();
                        model.deck[i].suit = (Card.Suit) reader.ReadInt32();
                        //writer.Write((int)model.deck[i].face);
                        //writer.Write((int)model.deck[i].suit);
                    }

                    for (int i = 0; i < 52; i++)
                    {
                        table.Controls[i].Visible = reader.ReadBoolean();
                    }

                    table.TurnBackCards();


                    /*aspectRatio = reader.ReadSingle();
                    tempDirectory = reader.ReadString();
                    autoSaveTime = reader.ReadInt32();
                    showStatusBar = reader.ReadBoolean();*/
                    }
                /*
                Console.WriteLine("Aspect ratio set to: " + aspectRatio);
                Console.WriteLine("Temp directory is: " + tempDirectory);
                Console.WriteLine("Auto save time set to: " + autoSaveTime);
                Console.WriteLine("Show status bar: " + showStatusBar);
                */
            }
        }
    }
}
