using System;
using System.Numerics;

namespace PixelClickerBackend
{
    public class FireDamageAttribute : Attribute
    {

        public FireDamageAttribute(int tier, Player player) : base(tier, player)
        {

        }

        protected override void Apply()
        {
            player.passiveFireDPS = BigInteger.Add(player.passiveFireDPS, 
                (BigInteger)GetEffectQuantity());
        }

        protected override void Remove()
        {
            player.passiveFireDPS = BigInteger.Subtract(player.passiveFireDPS, 
               (BigInteger)GetEffectQuantity());
        }

        public override object GetEffectQuantity()
        {
            BigInteger startingDamage = new BigInteger(5);
            return BigInteger.Multiply(startingDamage, BigInteger.Pow(2, this.tier - 1));
        }

    }
}