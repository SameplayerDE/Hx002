using Microsoft.Xna.Framework;

namespace Hx002.Framework.Components
{
    public abstract class HxCollider : HxComponent
    {

        public bool IsTrigger = false;
        public bool Enabled = true;
        
        public abstract Vector3 ClosestPoint(Vector3 location);

    }
}