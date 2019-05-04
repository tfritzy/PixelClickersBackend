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
            return BigInteger.Multiply(new BigInteger((long)this.tier),
                                       new BigInteger((long)this.tier));
        }

    }
}