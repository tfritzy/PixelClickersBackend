using System;
using System.Numerics;

namespace PixelClickerBackend
{
    public class WaterDamageAttribute : DamageAttribute
    {

        public WaterDamageAttribute(int tier) : base(tier)
        {
            this.damageType = Elements.Water;
        }

        protected override void Apply(Player player)
        {
            player.passiveWaterDPS.Add((ExpNumber)GetEffectQuantity());
        }

        protected override void Remove(Player player)
        {
            player.passiveWaterDPS.Subtract((ExpNumber)GetEffectQuantity());
        }

    }
}