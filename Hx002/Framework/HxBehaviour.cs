using System;

namespace Hx002.Framework
{
    public class HxBehaviour : HxComponent
    {

        public void InvokeMethode(HxBehaviour self, string methode)
        {
            self.GetType().GetMethod(methode)?.Invoke(self, null);
        }
    }
}