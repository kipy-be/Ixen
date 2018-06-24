using Ixen.Renderer;
using Ixen.Views;
using SkiaSharp;

namespace Ixen
{
    public abstract class IxenApplicationBase : ISkiaRenderer
    {
        protected IxenApplicationInitOptions _initOptions;
        internal ApplicationScene _scene;

        public abstract string Title { get; set; }
        public abstract int Width { get; set; }
        public abstract int Height { get; set; }

        public IxenApplicationBase(IxenApplicationInitOptions initOptions = null)
        {
            _scene = new ApplicationScene();
            _initOptions = initOptions ?? new IxenApplicationInitOptions();
        }

        public void Render(SKCanvas canvas, SKRect rect)
        {
            _scene.Render(canvas, rect);
        }

        protected abstract void Invalidate();

        public View MainView
        {
            get => _scene.Content;
            set
            {
                _scene.Content = value;
                Invalidate();
            }
        }
    }
}
