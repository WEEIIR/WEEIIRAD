#define DEBUG // Debug modda çalışacaksa bu satırı aç

using System;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System.Text.Json;

namespace WEEIIRAD
{

    public struct Vec2int
    {
        public int X;
        public int Y;

        public Vec2int(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj) => obj is Vec2int other && X == other.X && Y == other.Y;
        public override int GetHashCode() => HashCode.Combine(X, Y);
    }

    public class Game : GameWindow
    {
        Scene scene;
        private GameWindow debugWindow;
        
        public Game() : base(GameWindowSettings.Default, NativeWindowSettings.Default)
        {
            scene = new Scene();
        }

        public static T DeepClone<T>(T obj)
        {
            var json = JsonSerializer.Serialize(obj);
            return JsonSerializer.Deserialize<T>(json);
        }

        private ImGuiController _ImGuiController;
        protected override void OnLoad()
        {
            base.OnLoad();
            Title = "SRH Oyunu";
            GL.ClearColor(0.0f, 2.0f, 5.0f, 6.0f); // R G B A - kırmızı

            _ImGuiController = new ImGuiController(this);
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);


            GL.Clear(ClearBufferMask.ColorBufferBit);

            _ImGuiController.Update(this, (float)args.Time);
            // ImGui arayüz çağrılarınız
            _ImGuiController.DrawDebugPanel();
            _ImGuiController.Render();

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
