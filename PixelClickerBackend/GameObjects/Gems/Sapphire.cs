namespace PixelClickerBackend {

    public class Sapphire: Gem {

        public Sapphire(int tier, Player player) : base(tier, player){
            this.type = GemType.Sapphire;
            this.element = Elements.Water;
        }

        protected override Attribute[] SetupAttributes()
        {
            Attribute[] attributes = new Attribute[3];
            attributes[0] = new WaterDamageAttribute (this.tier, this.player);
            attributes[1] = new PercentExtraXPPerKillAttribute(this.tier, this.player);
            attributes[2] = new CooldownReductionAttribute(this.tier, this.player);
            return attributes;
        }
    }
}







