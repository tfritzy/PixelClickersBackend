using Xunit;
using System;
using System.Numerics;
using System.Collections.Generic;

namespace PixelClickerBackend.Tests {

    public class EnemyTests{
        
        [Fact]
        public void TestLevel1Constructor(){
            int level = 1;
            ExpNumber level1Health = new ExpNumber(3, 0);
            BigInteger level1Xp = new BigInteger(5);
            Enemy enemy = new Enemy(level);
            Assert.Equal(level, enemy.Level);
            Assert.Equal(level1Health, enemy.GetHealth());
            Assert.Equal(level1Xp, enemy.Xp);
        }

        [Fact]
        public void TestLevel5Constructor(){
            int level = 5;
            ExpNumber level5Health = new ExpNumber(75, 0);
            BigInteger level5Xp = new BigInteger(125);
            Enemy enemy = new Enemy(level);
            Assert.Equal(level, enemy.Level);
            Assert.Equal(level5Health, enemy.GetHealth());
            Assert.Equal(level5Xp, enemy.Xp);
        }

        [Fact]
        public void TestLevel100Constructor(){
            int level = 100;
            ExpNumber level100Health = new ExpNumber(30000, 0);
            BigInteger level100Xp = new BigInteger(50000);
            Enemy enemy = new Enemy(level);
            Assert.Equal(level, enemy.Level);
            Assert.Equal(level100Health, enemy.GetHealth());
            Assert.Equal(level100Xp, enemy.Xp);
        }

        [Fact]
        public void TestLevel1000Constructor(){
            int level = 1000;
            ExpNumber health = new ExpNumber(3000000, 0);
            BigInteger xp = new BigInteger(5000000);
            Enemy enemy = new Enemy(level);
            Assert.Equal(level, enemy.Level);
            Assert.Equal(health, enemy.GetHealth());
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
                ExpNumber prevEnemyHealth = enemy.GetHealth();
                enemy.DealDamage(amountOfDamage, player, Elements.Fire);
                prevEnemyHealth.Subtract(amountOfDamage);
                if (!prevEnemyHealth.IsPositive()){
                    prevEnemyHealth = new ExpNumber();
                }
                Assert.Equal(prevEnemyHealth, enemy.GetHealth());
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
                ExpNumber oldEnemyHealth = enemy.GetHealth();
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

        [Fact]
        public void TestEnemyGiveXp(){
            Random random = new Random();
            for (int i = 0; i < 100; i++){
                Player player = new Player();
                Enemy enemy = new Enemy(random.Next(100, 1000));
                List<Animental> playerAnimentals = player.Stats.AnimentalTeam;
                BigInteger[] oldXps = new BigInteger[playerAnimentals.Count];
                int[] oldLevels = new int[playerAnimentals.Count];
                
                for (int j = 0; j < playerAnimentals.Count; j++){
                    oldXps[j] = playerAnimentals[j].xp;
                    oldLevels[j] = playerAnimentals[j].level;
                }
                ExpNumber oldEnemyHealth = enemy.GetHealth();
                BigInteger expectedXpGain = enemy.Xp;
                enemy.DealDamage(enemy.GetHealth(), player, Elements.Normal);
                Assert.True(enemy.IsDead, String.Format("{0} damage is enough to kill enemy with {1} health. Enemy currently has {2} health",
                                             oldEnemyHealth, oldEnemyHealth, enemy.GetHealth()));
                BigInteger xpPerAnimental = expectedXpGain;
                for (int j = 0; j < playerAnimentals.Count; j++){
                    xpPerAnimental = BigInteger.Divide(xpPerAnimental, playerAnimentals.Count);
                    BigInteger expectedXp = oldXps[j];
                    expectedXp = BigInteger.Add(expectedXp, xpPerAnimental);
                    Assert.True(expectedXp.Equals(playerAnimentals[j].xp) || playerAnimentals[j].level > oldLevels[j], 
                                    String.Format("Animental must have gained the expected amount of xp, or gained at least 1 level " 
                                     + "oldXP:{0}, curXp:{1}, oldLevel:{2}, curLevel:{3}", oldXps[j], playerAnimentals[j].xp, 
                                     oldLevels[j], playerAnimentals[j].level));
                }

            }
        }

        [Fact]
        public void TestClickOnEnemy(){
            Player player = new Player();
            Enemy enemy = new Enemy(384);
            while (!enemy.IsDead){
                ExpNumber prevEnemyHealth = enemy.GetHealth();
                player.Stats.clickDamage = new ExpNumber(10, 1);
                player.Click(enemy);
                ExpNumber expectedEnemyHealth = prevEnemyHealth.Clone();
                expectedEnemyHealth.Subtract(player.Stats.clickDamage);
                Assert.True(enemy.GetHealth().Equals(expectedEnemyHealth) || enemy.IsDead, String.Format("The enemy starting with {0} " + 
                                                    "health taking {1} damage should now have {2} health",
                                                    prevEnemyHealth, player.Stats.clickDamage, expectedEnemyHealth));

            }

        }




        

    }

}