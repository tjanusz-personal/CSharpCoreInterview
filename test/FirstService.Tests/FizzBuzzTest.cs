using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Xunit;

namespace FirstService.Tests
{

    public class FizzBuzzTest
    {
        private FizBuzz buzz;

        public void setup()
        {
            buzz = new FizBuzz();
        }

        private void runGetStringValueScenario(List<int> numbersToVerify, String valueToAssert)
        {
            numbersToVerify.ForEach(x =>
            {
                Assert.Equal(buzz.GetStringValue(x), valueToAssert);
            });

        }

        [Fact]
        public void TestGetStringValueReturnsFizzBuzzValuesCorrectly2()
        {
            setup();
            List<int> numbersDivisibleBy5And3 = Enumerable.Range(1, 100).Where(x => (x % 3) == 0 && (x % 5) == 0).ToList();
            Assert.Equal(6, numbersDivisibleBy5And3.Count);
            runGetStringValueScenario(numbersDivisibleBy5And3, "FizzBuzz");
        }

        [Fact]
        public void TestGetStringValueReturnsFizzCorrectly()
        {
            setup();
            List<int> numbersDivisibleBy3Only = Enumerable.Range(1, 100).Where(x => (x % 3) == 0 && (x % 5) != 0).ToList();
            Assert.Equal(27, numbersDivisibleBy3Only.Count);
            runGetStringValueScenario(numbersDivisibleBy3Only, "Fizz");
        }

        [Fact]
        public void TestGetStringReturnsBuzzCorrectly()
        {
            setup();
            List<int> numbersDivisibleBy5Only = Enumerable.Range(1, 100).Where(x => (x % 5) == 0 && (x % 3) != 0).ToList();
            Assert.Equal(14, numbersDivisibleBy5Only.Count);
            runGetStringValueScenario(numbersDivisibleBy5Only, "Buzz");
        }

        [Fact]
        public void TestGetStringReturnsNonFizzBuzzNumbersCorrectly()
        {
            setup();
            List<int> numbersNotDivisibleBy5Or3 = Enumerable.Range(1, 100).Where(x => (x % 5) != 0 && (x % 3) != 0).ToList();
            Assert.Equal(53, numbersNotDivisibleBy5Or3.Count);
            numbersNotDivisibleBy5Or3.ForEach(x =>
            {
                Assert.Equal(x.ToString(), buzz.GetStringValue(x));
            });
        }


    }
}
