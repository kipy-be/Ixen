using Ixen.Renderer;
using Ixen.Visual.Styles;

namespace Ixen.Visual
{
    public abstract class VisualItem : VisualAbstractItem, IRenderer
    {
        public virtual VisualItemStyles Styles { get; set; }

        private View _content;
        public View Content
        {
            get => _content;
            set
            {
                _content = value;
                _content.X = X;
                _content.Y = Y;
                _content.Width = Width;
                _content.Height = Height;
            }
        }

        public abstract void Render(RendererContext context, ViewPort viewPort);
    }
}
