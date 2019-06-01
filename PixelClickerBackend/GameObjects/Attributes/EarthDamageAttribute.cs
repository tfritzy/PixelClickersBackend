using System;
using System.Numerics;

namespace PixelClickerBackend
{
    public class EarthDamageAttribute : DamageAttribute
    {

        public EarthDamageAttribute(int tier) : base(tier)
        {
            this.damageType = Elements.Earth;
        }

        protected override void Apply(Player player)
        {
            player.Stats.passiveEarthDPS.Add((ExpNumber)GetEffectQuantity());
        }

        protected override void Remove(Player player)
        {
            player.Stats.passiveEarthDPS.Subtract((ExpNumber)GetEffectQuantity());
        }

    }
}