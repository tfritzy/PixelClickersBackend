using System.Numerics;
using System;

namespace PixelClickerBackend
{
    public class ExtraTeamDamageAttribute : Attribute
    {

        public ExtraTeamDamageAttribute(int tier) : base(tier)
        {

        }

        protected override void Apply(Player player)
        {
            BigInteger oldPlayerTeamDamage = player.Stats.teamDamageBonusPercent;
            player.Stats.teamDamageBonusPercent = BigInteger.Add(oldPlayerTeamDamage,  
                                                    (BigInteger)GetEffectQuantity());
        }

        protected override void Remove(Player player)
        {
            BigInteger oldPlayerTeamDamage = player.Stats.teamDamageBonusPercent;
            player.Stats.teamDamageBonusPercent = BigInteger.Subtract(oldPlayerTeamDamage, 
                                                    (BigInteger)GetEffectQuantity());
        }

        public override object GetEffectQuantity()
        {
             return BigInteger.Multiply(new BigInteger(3), new BigInteger(this.tier));
        }
    }

}