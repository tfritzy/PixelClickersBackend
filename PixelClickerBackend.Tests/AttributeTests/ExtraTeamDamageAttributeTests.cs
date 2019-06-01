using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;


namespace PixelClickerBackend
{

    public class ExtraTeamDamageAttributeTests
    {

                #region LevelUpTests
        [Fact]
        public void TestLevelUpNotEquipt(){
            int startTier = 4;
            Player testPlayer = new Player();
            Attribute attr = new ExtraTeamDamageAttribute(startTier);
            
            attr.LevelUp();
            Assert.Equal(startTier + 1, attr.tier);
            Attribute testAttr = new ExtraTeamDamageAttribute(startTier+1);
            Assert.Equal(new BigInteger(0),
                        testPlayer.Stats.teamDamageBonusPercent);
            attr.ApplyEffect(testPlayer);
            Assert.Equal(testAttr.GetEffectQuantity(),
                        testPlayer.Stats.teamDamageBonusPercent);
        }

        [Fact]
        public void TestLevelUpEquipt(){
            int startTier = 4;
            Player testPlayer = new Player();
            Attribute attr = new ExtraTeamDamageAttribute(startTier);
            attr.ApplyEffect(testPlayer);
            attr.LevelUp();
            Assert.Equal(startTier + 1, attr.tier);
            Attribute testAttr = new ExtraTeamDamageAttribute(startTier+1);
            Assert.Equal(testAttr.GetEffectQuantity(),
                        testPlayer.Stats.teamDamageBonusPercent);
            attr.RemoveEffect(testPlayer);
            Assert.Equal(new BigInteger(0),
                        testPlayer.Stats.teamDamageBonusPercent);
        }

        [Fact]
        public void TestLevelUpAcrossManyLevels(){
            for (int i = 1; i < 1000; i+=i){
                Player testPlayer = new Player();
                Attribute attr = new ExtraTeamDamageAttribute(i);
                Assert.Equal(new BigInteger(0),
                        testPlayer.Stats.teamDamageBonusPercent);
                attr.ApplyEffect(testPlayer);
                attr.LevelUp();
                Assert.Equal(i + 1, attr.tier);
                Attribute testAttr = new ExtraTeamDamageAttribute(i+1);
                Assert.Equal(testAttr.GetEffectQuantity(),
                        testPlayer.Stats.teamDamageBonusPercent);
            
            }
        }
        #endregion


        [Fact]
        public void TestLevel1()
        {
            Player testPlayer = new Player();
            ExtraTeamDamageAttribute attr =
                new ExtraTeamDamageAttribute(1);
            Assert.Equal(1, attr.tier);
            Assert.Equal(applyFormula(1), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(1), testPlayer.Stats.teamDamageBonusPercent);
        }

        [Fact]
        public void TestLevel2()
        {
            Player testPlayer = new Player();
            ExtraTeamDamageAttribute attr =
                new ExtraTeamDamageAttribute(2);
            Assert.Equal(2, attr.tier);
            Assert.Equal(applyFormula(2), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(2), testPlayer.Stats.teamDamageBonusPercent);
        }

        [Fact]
        public void TestLevel3()
        {
            Player testPlayer = new Player();
            ExtraTeamDamageAttribute attr =
                new ExtraTeamDamageAttribute(3);
            Assert.Equal(3, attr.tier);
            Assert.Equal(applyFormula(3), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(3), testPlayer.Stats.teamDamageBonusPercent);
        }

        [Fact]
        public void TestLevel4()
        {
            Player testPlayer = new Player();
            ExtraTeamDamageAttribute attr =
                new ExtraTeamDamageAttribute(4);
            Assert.Equal(4, attr.tier);
            Assert.Equal(applyFormula(4), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(4), testPlayer.Stats.teamDamageBonusPercent);
        }

        [Fact]
        public void TestLevel5()
        {
            Player testPlayer = new Player();
            ExtraTeamDamageAttribute attr =
                new ExtraTeamDamageAttribute(5);
            Assert.Equal(5, attr.tier);
            Assert.Equal(applyFormula(5), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(5), testPlayer.Stats.teamDamageBonusPercent);
        }

        [Fact]
        public void TestLevel10()
        {
            Player testPlayer = new Player();
            ExtraTeamDamageAttribute attr =
                new ExtraTeamDamageAttribute(10);
            Assert.Equal(10, attr.tier);
            Assert.Equal(applyFormula(10), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(10), testPlayer.Stats.teamDamageBonusPercent);
        }

        [Fact]
        public void TestLevel100()
        {
            Player testPlayer = new Player();
            ExtraTeamDamageAttribute attr =
                new ExtraTeamDamageAttribute(100);
            Assert.Equal(100, attr.tier);
            Assert.Equal(applyFormula(100), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(100), testPlayer.Stats.teamDamageBonusPercent);
        }

        [Fact]
        public void TestActive()
        {
            Player testPlayer = new Player();
            ExtraTeamDamageAttribute attr =
            new ExtraTeamDamageAttribute(3);
            Assert.Equal(3, attr.tier);
            attr.ApplyEffect(testPlayer);
            Assert.True(attr.IsActive(testPlayer));
            attr.RemoveEffect(testPlayer);
            Assert.False(attr.IsActive(testPlayer));
            Assert.Equal(applyFormula(3), attr.GetEffectQuantity());
            attr.ApplyEffect(testPlayer);
            Assert.Equal(applyFormula(3), testPlayer.Stats.teamDamageBonusPercent);
        }

        [Fact]
        public void TestFlickerActive()
        {
            Player testPlayer = new Player();
            ExtraTeamDamageAttribute attr =
            new ExtraTeamDamageAttribute(10);
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
            Assert.Equal(applyFormula(10), testPlayer.Stats.teamDamageBonusPercent);
            attr.RemoveEffect(testPlayer);
            Assert.Equal(new BigInteger(0), testPlayer.Stats.teamDamageBonusPercent);
        }

        private BigInteger applyFormula(int tier){
            return BigInteger.Multiply(new BigInteger(3), new BigInteger(tier));
        }





    }

}