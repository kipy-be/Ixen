using Ixen.Renderer;

namespace Ixen.Visual
{
    public class View : VisualItem
    {
        public string Name { get; set; }
        public virtual ViewType Type { get; } = ViewType.View;

        public override void Render(RendererContext context, ViewPort viewPort)
        {
            context.Clear(Color.AliceBlue);
        }
    }
}
