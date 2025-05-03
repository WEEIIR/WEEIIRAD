using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEEIIRAD.Blocks;

namespace WEEIIRAD
{
    public class Chunk
    {
        public static readonly int XSize = 16, YSize = 16, ZSize = 16;
        public Block[,,] Blocks = new Block[XSize, YSize, ZSize];
        public Vec2int Position;

        public Chunk(Vec2int Position, int GenerationType)
        {
            this.Position = Position;
            if (GenerationType == 0) {
                GenerateWithFill(BlockType.Air);
             }
        }

        private void GenerateWithFill(BlockType type)
        {
            switch (type)
            {
                case BlockType.Air:
                    for (int x = 0; x < XSize; x++)
                    {
                        for (int y = 0; y < YSize; y++)
                        {
                            for (int z = 0; z < ZSize; z++)
                            {
                                Blocks[x, y, z] = new Air(new int[] { x, y, z });
                            }
                        }
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}

