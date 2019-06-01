using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;

namespace PixelClickerBackend.Tests
{

    public class AttributeGroupTests
    {
        [Fact]
        public void TestAttributeGroupConstructor(){
            Player player = new Player();
            AttributeGroup attrGroup = new AttributeGroup(player);
            Assert.True(attrGroup.Insert(new WaterDamageAttribute(5)));
            Assert.True(attrGroup.Contains(typeof(WaterDamageAttribute)));
            Assert.False(attrGroup.Contains(typeof(FireDamageAttribute)));
            Assert.False(attrGroup.Insert(new WaterDamageAttribute(3)));
        }       

        [Fact]
        public void TestAttributeGroupApply(){
            Player player = new Player();
            Player throwOffPlayer = new Player();
            AttributeGroup attrGroup = new AttributeGroup(player);
            int attributeTier = 5;
            Assert.True(attrGroup.Insert(new WaterDamageAttribute(attributeTier)));
            Assert.True(attrGroup.Insert(new FireDamageAttribute(attributeTier)));
            Assert.True(attrGroup.Insert(new EarthDamageAttribute(attributeTier)));
            Assert.True(attrGroup.Insert(new NatureDamageAttribute(attributeTier)));
            attrGroup.MakeAllActive();
            ExpNumber expectedDamage = new ExpNumber(2.5,1);
            Assert.Equal(expectedDamage, player.Stats.passiveEarthDPS);
            Assert.Equal(expectedDamage, player.Stats.passiveFireDPS);
            Assert.Equal(expectedDamage, player.Stats.passiveWaterDPS);
            Assert.Equal(expectedDamage, player.Stats.passiveNatureDPS);
            attrGroup.MakeAllInactive();
            Assert.Equal(new ExpNumber(), player.Stats.passiveEarthDPS);
            Assert.Equal(new ExpNumber(), player.Stats.passiveFireDPS);
            Assert.Equal(new ExpNumber(), player.Stats.passiveWaterDPS);
            Assert.Equal(new ExpNumber(), player.Stats.passiveNatureDPS);
        }

        [Fact]
        public void TestAttributeGroupWithCDR(){
            Player player = new Player();
            AttributeGroup group = new AttributeGroup(player);
            CooldownReductionAttribute cdr = new CooldownReductionAttribute(4);
            group.Insert(cdr);
            group.MakeAllActive();
            Assert.Equal((float)cdr.GetEffectQuantity(), player.Stats.cooldownReduction);
            cdr.LevelUp();
            Assert.Equal((float)cdr.GetEffectQuantity(), player.Stats.cooldownReduction);
            
            
        }



    }

}