namespace PixelClickerBackend
{
    public class Topaz : Gem
    {
        public Topaz(int tier, Player player) : base(tier, player)
        {
            this.type = GemType.Topaz;
            this.element = Elements.Earth;
        }

        protected override Attribute[] SetupAttributes()
        {
            Attribute[] attributes = new Attribute[3];
            attributes[0] = new EarthDamageAttribute(this.tier, this.player);
            attributes[1] = new CritHitChanceAttribute(this.tier, this.player);
            attributes[2] = new DamageIncreasePercentageAttribute(this.tier, this.player);
            return attributes;
        }
    }
}