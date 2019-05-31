using System;

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

        public ExpNumber Health {
            get { return _health; }
            set { _health = value; }
        }

        private ExpNumber _xp;

        public ExpNumber Xp {
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
            this.Health = baseHealth;
        }

        private void SetXp(){
            ExpNumber baseXp = new ExpNumber(5, 0);
            ExpNumber scalingFactor = new ExpNumber(Level, 0);
            scalingFactor.Pow(2);
            baseXp.Multiply(scalingFactor);
            this.Xp = baseXp;
        }

        public void DealDamage(ExpNumber damage, Player source, Elements damageType) {
            this.Health.Subtract(damage);
            if (!this.Health.IsPositive()){
                this.Health = ExpNumber.ZERO;
                IsDead = true;
            }
        }
    }
}