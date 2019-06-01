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
        public void TestAnimentalLevelUpHighXp()
        {
            Animental dropplet = new Dropplet(1, 1, new Player());
                dropplet.AddXp(BigInteger.Parse("163669530394807093500659484841379957610832102302153239474164568404806689820233727744163504616295207857544334206378003550460862827294269652666426379468800"));
                Assert.Equal(500, dropplet.level);

        }

        #endregion
    }

}