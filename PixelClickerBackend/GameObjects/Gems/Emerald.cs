using System.Collections.Generic;

namespace PixelClickerBackend
{
    public class Emerald : Gem
    {
        public Emerald(int tier)
        {
            this.type = GemType.Emerald;
            this.tier = tier;
            this.attributes = GetAttributes();
        }

        public override Attribute[] GetAttributes()
        {
            List<Attribute> attrs = new List<Attribute>();

            attrs.Add(new NatureDamageAttribute(this.tier));

            if (this.tier >= 3)
                attrs.Add(new GemDropChanceAttribute(this.tier));
            if (this.tier >= 5)
                attrs.Add(new EnemyLifeReductionAttribute(this.tier));

            return attrs.ToArray();
        }
    }
}