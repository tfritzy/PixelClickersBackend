using System.Numerics;
using System.Collections.Generic;

namespace PixelClickerBackend
{
    public class Player
    {

        private PlayerData _stats;

        public PlayerData Stats{
            get { return _stats; }
            set { _stats = value; }
        }

        public Player(){
            this.Stats = new PlayerData(this);
        }

        public int GetGemCount(int tier, GemType gemType){
            int count = 0;
            switch (gemType){
                case GemType.Emerald:
                    this.Stats.emeralds.TryGetValue(tier, out count);
                    break;
                case GemType.Ruby:
                    this.Stats.rubies.TryGetValue(tier, out count);
                    break;
                case GemType.Sapphire:
                    this.Stats.sapphires.TryGetValue(tier, out count);
                    break;
                case GemType.Topaz:
                    this.Stats.topaz.TryGetValue(tier, out count);
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
                    this.Stats.emeralds[tier] = currentCount + quantity;
                    break;
                case GemType.Ruby: 
                    this.Stats.rubies[tier] = currentCount + quantity;
                    break;
                case GemType.Sapphire: 
                    this.Stats.sapphires[tier] = currentCount + quantity;
                    break;
                case GemType.Topaz: 
                    this.Stats.topaz[tier] = currentCount + quantity;
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

        public void Click(Enemy enemy){
            enemy.DealDamage(this.Stats.clickDamage, this, Elements.Normal);
        }

    }
}