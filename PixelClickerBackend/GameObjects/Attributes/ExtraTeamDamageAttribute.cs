using System.Numerics;
using System;

namespace PixelClickerBackend
{
    public class ExtraTeamDamageAttribute : Attribute
    {

        public ExtraTeamDamageAttribute(int tier, Player player) : base(tier, player)
        {

        }

        protected override void Apply()
        {
            BigInteger oldPlayerTeamDamage = player.teamDamageBonusPercent;
            BigInteger increaseTeamDamagePercent = BigInteger.Pow(new BigInteger(2), this.tier - 1);
            player.teamDamageBonusPercent = BigInteger.Add(oldPlayerTeamDamage, increaseTeamDamagePercent);
        }

        protected override void Remove()
        {
            BigInteger oldPlayerTeamDamage = player.teamDamageBonusPercent;
            BigInteger changeInTeamDamagePercent = BigInteger.Pow(new BigInteger(2), this.tier - 1);
            player.teamDamageBonusPercent = BigInteger.Subtract(oldPlayerTeamDamage, changeInTeamDamagePercent);
        }
    }

}