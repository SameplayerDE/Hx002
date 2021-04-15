using System;

namespace Hx002.Framework
{
    public class HxComponent : ICloneable
    {
        public HxGameObject HxGameObject;
        public object Clone()
        {
            return (HxComponent) this.MemberwiseClone();
        }
    }
}