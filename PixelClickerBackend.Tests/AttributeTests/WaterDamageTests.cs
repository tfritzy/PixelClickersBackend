using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;


namespace PixelClickerBackend
{

    public class passiveWaterDPSTests
    {

        [Fact]
        public void TestLevel1()
        {
            Player testPlayer = new Player();
            WaterDamageAttribute attr =
                new WaterDamageAttribute(1, testPlayer);
            Assert.Equal(1, attr.tier);
            Assert.Equal(applyFormula(1), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(1), testPlayer.passiveWaterDPS);
        }

        [Fact]
        public void TestLevel2()
        {
            Player testPlayer = new Player();
            WaterDamageAttribute attr =
                new WaterDamageAttribute(2, testPlayer);
            Assert.Equal(2, attr.tier);
            Assert.Equal(applyFormula(2), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(2), testPlayer.passiveWaterDPS);
        }

        [Fact]
        public void TestLevel3()
        {
            Player testPlayer = new Player();
            WaterDamageAttribute attr =
                new WaterDamageAttribute(3, testPlayer);
            Assert.Equal(3, attr.tier);
            Assert.Equal(applyFormula(3), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(3), testPlayer.passiveWaterDPS);
        }

        [Fact]
        public void TestLevel4()
        {
            Player testPlayer = new Player();
            WaterDamageAttribute attr =
                new WaterDamageAttribute(4, testPlayer);
            Assert.Equal(4, attr.tier);
            Assert.Equal(applyFormula(4), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(4), testPlayer.passiveWaterDPS);
        }

        [Fact]
        public void TestLevel5()
        {
            Player testPlayer = new Player();
            WaterDamageAttribute attr =
                new WaterDamageAttribute(5, testPlayer);
            Assert.Equal(5, attr.tier);
            Assert.Equal(applyFormula(5), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(5), testPlayer.passiveWaterDPS);
        }

        [Fact]
        public void TestLevel10()
        {
            Player testPlayer = new Player();
            WaterDamageAttribute attr =
                new WaterDamageAttribute(10, testPlayer);
            Assert.Equal(10, attr.tier);
            Assert.Equal(applyFormula(10), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(10), testPlayer.passiveWaterDPS);
        }

        [Fact]
        public void TestLevel100()
        {
            Player testPlayer = new Player();
            WaterDamageAttribute attr =
                new WaterDamageAttribute(100, testPlayer);
            Assert.Equal(100, attr.tier);
            Assert.Equal(applyFormula(100), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(100), testPlayer.passiveWaterDPS);
        }

        [Fact]
        public void TestActive()
        {
            Player testPlayer = new Player();
            WaterDamageAttribute attr =
            new WaterDamageAttribute(3, testPlayer);
            Assert.Equal(3, attr.tier);
            attr.ApplyEffect();
            Assert.True(attr.isActive);
            attr.RemoveEffect();
            Assert.False(attr.isActive);
            Assert.Equal(applyFormula(3), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(3), testPlayer.passiveWaterDPS);
        }

        [Fact]
        public void TestFlickerActive()
        {
            Player testPlayer = new Player();
            WaterDamageAttribute attr =
            new WaterDamageAttribute(10, testPlayer);
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
            Assert.Equal(applyFormula(10), testPlayer.passiveWaterDPS);
            attr.RemoveEffect();
            Assert.Equal(new BigInteger(0), testPlayer.passiveWaterDPS);
        }

        private BigInteger applyFormula(int tier){
            return BigInteger.Multiply(new BigInteger(5), BigInteger.Pow(2, tier-1));
        }





    }

}