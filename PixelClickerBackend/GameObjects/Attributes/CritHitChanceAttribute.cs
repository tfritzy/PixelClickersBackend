using System;
using System.Numerics;

namespace PixelClickerBackend
{
    public class CritHitChanceAttribute : Attribute
    {

        public CritHitChanceAttribute(int tier) : base(tier)
        {

        }


        protected override void Apply(Player player)
        {
             player.critHitChance += (float)GetEffectQuantity();
        }

        protected override void Remove(Player player)
        {
            player.critHitChance -= (float)GetEffectQuantity();
        }

        public override object GetEffectQuantity()
        {
            return (float)this.tier;
        }

    }
}