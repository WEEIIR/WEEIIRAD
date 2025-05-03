using ImGuiNET;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Numerics;

public class ImGuiController
{
    private readonly GameWindow _window;
    private readonly IntPtr _context;
    private int _vertexArray;
    private int _vertexBuffer;
    private int _indexBuffer;
    private int _fontTexture;

    public ImGuiController(GameWindow window)
    {
        _window = window;
        _context = ImGui.CreateContext();
        ImGui.SetCurrentContext(_context);
        ImGui.StyleColorsDark();

        // Config
        var io = ImGui.GetIO();
        io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;
        io.BackendFlags |= ImGuiBackendFlags.HasMouseCursors;
        io.BackendFlags |= ImGuiBackendFlags.HasSetMousePos;

        CreateDeviceResources();
    }

    private void CreateDeviceResources()
    {
        GL.CreateVertexArrays(1, out _vertexArray);
        GL.CreateBuffers(1, out _vertexBuffer);
        GL.CreateBuffers(1, out _indexBuffer);
        UpdateFontTexture();
    }

    private void UpdateFontTexture()
    {
        var io = ImGui.GetIO();
        io.Fonts.GetTexDataAsRGBA32(out IntPtr pixels, out int width, out int height, out int bytesPerPixel);

        _fontTexture = GL.GenTexture();
        GL.BindTexture(TextureTarget.Texture2D, _fontTexture);
        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, width, height, 0,
                      PixelFormat.Rgba, PixelType.UnsignedByte, pixels);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

        io.Fonts.SetTexID((IntPtr)_fontTexture);
        io.Fonts.ClearTexData();
    }

    public void Update(GameWindow window, float deltaTime)
    {
        ImGui.SetCurrentContext(_context);
        var io = ImGui.GetIO();
        io.DisplaySize = new Vector2(window.Size.X, window.Size.Y);
        io.DeltaTime = deltaTime;

        UpdateInput(window);
        ImGui.NewFrame();
    }

    private void UpdateInput(GameWindow window)
    {
        var io = ImGui.GetIO();
        var mouse = window.MouseState;
        var keyboard = window.KeyboardState;

        io.MouseDown[0] = mouse.IsButtonDown(MouseButton.Left);
        io.MouseDown[1] = mouse.IsButtonDown(MouseButton.Right);
        io.MouseDown[2] = mouse.IsButtonDown(MouseButton.Middle);
        io.MousePos = new Vector2(mouse.X, mouse.Y);
        io.MouseWheel = mouse.ScrollDelta.Y;

        foreach (Keys key in Enum.GetValues(typeof(Keys)))
        {
            var imguiKey = ToImGuiKey(key);
            if (imguiKey != ImGuiKey.None)
                io.AddKeyEvent(imguiKey, keyboard.IsKeyDown(key));
        }

        bool ctrl = keyboard.IsKeyDown(Keys.LeftControl) || keyboard.IsKeyDown(Keys.RightControl);
        bool shift = keyboard.IsKeyDown(Keys.LeftShift) || keyboard.IsKeyDown(Keys.RightShift);
        bool alt = keyboard.IsKeyDown(Keys.LeftAlt) || keyboard.IsKeyDown(Keys.RightAlt);
        bool super = keyboard.IsKeyDown(Keys.LeftSuper) || keyboard.IsKeyDown(Keys.RightSuper);

        io.AddKeyEvent(ImGuiKey.ModCtrl, ctrl);
        io.AddKeyEvent(ImGuiKey.ModShift, shift);
        io.AddKeyEvent(ImGuiKey.ModAlt, alt);
        io.AddKeyEvent(ImGuiKey.ModSuper, super);
    }

    private ImGuiKey ToImGuiKey(Keys key)
    {
        switch (key)
        {
            case Keys.Tab: return ImGuiKey.Tab;
            case Keys.Left: return ImGuiKey.LeftArrow;
            case Keys.Right: return ImGuiKey.RightArrow;
            case Keys.Up: return ImGuiKey.UpArrow;
            case Keys.Down: return ImGuiKey.DownArrow;
            case Keys.PageUp: return ImGuiKey.PageUp;
            case Keys.PageDown: return ImGuiKey.PageDown;
            case Keys.Home: return ImGuiKey.Home;
            case Keys.End: return ImGuiKey.End;
            case Keys.Insert: return ImGuiKey.Insert;
            case Keys.Delete: return ImGuiKey.Delete;
            case Keys.Backspace: return ImGuiKey.Backspace;
            case Keys.Space: return ImGuiKey.Space;
            case Keys.Enter: return ImGuiKey.Enter;
            case Keys.Escape: return ImGuiKey.Escape;
            case Keys.A: return ImGuiKey.A;
            case Keys.C: return ImGuiKey.C;
            case Keys.V: return ImGuiKey.V;
            case Keys.X: return ImGuiKey.X;
            case Keys.Y: return ImGuiKey.Y;
            case Keys.Z: return ImGuiKey.Z;
            default: return ImGuiKey.None;
        }
    }

    public void DrawDebugPanel()
    {
        ImGui.Begin("Debug Panel");
        // Şimdilik sadece başlık gösteriliyor
        ImGui.Text("Debug Panel");
        ImGui.End();
    }

    public void Render()
    {
        ImGui.Render();
        RenderDrawData(ImGui.GetDrawData());
    }

    private void RenderDrawData(ImDrawDataPtr drawData)
    {
        // ImGui çizimini OpenGL ile gerçekleştirin.
    }

    public void WindowResized(int width, int height)
    {
        ImGui.GetIO().DisplaySize = new Vector2(width, height);
    }
}
