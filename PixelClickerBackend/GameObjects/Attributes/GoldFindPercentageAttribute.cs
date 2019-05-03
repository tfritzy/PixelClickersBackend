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
            BigInteger oldPlayerGoldFind = this.player.extraGoldFindPercentage;
            player.extraGoldFindPercentage = BigInteger.Add(oldPlayerGoldFind,
                                                    (BigInteger)GetEffectQuantity());
        }

        protected override void Remove()
        {
            BigInteger oldPlayerGoldFind = this.player.extraGoldFindPercentage;
            player.extraGoldFindPercentage = BigInteger.Subtract(oldPlayerGoldFind,
                                                    (BigInteger)GetEffectQuantity());
        }

        public override object GetEffectQuantity()
        {
            return BigInteger.Pow(new BigInteger(2), Math.Max(0, this.tier));
        }
    }

}