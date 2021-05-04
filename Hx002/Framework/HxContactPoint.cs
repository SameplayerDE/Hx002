using Hx002.Framework.Components;
using Microsoft.Xna.Framework;

namespace Hx002.Framework
{
    public class HxContactPoint
    {
        public Vector3 Normal;
        public HxCollider Other;
        public Vector3 Point;
        public float Seperation;
        public HxCollider This;
    }
}