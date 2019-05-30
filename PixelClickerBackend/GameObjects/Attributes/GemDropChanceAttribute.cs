using System;

namespace PixelClickerBackend
{
    public class GemDropChanceAttribute : Attribute
    {

        public GemDropChanceAttribute(int tier) : base(tier)
        {

        }

        protected override void Apply(Player player)
        {
            player.gemDropChance += (float)GetEffectQuantity();
        }

        protected override void Remove(Player player)
        {
            player.gemDropChance -= (float)GetEffectQuantity();
        }

        public override object GetEffectQuantity()
        {
            return (float)(2 * this.tier);
        }

    }
}