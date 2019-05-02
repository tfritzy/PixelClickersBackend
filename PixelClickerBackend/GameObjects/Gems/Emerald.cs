using System.Collections.Generic;

namespace PixelClickerBackend
{
    public class Emerald : Gem
    {
        public Emerald(int tier, Player player) : base(tier, player)
        {
            this.type = GemType.Emerald;
            this.element = Elements.Nature;
        }

        protected override Attribute[] SetupAttributes()
        {
            List<Attribute> attrs = new List<Attribute>();

            attrs.Add(new NatureDamageAttribute(this.tier, this.player));

            if (this.tier >= 3)
                attrs.Add(new GemDropChanceAttribute(this.tier, this.player));
            if (this.tier >= 5)
                attrs.Add(new EnemyLifeReductionAttribute(this.tier, this.player));

            return attrs.ToArray();
        }
    }
}