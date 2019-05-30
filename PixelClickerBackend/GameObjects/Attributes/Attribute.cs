using System.Numerics;
using System.Collections.Generic;
using System.Linq;

namespace PixelClickerBackend
{
    public abstract class Attribute
    {
        public string name;
        public string description;
        public int tier;
        HashSet<Player> activePlayers;

        public Attribute(int tier)
        {
            this.tier = tier;
            activePlayers = new HashSet<Player>();
        }

        public void ApplyEffect(Player player)
        {
            if (activePlayers.Contains(player))
            {
                return;
            }
            activePlayers.Add(player);
            Apply(player);
        }

        public void RemoveEffect(Player player)
        {
            if (!activePlayers.Contains(player))
                return;
            activePlayers.Remove(player);
            Remove(player);
        }

        public void LevelUp()
        {
            List<Player> impactedPlayers = activePlayers.ToList();
            foreach (Player player in impactedPlayers){
                RemoveEffect(player);
            }
            this.tier += 1;
            foreach (Player player in impactedPlayers){
                ApplyEffect(player);
            }
        }

        public bool IsActive(Player player){
            return activePlayers.Contains(player);
        }

        public abstract object GetEffectQuantity();
        protected abstract void Apply(Player player);
        protected abstract void Remove(Player player);


    }
}