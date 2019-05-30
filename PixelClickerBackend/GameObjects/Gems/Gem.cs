using System;
using System.Collections.Generic;

namespace PixelClickerBackend
{
    public abstract class Gem : AttributeGroup
    {
        public int tier;
        public GemType type;
        public Elements element;

        public Gem(int tier, Player player) : base(player)
        {
            if (tier < 1)
                throw new ArgumentException("Gems cannot have a tier lower than 1");
            this.tier = tier;
            SetupAttributes();
        }
    

        protected abstract void SetupAttributes();

        public Dictionary<Type, Attribute> GetAttributes()
        {
            return this.attributes;
        }

        public int GetAttributeCount()
        {
            return this.attributes.Count;
        }

        public ExpNumber GetDamage(){
            foreach (Attribute attribute in this.attributes.Values){
                if (attribute.GetType().IsSubclassOf(typeof(DamageAttribute))){
                    return ((DamageAttribute)attribute).GetDamage();
                }
            }
            return null;
        }

    }
}
