using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;


namespace PixelClickerBackend
{

    public class CooldownReductionTets
    {

        [Fact]
        public void TestLevelUpNotEquipt(){
            int startTier = 4;
            Player testPlayer = new Player();
            Attribute attr = new CooldownReductionAttribute(startTier);
            
            attr.LevelUp();
            Assert.Equal(startTier + 1, attr.tier);
            Attribute testAttr = new CooldownReductionAttribute(startTier+1);
            Assert.Equal(0f,
                        testPlayer.cooldownReduction);
            attr.ApplyEffect(testPlayer);
            Assert.Equal(testAttr.GetEffectQuantity(),
                        testPlayer.cooldownReduction);
        }

        [Fact]
        public void TestLevelUpEquipt(){
            int startTier = 4;
            Player testPlayer = new Player();
            Attribute attr = new CooldownReductionAttribute(startTier);
            attr.ApplyEffect(testPlayer);
            attr.LevelUp();
            Assert.Equal(startTier + 1, attr.tier);
            Attribute testAttr = new CooldownReductionAttribute(startTier+1);
            Assert.Equal(testAttr.GetEffectQuantity(),
                        testPlayer.cooldownReduction);
            attr.RemoveEffect(testPlayer);
            Assert.Equal(0f,
                        testPlayer.cooldownReduction);
        }

        [Fact]
        public void TestLevelUpAcrossManyLevels(){
            for (int i = 1; i < 1000; i+=i){
                Player testPlayer = new Player();
                Attribute attr = new CooldownReductionAttribute(i);
                Assert.Equal(0f,
                        testPlayer.cooldownReduction);
                attr.ApplyEffect(testPlayer);
                attr.LevelUp();
                Assert.Equal(i + 1, attr.tier);
                Attribute testAttr = new CooldownReductionAttribute(i+1);
                Assert.Equal(testAttr.GetEffectQuantity(),
                        testPlayer.cooldownReduction);
            
            }
        }

        [Fact]
        public void TestMultiLevelUp(){

            Random random = new Random();
            Player testPlayer = new Player();
            float oldCDR = testPlayer.cooldownReduction;
            int startTier = random.Next(1, 140);
            Attribute attr = new CooldownReductionAttribute(startTier);
            int numUpgrades = random.Next(0, 100);
            for (int i = 0; i < numUpgrades; i++){
                attr.LevelUp();
            }
            attr.ApplyEffect(testPlayer);
            Attribute expectedCDR = new CooldownReductionAttribute(
                                                        startTier + numUpgrades);
            Assert.Equal(startTier + numUpgrades, attr.tier);
            Assert.Equal(expectedCDR.GetEffectQuantity(), 
                        testPlayer.cooldownReduction - oldCDR);


        }

        [Fact]
        public void TestLevel1()
        {
            Player testPlayer = new Player();
            CooldownReductionAttribute attr =
                new CooldownReductionAttribute(1);
            Assert.Equal(1, attr.tier);
            Assert.Equal(1f, attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(1f, testPlayer.cooldownReduction);
        }

        [Fact]
        public void TestLevel2()
        {
            Player testPlayer = new Player();
            CooldownReductionAttribute attr =
                new CooldownReductionAttribute(2);
            Assert.Equal(2, attr.tier);
            Assert.Equal(2f, attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(2f, testPlayer.cooldownReduction);
        }

        [Fact]
        public void TestLevel3()
        {
            Player testPlayer = new Player();
            CooldownReductionAttribute attr =
                new CooldownReductionAttribute(3);
            Assert.Equal(3, attr.tier);
            Assert.Equal(3f, attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(3f, testPlayer.cooldownReduction);
        }

        [Fact]
        public void TestLevel4()
        {
            Player testPlayer = new Player();
            CooldownReductionAttribute attr =
                new CooldownReductionAttribute(4);
            Assert.Equal(4, attr.tier);
            Assert.Equal(4f, attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(4f, testPlayer.cooldownReduction);
        }

        [Fact]
        public void TestLevel5()
        {
            Player testPlayer = new Player();
            CooldownReductionAttribute attr =
                new CooldownReductionAttribute(5);
            Assert.Equal(5, attr.tier);
            Assert.Equal(5f, attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(5f, testPlayer.cooldownReduction);
        }

        [Fact]
        public void TestLevel10()
        {
            Player testPlayer = new Player();
            CooldownReductionAttribute attr =
                new CooldownReductionAttribute(10);
            Assert.Equal(10, attr.tier);
            Assert.Equal(10f, attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(10f, testPlayer.cooldownReduction);
        }

        [Fact]
        public void TestLevel100()
        {
            Player testPlayer = new Player();
            CooldownReductionAttribute attr =
                new CooldownReductionAttribute(100);
            Assert.Equal(100, attr.tier);
            Assert.Equal(100f, attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(100f, testPlayer.cooldownReduction);
        }


        [Fact]
        public void TestActive()
        {
            Player testPlayer = new Player();
            CooldownReductionAttribute attr =
            new CooldownReductionAttribute(3);
            Assert.Equal(3, attr.tier);
            attr.ApplyEffect(testPlayer);
            Assert.True(attr.IsActive(testPlayer));
            attr.RemoveEffect(testPlayer);
            Assert.False(attr.IsActive(testPlayer));
            Assert.Equal(3f, attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(3f, testPlayer.cooldownReduction);
        }

        [Fact]
        public void TestFlickerActive()
        {
            Player testPlayer = new Player();
            CooldownReductionAttribute attr =
            new CooldownReductionAttribute(10);
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
            Assert.Equal(10f, testPlayer.cooldownReduction);
            attr.RemoveEffect(testPlayer);
            Assert.Equal(0f, testPlayer.cooldownReduction);
        }





    }

}