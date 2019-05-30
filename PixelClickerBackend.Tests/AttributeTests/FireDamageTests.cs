using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;


namespace PixelClickerBackend
{

    public class PassiveFireDPSTests
    {

        #region LevelUpTests
        [Fact]
        public void TestLevelUpNotEquipt(){
            int startTier = 4;
            Player testPlayer = new Player();
            Attribute attr = new FireDamageAttribute(startTier);
            
            attr.LevelUp();
            Assert.Equal(startTier + 1, attr.tier);
            Attribute testAttr = new FireDamageAttribute(startTier+1);
            Assert.Equal(GetExpectedDamage(0),
                        testPlayer.passiveFireDPS);
            attr.ApplyEffect(testPlayer);
            Assert.Equal(testAttr.GetEffectQuantity(),
                        testPlayer.passiveFireDPS);
        }

        [Fact]
        public void TestLevelUpEquipt(){
            int startTier = 4;
            Player testPlayer = new Player();
            Attribute attr = new FireDamageAttribute(startTier);
            attr.ApplyEffect(testPlayer);
            attr.LevelUp();
            Assert.Equal(startTier + 1, attr.tier);
            Attribute testAttr = new FireDamageAttribute(startTier+1);
            Assert.Equal(testAttr.GetEffectQuantity(),
                        testPlayer.passiveFireDPS);
            attr.RemoveEffect(testPlayer);
            Assert.Equal(GetExpectedDamage(0),
                        testPlayer.passiveFireDPS);
        }

        [Fact]
        public void TestLevelUpAcrossManyLevels(){
            for (int i = 1; i < 1000; i+=i){
                Player testPlayer = new Player();
                Attribute attr = new FireDamageAttribute(i);
                Assert.Equal(GetExpectedDamage(0),
                        testPlayer.passiveFireDPS);
                attr.ApplyEffect(testPlayer);
                attr.LevelUp();
                Assert.Equal(i + 1, attr.tier);
                Attribute testAttr = new FireDamageAttribute(i+1);
                Assert.Equal(testAttr.GetEffectQuantity(),
                        testPlayer.passiveFireDPS);
            
            }
        }
        #endregion


        [Fact]
        public void TestLevel1()
        {
            Player testPlayer = new Player();
            FireDamageAttribute attr =
                new FireDamageAttribute(1);
            Assert.Equal(1, attr.tier);
            Assert.Equal(GetExpectedDamage(1), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(GetExpectedDamage(1), testPlayer.passiveFireDPS);
        }

        [Fact]
        public void TestLevel2()
        {
            Player testPlayer = new Player();
            FireDamageAttribute attr =
                new FireDamageAttribute(2);
            Assert.Equal(2, attr.tier);
            Assert.Equal(GetExpectedDamage(2), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(GetExpectedDamage(2), testPlayer.passiveFireDPS);
        }

        [Fact]
        public void TestLevel3()
        {
            Player testPlayer = new Player();
            FireDamageAttribute attr =
                new FireDamageAttribute(3);
            Assert.Equal(3, attr.tier);
            Assert.Equal(GetExpectedDamage(3), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(GetExpectedDamage(3), testPlayer.passiveFireDPS);
        }

        [Fact]
        public void TestLevel4()
        {
            Player testPlayer = new Player();
            FireDamageAttribute attr =
                new FireDamageAttribute(4);
            Assert.Equal(4, attr.tier);
            Assert.Equal(GetExpectedDamage(4), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(GetExpectedDamage(4), testPlayer.passiveFireDPS);
        }

        [Fact]
        public void TestLevel5()
        {
            Player testPlayer = new Player();
            FireDamageAttribute attr =
                new FireDamageAttribute(5);
            Assert.Equal(5, attr.tier);
            Assert.Equal(GetExpectedDamage(5), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(GetExpectedDamage(5), testPlayer.passiveFireDPS);
        }

        [Fact]
        public void TestLevel10()
        {
            Player testPlayer = new Player();
            FireDamageAttribute attr =
                new FireDamageAttribute(10);
            Assert.Equal(10, attr.tier);
            Assert.Equal(GetExpectedDamage(10), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(GetExpectedDamage(10), testPlayer.passiveFireDPS);
        }

        [Fact]
        public void TestLevel100()
        {
            Player testPlayer = new Player();
            FireDamageAttribute attr =
                new FireDamageAttribute(100);
            Assert.Equal(100, attr.tier);
            Assert.Equal(GetExpectedDamage(100), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(GetExpectedDamage(100), testPlayer.passiveFireDPS);
        }

        [Fact]
        public void TestActive()
        {
            Player testPlayer = new Player();
            FireDamageAttribute attr =
            new FireDamageAttribute(3);
            Assert.Equal(3, attr.tier);
            attr.ApplyEffect(testPlayer);
            Assert.True(attr.IsActive(testPlayer));
            attr.RemoveEffect(testPlayer);
            Assert.False(attr.IsActive(testPlayer));
            Assert.Equal(GetExpectedDamage(3), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(GetExpectedDamage(3), testPlayer.passiveFireDPS);
        }

        [Fact]
        public void TestFlickerActive()
        {
            Player testPlayer = new Player();
            FireDamageAttribute attr =
            new FireDamageAttribute(10);
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
            Assert.Equal(GetExpectedDamage(10), testPlayer.passiveFireDPS);
            attr.RemoveEffect(testPlayer);
            Assert.Equal(GetExpectedDamage(0), testPlayer.passiveFireDPS);
        }

        [Fact]
        public void TestLevelMaxInt()
        {
            Player testPlayer = new Player();
            FireDamageAttribute attr =
                new FireDamageAttribute(int.MaxValue);
            Assert.Equal(int.MaxValue, attr.tier);
            Assert.Equal(new ExpNumber(4.611, 18), attr.GetEffectQuantity()); // should be 4611686014132420609
            attr.ApplyEffect(testPlayer);
            Assert.Equal(new ExpNumber(4.611, 18), testPlayer.passiveFireDPS); // should be 4611686014132420609
        }

        private ExpNumber GetExpectedDamage(int tier){
            ExpNumber damage = new ExpNumber(tier, 0);
            damage.Pow(2);
            return damage;
        }





    }

}