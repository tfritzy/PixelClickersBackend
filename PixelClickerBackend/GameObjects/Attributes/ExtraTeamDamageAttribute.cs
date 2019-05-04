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
            player.teamDamageBonusPercent = BigInteger.Add(oldPlayerTeamDamage,  
                                                    (BigInteger)GetEffectQuantity());
        }

        protected override void Remove()
        {
            BigInteger oldPlayerTeamDamage = player.teamDamageBonusPercent;
            player.teamDamageBonusPercent = BigInteger.Subtract(oldPlayerTeamDamage, 
                                                    (BigInteger)GetEffectQuantity());
        }

        public override object GetEffectQuantity()
        {
             return BigInteger.Multiply(new BigInteger(3), new BigInteger(this.tier));
        }
    }

}