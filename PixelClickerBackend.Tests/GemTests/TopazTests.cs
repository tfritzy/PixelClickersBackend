using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;

namespace PixelClickerBackend.Tests
{
    public class TopazTests
    {
        [Fact]
        public void TestTopazBasics()
        {
            Gem Topaz = new Topaz(5, new Player());
            Assert.Equal(GemType.Topaz, Topaz.type);
            Assert.Equal(5, Topaz.tier);
            Assert.Equal(Elements.Earth, Topaz.element);

        }

        [Fact]
        public void TestTopazAttributes()
        {
            Gem topaz = new Topaz(3, new Player());
            Assert.Equal(3, topaz.GetAttributeCount());
            Assert.True(DoesGemContainAttribute(topaz, typeof(EarthDamageAttribute)));
            Assert.True(DoesGemContainAttribute(topaz, typeof(CritHitChanceAttribute)));
            Assert.True(DoesGemContainAttribute(topaz, typeof(DamageIncreasePercentageAttribute)));
        }

        private bool DoesGemContainAttribute(Gem gem, Type desiredAttribute)
        { 
            return gem.Contains(desiredAttribute);
        }

        [Fact]
        public void TestTopazAttributesAtLevels()
        {

            for (int i = 1; i < 10000; i += i)
            {
                Player testPlayer = new Player();
                EarthDamageAttribute earthDamage = new EarthDamageAttribute(i);
                CritHitChanceAttribute critHitChance =
                    new CritHitChanceAttribute(i);
                DamageIncreasePercentageAttribute damageIncrease =
                    new DamageIncreasePercentageAttribute(i);

                Assert.Equal(new ExpNumber(), testPlayer.passiveNatureDPS);
                Assert.Equal(new ExpNumber(), testPlayer.passiveEarthDPS);
                Assert.Equal(new ExpNumber(), testPlayer.passiveFireDPS);
                Assert.Equal(new ExpNumber(), testPlayer.passiveWaterDPS);

                Gem topaz = new Topaz(i, testPlayer);

                Random r = new Random();
                for (int j = 0; j < 1000; j++)
                {
                    if (r.Next(0, 2) == 1)
                    {
                        topaz.MakeAllActive();
                    }
                    else
                        topaz.MakeAllInactive();
                }
                topaz.MakeAllActive();

                Assert.Equal(testPlayer.passiveEarthDPS,
                    (ExpNumber)earthDamage.GetEffectQuantity());
                Assert.Equal(testPlayer.critHitChance,
                    (float)critHitChance.GetEffectQuantity());
                Assert.Equal(testPlayer.damageIncreasePercentage,
                    (BigInteger)damageIncrease.GetEffectQuantity());
            }
        }





    }
}