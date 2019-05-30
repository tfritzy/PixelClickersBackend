using System;
using System.Numerics;

namespace PixelClickerBackend
{
    public abstract class DamageAttribute : Attribute
    {

        public Elements damageType;

        public DamageAttribute(int tier) : base(tier)
        {

        }


        public override object GetEffectQuantity()
        {
            ExpNumber damage = new ExpNumber(this.tier, 0);
            damage.Pow(2);
            return damage;
        }

        public ExpNumber GetDamage(){
            return (ExpNumber)(GetEffectQuantity());
        }

    }
}