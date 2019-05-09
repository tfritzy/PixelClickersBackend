using System;
using Xunit;
using PixelClickerBackend;
using System.Numerics;
using System.Collections.Generic;

namespace PixelClickerBackend.Tests
{

    public class ExpNumberTests
    {

        [Fact]
        public void TestConstructor()
        {
            ExpNumber number = new ExpNumber(5f, 1);
            Assert.Equal(5, number.significand);
            Assert.Equal(1, number.magnitude);
        }

        [Fact]
        public void TestConstructorBigSignificand()
        {
            ExpNumber number = new ExpNumber(500f, 0);
            Assert.Equal(5, number.significand);
            Assert.Equal(2, number.magnitude);
        }

        [Fact]
        public void TestConstructorSmallSignificand()
        {
            ExpNumber number = new ExpNumber(.00000243, 0);
            Assert.Equal(2.43, number.significand);
            Assert.Equal(-6, number.magnitude);
        }

        [Fact]
        public void TestConstructorOutsidePrecisionNext()
        {
            ExpNumber num = new ExpNumber(4.23000015452, 59);
            Assert.Equal(4.23000, num.significand);
            Assert.Equal(59, num.magnitude);
        }

        #region Testing Power of


        [Fact]
        public void TestPowManyTimes()
        {
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                double num1 = random.Next(0, 9);
                int num2 = random.Next(0, 300);
                ExpNumber num1Exp = new ExpNumber(num1, 0);
                num1Exp.Pow(num2);
                ExpNumber expected = new ExpNumber(Math.Pow(num1, num2), 0);
                ExpNumber actual = num1Exp;
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void TestBigPow()
        {
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                double baseValue = random.Next(0, 99) / 10.0;
                int exponent = random.Next(1, 100000);
                ExpNumber num = new ExpNumber(baseValue, 0);
                num.Pow(exponent);
                Assert.Equal(VerifyPow(baseValue, exponent), num);
            }
        }

        private ExpNumber VerifyPow(double baseValue, int exponent){
            ExpNumber collector = new ExpNumber(1, 0);
            ExpNumber multiplier = new ExpNumber(baseValue, 0);
            for (int i = 0; i < exponent; i++){
                collector.Multiply(multiplier);
            }
            return collector;
        }



        #endregion

        #region Multiplying ExpNumbers together

        [Fact]
        public void TestSimpleMultiply200by4500()
        {
            ExpNumber num1 = new ExpNumber(2.00, 2);
            ExpNumber num2 = new ExpNumber(4.5, 3);
            num1.Multiply(num2);
            Assert.Equal(new ExpNumber(9, 5), num1);
        }

        [Fact]
        public void TestSimpleMultiply1by2()
        {
            ExpNumber num1 = new ExpNumber(1.00, 0);
            ExpNumber num2 = new ExpNumber(2, 0);
            num1.Multiply(num2);
            Assert.Equal(new ExpNumber(2, 0), num1);
        }

        [Fact]
        public void TestSimpleMultiply123by3()
        {
            ExpNumber num1 = new ExpNumber(3.00, 0);
            ExpNumber num2 = new ExpNumber(1.23, 2);
            num1.Multiply(num2);
            Assert.Equal(new ExpNumber(3.69, 2), num1);
        }

        [Fact]
        public void TestSimpleMultiply999by2()
        {
            ExpNumber num1 = new ExpNumber(2.00, 0);
            ExpNumber num2 = new ExpNumber(9.99, 2);
            num1.Multiply(num2);
            Assert.Equal(new ExpNumber(1.998, 3), num1);
        }

        [Fact]
        public void TestSimpleMultiply999byMinus2()
        {
            ExpNumber num1 = new ExpNumber(-2.00, 0);
            ExpNumber num2 = new ExpNumber(9.99, 2);
            num1.Multiply(num2);
            Assert.Equal(new ExpNumber(-1.998, 3), num1);
        }

        [Fact]
        public void TestSimpleMultiply942by0()
        {
            ExpNumber num1 = new ExpNumber(0, 0);
            ExpNumber num2 = new ExpNumber(9.42, 2);
            num1.Multiply(num2);
            Assert.Equal(new ExpNumber(0, 0), num1);
        }

        [Fact]
        public void TestSimpleMultiply900byPoint5()
        {
            ExpNumber num1 = new ExpNumber(9, 2);
            ExpNumber num2 = new ExpNumber(5, -1);
            num1.Multiply(num2);
            Assert.Equal(new ExpNumber(4.5, 2), num1);
        }

        [Fact]
        public void TestSimpleMultiply923byPoint1()
        {
            ExpNumber num1 = new ExpNumber(9.23, 2);
            ExpNumber num2 = new ExpNumber(1, -1);
            num1.Multiply(num2);
            Assert.Equal(new ExpNumber(9.23, 1), num1);
        }

