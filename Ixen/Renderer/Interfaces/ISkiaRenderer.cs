using SkiaSharp;

namespace Ixen.Renderer
{
    public interface ISkiaRenderer
    {
        void Render(SKCanvas canvas, SKRect rect);
    }
}
