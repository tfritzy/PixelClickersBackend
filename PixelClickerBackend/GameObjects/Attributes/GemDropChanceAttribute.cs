using System;

namespace PixelClickerBackend
{
    public class GemDropChanceAttribute : Attribute
    {
        public override void Apply(Player player)
        {
            player.gemDropChance += (float)Math.Max(0, Math.Pow(2.0, this.tier - 3.0));
            if (player.gemDropChance >= 100)
                player.gemDropChance = 100;
        }

        public GemDropChanceAttribute(int tier) : base(tier)
        {

        }

    }
}