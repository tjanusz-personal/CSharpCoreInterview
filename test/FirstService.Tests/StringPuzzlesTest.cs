using Xunit;
using System;
using System.Collections.Generic;

namespace FirstService.Tests
{

    public class StringPuzzlesTests {

        private StringPuzzles puzzler;

        private void Setup() {
            puzzler = new StringPuzzles();
        }

        [Fact]
        public void TestDuplicateCharactersInStringReturnsDuplicates() {
            Setup();
            String duplicates = puzzler.DuplicateCharactersInString("HelloWorld");
            Assert.Equal("lo", duplicates);
        }

        [Fact]
        public void TestIsAnagramReturnsTrueForMatchingStrings() {
            Setup();
            Assert.True(puzzler.IsAnagram("hello", "llohe"));
        }

        [Fact]
        public void TestIsAnagram2ReturnsTrueForMatchingStrings() {
            Setup();
            Assert.True(puzzler.IsAnagram2("hello", "llohe"));
        }

        [Fact]
        public void TestReturnFirstNonRepeatingCharacter() {
            Setup();
            Assert.Equal('h', puzzler.ReturnFirstNonRepeatingCharacter("hello"));
        }

        [Fact]
        public void TestReturnFirstNonRepeatingCharacterReturnsDefaultCharWhenNonePresent() {
            Setup();
            Assert.Equal('\0', puzzler.ReturnFirstNonRepeatingCharacter("ollo"));
        }

        [Fact]
        public void TestReverseStringUsingIterationWorksCorrectly() {
            Setup();
            Assert.Equal("olleh", puzzler.ReverseStringUsingIteration("hello"));
        }

        [Fact]
        public void TestReverseStringUsingRecusrionWorksCorrectly() {
            Setup();
            Assert.Equal("olleh", puzzler.ReverseStringUsingRecursion("hello"));
        }

        [Fact]
        public void ContainsOnlyDigitsReturnsTrueForDigitString() {
            Setup();
            Assert.True(puzzler.ContainsOnlyDigits("12345643"));
        }

        [Fact]
        public void ContainsOnlyDigitsReturnsFalseForDigitString() {
            Setup();
            Assert.False(puzzler.ContainsOnlyDigits("1A2345643"));
        }

        [Fact]
        public void CountNumConsonantsReturnsCorrectNumber() {
            Setup();
            Assert.Equal(3, puzzler.CountNumConsonants("AEIOullw"));
        }

        [Fact]
        public void CountNumConsonantsReturnsZeroIfNonFound() {
            Setup();
            Assert.Equal(0, puzzler.CountNumConsonants("AEIOU"));
        }

        [Fact]
        public void CountNumConsonantsAndVowelsReturnsProperString() {
            Setup();
            Assert.Equal("consonant: 3 vowels: 5", puzzler.CountNumConsonantsAndVowels("AEIOUlly"));
        }

        [Fact]
        public void CountNumConsonantsAndVowelsReturnsProperStringWithMixedCase() {
            Setup();
            Assert.Equal("consonant: 3 vowels: 5", puzzler.CountNumConsonantsAndVowels("AeiOUlLy"));
        }

        [Fact]
        public void PermutationsOfStringReturnsCorrectSetofPermutations() {
            Setup();
            List<String> actualStringPermutations = puzzler.PermutationsOfString("xyz");
            Assert.Equal(6, actualStringPermutations.Count);
        }

        [Fact]
        public void PermutationsOfStringReturnsCorrectSetofPermutationsWithAllSameChars() {
            Setup();
            List<String> actualStringPermutations = puzzler.PermutationsOfString("xxx");
            Assert.Equal(1, actualStringPermutations.Count);
        }

        [Fact]
        public void IsPalindromeReturnsTrueForPalindrome() {
            Setup();
            Assert.True(puzzler.IsPalindrome("abba"));
            Assert.True(puzzler.IsPalindrome("a"));
            Assert.True(puzzler.IsPalindrome("aba"));
        }

        [Fact]
        public void IsPalindromeReturnsFalseForPalindrome() {
            Setup();
            Assert.False(puzzler.IsPalindrome("abbaa"));
            Assert.False(puzzler.IsPalindrome(""));
            Assert.False(puzzler.IsPalindrome(null));
        }

        [Fact]
        public void RemoveDuplicatesRemovesLetters() {
            Setup();
            Assert.Equal("tes", puzzler.RemoveDuplicates("test"));
        }

        [Fact]
        public void RemoveDuplicatesRemovesLettersWithMixedCase() {
            Setup();
            Assert.Equal("tes", puzzler.RemoveDuplicates("tesT"));
            Assert.Equal("tes ", puzzler.RemoveDuplicates("tes T "));
        }



    }

}
