using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame
{
    public class Message
    {
    }

    public class PlaceCardMessage:Message
    {
        private int index;
        private string filename;

        public PlaceCardMessage(int index, string filename)
        {
            this.index = index;
            this.filename = filename;
        }
    }

    public class MatchMessage : Message
    {
    }

    public class NotMatchMessage : Message
    {
    }

    public class UpdateMoveLabel : Message
    {
        private int moves;

        public UpdateMoveLabel(int moves)
        {
            this.moves = moves;
        }
    }
}
