using System;
using System.Numerics;

namespace PixelClickerBackend
{
    public class CritHitChanceAttribute : Attribute
    {

        public CritHitChanceAttribute(int tier, Player player) : base(tier, player)
        {

        }


        protected override void Apply()
        {
             player.critHitChance += (float)GetEffectQuantity();
        }

        protected override void Remove()
        {
            player.critHitChance -= (float)GetEffectQuantity();
        }

        public override object GetEffectQuantity()
        {
            return (float)this.tier;
        }

    }
}