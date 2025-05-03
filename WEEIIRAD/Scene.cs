using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;

namespace WEEIIRAD
{
    public class Viewer
    {
        public Vector3 position;
        public Vector3 rotation;
        public float fov;

        public Viewer(Vector3 position, Vector3 rotation, float fov)
        {
            this.position = position;
            this.rotation = rotation;
            this.fov = fov;
        }
    }
    class Scene
    {
        public Dictionary<byte,Viewer> Viewers = new Dictionary<byte, Viewer>();
        public Dictionary<Vec2int, Chunk> LoadedChunks = new Dictionary<Vec2int, Chunk>();

        public static int renderDistance = 18;

        public Scene()
        {
            Viewers[0] = new Viewer(new Vector3(0, 0, 0), new Vector3(0, 0, 0), 90);

            for (int x = -(2+renderDistance); x <= (2+renderDistance); x++)
            {
                for (int y = -(2 + renderDistance); y <= (2 + renderDistance); y++)
                {
                    Vec2int pos = new Vec2int(x, y);
                    LoadedChunks.Add(pos, new Chunk(pos, 0));
                }
            }
        }
    }
}
