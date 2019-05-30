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
            player.passiveEarthDPS.Add((ExpNumber)GetEffectQuantity());
        }

        protected override void Remove(Player player)
        {
            player.passiveEarthDPS.Subtract((ExpNumber)GetEffectQuantity());
        }

    }
}