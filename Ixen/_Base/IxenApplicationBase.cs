using Ixen.Renderer;
using SkiaSharp;

namespace Ixen
{
    public abstract class IxenApplicationBase : IRenderer
    {
        protected IxenApplicationInitOptions _initOptions;
        internal ApplicationRenderer _applicationRenderer;

        public abstract string Title { get; set; }

        public IxenApplicationBase(IxenApplicationInitOptions initOptions = null)
        {
            _applicationRenderer = new ApplicationRenderer();
            _initOptions = initOptions ?? new IxenApplicationInitOptions();
        }

        public void Render(SKSurface surface, SKRect rectangle)
        {
            _applicationRenderer.Render(surface, rectangle);
        }
    }

    public abstract class IxenSizedApplicationBase : IxenApplicationBase
    {
        public abstract int Width { get; set; }
        public abstract int Height { get; set; }

        public IxenSizedApplicationBase(IxenSizedApplicationInitOptions initOptions)
            : base(initOptions)
        {
            _initOptions = initOptions ?? new IxenSizedApplicationInitOptions();
        }
    }
}
