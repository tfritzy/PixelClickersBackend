using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;

namespace PixelClickerBackend.Tests
{
    public class RubyTests
    {
        [Fact]
        public void TestRubyBasics()
        {
            Gem ruby = new Ruby(5, new Player());
            Assert.Equal(GemType.Ruby, ruby.type);
            Assert.Equal(5, ruby.tier);
            Assert.Equal(Elements.Fire, ruby.element);

        }

        [Fact]
        public void TestGemAttributes()
        {
            Player player = new Player();
            Gem ruby = new Ruby(5, player);
            ruby.Apply();
            Attribute[] attrs = ruby.GetAttributes();
            foreach (Attribute attr in attrs)
            {
                Assert.True(attr.isActive);
            }
            ruby.Remove();
            foreach (Attribute attr in attrs)
            {
                Assert.False(attr.isActive);
            }
        }

        [Fact]
        public void TestRubyAttributes()
        {
            Gem ruby = new Ruby(3, new Player());
            Assert.Equal(3, ruby.GetAttributeCount());
            Assert.True(DoesListContainAttribute(ruby, typeof(FireDamageAttribute)));
            Assert.True(DoesListContainAttribute(ruby, typeof(GoldFindPercentageAttribute)));
            Assert.True(DoesListContainAttribute(ruby, typeof(ExtraTeamDamageAttribute)));
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
        public void TestRubyAttributesAtLevels()
        {

            for (int i = 1; i < 10000; i += i)
            {
                Player testPlayer = new Player();
                FireDamageAttribute wda = new FireDamageAttribute(i, testPlayer);
                GoldFindPercentageAttribute pxp =
                    new GoldFindPercentageAttribute(i, testPlayer);
                ExtraTeamDamageAttribute cdr = new ExtraTeamDamageAttribute(i, testPlayer);

                Assert.Equal(0, testPlayer.passiveNatureDPS);
                Assert.Equal(0, testPlayer.passiveEarthDPS);
                Assert.Equal(0, testPlayer.passiveFireDPS);
                Assert.Equal(0, testPlayer.passiveWaterDPS);


                Gem s = new Ruby(i, testPlayer);
                Random r = new Random();
                for (int j = 0; j < 1000; j++)
                {
                    if (r.Next(0, 2) == 1)
                    {
                        s.Apply();
                    }
                    else
                        s.Remove();
                }
                s.Apply();

                Assert.Equal((BigInteger)wda.GetEffectQuantity(), testPlayer.passiveFireDPS);
                Assert.Equal((BigInteger)pxp.GetEffectQuantity(),
                    testPlayer.extraGoldFindPercentage);
                Assert.Equal((BigInteger)cdr.GetEffectQuantity(), (testPlayer.teamDamageBonusPercent));


            }


        }


    }
}