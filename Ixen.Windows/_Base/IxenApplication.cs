using System;
using WinApi.Desktop;
using WinApi.Windows;
using WinApi.Windows.Helpers;

namespace Ixen.Windows
{
    public class IxenApplication : IxenApplicationBase
    {
        public int Init(IxenSizedApplicationInitOptions initOptions = null)
        {
            if (initOptions == null)
                initOptions = new IxenSizedApplicationInitOptions();

            try
            {
                ApplicationHelpers.SetupDefaultExceptionHandlers();
                var factory = WindowFactory.Create(hBgBrush: IntPtr.Zero);
                using
                (
                    var win = factory.CreateWindow
                    (
                        () => new IxenWindow(Render),
                        initOptions.Title,
                        width: initOptions.Width,
                        height: initOptions.Height,
                        constructionParams: new FrameWindowConstructionParams())
                    )
                {
                    win.Show();
                    return new EventLoop().Run(win);
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelpers.ShowError(ex);
                return 1;
            }
        }
    }
}
