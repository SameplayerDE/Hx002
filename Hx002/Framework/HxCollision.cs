using System;
using System.Collections.Generic;
using Hx002.Framework.Components;
using Microsoft.Xna.Framework;

namespace Hx002.Framework
{
    public struct HxCollision
    {
        //public List<HxContactPoint> Conta
        public readonly HxCollider Collider;
        public int ContactCount;
        public HxContactPoint[] Contacts;
        public readonly HxGameObject GameObject;
        public Vector3 Impulse;
        public readonly Vector3 RelativeVelocity;
        public readonly HxRigidbody Rigidbody;
        public readonly HxTransform Transform;

        public HxContactPoint GetContact(int index)
        {
            if (index >= 0 || index < ContactCount)
            {
                return Contacts[index];
            }

            return null;
        }

        public int GetContacts(HxContactPoint[] contacts)
        {
            int max = Math.Min(ContactCount, contacts.Length);
            for (int i = 0; i < max; i++)
            {
                contacts[i] = GetContact(i);
            }
            return max;
        }
        
        public int GetContacts(List<HxContactPoint> contacts)
        {
            for (int i = 0; i < ContactCount; i++)
            {
                contacts.Add(GetContact(i));
            }
            return ContactCount;
        }
        
    }
}