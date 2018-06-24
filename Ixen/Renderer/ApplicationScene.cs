using SkiaSharp;

namespace Ixen.Renderer
{
    internal class ApplicationScene : VisualItem, ISkiaRenderer
    {
        private static Color _clearColor = Color.White;
        private ViewPort _viewPort;
        private RendererContext _rendererContext;

        public ApplicationScene()
        {
            _viewPort = new ViewPort();
            _rendererContext = new RendererContext();
        }

        public override void Render(RendererContext context, ViewPort viewPort)
        {
            context.Clear(_clearColor);
        }

        public void Render(SKCanvas canvas, SKRect rect)
        {
            _rendererContext.SKCanvas = canvas;
            _rendererContext.SKClientRect = rect;
            _viewPort.Height = rect.Height;
            _viewPort.Width = rect.Width;
            Render(_rendererContext, _viewPort);
        }
    }
}
