namespace PixelClickerBackend
{
    public class Ruby : Gem
    {
        public Ruby(int tier) : base(tier)
        {
            this.type = GemType.Ruby;
            this.element = Elements.Fire;
        }

        public override Attribute[] GetAttributes()
        {
            Attribute[] attributes = new Attribute[3];
            attributes[0] = new FireDamageAttribute(this.tier);
            attributes[1] = new GoldFindPercentageAttribute(this.tier);
            attributes[2] = new ExtraTeamDamageAttribute(this.tier);
            return attributes;
        }

    }

}