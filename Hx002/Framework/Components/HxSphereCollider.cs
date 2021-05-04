using Microsoft.Xna.Framework;
using SharpDX.DirectWrite;

namespace Hx002.Framework.Components
{
    public class HxSphereCollider : HxCollider
    {

        public Vector3 Center;
        public float Radius;

        public override Vector3 ClosestPoint(Vector3 location)
        {
            Vector3 objectPosition = HxGameObject.Get<HxTransform>().Position;
            Vector3 direction = location - (Center + objectPosition);
            direction.Normalize();
            return (Center + objectPosition) + (direction * Radius);
        }

    }
}