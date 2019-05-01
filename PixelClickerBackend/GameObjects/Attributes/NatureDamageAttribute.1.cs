using System;
using System.Numerics;

namespace PixelClickerBackend
{
    public class NatureDamageAttribute : Attribute
    {
        public override void Apply(Player player)
        {
            BigInteger damageIncrease = new BigInteger(5);
            damageIncrease = BigInteger.Multiply(BigInteger.Pow(2, this.tier - 1), damageIncrease);
            player.passiveNatureDPS += damageIncrease;
        }

        public NatureDamageAttribute(int tier) : base(tier)
        {

        }

    }
}