using System.Numerics;
using System.Collections.Generic;

namespace PixelClickerBackend {

    public class PlayerData {

        public string name;
        public int id;
        public string email;
        public string hashedAndSaltedPassword;
        public string numChests;
        public ExpNumber gold;
        public Gem[] gems;
        public ExpNumber clickDamage;
        public ExpNumber passiveWaterDPS;
        public ExpNumber passiveFireDPS;
        public ExpNumber passiveNatureDPS;
        public ExpNumber passiveEarthDPS;
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
        private List<Animental> _animentalStash;
        public List<Animental> AnimentalStash{
            get { return _animentalStash; }
            private set { _animentalStash = value; }
        }
        private List<Animental> _animentalTeam;
        public List<Animental> AnimentalTeam{
            get { return _animentalTeam; }
            private set { _animentalTeam = value; }
        }
        public PlayerData(Player owner){
            emeralds = new Dictionary<int, int>();
            rubies = new Dictionary<int, int>();
            sapphires = new Dictionary<int, int>();
            topaz = new Dictionary<int, int>();
            this.gold = new ExpNumber();
            this.passiveEarthDPS = new ExpNumber();
            this.passiveFireDPS = new ExpNumber();
            this.passiveWaterDPS = new ExpNumber();
            this.passiveNatureDPS = new ExpNumber();
            this.clickDamage = new ExpNumber();
            this.AnimentalTeam = GetPlayerAnimentalTeam(owner);
            this.AnimentalStash = GetPlayerAnimentalStash(owner);
        }

        public List<Animental> GetPlayerAnimentalTeam(Player owner){
            List<Animental> team = new List<Animental>();
            team.Add(new Furtle(1, 1, owner));
            team.Add(new Dropplet(1, 1, owner));
            return team;
        }

        
        public List<Animental> GetPlayerAnimentalStash(Player owner){
            return new List<Animental>();
        }





    }
}