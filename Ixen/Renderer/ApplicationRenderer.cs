using SkiaSharp;

namespace Ixen.Renderer
{
    public interface IRenderer
    {
        void Render(SKSurface surface, SKRect rectangle);
    }

    internal class ApplicationRenderer : IRenderer
    {
        private static SKColor _clearColor = new SKColor(0xFF, 0xFF, 0xFF);

        public void Render(SKSurface surface, SKRect rectangle)
        {
            var canvas = surface.Canvas;
            canvas.Clear(_clearColor);
        }
    }
}
