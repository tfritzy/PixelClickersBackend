using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;

namespace PixelClickerBackend {

    public class PlayerTests {

        [Fact]
        public void TestLevelUpGem(){
            foreach(GemType gemType in Enum.GetValues(typeof(GemType))) {
                Player testPlayer = new Player();
                Random random = new Random();
                int randomTier = random.Next(1, 100);
                Gem emerald = new Emerald(randomTier, testPlayer);
                testPlayer.AddGems(randomTier, 3, gemType);
                Assert.Equal(0, testPlayer.GetGemCount(randomTier+1, gemType));
                Assert.Equal(3, testPlayer.GetGemCount(randomTier, gemType));
                testPlayer.Merge(randomTier + 1, gemType);
                Assert.Equal(1, testPlayer.GetGemCount(randomTier+1, gemType));
                Assert.Equal(0, testPlayer.GetGemCount(randomTier, gemType));
            }
        }

        [Fact]
        public void TestLevelUpMultipleAllGems(){
            
            foreach(GemType gemType in Enum.GetValues(typeof(GemType))) {
                Player testPlayer = new Player();
                Random random = new Random();
                int randomTier = random.Next(1, 100);
                Gem emerald = new Emerald(randomTier, testPlayer);
                testPlayer.AddGems(randomTier, 11, gemType);
                Assert.Equal(0, testPlayer.GetGemCount(randomTier+1, gemType));
                Assert.Equal(11, testPlayer.GetGemCount(randomTier, gemType));
                Assert.True(testPlayer.Merge(randomTier + 1, gemType));
                Assert.True(testPlayer.Merge(randomTier + 1, gemType));
                Assert.True(testPlayer.Merge(randomTier + 1, gemType));
                Assert.False(testPlayer.Merge(randomTier + 1, gemType));
                Assert.Equal(2, testPlayer.GetGemCount(randomTier, gemType));
                Assert.Equal(3, testPlayer.GetGemCount(randomTier+1, gemType));
            }

        }


    }
}