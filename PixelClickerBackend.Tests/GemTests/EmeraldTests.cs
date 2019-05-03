using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;

namespace PixelClickerBackend.Tests
{
    public class GemTests
    {
        #region Sample_TestCode
        [Fact]
        public void TestEmeraldBasics()
        {
            Gem emerald = new Emerald(5, new Player());
            Assert.Equal(GemType.Emerald, emerald.type);
            Assert.Equal(5, emerald.tier);
        }
        #endregion

        [Fact]
        public void TestEmeraldElementType()
        {
            Gem emerald = new Emerald(3, new Player());
            Assert.Equal(Elements.Nature, emerald.element);
        }

        [Fact]
        public void TestEmeraldAttributes()
        {
            Gem emerald = new Emerald(100, new Player());
            Assert.Equal(3, emerald.GetAttributeCount());
            Assert.True(DoesListContainAttribute(emerald, typeof(NatureDamageAttribute)));
            Assert.True(DoesListContainAttribute(emerald, typeof(GemDropChanceAttribute)));
            Assert.True(DoesListContainAttribute(emerald, typeof(EnemyLifeReductionAttribute)));
        }


        private bool DoesListContainAttribute(Gem gem, Type desiredAttribute)
        {

            foreach (Attribute attr in gem.GetAttributes())
            {
                if (attr.GetType() == desiredAttribute)
                    return true;
            }
            return false;
        }

        [Fact]
        public void TestEmeraldAttributesAtLevels()
        {
            
            for (int i = 1; i < 10000; i += i)
            {
                Player testPlayer = new Player();
                NatureDamageAttribute nda = new NatureDamageAttribute(i, testPlayer);
                GemDropChanceAttribute gdc = 
                    new GemDropChanceAttribute(i, testPlayer);
                EnemyLifeReductionAttribute elr = new EnemyLifeReductionAttribute(i, testPlayer);

                Assert.Equal(0, testPlayer.passiveNatureDPS);
                Assert.Equal(0, testPlayer.passiveEarthDPS);
                Assert.Equal(0, testPlayer.passiveFireDPS);
                Assert.Equal(0, testPlayer.passiveWaterDPS);
               
                Gem s = new Emerald(i, testPlayer);
                s.Apply();

                Assert.Equal(testPlayer.passiveNatureDPS, (BigInteger)nda.GetEffectQuantity());
                Assert.Equal(testPlayer.gemDropChance, (float)gdc.GetEffectQuantity());
                Assert.Equal(testPlayer.enemyHealthPercentageReduction, (float)elr.GetEffectQuantity());
            }
        }
    }
}
