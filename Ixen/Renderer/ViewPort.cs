using Ixen.Visual;

namespace Ixen.Renderer
{
    public sealed class ViewPort : VisualAbstractItem
    {
        private float _x;
        public override float X
        {
            get => _x;
            set => _x = value < 0 ? 0 : value;
        }

        private float _y;
        public override float Y
        {
            get => _y;
            set => _y = value < 0 ? 0 : value;
        }
    }
}
