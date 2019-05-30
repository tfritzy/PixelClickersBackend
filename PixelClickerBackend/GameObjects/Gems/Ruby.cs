using System;
using System.Collections.Generic;

namespace PixelClickerBackend
{
    public class Ruby : Gem
    {
        public Ruby(int tier, Player player) : base(tier, player)
        {
            this.type = GemType.Ruby;
            this.element = Elements.Fire;
        }

        protected override void SetupAttributes()
        {
            this.attributes.Add(typeof(FireDamageAttribute), new FireDamageAttribute(this.tier));
            this.attributes.Add(typeof(GoldFindPercentageAttribute), new GoldFindPercentageAttribute(this.tier));
            this.attributes.Add(typeof(ExtraTeamDamageAttribute), new ExtraTeamDamageAttribute(this.tier));
        }

    }

}