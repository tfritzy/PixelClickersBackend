using System;

namespace PixelClickerBackend
{
    public class EnemyLifeReductionAttribute : Attribute
    {

        public EnemyLifeReductionAttribute(int tier, Player player) : base(tier, player)
        {

        }

        protected override void Apply()
        {
            player.enemyHealthPercentageReduction += (float)GetEffectQuantity();
        }

        protected override void Remove()
        {
            player.enemyHealthPercentageReduction -= (float)GetEffectQuantity();
        }

        public override object GetEffectQuantity()
        {
            return (float)this.tier;
        }
    }
}