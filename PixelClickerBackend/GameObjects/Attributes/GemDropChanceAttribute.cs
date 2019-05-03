using System;

namespace PixelClickerBackend
{
    public class GemDropChanceAttribute : Attribute
    {

        public GemDropChanceAttribute(int tier, Player player) : base(tier, player)
        {

        }


        protected override void Apply()
        {
            player.gemDropChance += (float)GetEffectQuantity();
        }

        protected override void Remove()
        {
            player.gemDropChance -= (float)GetEffectQuantity();
        }

        public override object GetEffectQuantity()
        {
            return (float)(2 * this.tier);
        }

    }
}