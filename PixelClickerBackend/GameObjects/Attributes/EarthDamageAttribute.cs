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
            BigInteger damageIncrease = new BigInteger(5);
            damageIncrease = BigInteger.Multiply(BigInteger.Pow(2, this.tier - 1), damageIncrease);
            player.passiveEarthDPS += damageIncrease;
        }

        protected override void Remove()
        {
            BigInteger damageChange = new BigInteger(5);
            damageChange = BigInteger.Multiply(BigInteger.Pow(2, this.tier - 1), damageChange);
            player.passiveEarthDPS -= damageChange;
        }

    }
}