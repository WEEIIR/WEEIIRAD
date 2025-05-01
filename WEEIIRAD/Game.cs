#define DEBUG // Debug modda çalışacaksa bu satırı aç

using System;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace WEEIIRAD
{
    public class Game : GameWindow
    {
        private GameWindow debugWindow;

        public Game() : base(GameWindowSettings.Default, NativeWindowSettings.Default)
        {
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

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            // ESC ile çıkış
            if (KeyboardState.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.Escape))
                Close();
        }
    }
}
