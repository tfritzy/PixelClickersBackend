namespace PixelClickerBackend
{
    public class Ruby : Gem
    {
        public Ruby(int tier, Player player) : base(tier, player)
        {
            this.type = GemType.Ruby;
            this.element = Elements.Fire;
        }

        protected override Attribute[] SetupAttributes()
        {
            Attribute[] attributes = new Attribute[3];
            attributes[0] = new FireDamageAttribute(this.tier, this.player);
            attributes[1] = new GoldFindPercentageAttribute(this.tier, this.player);
            attributes[2] = new ExtraTeamDamageAttribute(this.tier, this.player);
            return attributes;
        }

    }

}