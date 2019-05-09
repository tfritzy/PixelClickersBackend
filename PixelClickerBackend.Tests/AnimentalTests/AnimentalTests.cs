using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;
using System.Collections.Generic;

namespace PixelClickerBackend.Tests
{
    public class AnimentalTests
    {

        [Fact]
        public void TestAnimentalBasics()
        {
            int level = 1;
            int powerLevel = 1;
            Player player = new Player();
            Animental dlet = new Dropplet(level, powerLevel, player);
            Assert.Equal(1, dlet.level);
            Assert.Equal(1, dlet.powerLevel);
        }

        [Fact]
        public void TestAnimentalTier()
        {
            Dictionary<AnimentalTier, int> simulationResults =
                new Dictionary<AnimentalTier, int>();
            Player player = new Player();
            Random random = new Random();
            int numSimulations = 100000;
            for (int i = 0; i < numSimulations; i++)
            {
                Animental dropplet = new Dropplet(random.Next(0, 100),
                                                random.Next(0, 100), player);
                if (!simulationResults.ContainsKey(dropplet.tier))
                    simulationResults.Add(dropplet.tier, 0);
                simulationResults[dropplet.tier] += 1;
            }

            float percentSTier = simulationResults[AnimentalTier.S] / (float)numSimulations;
            float percentATier = simulationResults[AnimentalTier.A] / (float)numSimulations;
            float percentBTier = simulationResults[AnimentalTier.B] / (float)numSimulations;
            float percentCTier = simulationResults[AnimentalTier.C] / (float)numSimulations;
            float percentDTier = simulationResults[AnimentalTier.D] / (float)numSimulations;
            float percentETier = simulationResults[AnimentalTier.E] / (float)numSimulations;
            float percentFTier = simulationResults[AnimentalTier.F] / (float)numSimulations;

            Assert.True(simulationResults[AnimentalTier.S] != 0);
            Assert.True(simulationResults[AnimentalTier.A] != 0);
            Assert.True(simulationResults[AnimentalTier.B] != 0);
            Assert.True(simulationResults[AnimentalTier.C] != 0);
            Assert.True(simulationResults[AnimentalTier.D] != 0);
            Assert.True(simulationResults[AnimentalTier.E] != 0);
            Assert.True(simulationResults[AnimentalTier.F] != 0);


            Assert.True(percentSTier >= .05f * .90f && percentSTier <= .05f * 1.10f);
            Assert.True(percentATier >= .1f * .90f && percentATier <= .1f * 1.10f);
            Assert.True(percentBTier >= .3f * .90f && percentBTier <= .3f * 1.10f);
            Assert.True(percentCTier >= .3f * .90f && percentCTier <= .3f * 1.10f);
            Assert.True(percentDTier >= .15f * .90f && percentDTier <= .15f * 1.10f);
            Assert.True(percentETier >= .075f * .90f && percentETier <= .075f * 1.10f);
            Assert.True(percentFTier >= .025f * .90f && percentFTier <= .025f * 1.10f);

        }


        #region Testing leveling up the animental
        [Fact]
        public void TestAnimentalLevelUp()
        {
            Animental dropplet = new Dropplet(1, 1, new Player());
            Assert.True(dropplet.AddXp(GetTargetPrice(dropplet.powerLevel)));
            Assert.Equal(2, dropplet.level);
            Assert.True(dropplet.AddXp(GetTargetPrice(dropplet.powerLevel)));
            Assert.Equal(3, dropplet.level);
            Assert.False(dropplet.AddXp(GetTargetPrice(dropplet.powerLevel)));
            Assert.Equal(3, dropplet.level);
            Assert.True(dropplet.AddXp(GetTargetPrice(dropplet.powerLevel)));
            Assert.Equal(4, dropplet.level);
        }

        private int GetTargetPrice(int level){
            return (int)(10 * Math.Pow(1.1, level));
        }

        [Fact]
        public void TestModerateLevelUpXp(){
            Animental dropplet = new Dropplet(4, 1, new Player());
            Assert.True(dropplet.AddXp(4975));
            Assert.Equal(6, dropplet.level);
            Assert.True(dropplet.AddXp(6542));
            Assert.Equal(7, dropplet.level);
        }

        [Fact]
        public void TestAnimentalLevelUpHighXp()
        {
            Animental dropplet = new Dropplet(1, 1, new Player());
                dropplet.AddXp(BigInteger.Parse("163669530394807093500659484841379957610832102302153239474164568404806689820233727744163504616295207857544334206378003550460862827294269652666426379468800"));
                Assert.Equal(500, dropplet.level);

        }

        #endregion

        #region Testing Powering up Animentals

        public void TestEarlyPowerUps(){
            Player player = new Player();
            Animental dropplet = new Dropplet(1, 1, player);
            Assert.Equal(50, dropplet.GetPowerUpPrice());
            Assert.False(dropplet.PowerUp());

            player.gold = 300;
            // Upgrade 1 costs 10
            Assert.True(dropplet.PowerUp());
            Assert.Equal(2, dropplet.powerLevel);
            Assert.Equal(290, player.gold);

            // Upgrade 2 costs 11
            Assert.True(dropplet.PowerUp());
            Assert.Equal(3, dropplet.powerLevel);
            Assert.Equal(279, player.gold);

            // Upgrade 3 costs 12
            player.gold = 10;
            Assert.False(dropplet.PowerUp());
            Assert.Equal(10, player.gold);

            // Upgrade 3 costs 12
            player.gold = 13;
            Assert.True(dropplet.PowerUp());
            Assert.Equal(0, player.gold);

            // Upgrade 4 costs 13
            player.gold = 200;
            Assert.True(dropplet.PowerUp());
            Assert.Equal(0, player.gold);

            // Upgrade 5 costs 14 and 1 tier 1 sapphire
            player.gold = 14;
            Assert.False(dropplet.PowerUp());
            Assert.Equal(14, player.gold);

        }

  
        public void TestLargeCostUpgrades(){
            Animental dropplet = new Dropplet(1, 1, new Player());
            for (int i = 1; i < 100000000; i+=i){
                Assert.True(dropplet.GetPowerUpPrice() > 0);
                dropplet.powerLevel += 1;
            }
        }


        public void TestLatePowerUps(){
            Player player = new Player();
            Animental dropplet = new Dropplet(1, 1342, player);
            Assert.Equal(67100, dropplet.GetPowerUpPrice());

        }
        
        #endregion
    }

}