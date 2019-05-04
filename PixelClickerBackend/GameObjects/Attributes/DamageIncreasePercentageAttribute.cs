using System;
using System.Numerics;
namespace PixelClickerBackend
{
    public class DamageIncreasePercentageAttribute : Attribute
    {

        public DamageIncreasePercentageAttribute(int tier, Player player) : base(tier, player)
        {

        }


        protected override void Apply()
        {
            player.damageIncreasePercentage += (BigInteger)GetEffectQuantity();
        }

        protected override void Remove()
        {
            player.damageIncreasePercentage -= (BigInteger)GetEffectQuantity();
        }

        public override object GetEffectQuantity()
        {
            return BigInteger.Multiply(this.tier, 30);
        }

    }
}