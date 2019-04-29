using System;

namespace PixelClickerBackend
{
    public class NatureDamageAttribute : Attribute
    {
        public override void Apply(Player player)
        {
            player.passiveNatureDPS += (int)(5.0 * Math.Pow(2.0, (double)(this.tier - 1)));
        }

        public NatureDamageAttribute(int tier) : base(tier)
        {

        }

    }
}