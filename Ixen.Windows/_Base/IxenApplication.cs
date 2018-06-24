using System;
using WinApi.Desktop;
using WinApi.Windows;
using WinApi.Windows.Helpers;

namespace Ixen.Windows
{
    public class IxenApplication : IxenSizedApplicationBase
    {
        private IxenWindow _window;

        public IxenApplication(IxenSizedApplicationInitOptions initOptions = null)
            : base(initOptions)
        {}

        public int Init()
        {
            try
            {
                ApplicationHelpers.SetupDefaultExceptionHandlers();
                var factory = WindowFactory.Create(hBgBrush: IntPtr.Zero);
                var options = (IxenSizedApplicationInitOptions)_initOptions;
                using
                (
                    _window = factory.CreateWindow
                    (
                        () => new IxenWindow(Render),
                        options.Title,
                        width: options.Width,
                        height: options.Height,
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

        public override int Width
        {
            get => _window?.GetClientRect().Width ?? -1;
            set => _window?.SetSize(value, Height);
        }

        public override int Height
        {
            get => _window?.GetClientRect().Height ?? -1;
            set => _window?.SetSize(Width, value);
        }

        public override string Title
        {
            get => _window?.GetText();
            set => _window?.SetText(value);
        }
    }
}
