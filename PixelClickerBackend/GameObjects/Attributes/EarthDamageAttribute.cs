using System;
using System.Numerics;

namespace PixelClickerBackend
{
    public class EarthDamageAttribute : Attribute
    {

        public EarthDamageAttribute(int tier, Player player) : base(tier, player)
        {

        }

        protected override void Apply()
        {
            player.passiveEarthDPS = BigInteger.Add(player.passiveEarthDPS, (BigInteger)GetEffectQuantity());
        }

        protected override void Remove()
        {
            player.passiveEarthDPS = BigInteger.Subtract(player.passiveEarthDPS, (BigInteger)GetEffectQuantity());
        }

        public override object GetEffectQuantity()
        {
            return BigInteger.Multiply(this.tier, this.tier);
        }

    }
}