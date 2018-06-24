using Ixen.Views;
using SkiaSharp;

namespace Ixen.Renderer
{
    public abstract class VisualItem : VisualAbstractItem, IRenderer
    {
        public Color BackgroundColor { get; set; } = Color.Transparent;
        public View Content { get; set; }

        public abstract void Render(RendererContext context, ViewPort viewPort);
    }
}
