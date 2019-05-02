using System.Numerics;
using System;

namespace PixelClickerBackend
{
    public class GoldFindPercentageAttribute : Attribute
    {
        public GoldFindPercentageAttribute(int tier, Player player) : base(tier, player)
        {

        }

        protected override void Apply()
        {
            BigInteger oldPlayerGoldFind = player.extraGoldFindPercentage;
            BigInteger increaseGoldFind = BigInteger.Pow(new BigInteger(2), Math.Max(0, this.tier));
            player.extraGoldFindPercentage = BigInteger.Add(oldPlayerGoldFind, increaseGoldFind);
        }

        protected override void Remove()
        {
            BigInteger oldPlayerGoldFind = player.extraGoldFindPercentage;
            BigInteger increaseGoldFind = BigInteger.Pow(new BigInteger(2), Math.Max(0, this.tier));
            player.extraGoldFindPercentage = BigInteger.Subtract(oldPlayerGoldFind, increaseGoldFind);
        }
    }

}