using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
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
        public float hardness;
        public float damage;
        public bool isSolid = true;
        //Damage > hardness => call OnBlockBreak

        public int[] Position;
        public BlockType Type;

        public Block() { }
        public Block(int[] position)
        {
            Position = position;
        }

        public virtual void OnTickUpdate() { }
        public virtual void ManualUpdate() { }

        public virtual void OnBlockBreak() { }
        public virtual void OnBlockPlace() { }

        public virtual void OnPrimaryClickStart() { }
        public virtual void OnPrimaryClickHold() { }
        public virtual void OnPrimaryClickEnd() { }

        public virtual void OnSecondaryClickStart() { }
        public virtual void OnSecondaryClickHold() { }
        public virtual void OnSecondaryClickEnd() { }

        public virtual void OnEntityTouchStart() { }
        public virtual void OnEntityTouchHold() { }
        public virtual void OnEntityTouchEnd() { }

        public virtual void OnLookStart() { }
        public virtual void OnLookHold() { }
        public virtual void OnLookEnd() { }


    }

}
