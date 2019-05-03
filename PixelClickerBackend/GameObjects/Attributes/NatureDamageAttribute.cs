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
            BigInteger damageIncrease = new BigInteger(5);
            return BigInteger.Multiply(damageIncrease, BigInteger.Pow(2, this.tier - 1));
        }

    }
}