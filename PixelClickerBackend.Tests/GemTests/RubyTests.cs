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
        public void TestTierRubyPower()
        {
            for (int i = 1; i < 1000; i += 5)
            {
                Player testPlayer = new Player();
                Gem ruby = new Ruby(i, testPlayer);

                BigInteger expectedFireDPSIncrease = BigInteger.Multiply(5, BigInteger.Pow(2, i - 1));
                BigInteger expectedGoldFindIncrease = BigInteger.Pow(2, i);
                BigInteger expectedExtraTeamDamge = BigInteger.Pow(2, i - 1);

                BigInteger prevPlayerFireDamage = testPlayer.passiveFireDPS;
                BigInteger prevPlayerGoldFind = testPlayer.extraGoldFindPercentage;
                BigInteger extraTeamDamge = testPlayer.teamDamageBonusPercent;

                ruby.Apply();

                Assert.Equal(BigInteger.Add(prevPlayerFireDamage, expectedFireDPSIncrease), testPlayer.passiveFireDPS);
                Assert.Equal(prevPlayerGoldFind + expectedGoldFindIncrease, testPlayer.extraGoldFindPercentage);
                Assert.Equal(extraTeamDamge + expectedExtraTeamDamge, testPlayer.teamDamageBonusPercent);
            }
        }

        [Fact]
        public void TestTier0Ruby()
        {
            Assert.Throws<ArgumentException>(() => new Ruby(0, new Player()));
        }


        [Fact]
        public void TestMultiApplyRuby()
        {
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                int tier = random.Next(1, 1000000);

                Player testPlayer = new Player();
                Gem ruby = new Ruby(tier, testPlayer);

                BigInteger expectedFireDPSIncrease = BigInteger.Multiply(5, BigInteger.Pow(2, tier - 1));
                BigInteger expectedGoldFindIncrease = BigInteger.Pow(2, tier);
                BigInteger expectedExtraTeamDamge = BigInteger.Pow(2, tier - 1);

                BigInteger prevPlayerFireDamage = testPlayer.passiveFireDPS;
                BigInteger prevPlayerGoldFind = testPlayer.extraGoldFindPercentage;
                BigInteger extraTeamDamge = testPlayer.teamDamageBonusPercent;

                for (int j = 1; j < random.Next(2, 10); j++)
                {
                    ruby.Apply();
                }

                Assert.Equal(BigInteger.Add(prevPlayerFireDamage, expectedFireDPSIncrease), testPlayer.passiveFireDPS);
                Assert.Equal(prevPlayerGoldFind + expectedGoldFindIncrease, testPlayer.extraGoldFindPercentage);
                Assert.Equal(extraTeamDamge + expectedExtraTeamDamge, testPlayer.teamDamageBonusPercent);
            }

        }


        [Fact]
        public void TestMultiApplyAndRemoveRuby()
        {
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                int tier = random.Next(1, 1000);

                Player testPlayer = new Player();
                Gem ruby = new Ruby(tier, testPlayer);

                BigInteger expectedFireDPSIncrease = BigInteger.Multiply(5, 
                                                        BigInteger.Pow(2, tier - 1));
                BigInteger expectedGoldFindIncrease = BigInteger.Pow(2, tier);
                BigInteger expectedExtraTeamDamge = BigInteger.Pow(2, tier - 1);

                BigInteger prevPlayerFireDamage = testPlayer.passiveFireDPS;
                BigInteger prevPlayerGoldFind = testPlayer.extraGoldFindPercentage;
                BigInteger extraTeamDamge = testPlayer.teamDamageBonusPercent;


                Random r = new Random();
                for (int j = 0; j < 1000; j++)
                {
                    if (r.Next(0, 2) == 1)
                    {
                        ruby.Apply();
                    }
                    else
                        ruby.Remove();
                }
                ruby.Apply();

                Assert.Equal(BigInteger.Add(prevPlayerFireDamage, expectedFireDPSIncrease), testPlayer.passiveFireDPS);
                Assert.Equal(prevPlayerGoldFind + expectedGoldFindIncrease, testPlayer.extraGoldFindPercentage);
                Assert.Equal(extraTeamDamge + expectedExtraTeamDamge, testPlayer.teamDamageBonusPercent);
            }

        }



    }
}