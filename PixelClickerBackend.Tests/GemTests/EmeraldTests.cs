using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;

namespace PixelClickerBackend.Tests
{
    public class GemTests
    {

        #region Testing Emerald Basics
        [Fact]
        public void TestClass(){
            Emerald emerald = new Emerald(1, new Player());
            Assert.True(emerald.GetType().IsSubclassOf(typeof(AttributeGroup)));
            Assert.True(emerald.GetType().IsSubclassOf(typeof(Gem)));
        }
        
        [Fact]
        public void TestEmeraldBasics()
        {
            Gem emerald = new Emerald(5, new Player());
            Assert.Equal(GemType.Emerald, emerald.type);
            Assert.Equal(5, emerald.tier);
        }
        

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
            Assert.True(emerald.Contains(typeof(NatureDamageAttribute)));
            Assert.True(emerald.Contains(typeof(GemDropChanceAttribute)));
            Assert.True(emerald.Contains(typeof(EnemyLifeReductionAttribute)));
        }


        [Fact]
        public void TestEmeraldDamage(){
            Emerald emerald = new Emerald(1, new Player());
            Assert.Equal(new ExpNumber(1, 0), emerald.GetDamage());

            emerald = new Emerald(2, new Player());
            Assert.Equal(new ExpNumber(4, 0), emerald.GetDamage());

            emerald = new Emerald(3, new Player());
            Assert.Equal(new ExpNumber(9, 0), emerald.GetDamage());

            emerald = new Emerald(4, new Player());
            Assert.Equal(new ExpNumber(1.6, 1), emerald.GetDamage());

            emerald = new Emerald(5, new Player());
            Assert.Equal(new ExpNumber(2.5, 1), emerald.GetDamage());

            emerald = new Emerald(6, new Player());
            Assert.Equal(new ExpNumber(3.6, 1), emerald.GetDamage());

            emerald = new Emerald(7, new Player());
            Assert.Equal(new ExpNumber(4.9, 1), emerald.GetDamage());

            emerald = new Emerald(100, new Player());
            Assert.Equal(new ExpNumber(1, 4), emerald.GetDamage());


            emerald = new Emerald(1000, new Player());
            Assert.Equal(new ExpNumber(1, 6), emerald.GetDamage());

            emerald = new Emerald(1000000, new Player());
            Assert.Equal(new ExpNumber(1, 12), emerald.GetDamage());
        }

        #endregion


        #region Test Emerald Level ups. 
        [Fact]
        public void TestEmeraldAttributesAtLevels()
        {
            
            for (int i = 1; i < 10000; i += i)
            {
                Player testPlayer = new Player();
                NatureDamageAttribute nda = new NatureDamageAttribute(i);
                GemDropChanceAttribute gdc = 
                    new GemDropChanceAttribute(i);
                EnemyLifeReductionAttribute elr = new EnemyLifeReductionAttribute(i);

                Assert.Equal(new ExpNumber(), testPlayer.passiveNatureDPS);
                Assert.Equal(new ExpNumber(), testPlayer.passiveEarthDPS);
                Assert.Equal(new ExpNumber(), testPlayer.passiveFireDPS);
                Assert.Equal(new ExpNumber(), testPlayer.passiveWaterDPS);
               
                Gem s = new Emerald(i, testPlayer);
                s.MakeAllActive();

                Assert.Equal(testPlayer.passiveNatureDPS, (ExpNumber)nda.GetEffectQuantity());
                Assert.Equal(testPlayer.gemDropChance, (float)gdc.GetEffectQuantity());
                Assert.Equal(testPlayer.enemyHealthPercentageReduction, (float)elr.GetEffectQuantity());
            }
        }

        [Fact]
        public void TestGivePlayerEmeralds(){
            Player testPlayer = new Player();
            for (int i = 1; i < 10; i++){
                int tier = i;
                Assert.Equal(0, testPlayer.GetGemCount(tier, GemType.Emerald));
            }
            Random random = new Random();
            int randTier = random.Next(0, 100);
            int quantity = random.Next(0, 100);
            testPlayer.AddGems(randTier, quantity, GemType.Emerald);
            Assert.Equal(quantity, testPlayer.GetGemCount(randTier, GemType.Emerald));
            
        }

        #endregion
    }
}
