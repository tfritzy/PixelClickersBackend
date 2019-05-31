using Xunit;
using System;

namespace PixelClickerBackend.Tests {

    public class EnemyTests{
        
        [Fact]
        public void TestLevel1Constructor(){
            int level = 1;
            ExpNumber level1Health = new ExpNumber(3.3, 0);
            ExpNumber level1Xp = new ExpNumber(6, 0);
            Enemy enemy = new Enemy(level);
            Assert.Equal(level, enemy.Level);
            Assert.Equal(level1Health, enemy.Health);
            Assert.Equal(level1Xp, enemy.Xp);
        }

        [Fact]
        public void TestLevel5Constructor(){
            int level = 5;
            ExpNumber level5Health = new ExpNumber(4.831, 0);
            ExpNumber level5Xp = new ExpNumber(1.2441, 1);
            Enemy enemy = new Enemy(level);
            Assert.Equal(level, enemy.Level);
            Assert.Equal(level5Health, enemy.Health);
            Assert.Equal(level5Xp, enemy.Xp);
        }

        [Fact]
        public void TestLevel100Constructor(){
            int level = 100;
            ExpNumber level100Health = new ExpNumber(4.134183, 4);
            ExpNumber level100Xp = new ExpNumber(4.1408987261, 8);
            Enemy enemy = new Enemy(level);
            Assert.Equal(level, enemy.Level);
            Assert.Equal(level100Health, enemy.Health);
            Assert.Equal(level100Xp, enemy.Xp);
        }

        [Fact]
        public void TestLevel1000Constructor(){
            int level = 1000;
            ExpNumber health = new ExpNumber(7.4097, 41);
            ExpNumber xp = new ExpNumber(7.58955, 79);
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
            ExpNumber amountOfDamage = new ExpNumber(2, 0);
            Enemy enemy = new Enemy(1);
            ExpNumber prevEnemyHealth = enemy.Health;
            enemy.DealDamage(amountOfDamage, player, Elements.Fire);
            prevEnemyHealth.Subtract(amountOfDamage);
            Assert.Equal(prevEnemyHealth, enemy.Health);
        }

        

    }

}