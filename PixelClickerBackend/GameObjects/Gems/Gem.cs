namespace PixelClickerBackend
{
    public abstract class Gem
    {
        public int tier;
        public GemType type;
        protected Attribute[] attributes;
        public abstract Attribute[] GetAttributes();
        public void Apply(Player player)
        {
            foreach (Attribute attribute in this.attributes)
            {
                attribute.Apply(player);
            }
        }
    }
}
