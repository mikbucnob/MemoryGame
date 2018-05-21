﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public class FileWrite
    {
        const string fileName = "AppSettings.dat";

        public FileWrite(Model model,Table table)
        {
            WriteBinaryValues(model,table);
        }

        public void WriteBinaryValues(Model model,Table table)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                writer.Write(model.Counter);//int
                writer.Write(model.pairsFound);//int
                for (int i = 0; i < 52; i++)
                {
                    writer.Write((int)model.deck[i].face);
                    writer.Write((int)model.deck[i].suit);
                }
                foreach (Control control in table.Controls)
                {
                    if (control.TabIndex < 52)
                        writer.Write(((PictureBox)control).Visible);
                        
                }
            }
        }
    }
}