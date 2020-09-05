using System;
using WinApi.Desktop;
using WinApi.Windows;
using WinApi.Windows.Helpers;

namespace Ixen.Windows
{
    public class IxenApplication : IxenApplicationBase
    {
        private IxenWindow _window;

        public IxenApplication(IxenApplicationInitOptions initOptions = null)
            : base(initOptions)
        {}

        public int Init()
        {
            try
            {
                ApplicationHelpers.SetupDefaultExceptionHandlers();
                var factory = WindowFactory.Create(hBgBrush: IntPtr.Zero);
                using
                (
                    _window = factory.CreateWindow
                    (
                        () => new IxenWindow(Render),
                        _initOptions.Title,
                        width: _initOptions.Width,
                        height: _initOptions.Height,
                        constructionParams: new FrameWindowConstructionParams())
                    )
                {
                    _window.Show();
                    return new EventLoop().Run(_window);
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelpers.ShowError(ex);
                return 1;
            }
        }

        protected override void Invalidate()
        {
            _window?.Invalidate(true);
        }

        public override int Width
        {
            get => _window?.GetClientRect().Width ?? -1;
            set
            {
                _window?.SetSize(value, Height);
                _scene.Width = value;
            }
        }

        public override int Height
        {
            get => _window?.GetClientRect().Height ?? -1;
            set
            {
                _window?.SetSize(Width, value);
                _scene.Height = value;
            }
        }

        public override string Title
        {
            get => _window?.GetText();
            set => _window?.SetText(value);
        }
    }
}
