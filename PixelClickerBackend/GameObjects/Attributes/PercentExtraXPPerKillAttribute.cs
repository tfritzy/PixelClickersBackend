using System.Numerics;
using System;

namespace PixelClickerBackend
{
    public class PercentExtraXPPerKillAttribute : Attribute
    {
        public PercentExtraXPPerKillAttribute(int tier) : base(tier)
        {

        }

        protected override void Apply(Player player)
        {
            player.percentExtraXPPerKill = 
            BigInteger.Add(player.percentExtraXPPerKill, 
                            (BigInteger)GetEffectQuantity());
        }

        protected override void Remove(Player player)
        {
            player.percentExtraXPPerKill = 
            BigInteger.Subtract(player.percentExtraXPPerKill, 
                                (BigInteger)GetEffectQuantity());
        }

        public override object GetEffectQuantity()
        {
            return BigInteger.Multiply(new BigInteger(5), new BigInteger(this.tier));
        }


    }

}