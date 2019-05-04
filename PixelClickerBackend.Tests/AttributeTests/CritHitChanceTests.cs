using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;


namespace PixelClickerBackend
{

    public class CritHitChanceTests
    {

        [Fact]
        public void TestLevel1()
        {
            Player testPlayer = new Player();
            CritHitChanceAttribute attr =
                new CritHitChanceAttribute(1, testPlayer);
            Assert.Equal(1, attr.tier);
            Assert.Equal(1f, attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(1f, testPlayer.critHitChance);
        }

        [Fact]
        public void TestLevel2()
        {
            Player testPlayer = new Player();
            CritHitChanceAttribute attr =
                new CritHitChanceAttribute(2, testPlayer);
            Assert.Equal(2, attr.tier);
            Assert.Equal(2f, attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(2f, testPlayer.critHitChance);
        }

        [Fact]
        public void TestLevel3()
        {
            Player testPlayer = new Player();
            CritHitChanceAttribute attr =
                new CritHitChanceAttribute(3, testPlayer);
            Assert.Equal(3, attr.tier);
            Assert.Equal(3f, attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(3f, testPlayer.critHitChance);
        }

        [Fact]
        public void TestLevel4()
        {
            Player testPlayer = new Player();
            CritHitChanceAttribute attr =
                new CritHitChanceAttribute(4, testPlayer);
            Assert.Equal(4, attr.tier);
            Assert.Equal(4f, attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(4f, testPlayer.critHitChance);
        }

        [Fact]
        public void TestLevel5()
        {
            Player testPlayer = new Player();
            CritHitChanceAttribute attr =
                new CritHitChanceAttribute(5, testPlayer);
            Assert.Equal(5, attr.tier);
            Assert.Equal(5f, attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(5f, testPlayer.critHitChance);
        }

        [Fact]
        public void TestLevel10()
        {
            Player testPlayer = new Player();
            CritHitChanceAttribute attr =
                new CritHitChanceAttribute(10, testPlayer);
            Assert.Equal(10, attr.tier);
            Assert.Equal(10f, attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(10f, testPlayer.critHitChance);
        }

        [Fact]
        public void TestLevel100()
        {
            Player testPlayer = new Player();
            CritHitChanceAttribute attr =
                new CritHitChanceAttribute(100, testPlayer);
            Assert.Equal(100, attr.tier);
            Assert.Equal(100f, attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(100f, testPlayer.critHitChance);
        }

        [Fact]
        public void TestActive()
        {
            Player testPlayer = new Player();
            CritHitChanceAttribute attr =
            new CritHitChanceAttribute(3, testPlayer);
            Assert.Equal(3, attr.tier);
            attr.ApplyEffect();
            Assert.True(attr.isActive);
            attr.RemoveEffect();
            Assert.False(attr.isActive);
            Assert.Equal(3f, attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(3f, testPlayer.critHitChance);
        }

        [Fact]
        public void TestFlickerActive()
        {
            Player testPlayer = new Player();
            CritHitChanceAttribute attr =
            new CritHitChanceAttribute(10, testPlayer);
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
            Assert.Equal(10f, testPlayer.critHitChance);
            attr.RemoveEffect();
            Assert.Equal(0f, testPlayer.critHitChance);
        }





    }

}