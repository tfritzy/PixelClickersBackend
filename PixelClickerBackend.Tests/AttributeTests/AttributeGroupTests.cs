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
            Assert.Equal(expectedDamage, player.passiveEarthDPS);
            Assert.Equal(expectedDamage, player.passiveFireDPS);
            Assert.Equal(expectedDamage, player.passiveWaterDPS);
            Assert.Equal(expectedDamage, player.passiveNatureDPS);
            attrGroup.MakeAllInactive();
            Assert.Equal(new ExpNumber(), player.passiveEarthDPS);
            Assert.Equal(new ExpNumber(), player.passiveFireDPS);
            Assert.Equal(new ExpNumber(), player.passiveWaterDPS);
            Assert.Equal(new ExpNumber(), player.passiveNatureDPS);
        }

        [Fact]
        public void TestAttributeGroupWithCDR(){
            Player player = new Player();
            AttributeGroup group = new AttributeGroup(player);
            CooldownReductionAttribute cdr = new CooldownReductionAttribute(4);
            group.Insert(cdr);
            group.MakeAllActive();
            Assert.Equal((float)cdr.GetEffectQuantity(), player.cooldownReduction);
            cdr.LevelUp();
            Assert.Equal((float)cdr.GetEffectQuantity(), player.cooldownReduction);
            
            
        }



    }

}