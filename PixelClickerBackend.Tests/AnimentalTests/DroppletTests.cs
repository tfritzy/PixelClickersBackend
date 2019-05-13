using System;
using PixelClickerBackend;
using System.Numerics;
using System.Collections.Generic;
using Xunit;

namespace PixelClickerBackend.Tests {

    public class DroppletTests {

       #region Testing Powering up Dropplet

        [Fact]
        public void TestEarlyPowerUps(){
            Player player = new Player();
            Animental dropplet = new Dropplet(1, 1, player);
            Assert.False(dropplet.PowerUp());

            player.gold = new ExpNumber(300, 0);
            ExpNumber expectedGold = new ExpNumber(300, 0);
            // Upgrade 1 costs 10
            expectedGold.Subtract(10.0);
            Assert.True(dropplet.PowerUp());
            Assert.Equal(2, dropplet.powerLevel);
            Assert.Equal(expectedGold, player.gold);

            // Upgrade 2 costs 11
            expectedGold.Subtract(11);
            Assert.True(dropplet.PowerUp());
            Assert.Equal(3, dropplet.powerLevel);
            Assert.Equal(expectedGold, player.gold);

            // Upgrade 3 costs 12.1
            player.gold = new ExpNumber(10, 0);
            expectedGold = new ExpNumber(10, 0);
            Assert.False(dropplet.PowerUp());
            Assert.Equal(expectedGold, player.gold);

            // Upgrade 3 costs 12.1
            player.gold = new ExpNumber(12.1, 0);
            expectedGold = new ExpNumber(12.1, 0);
            expectedGold.Subtract(12.1);
            Assert.True(dropplet.PowerUp());
            Assert.Equal(expectedGold, player.gold);

            // Upgrade 4 costs 13.31 and 1 tier 1 sapphire
            player.gold = new ExpNumber(200, 0);
            expectedGold = new ExpNumber(200, 0);
            expectedGold.Subtract(13.31);
            player.AddGems(1, 1, GemType.Emerald);
            player.AddGems(1, 1, GemType.Ruby);
            player.AddGems(1, 1, GemType.Topaz);
            Assert.False(dropplet.PowerUp());
            player.AddGems(1, 1, GemType.Sapphire);
            Assert.True(dropplet.PowerUp());
            Assert.Equal(expectedGold, player.gold);
            Assert.Equal(0, player.GetGemCount(1, GemType.Sapphire));
            Assert.Equal(1, player.GetGemCount(1, GemType.Ruby));
            Assert.Equal(1, player.GetGemCount(1, GemType.Topaz));
            Assert.Equal(1, player.GetGemCount(1, GemType.Emerald));
            
            // Upgrade 5 costs 14.641 gold
            player.gold = new ExpNumber(15, 0);
            expectedGold = new ExpNumber(15, 0);
            expectedGold.Subtract(GetPowerUpPrice(dropplet.powerLevel));
            Assert.True(dropplet.PowerUp());
            Assert.Equal(expectedGold, player.gold);
        }

        [Fact]
        public void TestPowerUpGems(){
            Player player = new Player();
            player.gold = new ExpNumber(500, 20);
            Random random = new Random();
            Animental dropplet = new Dropplet(random.Next(1, 100),  3, player);
            Assert.True(dropplet.PowerUp()); // Can do level 3 because it doesn't require any gems. 
            Assert.False(dropplet.PowerUp()); // Can't do level 4 because it requires 1 tier 1 gem. 
            player.AddGems(1, 1, GemType.Sapphire);
            Assert.True(dropplet.PowerUp()); // Can now do the level up because it has the gem. 
            
            dropplet.powerLevel = 9;
            Assert.False(dropplet.PowerUp()); // This power up costs 2 tier 1 gems. 
            player.AddGems(1, 2, GemType.Sapphire);
            Assert.True(dropplet.PowerUp()); // Now have the required gems. 
            Assert.Equal(0, player.GetGemCount(2, GemType.Sapphire));
            
            player = new Player();
            player.gold = new ExpNumber(5.0, 400);
            dropplet = new Dropplet(1, 14, player);
            Assert.False(dropplet.PowerUp()); // Level 14 powerup requires 3 tier 1 gems.
            player.AddGems(1, 3, GemType.Sapphire);
            Assert.True(dropplet.PowerUp());
            Assert.Equal(0, player.GetGemCount(1, GemType.Sapphire));

            dropplet.powerLevel = 14;
            Assert.False(dropplet.PowerUp()); // Level 14 powerup requires 3 tier 1 gems.
            player.AddGems(1, 15, GemType.Sapphire);
            Assert.True(dropplet.PowerUp());
            Assert.Equal(12, player.GetGemCount(1, GemType.Sapphire));

            dropplet.powerLevel = 19;
            Assert.False(dropplet.PowerUp()); // This upgrade costs 1 tier 2 gem;
            player.AddGems(1, 4, GemType.Sapphire);
            Assert.False(dropplet.PowerUp()); // still don't have the required gems. 
            player.AddGems(2, 1, GemType.Sapphire);
            Assert.True(dropplet.PowerUp()); // Can now do the power up;
            Assert.Equal(0, player.GetGemCount(2, GemType.Sapphire));

            dropplet.powerLevel = 19;
            Assert.False(dropplet.PowerUp()); // This upgrade costs 1 tier 2 gem;
            player.AddGems(1, 4, GemType.Sapphire);
            Assert.False(dropplet.PowerUp()); // still don't have the required gems. 
            player.AddGems(2, 1, GemType.Sapphire);
            Assert.True(dropplet.PowerUp()); // Can now do the power up;

            dropplet.powerLevel = 34;
            Assert.False(dropplet.PowerUp()); // This upgrade costs 1 tier 3 gem;
            player.AddGems(3, 2, GemType.Sapphire);
            Assert.True(dropplet.PowerUp()); // Can now do the power up;
            Assert.Equal(1, player.GetGemCount(3, GemType.Sapphire)); // Should be 1 tier 3 gem left.
        }


        private ExpNumber GetPowerUpPrice(int level){
            ExpNumber baseNumber = new ExpNumber(10, 0);
            ExpNumber exponent = new ExpNumber(1.1, 0);
            exponent.Pow(level-1);
            baseNumber.Multiply(exponent);
            return baseNumber;
        }


        public void TestThatAttributeLevelIncreasesOnPowerup(){
            Player player = new Player();
            Animental dropplet = new Dropplet(1, 1, player);
            
        }


        [Fact]
        public void TestLargeCostUpgrades(){
            Animental dropplet = new Dropplet(1, 1, new Player());
            for (int i = 1; i < 100000000; i+=i){
                Assert.True(dropplet.GetPowerUpPrice().CompareTo(new ExpNumber(0, 0)) > 0);
                dropplet.powerLevel += 1;
            }
        }

        [Fact]
        public void TestLatePowerUps(){
            Player player = new Player();
            Animental dropplet = new Dropplet(1, 1342, player);
            ExpNumber expected = GetPowerUpPrice(1342);
            Assert.Equal(expected, dropplet.GetPowerUpPrice());
        }
        
        #endregion
    }
}