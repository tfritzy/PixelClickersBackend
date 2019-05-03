using System;

namespace PixelClickerBackend
{
    public class DamageIncreasePercentageAttribute : Attribute
    {

        public DamageIncreasePercentageAttribute(int tier, Player player) : base(tier, player)
        {

        }


        protected override void Apply()
        {
            player.damageIncreasePercentage += (float)GetEffectQuantity();
        }

        protected override void Remove()
        {
            player.damageIncreasePercentage -= (float)GetEffectQuantity();
        }

        public override object GetEffectQuantity()
        {
            return (float)(this.tier * 100);
        }

    }
}