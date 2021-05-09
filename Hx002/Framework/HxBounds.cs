using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace Hx002.Framework
{
    public class HxBounds
    {
        public Vector3 Center;
        public Vector3 Extents;
        public Vector3 Max;
        public Vector3 Min;
        public Vector3 Size;

        public HxBounds(Vector3 center, Vector3 size)
        {
            Center = center;
            Size = size;
        }
        
        public Vector3 ClosestPoint(Vector3 location)
        {
            Vector3 center = Center;
            
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

        public bool Contains(Vector3 location)
        {
            return (ClosestPoint(location) == location) ? true : false;
        }
    }
}