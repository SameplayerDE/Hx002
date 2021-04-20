using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Hx002.Framework
{
    public class HxGameObject : HxObject
    {

        private readonly List<HxComponent> _components = new List<HxComponent>();

        public List<HxComponent> Components
        {
            get { return _components; }
        }
        
        public override object Clone()
        {
            var clone = (HxGameObject)base.Clone();
            clone.Attach(this._components);
            return clone;
        }
        
        protected override HxObject Create()
        {
            return new HxGameObject();
        }
        
        public void Attach(HxComponent component)
        {
            component.HxGameObject = this;
            this._components.Add(component);
        }
        
        public void Attach(List<HxComponent> components)
        {
            foreach (var component in components)
            {
                component.HxGameObject = this;
                this._components.Add(component);
            }
            
        }

        public T Get<T>() where T : HxComponent
        {
            foreach (HxComponent component in this._components)
            {
                if (component is T obj)
                    return obj;
            }
            return default (T);
        }

        public void Detach(HxComponent component)
        {
            this._components.Remove(component);
        }
        
    }
}