using Microsoft.Xna.Framework;

namespace Hx002.Framework.Components
{
    public class HxBoxCollider : HxCollider
    {

        public Vector3 Center;
        public Vector3 Size;

        public override Vector3 ClosestPoint(Vector3 location)
        {
            throw new System.NotImplementedException();
        }
    }
}