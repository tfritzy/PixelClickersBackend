using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;


namespace PixelClickerBackend
{

    public class PercentExtraXPPerKillTests
    {
        #region LevelUpTests
        [Fact]
        public void TestLevelUpNotEquipt(){
            int startTier = 4;
            Player testPlayer = new Player();
            Attribute attr = new PercentExtraXPPerKillAttribute(startTier, testPlayer);
            
            attr.LevelUp();
            Assert.Equal(startTier + 1, attr.tier);
            Attribute testAttr = new PercentExtraXPPerKillAttribute(startTier+1, testPlayer);
            Assert.Equal(new BigInteger(0),
                        testPlayer.percentExtraXPPerKill);
            attr.ApplyEffect();
            Assert.Equal(testAttr.GetEffectQuantity(),
                        testPlayer.percentExtraXPPerKill);
        }

        [Fact]
        public void TestLevelUpEquipt(){
            int startTier = 4;
            Player testPlayer = new Player();
            Attribute attr = new PercentExtraXPPerKillAttribute(startTier, testPlayer);
            attr.ApplyEffect();
            attr.LevelUp();
            Assert.Equal(startTier + 1, attr.tier);
            Attribute testAttr = new PercentExtraXPPerKillAttribute(startTier+1, testPlayer);
            Assert.Equal(testAttr.GetEffectQuantity(),
                        testPlayer.percentExtraXPPerKill);
            attr.RemoveEffect();
            Assert.Equal(new BigInteger(0),
                        testPlayer.percentExtraXPPerKill);
        }

        [Fact]
        public void TestLevelUpAcrossManyLevels(){
            for (int i = 1; i < 1000; i+=i){
                Player testPlayer = new Player();
                Attribute attr = new PercentExtraXPPerKillAttribute(i, testPlayer);
                Assert.Equal(new BigInteger(0),
                        testPlayer.percentExtraXPPerKill);
                attr.ApplyEffect();
                attr.LevelUp();
                Assert.Equal(i + 1, attr.tier);
                Attribute testAttr = new PercentExtraXPPerKillAttribute(i+1, testPlayer);
                Assert.Equal(testAttr.GetEffectQuantity(),
                        testPlayer.percentExtraXPPerKill);
            
            }
        }
        #endregion

        [Fact]
        public void TestLevel1()
        {
            Player testPlayer = new Player();
            PercentExtraXPPerKillAttribute attr =
                new PercentExtraXPPerKillAttribute(1, testPlayer);
            Assert.Equal(1, attr.tier);
            Assert.Equal(applyFormula(1), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(1), testPlayer.percentExtraXPPerKill);
        }

        [Fact]
        public void TestLevel2()
        {
            Player testPlayer = new Player();
            PercentExtraXPPerKillAttribute attr =
                new PercentExtraXPPerKillAttribute(2, testPlayer);
            Assert.Equal(2, attr.tier);
            Assert.Equal(applyFormula(2), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(2), testPlayer.percentExtraXPPerKill);
        }

        [Fact]
        public void TestLevel3()
        {
            Player testPlayer = new Player();
            PercentExtraXPPerKillAttribute attr =
                new PercentExtraXPPerKillAttribute(3, testPlayer);
            Assert.Equal(3, attr.tier);
            Assert.Equal(applyFormula(3), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(3), testPlayer.percentExtraXPPerKill);
        }

        [Fact]
        public void TestLevel4()
        {
            Player testPlayer = new Player();
            PercentExtraXPPerKillAttribute attr =
                new PercentExtraXPPerKillAttribute(4, testPlayer);
            Assert.Equal(4, attr.tier);
            Assert.Equal(applyFormula(4), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(4), testPlayer.percentExtraXPPerKill);
        }

        [Fact]
        public void TestLevel5()
        {
            Player testPlayer = new Player();
            PercentExtraXPPerKillAttribute attr =
                new PercentExtraXPPerKillAttribute(5, testPlayer);
            Assert.Equal(5, attr.tier);
            Assert.Equal(applyFormula(5), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(5), testPlayer.percentExtraXPPerKill);
        }

        [Fact]
        public void TestLevel10()
        {
            Player testPlayer = new Player();
            PercentExtraXPPerKillAttribute attr =
                new PercentExtraXPPerKillAttribute(10, testPlayer);
            Assert.Equal(10, attr.tier);
            Assert.Equal(applyFormula(10), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(10), testPlayer.percentExtraXPPerKill);
        }

        [Fact]
        public void TestLevel100()
        {
            Player testPlayer = new Player();
            PercentExtraXPPerKillAttribute attr =
                new PercentExtraXPPerKillAttribute(100, testPlayer);
            Assert.Equal(100, attr.tier);
            Assert.Equal(applyFormula(100), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(100), testPlayer.percentExtraXPPerKill);
        }

        [Fact]
        public void TestActive()
        {
            Player testPlayer = new Player();
            PercentExtraXPPerKillAttribute attr =
            new PercentExtraXPPerKillAttribute(3, testPlayer);
            Assert.Equal(3, attr.tier);
            attr.ApplyEffect();
            Assert.True(attr.isActive);
            attr.RemoveEffect();
            Assert.False(attr.isActive);
            Assert.Equal(applyFormula(3), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(3), testPlayer.percentExtraXPPerKill);
        }

        [Fact]
        public void TestFlickerActive()
        {
            Player testPlayer = new Player();
            PercentExtraXPPerKillAttribute attr =
            new PercentExtraXPPerKillAttribute(10, testPlayer);
            Random r = new Random();
            for (int j = 0; j < 1000; j++)
            {
                if (r.Next(0, 2) == 1)
                {
                    attr.ApplyEffect();
                }
                else
                    attr.RemoveEffect();
            }
            attr.ApplyEffect();
            Assert.Equal(applyFormula(10), testPlayer.percentExtraXPPerKill);
            attr.RemoveEffect();
            Assert.Equal(new BigInteger(0), testPlayer.percentExtraXPPerKill);
        }

        private BigInteger applyFormula(int tier){
            return BigInteger.Multiply(new BigInteger(tier),  new BigInteger(5));
        }

    }

}