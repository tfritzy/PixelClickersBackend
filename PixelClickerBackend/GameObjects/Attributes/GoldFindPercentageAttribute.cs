using System.Numerics;
using System;

namespace PixelClickerBackend
{
    public class GoldFindPercentageAttribute : Attribute
    {

        public override void Apply(Player player)
        {
            BigInteger oldPlayerGoldFind = player.extraGoldFindPercentage;
            BigInteger increaseGoldFind = BigInteger.Pow(new BigInteger(2), Math.Max(0, this.tier));
            player.extraGoldFindPercentage = BigInteger.Add(oldPlayerGoldFind, increaseGoldFind);
        }

        public GoldFindPercentageAttribute(int tier) : base(tier)
        {

        }
    }

}