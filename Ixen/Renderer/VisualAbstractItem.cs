using System;
using System.Collections.Generic;
using System.Text;

namespace Ixen.Renderer
{
    public abstract class VisualAbstractItem
    {
        public virtual float X { get; set; }
        public virtual float Y { get; set; }

        private float _width;
        public float Width
        {
            get => _width;
            set => _width = value < 0 ? 0 : value;
        }

        private float _height;
        public float Height
        {
            get => _height;
            set => _height = value < 0 ? 0 : value;
        }
    }
}
