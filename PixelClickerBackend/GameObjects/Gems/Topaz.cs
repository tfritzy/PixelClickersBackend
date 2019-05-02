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
            return attributes;
        }
    }
}