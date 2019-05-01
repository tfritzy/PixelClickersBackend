using System;
using System.Numerics;

namespace PixelClickerBackend
{
    public class FireDamageAttribute : Attribute
    {
        public override void Apply(Player player)
        {
            BigInteger damageIncrease = new BigInteger(5);
            damageIncrease = BigInteger.Multiply(BigInteger.Pow(2, this.tier - 1), damageIncrease);
            player.passiveFireDPS += damageIncrease;
        }

        public FireDamageAttribute(int tier) : base(tier)
        {

        }

    }
}