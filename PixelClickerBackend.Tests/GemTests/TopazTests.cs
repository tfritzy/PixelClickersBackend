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
            Assert.True(DoesListContainAttribute(topaz, typeof(EarthDamageAttribute)));
            Assert.True(DoesListContainAttribute(topaz, typeof(CritHitChanceAttribute)));
            Assert.True(DoesListContainAttribute(topaz, typeof(DamageIncreasePercentageAttribute)));
        }

        private bool DoesListContainAttribute(Gem gem, Type desiredAttribute)
        {
            Attribute[] attrs = gem.GetAttributes();
            for (int i = 0; i < gem.GetAttributeCount(); i++)
            {
                Attribute attr = gem.GetAttributes()[i];
                if (attr.GetType() == desiredAttribute)
                    return true;
            }
            return false;
        }

        [Fact]
        public void TestTopazAttributesAtLevels()
        {

            for (int i = 1; i < 10000; i += i)
            {
                Player testPlayer = new Player();
                EarthDamageAttribute earthDamage = new EarthDamageAttribute(i, testPlayer);
                CritHitChanceAttribute critHitChance =
                    new CritHitChanceAttribute(i, testPlayer);
                DamageIncreasePercentageAttribute damageIncrease = 
                    new DamageIncreasePercentageAttribute(i, testPlayer);

                Assert.Equal(0, testPlayer.passiveNatureDPS);
                Assert.Equal(0, testPlayer.passiveEarthDPS);
                Assert.Equal(0, testPlayer.passiveFireDPS);
                Assert.Equal(0, testPlayer.passiveWaterDPS);

                Gem topaz = new Topaz(i, testPlayer);

                Random r = new Random();
                for (int j = 0; j < 1000;j++)
                {
                    if (r.Next(0, 2) == 1)
                    {
                        topaz.Apply();
                    }
                    else
                        topaz.Remove();
                }
                topaz.Apply();

                Assert.Equal(testPlayer.passiveEarthDPS, 
                    (BigInteger)earthDamage.GetEffectQuantity());
                Assert.Equal(testPlayer.critHitChance, 
                    (float)critHitChance.GetEffectQuantity());
                Assert.Equal(testPlayer.damageIncreasePercentage,
                    (float)damageIncrease.GetEffectQuantity());
            }
        }





    }
}