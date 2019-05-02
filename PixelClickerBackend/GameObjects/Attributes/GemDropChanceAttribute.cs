using System;

namespace PixelClickerBackend
{
    public class GemDropChanceAttribute : Attribute
    {

        public GemDropChanceAttribute(int tier, Player player) : base(tier, player)
        {

        }


        protected override void Apply()
        {
            player.gemDropChance += (float)Math.Max(0, Math.Pow(2.0, this.tier - 3.0));
            if (player.gemDropChance >= 100)
                player.gemDropChance = 100;
        }

        protected override void Remove()
        {
            player.gemDropChance -= (float)Math.Max(0, Math.Pow(2.0, this.tier - 3.0));
            if (player.gemDropChance < 0)
                player.gemDropChance = 0;
        }

    }
}