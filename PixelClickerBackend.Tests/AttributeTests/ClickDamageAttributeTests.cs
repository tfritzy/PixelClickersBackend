using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;

namespace PixelClickerBackend.Tests
{
    public class ClickDamageAttributeTests {
        
        [Fact]
        public void TestClickDamageLevel1() {
            Player testPlayer = new Player();
            int tier = 1;
            ClickDamageAttribute cda = new ClickDamageAttribute(tier);
            ExpNumber expectedClickDamage = new ExpNumber(4 * tier, 0);
            cda.ApplyEffect(testPlayer);
            Assert.Equal(expectedClickDamage, testPlayer.clickDamage);
        }

        [Fact]
        public void TestClickDamageLevel2() {
            Player testPlayer = new Player();
            int tier = 2;
            ClickDamageAttribute cda = new ClickDamageAttribute(tier);
            ExpNumber expectedClickDamage = new ExpNumber(4 * tier, 0);
            cda.ApplyEffect(testPlayer);
            Assert.Equal(expectedClickDamage, testPlayer.clickDamage);
        }

        [Fact]
        public void TestClickDamageLevel3() {
            Player testPlayer = new Player();
            int tier = 3;
            ClickDamageAttribute cda = new ClickDamageAttribute(tier);
            ExpNumber expectedClickDamage = new ExpNumber(4 * tier, 0);
            cda.ApplyEffect(testPlayer);
            Assert.Equal(expectedClickDamage, testPlayer.clickDamage);
        }

        [Fact]
        public void TestClickDamageLevel4() {
            Player testPlayer = new Player();
            int tier = 4;
            ClickDamageAttribute cda = new ClickDamageAttribute(tier);
            ExpNumber expectedClickDamage = new ExpNumber(4 * tier, 0);
            cda.ApplyEffect(testPlayer);
            Assert.Equal(expectedClickDamage, testPlayer.clickDamage);
        }

        [Fact]
        public void TestClickDamageLevel10() {
            Player testPlayer = new Player();
            int tier = 10;
            ClickDamageAttribute cda = new ClickDamageAttribute(tier);
            ExpNumber expectedClickDamage = new ExpNumber(4 * tier, 0);
            cda.ApplyEffect(testPlayer);
            Assert.Equal(expectedClickDamage, testPlayer.clickDamage);
        }

        [Fact]
        public void TestClickDamageLevelMaxInt() {
            Player testPlayer = new Player();
            int tier = int.MaxValue;
            ClickDamageAttribute cda = new ClickDamageAttribute(tier);
            ExpNumber expectedClickDamage = new ExpNumber(8.589934588, 9);
            cda.ApplyEffect(testPlayer);
            Assert.Equal(expectedClickDamage, testPlayer.clickDamage);
        }

        [Fact]
        public void TestPowerUpClickAttr(){
            Player testPlayer = new Player();
            Random random = new Random();
            int tier = random.Next(1, 1000);
            ClickDamageAttribute cda = new ClickDamageAttribute(tier);
            int numPowerUps = random.Next(1, 1000);
            for (int i = 0; i < numPowerUps; i++){
                cda.LevelUp();
            }
            cda.ApplyEffect(testPlayer);
            ExpNumber expectedClickDamage = new ExpNumber((tier + numPowerUps) * 4, 0);
            Assert.Equal(expectedClickDamage, testPlayer.clickDamage);

        }

    }
}