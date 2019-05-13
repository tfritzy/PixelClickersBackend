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
        private Player player;

        private readonly int POWER_SPIKE_INTERVAL = 5;

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
                this.level += 1;
                leveledUp = true;
                levelRequirement = GetLevelUpXpRequirement();
            }
            return leveledUp;
        }

        public BigInteger GetLevelUpXpRequirement(){
            BigInteger baseXp = new BigInteger(100);
            return BigInteger.Multiply(baseXp, BigInteger.Pow(2, this.level-1));
        }

        public bool PowerUp(){
            if (player.gold.CompareTo(GetPowerUpPrice()) < 0)
                return false;   
            if (player.GetGemCount(GetPowerUpGemTier(), GemType.Sapphire) < GetPowerUpGemQuantity()){
                return false;
            }
            this.player.AddGems(GetPowerUpGemTier(), -GetPowerUpGemQuantity(), GemType.Sapphire);
            player.gold.Subtract(GetPowerUpPrice());
            this.powerLevel += 1; 
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
    }

}

