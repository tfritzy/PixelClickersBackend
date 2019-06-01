using System;
using System.Numerics;
namespace PixelClickerBackend
{
    public class DamageIncreasePercentageAttribute : Attribute
    {

        public DamageIncreasePercentageAttribute(int tier) : base(tier)
        {

        }


        protected override void Apply(Player player)
        {
            player.Stats.damageIncreasePercentage += (BigInteger)GetEffectQuantity();
        }

        protected override void Remove(Player player)
        {
            player.Stats.damageIncreasePercentage -= (BigInteger)GetEffectQuantity();
        }

        public override object GetEffectQuantity()
        {
            return BigInteger.Multiply(this.tier, 30);
        }

    }
}