using System.Numerics;
using System;

namespace PixelClickerBackend
{
    public class PercentExtraXPPerKillAttribute : Attribute
    {
        public PercentExtraXPPerKillAttribute(int tier, Player player) : base(tier, player)
        {

        }

        protected override void Apply()
        {
            player.percentExtraXPPerKill = BigInteger.Add(player.extraGoldFindPercentage, (BigInteger)GetEffectQuantity());
        }

        protected override void Remove()
        {
            player.percentExtraXPPerKill = BigInteger.Subtract(player.extraGoldFindPercentage, (BigInteger)GetEffectQuantity());
        }

        public override object GetEffectQuantity()
        {
            return BigInteger.Multiply(new BigInteger(5), this.tier);
        }


    }

}