using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEEIIRAD.Blocks
{
    internal class Stone : Block
    {
        public Stone() { }
        public Stone(int[] position) : base(position)
        {
            Type = BlockType.Stone;
        }
    }
}
