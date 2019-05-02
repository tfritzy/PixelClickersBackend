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
            player.enemyHealthPercentageReduction += (float)Math.Max(0, Math.Pow(2.0, this.tier - 5));
            if (player.enemyHealthPercentageReduction >= 90f)
                player.enemyHealthPercentageReduction = 90f;
        }

        protected override void Remove()
        {
            player.enemyHealthPercentageReduction -= (float)Math.Max(0, Math.Pow(2.0, this.tier - 5));
            if (player.enemyHealthPercentageReduction <= 0f)
                player.enemyHealthPercentageReduction = 0f;
        }
    }
}