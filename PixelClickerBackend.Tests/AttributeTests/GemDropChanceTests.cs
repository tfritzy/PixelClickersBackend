using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;


namespace PixelClickerBackend
{

    public class GemDropChanceAttributeTests
    {

                #region LevelUpTests
        [Fact]
        public void TestLevelUpNotEquipt(){
            int startTier = 4;
            Player testPlayer = new Player();
            Attribute attr = new GemDropChanceAttribute(startTier);
            
            attr.LevelUp();
            Assert.Equal(startTier + 1, attr.tier);
            Attribute testAttr = new GemDropChanceAttribute(startTier+1);
            Assert.Equal(0f,
                        testPlayer.Stats.gemDropChance);
            attr.ApplyEffect(testPlayer);
            Assert.Equal(testAttr.GetEffectQuantity(),
                        testPlayer.Stats.gemDropChance);
        }

        [Fact]
        public void TestLevelUpEquipt(){
            int startTier = 4;
            Player testPlayer = new Player();
            Attribute attr = new GemDropChanceAttribute(startTier);
            attr.ApplyEffect(testPlayer);
            attr.LevelUp();
            Assert.Equal(startTier + 1, attr.tier);
            Attribute testAttr = new GemDropChanceAttribute(startTier+1);
            Assert.Equal(testAttr.GetEffectQuantity(),
                        testPlayer.Stats.gemDropChance);
            attr.RemoveEffect(testPlayer);
            Assert.Equal(0f,
                        testPlayer.Stats.gemDropChance);
        }

        [Fact]
        public void TestLevelUpAcrossManyLevels(){
            for (int i = 1; i < 1000; i+=i){
                Player testPlayer = new Player();
                Attribute attr = new GemDropChanceAttribute(i);
                Assert.Equal(0f,
                        testPlayer.Stats.gemDropChance);
                attr.ApplyEffect(testPlayer);
                attr.LevelUp();
                Assert.Equal(i + 1, attr.tier);
                Attribute testAttr = new GemDropChanceAttribute(i+1);
                Assert.Equal(testAttr.GetEffectQuantity(),
                        testPlayer.Stats.gemDropChance);
            
            }
        }
        #endregion


        [Fact]
        public void TestLevel1()
        {
            Player testPlayer = new Player();
            GemDropChanceAttribute attr =
                new GemDropChanceAttribute(1);
            Assert.Equal(1, attr.tier);
            Assert.Equal(applyFormula(1), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(1), testPlayer.Stats.gemDropChance);
        }

        [Fact]
        public void TestLevel2()
        {
            Player testPlayer = new Player();
            GemDropChanceAttribute attr =
                new GemDropChanceAttribute(2);
            Assert.Equal(2, attr.tier);
            Assert.Equal(applyFormula(2), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(2), testPlayer.Stats.gemDropChance);
        }

        [Fact]
        public void TestLevel3()
        {
            Player testPlayer = new Player();
            GemDropChanceAttribute attr =
                new GemDropChanceAttribute(3);
            Assert.Equal(3, attr.tier);
            Assert.Equal(applyFormula(3), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(3), testPlayer.Stats.gemDropChance);
        }

        [Fact]
        public void TestLevel4()
        {
            Player testPlayer = new Player();
            GemDropChanceAttribute attr =
                new GemDropChanceAttribute(4);
            Assert.Equal(4, attr.tier);
            Assert.Equal(applyFormula(4), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(4), testPlayer.Stats.gemDropChance);
        }

        [Fact]
        public void TestLevel5()
        {
            Player testPlayer = new Player();
            GemDropChanceAttribute attr =
                new GemDropChanceAttribute(5);
            Assert.Equal(5, attr.tier);
            Assert.Equal(applyFormula(5), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(5), testPlayer.Stats.gemDropChance);
        }

        [Fact]
        public void TestLevel10()
        {
            Player testPlayer = new Player();
            GemDropChanceAttribute attr =
                new GemDropChanceAttribute(10);
            Assert.Equal(10, attr.tier);
            Assert.Equal(applyFormula(10), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(10), testPlayer.Stats.gemDropChance);
        }

        [Fact]
        public void TestLevel100()
        {
            Player testPlayer = new Player();
            GemDropChanceAttribute attr =
                new GemDropChanceAttribute(100);
            Assert.Equal(100, attr.tier);
            Assert.Equal(applyFormula(100), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(100), testPlayer.Stats.gemDropChance);
        }

        [Fact]
        public void TestActive()
        {
            Player testPlayer = new Player();
            GemDropChanceAttribute attr =
            new GemDropChanceAttribute(3);
            Assert.Equal(3, attr.tier);
            attr.ApplyEffect(testPlayer);
            Assert.True(attr.IsActive(testPlayer));
            attr.RemoveEffect(testPlayer);
            Assert.False(attr.IsActive(testPlayer));
            Assert.Equal(applyFormula(3), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(3), testPlayer.Stats.gemDropChance);
        }

        [Fact]
        public void TestFlickerActive()
        {
            Player testPlayer = new Player();
            GemDropChanceAttribute attr =
            new GemDropChanceAttribute(10);
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
            Assert.Equal(applyFormula(10), testPlayer.Stats.gemDropChance);
            attr.RemoveEffect(testPlayer);
            Assert.Equal(0f, testPlayer.Stats.gemDropChance);
        }

        private float applyFormula(int tier){
            return 2f * tier;
        }





    }

}