        [Fact]
        public void TestSimpleMultiply15432byPoint000000000000000001()
        {
            ExpNumber num1 = new ExpNumber(1.5432, 4);
            ExpNumber num2 = new ExpNumber(1, -18);
            num1.Multiply(num2);
            Assert.Equal(new ExpNumber(1.5432, -14), num1);
        }

        [Fact]
        public void MultiplyManyNubmers()
        {
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                double num1 = random.Next(0, 10000);
                double num2 = random.Next(0, 10000);
                ExpNumber num1Exp = new ExpNumber(num1, 0);
                ExpNumber num2Exp = new ExpNumber(num2, 0);
                num1Exp.Multiply(num2Exp);
                ExpNumber expected = new ExpNumber(num1 * num2, 0);
                ExpNumber actual = num1Exp;
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void TestMultiplyReallyBigNubmer()
        {
            ExpNumber num1 = new ExpNumber(1, 1000000000);
            ExpNumber num2 = new ExpNumber(1, 1000000000);
            num1.Multiply(num2);
            Assert.Equal(new ExpNumber(1, 2000000000), num1);
        }

        #endregion

        #region Testing Division of ExpNumbers

        [Fact]
        public void TestManyDivisions()
        {
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                double num1 = random.Next(0, 100000);
                double num2 = random.Next(0, 100000);
                ExpNumber num1Exp = new ExpNumber(num1, 0);
                ExpNumber num2Exp = new ExpNumber(num2, 0);
                num1Exp.Divide(num2Exp);
                ExpNumber actual = num1Exp;
                ExpNumber expected = new ExpNumber(num1 / num2, 0);
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void TestLargeDivision()
        {
            ExpNumber num1 = new ExpNumber(5.0, 100000000);
            ExpNumber num2 = new ExpNumber(2.0, 100000000);
            ExpNumber expected = new ExpNumber(2.5, 0);
            num1.Divide(num2);
            Assert.Equal(expected, num1);

            num1 = new ExpNumber(5.0, 766421642);
            num2 = new ExpNumber(2.0, 511374511);
            expected = new ExpNumber(2.5, 255047131);
            num1.Divide(num2);
            Assert.Equal(expected, num1);

            num1 = new ExpNumber(9, 421345188);
            num2 = new ExpNumber(1.0, 0);
            expected = new ExpNumber(9.0, 421345188);
            num1.Divide(num2);
            Assert.Equal(expected, num1);

            num1 = new ExpNumber(10, 421345188);
            num2 = new ExpNumber(1.0, 1);
            expected = new ExpNumber(1.0, 421345188);
            num1.Divide(num2);
            Assert.Equal(expected, num1);
        }

        [Fact]
        public void TestNegativeDivision()
        {
            ExpNumber num1 = new ExpNumber(-5.0, 100000000);
            ExpNumber num2 = new ExpNumber(2.0, 100000000);
            ExpNumber expected = new ExpNumber(-2.5, 0);
            num1.Divide(num2);
            Assert.Equal(expected, num1);

            num1 = new ExpNumber(-5.0, 766421642);
            num2 = new ExpNumber(-2.0, 511374511);
            expected = new ExpNumber(2.5, 255047131);
            num1.Divide(num2);
            Assert.Equal(expected, num1);

            num1 = new ExpNumber(9, 421345188);
            num2 = new ExpNumber(-1.0, 0);
            expected = new ExpNumber(-9.0, 421345188);
            num1.Divide(num2);
            Assert.Equal(expected, num1);

            num1 = new ExpNumber(-10, 421345188);
            num2 = new ExpNumber(-1.0, 1);
            expected = new ExpNumber(1.0, 421345188);
            num1.Divide(num2);
            Assert.Equal(expected, num1);

        }
        #endregion


        #region Adding ExpNumbers together
        [Fact]
        public void TestAdd500and100()
        {
            ExpNumber number = new ExpNumber(5, 2);
            number.Add(new ExpNumber(1, 2));
            Assert.Equal(6f, number.significand);
            Assert.Equal(2, number.magnitude);
        }

        [Fact]
        public void TestAdd35and15()
        {
            ExpNumber number = new ExpNumber(3.5, 1);
            number.Add(new ExpNumber(1.5, 1));
            Assert.Equal(5f, number.significand);
            Assert.Equal(1, number.magnitude);
        }

        [Fact]
        public void TestAdd96and1534()
        {
            ExpNumber number = new ExpNumber(9.6, 1);
            number.Add(new ExpNumber(1.534, 3));
            Assert.Equal(1.63, number.significand);
            Assert.Equal(3, number.magnitude);
        }

        [Fact]
        public void TestAdd1534and96()
        {
            ExpNumber number = new ExpNumber(1.534, 3);
            number.Add(new ExpNumber(9.6, 1));
            Assert.Equal(1.63, number.significand);
            Assert.Equal(3, number.magnitude);
        }

        [Fact]
        public void TestAddRandomNumbers()
        {
            ExpNumber number = new ExpNumber(9.6, 1);
            number.Add(new ExpNumber(1.534, 3));
            Assert.Equal(1.63, number.significand);
            Assert.Equal(3, number.magnitude);
        }

        [Fact]
        public void TestAddHugeToSmall()
        {
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                ExpNumber smallNumber = new ExpNumber(random.Next(1, 99) / 10.0,
                                                        random.Next(0, 10));
                ExpNumber largeNumber = new ExpNumber(random.Next(1, 99) / 10.0,
                                                        random.Next(10000, 1000000000));
                ExpNumber temp = smallNumber.Clone();
                String expectedMessage = String.Format("Expected: {0} + {1} = {2}\n",
                                                    smallNumber.ToString(),
                                                    largeNumber.ToString(),
                                                    largeNumber.ToString());

                smallNumber.Add(largeNumber);
                String actualMessage = String.Format(" Actual: {0} + {1} = {2}",
                                                    temp.ToString(),
                                                    largeNumber.ToString(),
                                                    smallNumber.ToString());
                Assert.True(smallNumber.Equals(largeNumber), expectedMessage + actualMessage);
                largeNumber.Add(temp);
                Assert.True(smallNumber.Equals(largeNumber), expectedMessage + actualMessage);
            }
        }

        [Fact]
        public void TestManyAdditions()
        {
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                double num1 = random.Next(0, 100000);
                double num2 = random.Next(0, 100000);
                ExpNumber num1Exp = new ExpNumber(num1, 0);
                ExpNumber num2Exp = new ExpNumber(num2, 0);
                num1Exp.Add(num2Exp);
                ExpNumber actual = num1Exp;
                ExpNumber expected = new ExpNumber(num1 + num2, 0);
                Assert.Equal(expected, actual);
            }
        }

