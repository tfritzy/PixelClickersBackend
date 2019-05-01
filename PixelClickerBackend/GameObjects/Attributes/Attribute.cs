namespace PixelClickerBackend
{
    public abstract class Attribute
    {
        public string name;
        public string description;
        public abstract void Apply(Player player);
        protected int tier;
        
        public Attribute(int tier)
        {
            this.tier = tier;
        }
    }
}