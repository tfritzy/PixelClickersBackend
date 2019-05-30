using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;


namespace PixelClickerBackend
{

    public class damageIncreasePercentageTests
    {

        #region LevelUpTests
        [Fact]
        public void TestLevelUpNotEquipt(){
            int startTier = 4;
            Player testPlayer = new Player();
            Attribute attr = new DamageIncreasePercentageAttribute(startTier);
            
            attr.LevelUp();
            Assert.Equal(startTier + 1, attr.tier);
            Attribute testAttr = new DamageIncreasePercentageAttribute(startTier+1);
            Assert.Equal(new BigInteger(0),
                        testPlayer.damageIncreasePercentage);
            attr.ApplyEffect(testPlayer);
            Assert.Equal(testAttr.GetEffectQuantity(),
                        testPlayer.damageIncreasePercentage);
        }

        [Fact]
        public void TestLevelUpEquipt(){
            int startTier = 4;
            Player testPlayer = new Player();
            Attribute attr = new DamageIncreasePercentageAttribute(startTier);
            attr.ApplyEffect(testPlayer);
            attr.LevelUp();
            Assert.Equal(startTier + 1, attr.tier);
            Attribute testAttr = new DamageIncreasePercentageAttribute(startTier+1);
            Assert.Equal(testAttr.GetEffectQuantity(),
                        testPlayer.damageIncreasePercentage);
            attr.RemoveEffect(testPlayer);
            Assert.Equal(new BigInteger(0),
                        testPlayer.damageIncreasePercentage);
        }

        [Fact]
        public void TestLevelUpAcrossManyLevels(){
            for (int i = 1; i < 1000; i+=i){
                Player testPlayer = new Player();
                Attribute attr = new DamageIncreasePercentageAttribute(i);
                Assert.Equal(new BigInteger(0),
                        testPlayer.damageIncreasePercentage);
                attr.ApplyEffect(testPlayer);
                attr.LevelUp();
                Assert.Equal(i + 1, attr.tier);
                Attribute testAttr = new DamageIncreasePercentageAttribute(i+1);
                Assert.Equal(testAttr.GetEffectQuantity(),
                        testPlayer.damageIncreasePercentage);
            
            }
        }
        #endregion

        [Fact]
        public void TestLevel1()
        {
            Player testPlayer = new Player();
            DamageIncreasePercentageAttribute attr =
                new DamageIncreasePercentageAttribute(1);
            Assert.Equal(1, attr.tier);
            Assert.Equal(applyFormula(1), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(1), testPlayer.damageIncreasePercentage);
        }

        [Fact]
        public void TestLevel2()
        {
            Player testPlayer = new Player();
            DamageIncreasePercentageAttribute attr =
                new DamageIncreasePercentageAttribute(2);
            Assert.Equal(2, attr.tier);
            Assert.Equal(applyFormula(2), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(2), testPlayer.damageIncreasePercentage);
        }

        [Fact]
        public void TestLevel3()
        {
            Player testPlayer = new Player();
            DamageIncreasePercentageAttribute attr =
                new DamageIncreasePercentageAttribute(3);
            Assert.Equal(3, attr.tier);
            Assert.Equal(applyFormula(3), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(3), testPlayer.damageIncreasePercentage);
        }

        [Fact]
        public void TestLevel4()
        {
            Player testPlayer = new Player();
            DamageIncreasePercentageAttribute attr =
                new DamageIncreasePercentageAttribute(4);
            Assert.Equal(4, attr.tier);
            Assert.Equal(applyFormula(4), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(4), testPlayer.damageIncreasePercentage);
        }

        [Fact]
        public void TestLevel5()
        {
            Player testPlayer = new Player();
            DamageIncreasePercentageAttribute attr =
                new DamageIncreasePercentageAttribute(5);
            Assert.Equal(5, attr.tier);
            Assert.Equal(applyFormula(5), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(5), testPlayer.damageIncreasePercentage);
        }

        [Fact]
        public void TestLevel10()
        {
            Player testPlayer = new Player();
            DamageIncreasePercentageAttribute attr =
                new DamageIncreasePercentageAttribute(10);
            Assert.Equal(10, attr.tier);
            Assert.Equal(applyFormula(10), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(10), testPlayer.damageIncreasePercentage);
        }

        [Fact]
        public void TestLevel100()
        {
            Player testPlayer = new Player();
            DamageIncreasePercentageAttribute attr =
                new DamageIncreasePercentageAttribute(100);
            Assert.Equal(100, attr.tier);
            Assert.Equal(applyFormula(100), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(100), testPlayer.damageIncreasePercentage);
        }

        [Fact]
        public void TestActive()
        {
            Player testPlayer = new Player();
            DamageIncreasePercentageAttribute attr =
            new DamageIncreasePercentageAttribute(3);
            Assert.Equal(3, attr.tier);
            attr.ApplyEffect(testPlayer);
            Assert.True(attr.IsActive(testPlayer));
            attr.RemoveEffect(testPlayer);
            Assert.False(attr.IsActive(testPlayer));
            Assert.Equal(applyFormula(3), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(3), testPlayer.damageIncreasePercentage);
        }

        [Fact]
        public void TestFlickerActive()
        {
            Player testPlayer = new Player();
            DamageIncreasePercentageAttribute attr =
            new DamageIncreasePercentageAttribute(10);
            Random r = new Random();
            for (int j = 0; j < 1000; j++)
            {
                if (r.Next(0, 2) == 1)
                {
                    attr.ApplyEffect(testPlayer);
                }
                else
                    attr.RemoveEffect(testPlayer);
            }
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(10), testPlayer.damageIncreasePercentage);
            attr.RemoveEffect(testPlayer);
            Assert.Equal(new BigInteger(0), testPlayer.damageIncreasePercentage);
        }

        [Fact]
        public void TestLevelMaxInt()
        {
            Player testPlayer = new Player();
            DamageIncreasePercentageAttribute attr =
                new DamageIncreasePercentageAttribute(int.MaxValue);
            Assert.Equal(int.MaxValue, attr.tier);
            Assert.Equal(BigInteger.Parse("64424509410"), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(BigInteger.Parse("64424509410"), testPlayer.damageIncreasePercentage);
        }

        private BigInteger applyFormula(int tier){
            return BigInteger.Multiply(tier, 30);
        }





    }

}