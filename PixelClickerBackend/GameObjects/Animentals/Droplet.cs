
namespace PixelClickerBackend
{

    public class Dropplet : Animental
    {
        public Dropplet(int level, int powerLevel, Player player) : base(level, powerLevel, player)
        {
            this.element = Elements.Water;
            this.damage = new ExpNumber(3, 0);
            this.levelUpDamageScalingFactor = new ExpNumber(1.1, 0);
            this.powerUpDamageScalingFactor = new ExpNumber(1.01, 0);
            this.percentOfNormXpRequiredForLevelUp = .9;
        }
    }




}