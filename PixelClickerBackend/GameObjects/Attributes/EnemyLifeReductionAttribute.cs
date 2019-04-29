using System;

namespace PixelClickerBackend
{
    public class EnemyLifeReductionAttribute : Attribute
    {
        public override void Apply(Player player)
        {
            player.enemyHealthPercentageReduction += (float)Math.Max(0, Math.Pow(2.0, this.tier - 5));
            if (player.enemyHealthPercentageReduction >= 90f)
                player.enemyHealthPercentageReduction = 90f;
        }
        public EnemyLifeReductionAttribute(int tier) : base(tier)
        {

        }
    }
}