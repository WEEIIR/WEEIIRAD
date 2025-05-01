using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEEIIRAD.Blocks
{
    public enum BlockType
    {
        None,
        Air,
        Dirt,
        Stone
    }
    public class Block
    {
        public int[] pos = new int[3];
        BlockType type;
        public Block() { }

        public virtual void UpdatePerTick() { }
        public virtual void UpdatePerCall() { }
       
        public virtual void OnBlockBreake() { }
    }
}
