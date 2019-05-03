using System;
using System.Numerics;

namespace PixelClickerBackend
{
    public class CooldownReductionAttribute: Attribute
    {

        public CooldownReductionAttribute(int tier, Player player) : base(tier, player)
        {

        }

        protected override void Apply()
        {
            player.cooldownReduction += (float)GetEffectQuantity();
        }

        protected override void Remove()
        {
            player.cooldownReduction -= (float)GetEffectQuantity();
        }

        public override object GetEffectQuantity()
        {
            return (float)this.tier;
        }

    }
}