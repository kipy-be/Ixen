﻿using Ixen.Renderer;
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
        private SKSurface _surface;
        private Action<SKSurface, SKRect> _renderer;

        public IxenWindow(Action<SKSurface, SKRect> renderer)
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
            _painted = false;

            try
            {
                using
                (
                    _surface = SKSurface.Create
                    (
                        clientRect.Width, clientRect.Height,
                        SKColorType.Bgra8888, SKAlphaType.Premul,
                        _pixelBuffer.Handle, _pixelBuffer.Stride
                    )
                )
                {
                    if (_surface != null)
                    {
                        _renderer(_surface, new SKRect(0, 0, clientRect.Width, clientRect.Height));
                        _painted = true;
                    }
                }
            }
            finally
            {
                if (_painted)
                    Gdi32Helpers.SetRgbBitsToDevice(_hdc, clientRect.Width, clientRect.Height, _pixelBuffer.Handle);
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