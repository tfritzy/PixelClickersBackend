using System;
using System.Numerics;

namespace PixelClickerBackend
{
    public class WaterDamageAttribute : Attribute
    {

        public WaterDamageAttribute(int tier, Player player) : base(tier, player)
        {

        }

        protected override void Apply()
        {
            player.passiveWaterDPS = BigInteger.Add(player.passiveWaterDPS, (BigInteger)GetEffectQuantity());
        }

        protected override void Remove()
        {
            player.passiveWaterDPS = BigInteger.Subtract(player.passiveWaterDPS, (BigInteger)GetEffectQuantity());
        }

        public override object GetEffectQuantity()
        {
            return BigInteger.Multiply(BigInteger.Pow(2, this.tier - 1), new BigInteger(5));
        }

    }
}