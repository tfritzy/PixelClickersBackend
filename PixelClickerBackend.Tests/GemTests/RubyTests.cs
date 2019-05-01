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
            Gem ruby = new Ruby(5);
            Assert.Equal(GemType.Ruby, ruby.type);
            Assert.Equal(5, ruby.tier);
            Assert.Equal(Elements.Fire, ruby.element);

        }

        [Fact]
        public void TestTierRubyPower()
        {
            for (int i = 1; i < 10000; i += 1)
            {
                Gem ruby = new Ruby(i);
                Player testPlayer = new Player();

                BigInteger expectedFireDPSIncrease = BigInteger.Multiply(5, BigInteger.Pow(2, i - 1));
                BigInteger expectedGoldFindIncrease = BigInteger.Pow(2, i);
                BigInteger expectedExtraTeamDamge = BigInteger.Pow(2, i - 1);

                BigInteger prevPlayerFireDamage = testPlayer.passiveFireDPS;
                BigInteger prevPlayerGoldFind = testPlayer.extraGoldFindPercentage;
                BigInteger extraTeamDamge = testPlayer.teamDamageBonusPercent;

                ruby.Apply(testPlayer);

                Assert.Equal(BigInteger.Add(prevPlayerFireDamage, expectedFireDPSIncrease), testPlayer.passiveFireDPS);
                Assert.Equal(prevPlayerGoldFind + expectedGoldFindIncrease, testPlayer.extraGoldFindPercentage);
                Assert.Equal(extraTeamDamge + expectedExtraTeamDamge, testPlayer.teamDamageBonusPercent);
            }
        }

        [Fact]
        public void TestTier0Ruby(){
            Assert.Throws<ArgumentException>(() => new Ruby(0));
        }


        [Fact]
        public void TestMultiApplyRuby(){
            Random random = new Random();

            for (int i = 0; i < 10; i++){
                int tier = random.Next(1, 1000000);
                Gem ruby = new Ruby(tier);
                Player testPlayer = new Player();

                BigInteger expectedFireDPSIncrease = BigInteger.Multiply(5, BigInteger.Pow(2, tier - 1));
                BigInteger expectedGoldFindIncrease = BigInteger.Pow(2, tier);
                BigInteger expectedExtraTeamDamge = BigInteger.Pow(2, tier - 1);

                BigInteger prevPlayerFireDamage = testPlayer.passiveFireDPS;
                BigInteger prevPlayerGoldFind = testPlayer.extraGoldFindPercentage;
                BigInteger extraTeamDamge = testPlayer.teamDamageBonusPercent;

                for (int j = 0; j < random.Next(0, 10); j++){
                    ruby.Apply(testPlayer);
                }

                Assert.Equal(BigInteger.Add(prevPlayerFireDamage, expectedFireDPSIncrease), testPlayer.passiveFireDPS);
                Assert.Equal(prevPlayerGoldFind + expectedGoldFindIncrease, testPlayer.extraGoldFindPercentage);
                Assert.Equal(extraTeamDamge + expectedExtraTeamDamge, testPlayer.teamDamageBonusPercent);
            }
            
        }




    }
}