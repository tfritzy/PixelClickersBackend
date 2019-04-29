namespace PixelClickerBackend
{
    public class Player
    {
        public Animental[] stash;
        public Animental[] team;
        public string name;
        public int id;
        public string email;
        public string hashedAndSaltedPassword;
        public string numChests;
        public int gold;
        public Gem[] gems;
        public int clickDamage;
        public int passiveWaterDPS;
        public int passiveFireDPS;
        public int passiveNatureDPS;
        public int passiveEarthDPS;
        public float gemDropChance;
        public float enemyHealthPercentageReduction;
    }
}