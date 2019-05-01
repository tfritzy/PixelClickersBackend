using System;

namespace PixelClickerBackend
{
    public abstract class Gem
    {
        public int tier;
        public GemType type;
        protected Attribute[] attributes;
        public abstract Attribute[] GetAttributes();
        private abstract void ModifyTargetedAttribute(BigInteger amount);
        public Elements element;

        private bool isEffetCurrentlyApplied;

        public void Apply(Player player)
        {
            if (isEffetCurrentlyApplied)
                return;
            ModifyTargetedAttribute(BigInteger.Multiply(new BigInteger(1), GetEfffectValue()));
            isEffetCurrentlyApplied = !isEffetCurrentlyApplied;
            BigInteger modifier = new BigInteger(1);
            ModifyTargetedAttribute(BigInteger.Multiply(modifier, GetEfffectValue()));
            foreach (Attribute attribute in this.attributes)
            {
                attribute.Apply(player);
            }
        }

        public void UnApplyEffect(){
            if (!isEffetCurrentlyApplied)
                return;
            BigInteger modifier = new BigInteger(-1);
            ModifyTargetedAttribute(BigInteger.Multiply(modifier, GetEfffectValue()));
        }

        public Gem(int tier)
        {
            if (tier < 1)
                throw new ArgumentException("Gems cannot have a tier lower than 1");
            this.tier = tier;
            this.attributes = GetAttributes();
        }
    }
}
