using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct2D1.Effects;

namespace Hx002.Framework
{
    public class HxObject : ICloneable
    {

        public HxScene Scene;


        public virtual object Clone()
        {
            var clone = this.Create();
            return clone;
        }
        
        protected virtual HxObject Create()
        {
            return new HxObject();
        }
        
        public static HxObject Instantiate(HxObject original)
        {
            HxObject copy = (HxObject)original.Clone();
            return copy;
        }
        
    }
}