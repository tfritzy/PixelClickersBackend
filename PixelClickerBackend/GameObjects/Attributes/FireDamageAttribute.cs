using System;
using System.Numerics;

namespace PixelClickerBackend
{
    public class FireDamageAttribute : DamageAttribute
    {

        public FireDamageAttribute(int tier) : base(tier)
        {
            this.damageType = Elements.Fire;
        }

        protected override void Apply(Player player)
        {
            player.passiveFireDPS.Add((ExpNumber)GetEffectQuantity());
        }

        protected override void Remove(Player player)
        {
            player.passiveFireDPS.Subtract((ExpNumber)GetEffectQuantity());
        }

    }
}