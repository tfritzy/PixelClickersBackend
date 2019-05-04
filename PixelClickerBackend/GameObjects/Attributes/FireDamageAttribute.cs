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
            return BigInteger.Multiply(this.tier, this.tier);
        }

    }
}