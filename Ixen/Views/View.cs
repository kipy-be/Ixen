using Ixen.Renderer;
using SkiaSharp;

namespace Ixen.Views
{
    public class View : VisualItem
    {
        public string Name { get; set; }
        public virtual ViewType Type { get; } = ViewType.View;
        public Color BorderColor { get; set; } = Color.Transparent;
        public float BorderThickness { get; set; }

        public override void Render(RendererContext context, ViewPort viewPort)
        {
            
        }
    }
}
