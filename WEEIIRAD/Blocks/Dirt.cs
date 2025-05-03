using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEEIIRAD.Blocks
{
    internal class Dirt : Block
    {
        public Dirt() { }
        public Dirt(int[] position) : base(position)
        {
            Type = BlockType.Dirt;
        }
    }
}
