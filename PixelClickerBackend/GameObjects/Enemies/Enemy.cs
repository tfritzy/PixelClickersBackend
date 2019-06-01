using System;
using System.Numerics;

namespace PixelClickerBackend {

    public class Enemy {


        private Elements _elementalType;
        public Elements ElementalType {
            get { return _elementalType; }
            private set { _elementalType = value; }
        }

        private bool _isDead;
        public bool IsDead {
            get { return _isDead; }
            private set { _isDead = value; }
        }

        private int _level;
        public int Level {
            get { return _level; }
            set { _level = value; }
        }

        private ExpNumber _health;

        private ExpNumber Health {
            get { return _health;}
        }

        public ExpNumber GetHealth(){
            return _health.Clone();
        }

        private BigInteger _xp;

        public BigInteger Xp {
            get { return _xp; }
            set { _xp = value; }
        }


        public Enemy(int level){
            if (level <= 0)
                throw new ArgumentException("Enemy level cannot be less than 1");
            this.Level = level;
            IsDead = false;
            this.ElementalType = Elements.Normal;
            SetHealth();
            SetXp();
        }

        private void SetHealth(){
            ExpNumber baseHealth = new ExpNumber(3, 0);
            ExpNumber scalingFactor = new ExpNumber(Level, 0);
            scalingFactor.Pow(2);
            baseHealth.Multiply(scalingFactor);
            this._health = baseHealth;
        }

        private void SetXp(){
            BigInteger baseXp = new BigInteger(5);
            BigInteger scalingFactor = new BigInteger(Level);
            scalingFactor = BigInteger.Pow(Level, 2);
            baseXp = BigInteger.Multiply(baseXp, scalingFactor);
            this.Xp = baseXp;
        }

        public void DealDamage(ExpNumber damage, Player source, Elements damageType) {
            this.Health.Subtract(damage);
            if (!this.Health.IsPositive()){
                OnDeath(source);
            }
        }

        private void OnDeath(Player killer){
            this._health = ExpNumber.ZERO;
            IsDead = true;
            DistributeXpAcrossPlayersAnimentals(killer);
        }

        private void DistributeXpAcrossPlayersAnimentals(Player killer){
            int animentalTeamSize = killer.Stats.AnimentalTeam.Count;
            if (animentalTeamSize == 0)
                return;
            BigInteger xpPerAnimental = BigInteger.Divide(this.Xp, animentalTeamSize);
            foreach(Animental animental in killer.Stats.AnimentalTeam){
                animental.AddXp(xpPerAnimental);
            }
        }
    }
}