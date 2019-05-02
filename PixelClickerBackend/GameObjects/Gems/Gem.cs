using System;

namespace PixelClickerBackend
{
    public abstract class Gem
    {
        public int tier;
        public GemType type;
        protected Attribute[] attributes;
        public Elements element;
        protected Player player;

        public Gem(int tier, Player player)
        {
            if (tier < 1)
                throw new ArgumentException("Gems cannot have a tier lower than 1");
            this.tier = tier;
            this.player = player;
            this.attributes = SetupAttributes();

        }
        public void Apply()
        {
            foreach (Attribute attribute in this.attributes)
            {
                attribute.ApplyEffect();
            }
        }

        public void Remove()
        {
            foreach (Attribute attribute in this.attributes)
            {
                attribute.RemoveEffect();
            }
        }

        protected abstract Attribute[] SetupAttributes();

        public Attribute[] GetAttributes()
        {
            return this.attributes;
        }

        public int GetAttributeCount()
        {
            return this.attributes.Length;
        }

    }
}
