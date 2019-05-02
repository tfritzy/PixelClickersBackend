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
            BigInteger damageIncrease = new BigInteger(5);
            damageIncrease = BigInteger.Multiply(BigInteger.Pow(2, this.tier - 1), damageIncrease);
            player.passiveNatureDPS += damageIncrease;
        }

        protected override void Remove()
        {
            BigInteger damageIncrease = new BigInteger(5);
            damageIncrease = BigInteger.Multiply(BigInteger.Pow(2, this.tier - 1), damageIncrease);
            player.passiveNatureDPS -= damageIncrease;
        }

    }
}