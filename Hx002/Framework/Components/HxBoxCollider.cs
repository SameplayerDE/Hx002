using System;
using Microsoft.Xna.Framework;

namespace Hx002.Framework.Components
{
    public class HxBoxCollider : HxCollider
    {

        public Vector3 Center;
        public Vector3 Size = Vector3.One;

        public override Vector3 ClosestPoint(Vector3 location)
        {
            Vector3 objectPosition = HxGameObject.Get<HxTransform>().Position;
            Vector3 center = objectPosition + Center;
            
            float maxX = center.X + Size.X / 2;
            float minX = center.X - Size.X / 2;
            
            float maxY = center.Y + Size.Y / 2;
            float minY = center.Y - Size.Y / 2;
            
            float maxZ = center.Z + Size.Z / 2;
            float minZ = center.Z - Size.Z / 2;

            float x = Math.Clamp(location.X, minX, maxX);
            float y = Math.Clamp(location.Y, minY, maxY);
            float z = Math.Clamp(location.Z, minZ, maxZ);

            return new Vector3(x, y, z);
        }
    }
}