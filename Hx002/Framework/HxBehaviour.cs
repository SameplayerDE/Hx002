#nullable enable
using System;
using System.Windows.Forms;

namespace Hx002.Framework
{
    public class HxBehaviour : HxComponent
    {

        public void InvokeMethode(HxBehaviour self, string methode)
        {
            self.GetType().GetMethod(methode)?.Invoke(self, null);
        }
        
        public void InvokeMethode(HxBehaviour self, string methode, object?[]? parameters)
        {
            self.GetType().GetMethod(methode)?.Invoke(self, parameters);
        }

    }
}