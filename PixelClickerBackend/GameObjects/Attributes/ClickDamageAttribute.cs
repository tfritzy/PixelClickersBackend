namespace PixelClickerBackend {

    public class ClickDamageAttribute : Attribute {

        public ClickDamageAttribute(int tier) : base(tier) {


        }
        protected override void Apply(Player player)
        {
            player.Stats.clickDamage.Add((ExpNumber)GetEffectQuantity());
        }

        protected override void Remove(Player player)
        {
            player.Stats.clickDamage.Subtract((ExpNumber)GetEffectQuantity());
        }

        public override object GetEffectQuantity()
        {
            ExpNumber clickDamage = new ExpNumber(4, 0);
            clickDamage.Multiply(new ExpNumber(this.tier, 0));
            return clickDamage;
        }

    }
}