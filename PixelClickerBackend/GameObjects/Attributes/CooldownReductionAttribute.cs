using System;
using System.Numerics;

namespace PixelClickerBackend
{
    public class CooldownReductionAttribute: Attribute
    {

        public CooldownReductionAttribute(int tier) : base(tier)
        {

        }

        protected override void Apply(Player player)
        {
            player.Stats.cooldownReduction += (float)GetEffectQuantity();
        }

        protected override void Remove(Player player)
        {
            player.Stats.cooldownReduction -= (float)GetEffectQuantity();
        }

        public override object GetEffectQuantity()
        {
            return (float)this.tier;
        }

    }
}