using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;

namespace PixelClickerBackend.Tests
{
    public class GemTests
    {
        #region Sample_TestCode
        [Fact]
        public void TestEmeraldBasics()
        {
            Gem emerald = new Emerald(5);
            Assert.Equal(GemType.Emerald, emerald.type);
            Assert.Equal(5, emerald.tier);
        }
        #endregion

        [Fact]
        public void TestEmeraldElementType()
        {
            Gem emerald = new Emerald(3);
            Assert.Equal(emerald.element, Elements.Nature);
        }
        [Fact]
        public void TestTier1Emerald()
        {
            int tier = 1;

            Gem emerald = new Emerald(tier);
            Player player = new Player();

            Assert.Equal(emerald.tier, tier);

            BigInteger expectedDamageIncrease = new BigInteger(5);
            float expectedGemDropChanceIncrease = 0f;
            float expectedEnemyLifeReduction = 0f;

            BigInteger prevPlayerDamge = player.passiveNatureDPS;
            float prevGemDropChance = player.gemDropChance;
            float prevEnemyLifeReduction = player.enemyHealthPercentageReduction;

            emerald.Apply(player);

            Assert.Equal(prevPlayerDamge + expectedDamageIncrease, player.passiveNatureDPS);
            Assert.Equal(prevGemDropChance + expectedGemDropChanceIncrease, player.gemDropChance);
            Assert.Equal(prevEnemyLifeReduction + expectedEnemyLifeReduction, player.enemyHealthPercentageReduction);
        }

        [Fact]
        public void TestTier2Emerald()
        {
            int tier = 2;

            Gem emerald = new Emerald(tier);
            Player player = new Player();

            Assert.Equal(emerald.tier, tier);

            BigInteger expectedDamageIncrease = new BigInteger(10);
            float expectedGemDropChanceIncrease = 0f;
            float expectedEnemyLifeReduction = 0f;

            BigInteger prevPlayerDamge = player.passiveNatureDPS;
            float prevGemDropChance = player.gemDropChance;
            float prevEnemyLifeReduction = player.enemyHealthPercentageReduction;

            emerald.Apply(player);

            Assert.Equal(prevPlayerDamge + expectedDamageIncrease, player.passiveNatureDPS);
            Assert.Equal(prevGemDropChance + expectedGemDropChanceIncrease, player.gemDropChance);
            Assert.Equal(prevEnemyLifeReduction + expectedEnemyLifeReduction, player.enemyHealthPercentageReduction);
        }

        [Fact]
        public void TestTier3Emerald()
        {
            int tier = 3;

            Gem emerald = new Emerald(tier);
            Player player = new Player();

            Assert.Equal(emerald.tier, tier);

            BigInteger expectedDamageIncrease = new BigInteger(20);
            float expectedGemDropChanceIncrease = 1f;
            float expectedEnemyLifeReduction = 0f;

            BigInteger prevPlayerDamge = player.passiveNatureDPS;
            float prevGemDropChance = player.gemDropChance;
            float prevEnemyLifeReduction = player.enemyHealthPercentageReduction;

            emerald.Apply(player);

            Assert.Equal(prevPlayerDamge + expectedDamageIncrease, player.passiveNatureDPS);
            Assert.Equal(prevGemDropChance + expectedGemDropChanceIncrease, player.gemDropChance);
            Assert.Equal(prevEnemyLifeReduction + expectedEnemyLifeReduction, player.enemyHealthPercentageReduction);
        }

        [Fact]
        public void TestTier4Emerald()
        {
            int tier = 4;

            Gem emerald = new Emerald(tier);
            Player player = new Player();

            Assert.Equal(emerald.tier, tier);

            BigInteger expectedDamageIncrease = new BigInteger(40);
            float expectedGemDropChanceIncrease = 2f;
            float expectedEnemyLifeReduction = 0f;

            BigInteger prevPlayerDamge = player.passiveNatureDPS;
            float prevGemDropChance = player.gemDropChance;
            float prevEnemyLifeReduction = player.enemyHealthPercentageReduction;

            emerald.Apply(player);

            Assert.Equal(prevPlayerDamge + expectedDamageIncrease, player.passiveNatureDPS);
            Assert.Equal(prevGemDropChance + expectedGemDropChanceIncrease, player.gemDropChance);
            Assert.Equal(prevEnemyLifeReduction + expectedEnemyLifeReduction, player.enemyHealthPercentageReduction);
        }

