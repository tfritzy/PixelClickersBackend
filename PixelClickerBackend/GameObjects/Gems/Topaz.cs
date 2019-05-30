using System;
using System.Collections.Generic;

namespace PixelClickerBackend
{
    public class Topaz : Gem
    {
        public Topaz(int tier, Player player) : base(tier, player)
        {
            this.type = GemType.Topaz;
            this.element = Elements.Earth;
            
        }

        protected override void SetupAttributes()
        {
            this.attributes.Add(typeof(EarthDamageAttribute), new EarthDamageAttribute(this.tier));
            this.attributes.Add(typeof(CritHitChanceAttribute), new CritHitChanceAttribute(this.tier));
            this.attributes.Add(typeof(DamageIncreasePercentageAttribute), new DamageIncreasePercentageAttribute(this.tier));
        }
    }
}