using Ixen.Renderer;
using SkiaSharp;

namespace Ixen
{
    public abstract class IxenApplicationBase : IRenderer
    {
        internal ApplicationRenderer _applicationRenderer;

        public IxenApplicationBase()
        {
            _applicationRenderer = new ApplicationRenderer();
        }

        public void Render(SKSurface surface, SKRect rectangle)
        {
            _applicationRenderer.Render(surface, rectangle);
        }
    }
}
