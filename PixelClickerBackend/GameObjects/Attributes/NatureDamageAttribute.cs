using System;
using System.Numerics;

namespace PixelClickerBackend
{
    public class NatureDamageAttribute : Attribute
    {
        public NatureDamageAttribute(int tier, Player player) : base(tier, player)
        {

        }

        protected override void Apply()
        {
            player.passiveNatureDPS = BigInteger.Add(player.passiveNatureDPS, (BigInteger)GetEffectQuantity());
        }

        protected override void Remove()
        {
            
            player.passiveNatureDPS = BigInteger.Subtract(player.passiveNatureDPS, (BigInteger)GetEffectQuantity());
        }

        public override object GetEffectQuantity()
        {
            return BigInteger.Multiply(this.tier, this.tier);
        }

    }
}