        [Fact]
        public void TestTier5Emerald()
        {
            int tier = 5;

            Gem emerald = new Emerald(tier);
            Player player = new Player();

            Assert.Equal(emerald.tier, tier);

            BigInteger expectedDamageIncrease = new BigInteger(80);
            float expectedGemDropChanceIncrease = 4f;
            float expectedEnemyLifeReduction = 1f;

            BigInteger prevPlayerDamge = player.passiveNatureDPS;
            float prevGemDropChance = player.gemDropChance;
            float prevEnemyLifeReduction = player.enemyHealthPercentageReduction;

            emerald.Apply(player);

            Assert.Equal(prevPlayerDamge + expectedDamageIncrease, player.passiveNatureDPS);
            Assert.Equal(prevGemDropChance + expectedGemDropChanceIncrease, player.gemDropChance);
            Assert.Equal(prevEnemyLifeReduction + expectedEnemyLifeReduction, player.enemyHealthPercentageReduction);
        }


        [Fact]
        public void TestTier6Emerald()
        {
            int tier = 6;

            Gem emerald = new Emerald(tier);
            Player player = new Player();

            Assert.Equal(emerald.tier, tier);

            BigInteger expectedDamageIncrease = new BigInteger(160);
            float expectedGemDropChanceIncrease = 8f;
            float expectedEnemyLifeReduction = 2f;

            BigInteger prevPlayerDamge = player.passiveNatureDPS;
            float prevGemDropChance = player.gemDropChance;
            float prevEnemyLifeReduction = player.enemyHealthPercentageReduction;

            emerald.Apply(player);

            Assert.Equal(prevPlayerDamge + expectedDamageIncrease, player.passiveNatureDPS);
            Assert.Equal(prevGemDropChance + expectedGemDropChanceIncrease, player.gemDropChance);
            Assert.Equal(prevEnemyLifeReduction + expectedEnemyLifeReduction, player.enemyHealthPercentageReduction);
        }

        [Fact]
        public void TestTier7Emerald()
        {
            int tier = 7;

            Gem emerald = new Emerald(tier);
            Player player = new Player();

            Assert.Equal(emerald.tier, tier);

            BigInteger expectedDamageIncrease = new BigInteger(320);
            float expectedGemDropChanceIncrease = 16f;
            float expectedEnemyLifeReduction = 4f;

            BigInteger prevPlayerDamge = player.passiveNatureDPS;
            float prevGemDropChance = player.gemDropChance;
            float prevEnemyLifeReduction = player.enemyHealthPercentageReduction;

            emerald.Apply(player);

            Assert.Equal(prevPlayerDamge + expectedDamageIncrease, player.passiveNatureDPS);
            Assert.Equal(prevGemDropChance + expectedGemDropChanceIncrease, player.gemDropChance);
            Assert.Equal(prevEnemyLifeReduction + expectedEnemyLifeReduction, player.enemyHealthPercentageReduction);
        }

        [Fact]
        public void TestTier8Emerald()
        {
            int tier = 8;

            Gem emerald = new Emerald(tier);
            Player player = new Player();

            Assert.Equal(emerald.tier, tier);

            BigInteger expectedDamageIncrease = new BigInteger(640);
            float expectedGemDropChanceIncrease = 32f;
            float expectedEnemyLifeReduction = 8f;

            BigInteger prevPlayerDamge = player.passiveNatureDPS;
            float prevGemDropChance = player.gemDropChance;
            float prevEnemyLifeReduction = player.enemyHealthPercentageReduction;

            emerald.Apply(player);

            Assert.Equal(prevPlayerDamge + expectedDamageIncrease, player.passiveNatureDPS);
            Assert.Equal(prevGemDropChance + expectedGemDropChanceIncrease, player.gemDropChance);
            Assert.Equal(prevEnemyLifeReduction + expectedEnemyLifeReduction, player.enemyHealthPercentageReduction);
        }

