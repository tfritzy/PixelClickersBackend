using System;
using System.Numerics;

namespace PixelClickerBackend
{
    public abstract class Animental
    {
        public string name;
        public int level; // upgraded with xp
        public int powerLevel; // upgraded with gold
        public BigInteger xp;
        public Gem heldGem;
        public AnimentalTier tier;
        public Player player;
        public Elements element;
        public ExpNumber damage;
        protected ExpNumber levelUpDamageScalingFactor;
        protected ExpNumber powerUpDamageScalingFactor;
        protected double percentOfNormXpRequiredForLevelUp;
        private readonly int POWER_SPIKE_INTERVAL = 5;
        private readonly int XP_INCREASE_FACTOR_PER_LEVEL = 2;

        public Animental(int level, int powerLevel, Player player)
        {
            this.level = level;
            this.player = player;
            this.powerLevel = powerLevel;
            this.tier = RandomlyGenerateTier();
        }

        public AnimentalTier RandomlyGenerateTier()
        {
            String[] tiers = Enum.GetNames(typeof(AnimentalTier));
            int[] tierWeights = new int[] { 50, 100, 300, 300, 150, 75, 25 };
            int weightTotal = 0;
            foreach (int tierWeight in tierWeights)
                weightTotal += tierWeight;

            Random random = new Random();
            float roll = random.Next(0, weightTotal);
            float weightSum = 0;
            for (int i = 0; i < tierWeights.Length; i++)
            {
                int weight = tierWeights[i];
                weightSum += weight;
                if (weightSum >= roll)
                {
                    return (AnimentalTier)Enum.Parse(typeof(AnimentalTier), tiers[i]);
                }
            }

            throw new InvalidOperationException("A tier must have been returned by this point");
        }

        /// <summary>
        /// This method increments this animental's xp by the specified amount.
        /// If enough xp is gained, the animental's xp is increased unitl it cannon be increased further.
        /// </summary>
        /// <returns>
        /// true if a level is gained, false otherwise.
        /// </returns>
        public bool AddXp(BigInteger amount){
            this.xp = BigInteger.Add(this.xp, amount);
            bool leveledUp = false;
            BigInteger levelRequirement = GetLevelUpXpRequirement();
            while (this.xp >= levelRequirement){
                this.xp -= levelRequirement;
                LevelUp();
                leveledUp = true;
                levelRequirement = GetLevelUpXpRequirement();
            }
            return leveledUp;
        }

        private void LevelUp(){
            this.level += 1;
            this.damage.Multiply(levelUpDamageScalingFactor);
        }

        public BigInteger GetLevelUpXpRequirement(){
            BigInteger baseXp = new BigInteger((int)(100*percentOfNormXpRequiredForLevelUp));
            return BigInteger.Multiply(baseXp, BigInteger.Pow(XP_INCREASE_FACTOR_PER_LEVEL, this.level-1));
        }

        public bool PowerUp(){
            if (player.Stats.gold.CompareTo(GetPowerUpPrice()) < 0)
                return false;   
            if (player.GetGemCount(GetPowerUpGemTier(), GemType.Sapphire) < GetPowerUpGemQuantity()){
                return false;
            }
            this.player.AddGems(GetPowerUpGemTier(), -GetPowerUpGemQuantity(), GemType.Sapphire);
            player.Stats.gold.Subtract(GetPowerUpPrice());
            this.powerLevel += 1; 
            this.damage.Multiply(this.powerUpDamageScalingFactor);
            return true;

        }

        private int GetPowerUpGemTier(){
            if ((powerLevel+1) % POWER_SPIKE_INTERVAL != 0)
                return 0;
            int tier = (powerLevel + 1) / POWER_SPIKE_INTERVAL - 1;
            tier = tier / 3 + 1;
            return tier;
        }

        private int GetPowerUpGemQuantity(){
            if ((powerLevel+1) % POWER_SPIKE_INTERVAL != 0)
                return 0;
            int quantity = (powerLevel + 1) / POWER_SPIKE_INTERVAL - 1;
            quantity = quantity % 3 + 1;
            return quantity;
        }

        public ExpNumber GetPowerUpPrice(){
            ExpNumber baseNumber = new ExpNumber(10, 0);
            ExpNumber exponent = new ExpNumber(1.1, 0);
            exponent.Pow(this.powerLevel-1);
            baseNumber.Multiply(exponent);
            return baseNumber;
        }

        public void GiveGem(Gem gem){
            this.heldGem = gem;
            
        }
    }

}