        #endregion

        #region Testing Subtraction of ExpNumbers

        [Fact]
        public void TestManySmallSubtractions()
        {
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                double num1 = random.Next(-100000, 100000);
                double num2 = random.Next(-100000, 100000);
                ExpNumber num1Exp = new ExpNumber(num1, 0);
                ExpNumber num2Exp = new ExpNumber(num2, 0);
                num1Exp.Subtract(num2Exp);
                ExpNumber actual = num1Exp;
                ExpNumber expected = new ExpNumber(num1 - num2, 0);
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void TestSubtractHugeToSmall()
        {
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                ExpNumber smallNumber = new ExpNumber(random.Next(1, 99) / 10.0,
                                                        random.Next(0, 10));
                ExpNumber largeNumber = new ExpNumber(random.Next(1, 99) / 10.0,
                                                        random.Next(10000, 1000000000));
                ExpNumber temp = smallNumber.Clone();
                String expectedMessage = String.Format("Expected: {0} + {1} = {2}\n",
                                                    smallNumber.ToString(),
                                                    largeNumber.ToString(),
                                                    largeNumber.ToString());

                smallNumber.Subtract(largeNumber);
                String actualMessage = String.Format(" Actual: {0} + {1} = {2}",
                                                    temp.ToString(),
                                                    largeNumber.ToString(),
                                                    smallNumber.ToString());
                Assert.True(smallNumber.Equals(largeNumber), expectedMessage + actualMessage);
                largeNumber.Add(temp);
                Assert.True(smallNumber.Equals(largeNumber), expectedMessage + actualMessage);
            }
        }


        #endregion

        #region Testing Equality

        [Fact]
        public void TestReflexiveProperty()
        {
            ExpNumber num1 = new ExpNumber(4.23, 59);
            ExpNumber num2 = new ExpNumber(4.23, 59);

            Assert.Equal(num1, num2);
        }

        [Fact]
        public void TestOutsidePrecisionNext()
        {
            ExpNumber num1 = new ExpNumber(4.123456789, 59);
            ExpNumber num2 = new ExpNumber(4.12345, 59);
            Assert.Equal(num1, num2);
        }

        [Fact]
        public void TestInsidePrecisionNext()
        {
            ExpNumber num1 = new ExpNumber(4.2, 59);
            ExpNumber num2 = new ExpNumber(4.12345, 59);
            Assert.NotEqual(num1, num2);
        }

        [Fact]
        public void TestInsidePrecisionNextMagnitude()
        {
            ExpNumber num1 = new ExpNumber(4.12345, 54);
            ExpNumber num2 = new ExpNumber(4.12345, 59);
            Assert.NotEqual(num1, num2);
        }

        [Fact]
        public void TestVeryLargeNumbers()
        {
            ExpNumber num1 = new ExpNumber(4.12345, int.MaxValue);
            ExpNumber num2 = new ExpNumber(4.12345, int.MaxValue);
            Assert.Equal(num1, num2);
        }

        #endregion



        //Test differences in magnitude greater than 100
        // Make sure to test this where both the starting number is the large and small number


    }
}