        [Fact]
        public void TestTier9Emerald()
        {
            int tier = 9;

            Gem emerald = new Emerald(tier);
            Player player = new Player();

            Assert.Equal(emerald.tier, tier);

            BigInteger expectedDamageIncrease = new BigInteger(1280);
            float expectedGemDropChanceIncrease = 64f;
            float expectedEnemyLifeReduction = 16f;

            BigInteger prevPlayerDamge = player.passiveNatureDPS;
            float prevGemDropChance = player.gemDropChance;
            float prevEnemyLifeReduction = player.enemyHealthPercentageReduction;

            emerald.Apply(player);

            Assert.Equal(prevPlayerDamge + expectedDamageIncrease, player.passiveNatureDPS);
            Assert.Equal(prevGemDropChance + expectedGemDropChanceIncrease, player.gemDropChance);
            Assert.Equal(prevEnemyLifeReduction + expectedEnemyLifeReduction, player.enemyHealthPercentageReduction);
        }

        [Fact]
        public void TestTier10Emerald()
        {
            int tier = 10;

            Gem emerald = new Emerald(tier);
            Player player = new Player();

            Assert.Equal(emerald.tier, tier);

            BigInteger expectedDamageIncrease = new BigInteger(2560);
            float expectedGemDropChanceIncrease = 100f;
            float expectedEnemyLifeReduction = 32f;

            BigInteger prevPlayerDamge = player.passiveNatureDPS;
            float prevGemDropChance = player.gemDropChance;
            float prevEnemyLifeReduction = player.enemyHealthPercentageReduction;

            emerald.Apply(player);

            Assert.Equal(prevPlayerDamge + expectedDamageIncrease, player.passiveNatureDPS);
            Assert.Equal(prevGemDropChance + expectedGemDropChanceIncrease, player.gemDropChance);
            Assert.Equal(prevEnemyLifeReduction + expectedEnemyLifeReduction, player.enemyHealthPercentageReduction);
        }

        [Fact]
        public void TestTier20Emerald()
        {
            int tier = 20;

            Gem emerald = new Emerald(tier);
            Player player = new Player();

            Assert.Equal(emerald.tier, tier);

            BigInteger expectedDamageIncrease = new BigInteger(2621440);
            float expectedGemDropChanceIncrease = 100f;
            float expectedEnemyLifeReduction = 90f;

            BigInteger prevPlayerDamge = player.passiveNatureDPS;
            float prevGemDropChance = player.gemDropChance;
            float prevEnemyLifeReduction = player.enemyHealthPercentageReduction;

            emerald.Apply(player);

            Assert.Equal(prevPlayerDamge + expectedDamageIncrease, player.passiveNatureDPS);
            Assert.Equal(prevGemDropChance + expectedGemDropChanceIncrease, player.gemDropChance);
            Assert.Equal(prevEnemyLifeReduction + expectedEnemyLifeReduction, player.enemyHealthPercentageReduction);
        }

        [Fact]
        public void TestTier100Emerald()
        {
            int tier = 100;

            Gem emerald = new Emerald(tier);
            Player player = new Player();

            Assert.Equal(emerald.tier, tier);

            BigInteger expectedDamageIncrease = new BigInteger(5);
            expectedDamageIncrease = BigInteger.Multiply(BigInteger.Pow(2, tier - 1), expectedDamageIncrease);

            float expectedGemDropChanceIncrease = 100;
            float expectedEnemyLifeReduction = 90f;

            BigInteger prevPlayerDamge = player.passiveNatureDPS;
            float prevGemDropChance = player.gemDropChance;
            float prevEnemyLifeReduction = player.enemyHealthPercentageReduction;

            emerald.Apply(player);

            Assert.Equal(BigInteger.Add(prevPlayerDamge, expectedDamageIncrease), player.passiveNatureDPS);
            Assert.Equal(prevGemDropChance + expectedGemDropChanceIncrease, player.gemDropChance);
            Assert.Equal(prevEnemyLifeReduction + expectedEnemyLifeReduction, player.enemyHealthPercentageReduction);
        }
    }
}
