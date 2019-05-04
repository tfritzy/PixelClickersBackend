using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;


namespace PixelClickerBackend
{

    public class GemDropChanceAttributeTests
    {

        [Fact]
        public void TestLevel1()
        {
            Player testPlayer = new Player();
            GemDropChanceAttribute attr =
                new GemDropChanceAttribute(1, testPlayer);
            Assert.Equal(1, attr.tier);
            Assert.Equal(applyFormula(1), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(1), testPlayer.gemDropChance);
        }

        [Fact]
        public void TestLevel2()
        {
            Player testPlayer = new Player();
            GemDropChanceAttribute attr =
                new GemDropChanceAttribute(2, testPlayer);
            Assert.Equal(2, attr.tier);
            Assert.Equal(applyFormula(2), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(2), testPlayer.gemDropChance);
        }

        [Fact]
        public void TestLevel3()
        {
            Player testPlayer = new Player();
            GemDropChanceAttribute attr =
                new GemDropChanceAttribute(3, testPlayer);
            Assert.Equal(3, attr.tier);
            Assert.Equal(applyFormula(3), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(3), testPlayer.gemDropChance);
        }

        [Fact]
        public void TestLevel4()
        {
            Player testPlayer = new Player();
            GemDropChanceAttribute attr =
                new GemDropChanceAttribute(4, testPlayer);
            Assert.Equal(4, attr.tier);
            Assert.Equal(applyFormula(4), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(4), testPlayer.gemDropChance);
        }

        [Fact]
        public void TestLevel5()
        {
            Player testPlayer = new Player();
            GemDropChanceAttribute attr =
                new GemDropChanceAttribute(5, testPlayer);
            Assert.Equal(5, attr.tier);
            Assert.Equal(applyFormula(5), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(5), testPlayer.gemDropChance);
        }

        [Fact]
        public void TestLevel10()
        {
            Player testPlayer = new Player();
            GemDropChanceAttribute attr =
                new GemDropChanceAttribute(10, testPlayer);
            Assert.Equal(10, attr.tier);
            Assert.Equal(applyFormula(10), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(10), testPlayer.gemDropChance);
        }

        [Fact]
        public void TestLevel100()
        {
            Player testPlayer = new Player();
            GemDropChanceAttribute attr =
                new GemDropChanceAttribute(100, testPlayer);
            Assert.Equal(100, attr.tier);
            Assert.Equal(applyFormula(100), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(100), testPlayer.gemDropChance);
        }

        [Fact]
        public void TestActive()
        {
            Player testPlayer = new Player();
            GemDropChanceAttribute attr =
            new GemDropChanceAttribute(3, testPlayer);
            Assert.Equal(3, attr.tier);
            attr.ApplyEffect();
            Assert.True(attr.isActive);
            attr.RemoveEffect();
            Assert.False(attr.isActive);
            Assert.Equal(applyFormula(3), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(3), testPlayer.gemDropChance);
        }

        [Fact]
        public void TestFlickerActive()
        {
            Player testPlayer = new Player();
            GemDropChanceAttribute attr =
            new GemDropChanceAttribute(10, testPlayer);
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
            Assert.Equal(applyFormula(10), testPlayer.gemDropChance);
            attr.RemoveEffect();
            Assert.Equal(0f, testPlayer.gemDropChance);
        }

        private float applyFormula(int tier){
            return 2f * tier;
        }





    }

}