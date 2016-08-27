using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FirstService.Tests
{
    public class EnumerableTest
    {

        [Fact]
        public void IntersectOnTwoEnumerablesReturnsIntersectionWithOneMatchingItem()
        {
            string[] someWords = { "AAA", "CCC" };
            string[] moreWords = { "AAA", "DDD" };
            IEnumerable<string> stringsInCommon = someWords.Intersect(moreWords);
            Assert.Equal(1, stringsInCommon.Count());
            Assert.True(stringsInCommon.Any());
            Assert.Equal("AAA", stringsInCommon.First());
            string[] expectedArray = { "AAA" };
            Assert.Equal( expectedArray, stringsInCommon.ToArray());
        }

        [Fact]
        public void IntersectOnTwoEnumerablesReturnsIntersectionWithTwoMatchingItems()
        {
            string[] moreWords = { "AAA", "DDD" };
            string[] someWords = { "AAA", "CCC", "DDD", "AAA" };
            IEnumerable<string> stringsInCommon = someWords.Intersect(moreWords);
            Assert.Equal(2, stringsInCommon.Count());
            Assert.Equal(moreWords, stringsInCommon.ToArray());
        }

        [Fact]
        public void ExceptOnTwoEnumerablesReturnsNonMatchingItems()
        {
            string[] someWords = { "AAA", "CCC", "DDD", "EEE" };
            string[] moreWords = { "AAA", "DDD" };
            IEnumerable<string> stringsNotInCommon = someWords.Except(moreWords);
            string[] nonMatchingItems = { "CCC", "EEE" };
            Assert.Equal(nonMatchingItems, stringsNotInCommon.ToArray());
        }

        private IEnumerable<String> getStringList()
        {
            List<String> stringList = new List<String>() { "AAA", "BBBB", "CCCC" };
            return stringList.AsEnumerable();
        }

        [Fact]
        public void AnyReturnsTrueForFoundItem()
        {
            Assert.True(getStringList().Any());
            Assert.True(getStringList().Contains("AAA"));
            Assert.False(getStringList().Contains("DDD"));
        }

        [Fact]
        public void AverageReturnsAverageStringLengths()
        {
            double average = getStringList().Average(s => s.Length);
            Assert.Equal(3.67, average, 1);
        }

        [Fact]
        public void CountReturnsTotalCountOfStrings()
        {
            Assert.Equal(3, getStringList().Count());
            Assert.Equal(2, getStringList().Count(s => s.Length == 4));
        }

        [Fact]
        public void DistinctReturnsUniqueSet()
        {
            List<String> stringList = new List<String>() { "AAA", "BBBB", "BBBB" };
            string[] distinctItems = { "AAA", "BBBB" };
            Assert.Equal(distinctItems, stringList.AsEnumerable().Distinct().ToArray());
            string[] distinctItems2 = { "AAA", "BBBB" };
            stringList = new List<String>() { "AAA", "BBBB", "bbbb" };
            Assert.Equal(distinctItems2, stringList.AsEnumerable().Distinct(StringComparer.OrdinalIgnoreCase).ToArray());
        }

        [Fact]
        public void LastReturnsLastItem()
        {
            String lastItem = getStringList().Last();
            Assert.Equal("CCCC", lastItem);
            lastItem = getStringList().Last(s => s.Length == 3);
            Assert.Equal("AAA", lastItem);
            Assert.Null(getStringList().LastOrDefault(s => s.Length == 2));
        }

        [Fact]
        public void DefaultIfEmptyDefaultsEmptyList()
        {
            List<String> stringList = new List<String>();
            Assert.Equal("Empty", stringList.DefaultIfEmpty("Empty").LastOrDefault());
            Assert.Null(stringList.DefaultIfEmpty("Empty").LastOrDefault(s => s.Length == 2));
        }

        [Fact]
        public void LongCountReturnsSize()
        {
            Assert.Equal(3, getStringList().LongCount());
            Assert.Equal(2, getStringList().LongCount(s => s.Length == 4));
            Assert.Equal(0, getStringList().LongCount(s => s.Length == 2));
        }

        [Fact]
        public void MaxReturnsMaxItem()
        {
            List<int> intList = new List<int>() { 100, 400, 200 };
            Assert.Equal(400, intList.Max());
            Assert.Equal(800, intList.Max(s => s * 2));
        }

        [Fact]
        public void MinReturnsMinItem()
        {
            List<int> intList = new List<int>() { 200, 400, 150 };
            Assert.Equal(150, intList.Min());
            Assert.Equal(300, intList.Min(s => s * 2));
        }

        [Fact]
        public void SequenceEqualComparesCorrectly()
        {
            List<int> intList = new List<int>() { 200, 400 };
            List<int> intList2 = new List<int>() { 200, 400 };
            Assert.True(intList.SequenceEqual(intList2));
            List<int> intList3 = new List<int>() { 400, 200 };
            Assert.False(intList.SequenceEqual(intList3));
            intList3.Reverse();
            Assert.True(intList.SequenceEqual(intList3));
        }

        [Fact]
        public void SequenceEqualComparesStringsCorrectly()
        {
            List<String> stringList = new List<String>() { "One", "Two", "Three" };
            List<String> stringList2 = new List<String>() { "ONE", "TWO", "THREE" };
            Assert.False(stringList.SequenceEqual(stringList2));
            Assert.True(stringList.SequenceEqual(stringList2, StringComparer.OrdinalIgnoreCase));
        }

        [Fact]
        public void SingleReturnsOnlyItem()
        {
            List<String> stringList = new List<String>() { "One" };
            Assert.Equal("One", stringList.Single());
            stringList = new List<String>() { "One", "Two" };
            Assert.Equal("One", stringList.Single(s => s.Equals("One")));
        }

        [Fact]
        public void SingleThrowsInvalidOperationExceptionOnMoreThanOneMatching()
        {
            List<String> stringList = new List<String>() { "One", "Two" };
            Assert.Throws<InvalidOperationException>(() => stringList.Single(s => s.Length == 3));
        }

        [Fact]
        public void SkipBypassesElements()
        {
            List<String> stringList = new List<String>() { "One", "Two" };
            Assert.Equal("Two", stringList.Skip(1).Single(s => s.Length == 3));
            Assert.Equal("Two", Enumerable.Skip(stringList, 1).Single(s => s.Length == 3));
        }

        [Fact]
        public void SkipWhileBypassesMatchinElements()
        {
            List<String> stringList = new List<String>() { "One", "Two", "Three" };
            Assert.Equal("Three", stringList.SkipWhile(s => s.Length == 3).Single());
        }

        [Fact]
        public void SumReturnsTotalLengthOfStringsInList()
        {
            List<String> stringList = new List<String>() { "One", "Two", "Three" };
            Assert.Equal(11, stringList.Sum(s => s.Length));
            Assert.Equal(11, Enumerable.Sum(stringList, s => s.Length));
        }

        [Fact]
        public void TakePullsTheNumberSpecifiedOffEnumerable()
        {
            List<String> stringList = new List<String>() { "One", "Two", "Three" };
            Assert.Equal("One", stringList.Take(1).Single());
        }

        [Fact]
        public void TakeWhileStopsAfterStringNotLength3()
        {
            List<String> stringList = new List<String>() { "One", "Two", "Three" };
            IEnumerable<String> valueEnumerator = stringList.TakeWhile(s => s.Length == 3);
            List<String> expectedStrings = new List<String>() { "One", "Two" };
            Assert.Equal(expectedStrings, valueEnumerator.ToList());
        }

        [Fact]
        public void ThenByOrdersStringsAlphabetically()
        {
            List<String> stringList = new List<String>() { "Three", "Two", "One", "Four" };
            List<String> sortedList = stringList.OrderBy(s => s.Length).ThenBy(s => s).ToList();
            List<String> expectedStrings = new List<String>() { "One", "Two", "Four", "Three" };
            Assert.Equal(expectedStrings, sortedList);
        }

        [Fact]
        public void OrderByDescendingOrdersStringsByLength()
        {
            List<String> stringList = new List<String>() { "Three", "Two", "One", "Four", "Five" };
            List<String> sortedList = stringList.OrderByDescending(s => s.Length).ThenByDescending(s => s).ToList();
            List<String> expectedStrings = new List<String>() { "Three",  "Four", "Five", "Two", "One" };
            Assert.Equal(expectedStrings, sortedList);
        }

        [Fact]
        public void ThenByDescendingOrdersStringsReverseAlphabetically()
        {
            List<String> stringList = new List<String>() { "Three", "Two", "One", "Four", "Five" };
            List<String> sortedList = stringList.OrderBy(s => s.Length).ThenByDescending(s => s).ToList();
            List<String> expectedStrings = new List<String>() { "Two", "One", "Four", "Five", "Three" };
            Assert.Equal(expectedStrings, sortedList);
        }

        [Fact]
        public void RepeatRepeatsItem()
        {
            List<String> repeatedList = Enumerable.Repeat("One", 3).ToList();
            List<String> expectedStrings = new List<String>() { "One", "One", "One" };
            Assert.Equal(expectedStrings, repeatedList);
        }

        [Fact]
        public void TestOnlyCountsEvenIntegersCorrectly() {
            int [] theIntegers = { 1, 2, 3, 4, 5, 6, 7, 8};
            int theSum = theIntegers.AsEnumerable().Where(x => x % 2 == 0).Sum();
            Assert.Equal(20, theSum);
        }

        [Fact]
        public void TestOnlyCountsOddIntegersCorrectly() {
            int [] theIntegers = { 1, 2, 3, 4, 5, 6, 7, 8};
            int theSum = theIntegers.AsEnumerable().Where(x => x % 2 != 0).Sum();
            Assert.Equal(16, theSum);
        }

    }
}
