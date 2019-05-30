using System;
using System.Collections.Generic;

namespace PixelClickerBackend
{

    public class AttributeGroup
    {

        protected Dictionary<Type, Attribute> attributes;
        protected Player player;

        public AttributeGroup(Player player)
        {
            attributes = new Dictionary<Type, Attribute>();
            this.player = player;
        }

        public bool Insert(Attribute attr)
        {
            if (Contains(attr.GetType()))
                return false;
            attributes.Add(attr.GetType(), attr);
            return true;
        }

        public bool Contains(Type type)
        {
            return attributes.ContainsKey(type);
        }

        public void MakeAllActive(){
            foreach(Attribute attr in attributes.Values){
                attr.ApplyEffect(this.player);
            }
        }

        public void MakeAllInactive(){
            foreach(Attribute attr in attributes.Values){
                attr.RemoveEffect(this.player);
            }
        }


    }
}