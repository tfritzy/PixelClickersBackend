using System;

namespace PixelClickerBackend
{
    public class CritHitChanceAttribute : Attribute
    {

        public CritHitChanceAttribute(int tier, Player player) : base(tier, player)
        {

        }


        protected override void Apply()
        {
            player.critHitChance += this.tier;
        }

        protected override void Remove()
        {
            player.critHitChance -= this.tier;
            if (player.critHitChance < 0)
                player.critHitChance = 0;
        }

    }
}