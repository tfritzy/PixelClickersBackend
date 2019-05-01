using System.Numerics;
using System;

namespace PixelClickerBackend
{
    public class ExtraTeamDamageAttribute : Attribute
    {

        public override void Apply(Player player)
        {
            BigInteger oldPlayerTeamDamage = player.teamDamageBonusPercent;
            BigInteger increaseTeamDamagePercent = BigInteger.Pow(new BigInteger(2), this.tier - 1);
            player.teamDamageBonusPercent = BigInteger.Add(oldPlayerTeamDamage, increaseTeamDamagePercent);
        }

        public ExtraTeamDamageAttribute(int tier) : base(tier)
        {

        }
    }

}