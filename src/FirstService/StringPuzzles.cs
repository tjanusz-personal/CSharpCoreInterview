using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Text;

namespace FirstService
{
    public class StringPuzzles {

        public String DuplicateCharactersInString(String theString) {
            char[] charArray = theString.ToCharArray();
            var duplicates = charArray.GroupBy(x => x).Where(y => y.Count() > 1).Select(k => k.Key).ToArray();
            return new String(duplicates);
        }

        public bool IsAnagram(String firstString, String secondString) {
            // TODO: strip off invalid characters..
            char[] firstArray = firstString.ToArray();
            char[] secondArray = secondString.ToArray();
            Array.Sort(firstArray);
            Array.Sort(secondArray);
            String sortedString1 = new String(firstArray);
            String sortedString2 = new String(secondArray);
            return sortedString1.Equals(sortedString2);
        }

        public bool IsAnagram2(String firstString, String secondString) {
            return firstString.OrderBy(x => x).SequenceEqual(secondString.OrderBy(y => y));
        }

        public char ReturnFirstNonRepeatingCharacter(String theString) {
            return theString.GroupBy(x => x).Where(y => y.Count() == 1).Select(k => k.Key).FirstOrDefault();
        }

        public String ReverseStringUsingIteration(String originalString) {
            int originalStringLength = originalString.Length;
            char[] reverseArray = new char[originalStringLength];
            char[] stringCharArray = originalString.ToArray();
            for (int backwardsCounter = originalStringLength -1, forwardsCounter = 0; backwardsCounter >=0; 
                backwardsCounter--, forwardsCounter++) {
                    reverseArray[forwardsCounter] = stringCharArray[backwardsCounter];
            }
            return new String(reverseArray);
        }

        public String ReverseStringUsingRecursion(String originalString) {
            if (originalString.Length < 2) {
                return originalString;
            }
            return ReverseStringUsingRecursion(originalString.Substring(1)) + originalString.ToArray()[0];
        }

        public bool ContainsOnlyDigits(String originalString) {
            return originalString.All(x => Char.IsDigit(x));
        }

        public int CountNumConsonants(String originalString) {
            char[] consonantArray = {'A', 'E','I','O','U'};
            Func<char, bool> isConsonant = (x => Array.IndexOf(consonantArray, x) < 0);
            return originalString.ToUpper().ToArray().Where(isConsonant).Count();
        }

        public String CountNumConsonantsAndVowels(String originalString) {
            char[] consonantArray = {'A', 'E','I','O','U'};
            int consonants = 0, vowels = 0;
            foreach (char theChar in originalString.ToUpper().ToArray()) {
                if (Array.IndexOf(consonantArray, theChar) > -1) {
                    vowels++;
                } else {
                    consonants++;
                }
            }
            StringBuilder buffer = new StringBuilder();
            buffer.Append("consonant: ").Append(consonants).Append(" vowels: ").Append(vowels);
            return buffer.ToString();
        }

        public List<String> PermutationsOfString(String theString) {
            HashSet<String> permutationList = new HashSet<String>();
            char[] charArray = theString.ToArray(); 
            int stringLength = charArray.Length - 1;
            permute(charArray, 0, stringLength, permutationList);
            
            return permutationList.ToList();
        }

        private void permute(char[] arrayOfChars, int recursiveDepth, int maxDepth, HashSet<String> permutationList)
        {
            int j;
            if (recursiveDepth==maxDepth) {
                // Console.WriteLine(arrayOfChars);
                permutationList.Add(new String(arrayOfChars));
            }
            else
            {
                for(j = recursiveDepth; j <=maxDepth; j++)
                {
                    swap(ref arrayOfChars[recursiveDepth],ref arrayOfChars[j]);
                    permute(arrayOfChars,recursiveDepth+1,maxDepth, permutationList);
                    swap(ref arrayOfChars[recursiveDepth], ref arrayOfChars[j]); //backtrack
                }
            }
        }

        private void swap(ref char a, ref char b)
        {
            char tmp;
            tmp = a;
            a=b;
            b = tmp;
        }

        public bool IsPalindrome(String theString) {
            if (theString == null || theString.Length == 0) {
                return false;
            } else if (theString.Length == 1) {
                return true;
            }
            for (int forwardPos = 0, backwardPos = theString.Length - 1; forwardPos < theString.Length; forwardPos++, backwardPos--) {
                if (theString[forwardPos] != theString[backwardPos]) {
                    return false;
                }
            }
            return true;
        }

        public String RemoveDuplicates(String theString) {
            Dictionary<char,int> uniqueChars = new Dictionary<char,int>();
            StringBuilder buffer = new StringBuilder();
            foreach (char theChar in theString.ToArray()) {
                if (uniqueChars.ContainsKey(Char.ToUpper(theChar))) {
                    continue;
                } else {
                    uniqueChars.Add(Char.ToUpper(theChar), 1);
                    buffer.Append(theChar);
                }
            }
            return buffer.ToString();
        }

    }
}