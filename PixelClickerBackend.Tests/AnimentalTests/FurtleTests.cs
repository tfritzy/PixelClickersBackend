using System;
using PixelClickerBackend;
using System.Numerics;
using System.Collections.Generic;
using Xunit;

namespace PixelClickerBackend
{
    public class FurtleTests
    {

        [Fact]
        public void TestFurtleConstructor()
        {
            Player player = new Player();
            Animental furtle = new Furtle(1, 1, player);
            Assert.Equal(Elements.Fire, furtle.element);
        }


        [Fact]
        public void TestFurtleDamage()
        {
            Player player = new Player();
            Animental furtle = new Furtle(1, 1, player);
            Assert.Equal(new ExpNumber(3.5, 0), furtle.damage);
            furtle.AddXp(100);
            Assert.Equal(new ExpNumber(3.92, 0), furtle.damage);
            player.gold = new ExpNumber(3, 304923);
            furtle.PowerUp();
            Assert.Equal(new ExpNumber(3.92 * 1.011, 0), furtle.damage);
            furtle.PowerUp();
            Assert.Equal(new ExpNumber(3.92 * 1.011 * 1.011, 0), furtle.damage);
            furtle.AddXp(200);
            Assert.Equal(new ExpNumber(3.92 * 1.011 * 1.011 * 1.12, 0), furtle.damage);
        }

        [Fact]
        public void TestLevelUpFurtle()
        {
            Player player = new Player();
            Animental dropplet = new Dropplet(1, 1, player);

            BigInteger xp = new BigInteger(100);
            for (int i = 2; i < 100; i++)
            {
                dropplet.AddXp((xp));
                xp = BigInteger.Multiply(xp, 2);
                Assert.Equal(i, dropplet.level);
            }
        }


        [Fact]
        public void TestEquipGem()
        {
            Player player = new Player();
            Furtle furtle = new Furtle(1, 1, player);
            Gem tier10Ruby = new Ruby(10, null);
            ExpNumber originalFurtleDamage = furtle.damage.Clone();
            furtle.GiveGem(tier10Ruby);
           // originalFurtleDamage.Add(new ExpNumber(100, 0));
            ExpNumber newFurtleDamage = originalFurtleDamage;
            Assert.Equal(newFurtleDamage, furtle.damage);
        }



    }
}