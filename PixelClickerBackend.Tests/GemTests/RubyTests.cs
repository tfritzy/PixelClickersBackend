using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;
using System.Collections.Generic;

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
            ruby.MakeAllActive();
            Dictionary<Type, Attribute> attrs = ruby.GetAttributes();
            foreach (Attribute attr in attrs.Values)
            {
                Assert.True(attr.IsActive(player));
            }
            ruby.MakeAllInactive();
            foreach (Attribute attr in attrs.Values)
            {
                Assert.False(attr.IsActive(player));
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
            return gem.Contains(desiredAttribute);
        }

        [Fact]
        public void TestRubyAttributesAtLevels()
        {

            for (int i = 1; i < 10000; i += i)
            {
                Player testPlayer = new Player();
                FireDamageAttribute wda = new FireDamageAttribute(i);
                GoldFindPercentageAttribute pxp =
                    new GoldFindPercentageAttribute(i);
                ExtraTeamDamageAttribute cdr = new ExtraTeamDamageAttribute(i);

                Assert.Equal(new ExpNumber(), testPlayer.Stats.passiveNatureDPS);
                Assert.Equal(new ExpNumber(), testPlayer.Stats.passiveEarthDPS);
                Assert.Equal(new ExpNumber(), testPlayer.Stats.passiveFireDPS);
                Assert.Equal(new ExpNumber(), testPlayer.Stats.passiveWaterDPS);


                Gem s = new Ruby(i, testPlayer);
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

                Assert.Equal((ExpNumber)wda.GetEffectQuantity(), testPlayer.Stats.passiveFireDPS);
                Assert.Equal((BigInteger)pxp.GetEffectQuantity(),
                    testPlayer.Stats.extraGoldFindPercentage);
                Assert.Equal((BigInteger)cdr.GetEffectQuantity(), (testPlayer.Stats.teamDamageBonusPercent));


            }


        }


    }
}