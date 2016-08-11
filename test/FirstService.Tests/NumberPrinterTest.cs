using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using FirstService;

namespace InterviewPracticeTest
{
    public class NumberPrinterTest
    {
        private NumberPrinter printer;

        public void setup()
        {
            printer = new NumberPrinter();
        }

        [Fact]
        public void GetNumbersUsingWhereReturnsOnlyNumbersFromString()
        {
            setup();
            Assert.Equal("123", printer.GetNumbersUsingWhere("Hello12This3"));
        }

        [Fact]
        public void GetNumbersUsingWhereReturnsEmptyStringWithNullString()
        {
            setup();
            Assert.Equal("", printer.GetNumbersUsingWhere(null));
        }

        [Fact]
        public void GetNumbersUsingForEachLoopReturnsOnlyNumbersFromString()
        {
            setup();
            Assert.Equal("123", printer.GetNumbersUsingForEachLoop("Hello12This3"));
        }

        [Fact]
        public void GetNumbersUsingForEachLoopReturnsEmptyStringWithNullString()
        {
            setup();
            Assert.Equal("", printer.GetNumbersUsingForEachLoop(null));
        }

        [Fact]
        public void GetNumbersUsingForLoopReturnsOnlyNumbersFromString()
        {
            setup();
            Assert.Equal("123", printer.GetNumbersUsingForLoop("Hello12This3"));
        }

        [Fact]
        public void GetNumbersUsingForLoopReturnsEmptyStringWithNullString()
        {
            setup();
            Assert.Equal("", printer.GetNumbersUsingForLoop(null));
        }

        [Fact]
        public void GetNumbersUsingLinqReturnsOnlyNumbersFromString()
        {
            setup();
            Assert.Equal("123", printer.GetNumbersUsingLinq("Hello12This3"));
        }

        [Fact]
        public void GetNumbersUsingLinqReturnsEmptyStringWithEmptyString()
        {
            setup();
            Assert.Equal("", printer.GetNumbersUsingLinq(""));
        }

        [Fact]
        public void GetNumbersUsingLinqReturnsEmptyStringWithNull()
        {
            setup();
            Assert.Equal("", printer.GetNumbersUsingLinq(null));
        }

        [Fact]
        public void CountWordsInStringReturnsCorrectCountWithMatchingWordsRegardlessOfCase()
        {
            setup();
            Assert.Equal(3, printer.CountWordsInString("Hello", "Hello Hello Helll HELLO To You"));
        }

        [Fact]
        public void CountWordsInStringReturnsCorrectCountWithNoMatchingWords()
        {
            setup();
            Assert.Equal(0, printer.CountWordsInString("HelloX", "Hello Hello Helll To You"));
        }

        [Fact]
        public void CountWordsInStringReturnsCorrectCountWithSingleString()
        {
            setup();
            Assert.Equal(0, printer.CountWordsInString("Hello", "HelloHelloHelllToYou"));
        }

        [Fact]
        public void CountWordsInStringReturnsCorrectCountWithNullString()
        {
            setup();
            Assert.Equal(0, printer.CountWordsInString("Hello", null));
        }

        [Fact]
        public void SortWordsAlphabeticallySortsWordsInAlphabeticalOrder()
        {
            setup();
            String sortedResult = printer.SortWordsAlphabetically("AAA DDD CCC BBB");
            Assert.Equal("AAA BBB CCC DDD", sortedResult);
        }

        [Fact]
        public void SortWordsAlphabeticallyReturnsEmptyStringWithNullArgument()
        {
            setup();
            Assert.Equal("", printer.SortWordsAlphabetically(null));
        }

        [Fact]
        public void SentanceContainsWordsReturnsTrueWhenSentanceContainsWords()
        {
            setup();
            string[] wordsToFind = { "AAA", "CCC" };
            Assert.True(printer.SentanceContainsWords("AAA BBB CCC. AAA BBB DDD.", wordsToFind));
        }

        [Fact]
        public void SentanceContainsWordsReturnsFalseWhenSentanceHasNoWords()
        {
            setup();
            string[] wordsToFind = { "AAA", "CCC" };
            Assert.False(printer.SentanceContainsWords("BBB. AAA DDD.", wordsToFind));
        }

        [Fact]
        public void SentanceContainsWordsReturnsFalseWhenSentanceIsNull()
        {
            setup();
            string[] wordsToFind = { "AAA", "CCC" };
            Assert.False(printer.SentanceContainsWords(null, wordsToFind));
        }

    }
}
