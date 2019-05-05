using System.Numerics;
using System.Collections.Generic;

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
        public BigInteger gold;
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
        public BigInteger damageIncreasePercentage;
        public BigInteger percentExtraXPPerKill;
        public float cooldownReduction;
        public Dictionary<int, int> emeralds;
        public Dictionary<int, int> rubies;
        public Dictionary<int, int> sapphires;
        public Dictionary<int, int> topaz;

        public Player(){
            emeralds = new Dictionary<int, int>();
            rubies = new Dictionary<int, int>();
            sapphires = new Dictionary<int, int>();
            topaz = new Dictionary<int, int>();
        }

        public int GetGemCount(int tier, GemType gemType){
            int count = 0;
            switch (gemType){
                case GemType.Emerald:
                    this.emeralds.TryGetValue(tier, out count);
                    break;
                case GemType.Ruby:
                    this.rubies.TryGetValue(tier, out count);
                    break;
                case GemType.Sapphire:
                    this.sapphires.TryGetValue(tier, out count);
                    break;
                case GemType.Topaz:
                    this.topaz.TryGetValue(tier, out count);
                    break;
            }
            return count;
        }


        public bool AddGems(int tier, int quantity, GemType gemType){

            int currentCount = GetGemCount(tier, gemType);
            if (quantity + currentCount < 0)
                return false;

            switch (gemType){
                case GemType.Emerald: 
                    this.emeralds[tier] = currentCount + quantity;
                    break;
                case GemType.Ruby: 
                    this.rubies[tier] = currentCount + quantity;
                    break;
                case GemType.Sapphire: 
                    this.sapphires[tier] = currentCount + quantity;
                    break;
                case GemType.Topaz: 
                    this.topaz[tier] = currentCount + quantity;
                    break;
                
            }
            return false;
            
        }

        public bool Merge(int targetTier, GemType gemType){
            int currentGemCount = GetGemCount(targetTier-1, gemType);
            if (currentGemCount >= 3){
                AddGems(targetTier-1, -3, gemType);
                AddGems(targetTier, 1, gemType);
                return true;
            } else {
                return false;
            }
        }
    }
}