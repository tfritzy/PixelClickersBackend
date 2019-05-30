
namespace PixelClickerBackend
{
    public class Furtle : Animental
    {
        public Furtle(int level, int powerLevel, Player player) : base(level, powerLevel, player)
        {
            this.element = Elements.Fire;
            this.damage = new ExpNumber(3.5, 0);
            this.levelUpDamageScalingFactor = new ExpNumber(1.12, 0);
            this.powerUpDamageScalingFactor = new ExpNumber(1.011, 0);
            this.percentOfNormXpRequiredForLevelUp = 1;
        }
    }
}