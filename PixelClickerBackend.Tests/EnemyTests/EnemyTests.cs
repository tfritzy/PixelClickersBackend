using Xunit;
using System;

namespace PixelClickerBackend.Tests {

    public class EnemyTests{
        
        [Fact]
        public void TestLevel1Constructor(){
            int level = 1;
            ExpNumber level1Health = new ExpNumber(3, 0);
            ExpNumber level1Xp = new ExpNumber(5, 0);
            Enemy enemy = new Enemy(level);
            Assert.Equal(level, enemy.Level);
            Assert.Equal(level1Health, enemy.Health);
            Assert.Equal(level1Xp, enemy.Xp);
        }

        [Fact]
        public void TestLevel5Constructor(){
            int level = 5;
            ExpNumber level5Health = new ExpNumber(75, 0);
            ExpNumber level5Xp = new ExpNumber(125, 0);
            Enemy enemy = new Enemy(level);
            Assert.Equal(level, enemy.Level);
            Assert.Equal(level5Health, enemy.Health);
            Assert.Equal(level5Xp, enemy.Xp);
        }

        [Fact]
        public void TestLevel100Constructor(){
            int level = 100;
            ExpNumber level100Health = new ExpNumber(30000, 0);
            ExpNumber level100Xp = new ExpNumber(50000, 0);
            Enemy enemy = new Enemy(level);
            Assert.Equal(level, enemy.Level);
            Assert.Equal(level100Health, enemy.Health);
            Assert.Equal(level100Xp, enemy.Xp);
        }

        [Fact]
        public void TestLevel1000Constructor(){
            int level = 1000;
            ExpNumber health = new ExpNumber(3000000, 0);
            ExpNumber xp = new ExpNumber(5000000, 0);
            Enemy enemy = new Enemy(level);
            Assert.Equal(level, enemy.Level);
            Assert.Equal(health, enemy.Health);
            Assert.Equal(xp, enemy.Xp);
        }

        [Fact]
        public void TestLevel0Enemy(){
            Enemy enemy;
            Assert.Throws<ArgumentException>(() => enemy = new Enemy(0));
        }

        [Fact]
        public void TestDealDamage(){
            Player player = new Player();
            Random random = new Random();
            for (int i = 0; i < 1000; i++){
                double amountOfDamageSignificand = random.NextDouble();
                int amountOfDamageMagnitude = random.Next(0, 1000);
                ExpNumber amountOfDamage = new ExpNumber(amountOfDamageSignificand, amountOfDamageMagnitude);
                Enemy enemy = new Enemy(random.Next(1, int.MaxValue));
                ExpNumber prevEnemyHealth = enemy.Health.Clone();
                enemy.DealDamage(amountOfDamage, player, Elements.Fire);
                prevEnemyHealth.Subtract(amountOfDamage);
                if (!prevEnemyHealth.IsPositive()){
                    prevEnemyHealth = new ExpNumber();
                }
                Assert.Equal(prevEnemyHealth, enemy.Health);
            }
            
            
        }

        [Fact]
        public void TestTimingOfInstantiatingLargeEnemies(){
            TimeSpan startTime = DateTime.Now.TimeOfDay;
            for (int i = 0; i < 1000; i++){
                Enemy enemy = new Enemy(int.MaxValue);
            }
            TimeSpan endTime = DateTime.Now.TimeOfDay;
            Assert.True((endTime - startTime) < new TimeSpan(0, 0, 1));
        }

        [Fact]
        public void TestKillingEnemies(){
            Player testPlayer = new Player();
            Random random = new Random();
            int enemyLevel = random.Next(0, 100);
            for (int i = 0; i < 100; i++){
                Enemy enemy = new Enemy(enemyLevel);
                ExpNumber oldEnemyHealth = enemy.Health.Clone();
                ExpNumber damage = new ExpNumber(1, int.MaxValue);
                enemy.DealDamage(damage, testPlayer, Elements.Fire);
                Assert.True(enemy.IsDead, String.Format("{0} damage is enough to kill enemy with {1} health.", damage, oldEnemyHealth));
            }
        }

        [Fact]
        public void TestEnemyType(){
            Random random = new Random();
            for (int i = 0; i < 5; i++){
                Enemy enemy = new Enemy(random.Next(1, 1000000));
                Assert.True(enemy.ElementalType == Elements.Normal, "The base enemy instantiation should have the normal type.");
            }
        }




        

    }

}