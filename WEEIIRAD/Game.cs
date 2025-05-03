#define DEBUG // Debug modda çalışacaksa bu satırı aç

using System;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System.Text.Json;

namespace WEEIIRAD
{

    public class Game : GameWindow
    {
        Chunk demoChunk;
        private GameWindow debugWindow;
        public Game() : base(GameWindowSettings.Default, NativeWindowSettings.Default)
        {
            demoChunk = new Chunk(new int[] {0,0}, 0);
        }

        public static T DeepClone<T>(T obj)
        {
            var json = JsonSerializer.Serialize(obj);
            return JsonSerializer.Deserialize<T>(json);
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            Title = "SRH Oyunu";
            GL.ClearColor(0.0f, 2.0f, 5.0f, 6.0f); // R G B A - kırmızı
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            SwapBuffers(); // Çift tamponlu çizimi göster


        }

        double[] avarageFPS = new double[100];
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            // FPS sayacı
            double fps = 1.0 / args.Time;
            

            Title = $"SRH Oyunu - FPS: {Math.Floor(fps*100)/100}";

            // ESC ile çıkış
            if (KeyboardState.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.Escape))
                Close();
        }
    }
}
