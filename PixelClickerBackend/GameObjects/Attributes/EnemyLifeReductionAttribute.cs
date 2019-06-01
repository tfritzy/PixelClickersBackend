using System;

namespace PixelClickerBackend
{
    public class EnemyLifeReductionAttribute : Attribute
    {

        public EnemyLifeReductionAttribute(int tier) : base(tier)
        {

        }

        protected override void Apply(Player player)
        {
            player.Stats.enemyHealthPercentageReduction += (float)GetEffectQuantity();
        }

        protected override void Remove(Player player)
        {
            player.Stats.enemyHealthPercentageReduction -= (float)GetEffectQuantity();
        }

        public override object GetEffectQuantity()
        {
            return (float)this.tier;
        }
    }
}