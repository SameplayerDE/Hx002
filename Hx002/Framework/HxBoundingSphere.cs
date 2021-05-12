using Microsoft.Xna.Framework;

namespace Hx002.Framework
{
    public class HxBoundingSphere
    {
        public Vector3 Position;
        public float Radius;

        public HxBoundingSphere(Vector3 position, float radius)
        {
            Position = position;
            Radius = radius;
        }

        public HxBoundingSphere(Vector4 data) : this(new Vector3(data.X, data.Y, data.Z), data.W)
        {
            
        }
    }
}