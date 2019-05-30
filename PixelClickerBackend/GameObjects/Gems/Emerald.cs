using System.Collections.Generic;
using System;

namespace PixelClickerBackend
{
    public class Emerald : Gem
    {
        public Emerald(int tier, Player player) : base(tier, player)
        {
            this.type = GemType.Emerald;
            this.element = Elements.Nature;
        }

        protected override void SetupAttributes()
        {
            this.attributes.Add(typeof(NatureDamageAttribute), new NatureDamageAttribute(this.tier));
            this.attributes.Add(typeof(GemDropChanceAttribute), new GemDropChanceAttribute(this.tier));
            this.attributes.Add(typeof(EnemyLifeReductionAttribute), new EnemyLifeReductionAttribute(this.tier));
        }
    }
}