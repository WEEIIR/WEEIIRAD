using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEEIIRAD.Blocks
{
    internal class Air : Block
    {
        public Air() {
            Type = BlockType.Air;
            isSolid = false;
        }
        public Air(int[] position) : base(position)
        {
            Type = BlockType.Air;
            isSolid = false;
        }
    }
}
