using System;
using System.Numerics;

namespace PixelClickerBackend
{
    public class NatureDamageAttribute : DamageAttribute
    {
        public NatureDamageAttribute(int tier) : base(tier)
        {
            this.damageType = Elements.Nature;
        }

        protected override void Apply(Player player)
        {
            player.passiveNatureDPS.Add((ExpNumber)GetEffectQuantity());
        }

        protected override void Remove(Player player)
        {
            player.passiveNatureDPS.Subtract((ExpNumber)GetEffectQuantity());
        }

    }
}