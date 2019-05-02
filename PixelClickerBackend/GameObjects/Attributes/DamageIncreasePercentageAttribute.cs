using System;

namespace PixelClickerBackend
{
    public class DamageIncreasePercentageAttribute : Attribute
    {

        public DamageIncreasePercentageAttribute(int tier, Player player) : base(tier, player)
        {

        }


        protected override void Apply()
        {
            player.damageIncreasePercentage += this.tier * 100;
        }

        protected override void Remove()
        {
            player.critHitChance -= this.tier * 100;
            if (player.damageIncreasePercentage < 0)
                player.damageIncreasePercentage = 0;
        }

    }
}