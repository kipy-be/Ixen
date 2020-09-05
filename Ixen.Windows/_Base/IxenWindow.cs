using NetCoreEx.Geometry;
using SkiaSharp;
using System;
using WinApi.Gdi32;
using WinApi.User32;
using WinApi.Utils;
using WinApi.Windows;

namespace Ixen.Windows
{
    internal class IxenWindow : EventedWindowCore
    {
        private readonly NativePixelBuffer _pixelBuffer;
        private bool _painted;
        private IntPtr _hdc;
        private SKImageInfo _imageInfo;
        private SKSurface _surface;
        private Action<SKCanvas, SKRect> _renderer;

        public IxenWindow(Action<SKCanvas, SKRect> renderer)
        {
            _renderer = renderer;
            _pixelBuffer = new NativePixelBuffer();
        }

        protected override void OnCreate(ref CreateWindowPacket packet)
        {
            base.OnCreate(ref packet);
        }

        protected override void OnPaint(ref PaintPacket packet)
        {
            User32Methods.GetClientRect(packet.Hwnd, out Rectangle clientRect);
            _pixelBuffer.EnsureSize(clientRect.Width, clientRect.Height);
            _hdc = User32Methods.BeginPaint(packet.Hwnd, out PaintStruct ps);
            _imageInfo = new SKImageInfo(clientRect.Width, clientRect.Height, SKColorType.Bgra8888, SKAlphaType.Premul);
            _painted = false;

            try
            {
                using(_surface = SKSurface.Create(_imageInfo, _pixelBuffer.Handle, _pixelBuffer.Stride))
                {
                    if (_surface != null)
                    {
                        _renderer(_surface.Canvas, new SKRect(0, 0, clientRect.Width, clientRect.Height));
                        _painted = true;
                    }
                }
            }
            finally
            {
                if (_painted)
                {
                    Gdi32Helpers.SetRgbBitsToDevice(_hdc, clientRect.Width, clientRect.Height, _pixelBuffer.Handle);
                }

                User32Methods.EndPaint(packet.Hwnd, ref ps);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _pixelBuffer.Dispose();
            base.Dispose(disposing);
        }
    }
}
