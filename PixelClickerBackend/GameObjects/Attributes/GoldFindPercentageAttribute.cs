using System.Numerics;
using System;

namespace PixelClickerBackend
{
    public class GoldFindPercentageAttribute : Attribute
    {
        public GoldFindPercentageAttribute(int tier) : base(tier)
        {

        }

        protected override void Apply(Player player)
        {
            BigInteger oldPlayerGoldFind = player.extraGoldFindPercentage;
            player.extraGoldFindPercentage = BigInteger.Add(oldPlayerGoldFind,
                                                    (BigInteger)GetEffectQuantity());
        }

        protected override void Remove(Player player)
        {
            BigInteger oldPlayerGoldFind = player.extraGoldFindPercentage;
            player.extraGoldFindPercentage = BigInteger.Subtract(oldPlayerGoldFind,
                                                    (BigInteger)GetEffectQuantity());
        }

        public override object GetEffectQuantity()
        {
            return BigInteger.Multiply(new BigInteger(10), this.tier);
        }
    }

}