using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;

namespace PixelClickerBackend.Tests
{

    public class SapphireTests
    {

        [Fact]
        public void TestSapphireTier()
        {
            Gem s = new Sapphire(3, new Player());
            Assert.Equal(3, s.tier);
            Assert.Equal(Elements.Water, s.element);
            Assert.Equal(GemType.Sapphire, s.type);
        }

        [Fact]
        public void TestSapphireAttributes()
        {
            int tier = 5;
            Gem s = new Sapphire(tier, new Player());
            Assert.True(DoesListContainAttribute(s, typeof(WaterDamageAttribute)));
            Assert.True(DoesListContainAttribute(s, typeof(PercentExtraXPPerKillAttribute)));
            Assert.True(DoesListContainAttribute(s, typeof(CooldownReductionAttribute)));

        }

        private bool DoesListContainAttribute(Gem gem, Type desiredAttribute)
        {
            return gem.Contains(desiredAttribute);
        }

        [Fact]
        public void TestSapphireAttributesAtLevels()
        {
            
            for (int i = 1; i < 10000; i += i)
            {
                Player testPlayer = new Player();
                WaterDamageAttribute wda = new WaterDamageAttribute(i);
                PercentExtraXPPerKillAttribute pxp = 
                    new PercentExtraXPPerKillAttribute(i);
                CooldownReductionAttribute cdr = new CooldownReductionAttribute(i);

                Assert.Equal(new ExpNumber(), testPlayer.Stats.passiveNatureDPS);
                Assert.Equal(new ExpNumber(), testPlayer.Stats.passiveEarthDPS);
                Assert.Equal(new ExpNumber(), testPlayer.Stats.passiveFireDPS);
                Assert.Equal(new ExpNumber(), testPlayer.Stats.passiveWaterDPS);
               

                Gem s = new Sapphire(i, testPlayer);
                Random r = new Random();
                for (int j = 0; j < 1000; j++)
                {
                    if (r.Next(0, 2) == 1)
                    {
                        s.MakeAllActive();
                    }
                    else
                        s.MakeAllInactive();
                }
                s.MakeAllActive();

                Assert.Equal((ExpNumber)wda.GetEffectQuantity(), testPlayer.Stats.passiveWaterDPS);
                Assert.Equal((BigInteger)pxp.GetEffectQuantity(),
                    testPlayer.Stats.percentExtraXPPerKill);
                Assert.Equal((float)cdr.GetEffectQuantity(), (testPlayer.Stats.cooldownReduction));


            }
        }



    }
}