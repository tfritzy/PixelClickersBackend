using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;


namespace PixelClickerBackend
{

    public class enemyHealthPercentageReductionTests
    {

        #region LevelUpTests
        [Fact]
        public void TestLevelUpNotEquipt(){
            int startTier = 4;
            Player testPlayer = new Player();
            Attribute attr = new EnemyLifeReductionAttribute(startTier, testPlayer);
            
            attr.LevelUp();
            Assert.Equal(startTier + 1, attr.tier);
            Attribute testAttr = new EnemyLifeReductionAttribute(startTier+1, testPlayer);
            Assert.Equal(0f,
                        testPlayer.enemyHealthPercentageReduction);
            attr.ApplyEffect();
            Assert.Equal(testAttr.GetEffectQuantity(),
                        testPlayer.enemyHealthPercentageReduction);
        }

        [Fact]
        public void TestLevelUpEquipt(){
            int startTier = 4;
            Player testPlayer = new Player();
            Attribute attr = new EnemyLifeReductionAttribute(startTier, testPlayer);
            attr.ApplyEffect();
            attr.LevelUp();
            Assert.Equal(startTier + 1, attr.tier);
            Attribute testAttr = new EnemyLifeReductionAttribute(startTier+1, testPlayer);
            Assert.Equal(testAttr.GetEffectQuantity(),
                        testPlayer.enemyHealthPercentageReduction);
            attr.RemoveEffect();
            Assert.Equal(0f,
                        testPlayer.enemyHealthPercentageReduction);
        }

        [Fact]
        public void TestLevelUpAcrossManyLevels(){
            for (int i = 1; i < 1000; i+=i){
                Player testPlayer = new Player();
                Attribute attr = new EnemyLifeReductionAttribute(i, testPlayer);
                Assert.Equal(0f,
                        testPlayer.enemyHealthPercentageReduction);
                attr.ApplyEffect();
                attr.LevelUp();
                Assert.Equal(i + 1, attr.tier);
                Attribute testAttr = new EnemyLifeReductionAttribute(i+1, testPlayer);
                Assert.Equal(testAttr.GetEffectQuantity(),
                        testPlayer.enemyHealthPercentageReduction);
            
            }
        }
        #endregion


        [Fact]
        public void TestLevel1()
        {
            Player testPlayer = new Player();
            EnemyLifeReductionAttribute attr =
                new EnemyLifeReductionAttribute(1, testPlayer);
            Assert.Equal(1, attr.tier);
            Assert.Equal(applyFormula(1), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(1), testPlayer.enemyHealthPercentageReduction);
        }

        [Fact]
        public void TestLevel2()
        {
            Player testPlayer = new Player();
            EnemyLifeReductionAttribute attr =
                new EnemyLifeReductionAttribute(2, testPlayer);
            Assert.Equal(2, attr.tier);
            Assert.Equal(applyFormula(2), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(2), testPlayer.enemyHealthPercentageReduction);
        }

        [Fact]
        public void TestLevel3()
        {
            Player testPlayer = new Player();
            EnemyLifeReductionAttribute attr =
                new EnemyLifeReductionAttribute(3, testPlayer);
            Assert.Equal(3, attr.tier);
            Assert.Equal(applyFormula(3), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(3), testPlayer.enemyHealthPercentageReduction);
        }

        [Fact]
        public void TestLevel4()
        {
            Player testPlayer = new Player();
            EnemyLifeReductionAttribute attr =
                new EnemyLifeReductionAttribute(4, testPlayer);
            Assert.Equal(4, attr.tier);
            Assert.Equal(applyFormula(4), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(4), testPlayer.enemyHealthPercentageReduction);
        }

        [Fact]
        public void TestLevel5()
        {
            Player testPlayer = new Player();
            EnemyLifeReductionAttribute attr =
                new EnemyLifeReductionAttribute(5, testPlayer);
            Assert.Equal(5, attr.tier);
            Assert.Equal(applyFormula(5), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(5), testPlayer.enemyHealthPercentageReduction);
        }

        [Fact]
        public void TestLevel10()
        {
            Player testPlayer = new Player();
            EnemyLifeReductionAttribute attr =
                new EnemyLifeReductionAttribute(10, testPlayer);
            Assert.Equal(10, attr.tier);
            Assert.Equal(applyFormula(10), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(10), testPlayer.enemyHealthPercentageReduction);
        }

        [Fact]
        public void TestLevel100()
        {
            Player testPlayer = new Player();
            EnemyLifeReductionAttribute attr =
                new EnemyLifeReductionAttribute(100, testPlayer);
            Assert.Equal(100, attr.tier);
            Assert.Equal(applyFormula(100), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(100), testPlayer.enemyHealthPercentageReduction);
        }

        [Fact]
        public void TestActive()
        {
            Player testPlayer = new Player();
            EnemyLifeReductionAttribute attr =
            new EnemyLifeReductionAttribute(3, testPlayer);
            Assert.Equal(3, attr.tier);
            attr.ApplyEffect();
            Assert.True(attr.isActive);
            attr.RemoveEffect();
            Assert.False(attr.isActive);
            Assert.Equal(applyFormula(3), attr.GetEffectQuantity());
            attr.ApplyEffect();
            Assert.Equal(applyFormula(3), testPlayer.enemyHealthPercentageReduction);
        }

        [Fact]
        public void TestFlickerActive()
        {
            Player testPlayer = new Player();
            EnemyLifeReductionAttribute attr =
            new EnemyLifeReductionAttribute(10, testPlayer);
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
            Assert.Equal(applyFormula(10), testPlayer.enemyHealthPercentageReduction);
            attr.RemoveEffect();
            Assert.Equal(0f, testPlayer.enemyHealthPercentageReduction);
        }

        private float applyFormula(int tier){
            return (float)tier;
        }





    }

}