namespace PixelClickerBackend
{
    public abstract class Attribute
    {
        public string name;
        public string description;
        protected Player player;
        public int tier;
        public bool isActive;

        public Attribute(int tier, Player player)
        {
            this.tier = tier;
            this.player = player;
            this.isActive = false;
        }

        public void ApplyEffect()
        {
            if (isActive)
            {
                return;
            }
            isActive = true;
            Apply();
        }

        public void RemoveEffect()
        {
            if (!isActive)
                return;
            isActive = false;
            Remove();
        }


        public abstract object GetEffectQuantity();
        protected abstract void Apply();
        protected abstract void Remove();
    }
}