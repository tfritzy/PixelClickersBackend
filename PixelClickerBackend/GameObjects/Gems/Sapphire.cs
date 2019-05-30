using System;
using System.Collections.Generic;

namespace PixelClickerBackend
{

    public class Sapphire : Gem
    {

        public Sapphire(int tier, Player player) : base(tier, player)
        {
            this.type = GemType.Sapphire;
            this.element = Elements.Water;
        }


        protected override void SetupAttributes()
        {
            this.attributes.Add(typeof(WaterDamageAttribute), new WaterDamageAttribute(this.tier));
            this.attributes.Add(typeof(PercentExtraXPPerKillAttribute), new PercentExtraXPPerKillAttribute(this.tier));
            this.attributes.Add(typeof(CooldownReductionAttribute), new CooldownReductionAttribute(this.tier));
        }
    }
}







