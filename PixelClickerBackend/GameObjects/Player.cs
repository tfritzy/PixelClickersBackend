using System.Numerics;
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
        public BigInteger clickDamage;
        public BigInteger passiveWaterDPS;
        public BigInteger passiveFireDPS;
        public BigInteger passiveNatureDPS;
        public BigInteger passiveEarthDPS;
        public float gemDropChance;
        public float enemyHealthPercentageReduction;
        public BigInteger extraGoldFindPercentage;
        public BigInteger teamDamageBonusPercent;
        public float critHitChance;
        public float critHitDamage;
        public float damageIncreasePercentage;
        public BigInteger percentExtraXPPerKill;
        public float cooldownReduction;

        public Player(){
        
        }
    }
}