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
            attrs.Add(new GemDropChanceAttribute(this.tier, this.player));
            attrs.Add(new EnemyLifeReductionAttribute(this.tier, this.player));

            return attrs.ToArray();
        }
    }
}