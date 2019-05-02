using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;

namespace PixelClickerBackend.Tests
{
    public class TopazTests
    {
        [Fact]
        public void TestTopazBasics()
        {
            Gem Topaz = new Topaz(5, new Player());
            Assert.Equal(GemType.Topaz, Topaz.type);
            Assert.Equal(5, Topaz.tier);
            Assert.Equal(Elements.Earth, Topaz.element);

        }

        [Fact]
        public void TestTopazAttributes()
        {
            Gem topaz = new Topaz(3, new Player());
            Assert.Equal(topaz.GetAttributeCount(), 3);
            Assert.True(DoesListContainAttribute(topaz, typeof(EarthDamageAttribute)));
            Assert.True(DoesListContainAttribute(topaz, typeof(GoldFindPercentageAttribute)));
            Assert.True(DoesListContainAttribute(topaz, typeof(DamageIncreasePercentageAttribute)));
        }

        private bool DoesListContainAttribute(Gem gem, Type desiredAttribute)
        {
            Attribute[] attrs = gem.GetAttributes();
            for (int i = 0; i < gem.GetAttributeCount(); i++)
            {
                Attribute attr = gem.GetAttributes()[i];
                if (typeof(attr) == desiredAttribute)
                    return true;
            }
            return false;
        }




    }
}