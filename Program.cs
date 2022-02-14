// Naga Chaitanya Chintalapudi

using System;
using System.Collections.Generic;

namespace DISassignment2
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            
            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
           
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {

                int low = 0, high = nums.Length-1;
                int mid = 0;

                while (low <= high)
                {
                    // Get the index of mid element
                    mid = (low + high) / 2;

                    // check if mid element is the target, return the index.
                    if (nums[mid] == target)
                    {
                        return mid;
                    }
                    // if mid element is greater than target, then our target element will be on left side of the mid. Update the high.
                    else if (nums[mid] > target)
                    {
                        high = mid - 1;
                    }
                    // if mid element is lower than target, then our target element will be on right side of the mid. Update the low.
                    else
                    {
                        low = mid + 1;
                    }
                }
                // return the index.
                return low;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Concat("Exception in SearchInsert ", ex.Message));
                throw;
            }
        }

        /*

           Question 2

           Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned. It is guaranteed there is at least one word that is not banned, and that the answer is unique.
           The words in paragraph are case-insensitive and the answer should be returned in lowercase.

           Example 1:
           Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
           Output: "ball"
           Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph. 
           Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.

           Example 2:
           Input: paragraph = "a.", banned = []
           Output: "a"
           */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                // Update the string to lowercase.
                paragraph = paragraph.ToLower();

                // Replace the banned words in the paragraph.
                foreach (var b in banned)
                {
                    paragraph = paragraph.Replace(b, "");
                }

                // Split the paragraph to words 
                string[] specialEngChar = { ".", ",", "!", "?", "\'", ";", "\"", " " };
                string[] words = paragraph.Split(specialEngChar, StringSplitOptions.RemoveEmptyEntries);


                int maxCount = 0;
                string mostFrequentWord = "";


                for (int i = 0; i < words.Length; i++)
                {
                    int count = 0;
                    for (int j = i + 1; j < words.Length - 1; j++)
                    {
                        // count the words if they repeat
                        if (words[i].Equals(words[j]))
                        {
                            count++;
                        }
                    }

                    //  If the current count is greater than maxCount, update the maxCount and mostFrequentWord.
                    if (count > maxCount)
                    {
                        maxCount = count;
                        mostFrequentWord = words[i];
                    }

                }

                return mostFrequentWord;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Concat("Exception in MostCommonWord ", ex.Message));
                throw;
            }
        }

        /*Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.


        Example 1:
        Input: arr = [2, 2, 3, 4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.

        Example 2:
        Input: arr = [1, 2, 2, 3, 3, 3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.

        Example 3:
        Input: arr = [2, 2, 2, 3, 3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                /* Solution which is O(n2)
                 * 
                 * int num = -1;
                 for (int i=0; i< arr.Length; i++) {
                     int count = 1;
                     for (int j = i+1; j < arr.Length-1; j++) {

                         if (arr[i] == arr[j])
                         {
                             count++;
                         }
                     }
                     if (count == arr[i]) {
                         num = arr[i];
                     }

               }*/


                var map = new Dictionary<int, int>();

                // Add element and count into the dictionary
                for (int i = 0; i < arr.Length; i++)
                {
                    if (map.ContainsKey(arr[i]))
                    {
                        map[arr[i]] += 1;
                    }
                    else
                    {
                        map.Add(arr[i], 1);
                    }

                }

                int max = -1;
                // Get the count which is equal to its number.
                foreach (var pair in map)
                {
                    if (pair.Key == pair.Value && max < pair.Value)
                    {
                        max = pair.Value;
                    }
                }

                return max;
            }
            catch (Exception ex)
            {

                Console.WriteLine(String.Concat("FindLucky", ex.Message));
                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"

        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                int bulls = 0, cows = 0;

                // Array to count the secret and guess characters
                int[] countSecret = new int[10];
                int[] countGuess = new int[10];

                for (int i = 0; i < secret.Length; i++)
                {
                    // If character is in same position, increment the bulls count.
                    if (secret[i] == guess[i])
                    {
                        bulls++;
                    }
                    else
                    {
                        // If character is not in same position, increment the count of that character in countSecret and countGuess.
                        countSecret[secret[i] - '0']++;
                        countGuess[guess[i] - '0']++;
                    }
                }

                for (int i = 0; i < 10; i++)
                {
                    // If countSecret and countGuess are equal, then update the cows count.
                    if (countSecret[i] == countGuess[i])
                    {
                        cows += countSecret[i];
                    }
                    // Else take the minimum of countSecret and countGuess and update the cows count. This avoids counting the same character more than once.
                    else
                    {
                        cows += Math.Min(countSecret[i], countGuess[i]);
                    }
                }

                return bulls + "A" + cows + "B";
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Concat("GetHint", ex.Message));
                throw;
            }
        }

        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.

        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.

        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                // Iterate over the string and copy the index value of the characters to the letterIndex Array.
                int[] lettersIndex = new int[26];
                for (int i = 0; i < s.Length; i++)
                {
                    lettersIndex[s[i] - 'a'] = i;
                }

                int startIndex = 0, endIndex = 0;

                var parititonList = new List<int>();

                // Update the start and endIndex of a character. Find the parition.
                for (int i = 0; i < s.Length; i++)
                {
                    endIndex = Math.Max(endIndex, lettersIndex[s[i] - 'a']);
                    // Add the parition to the list.
                    if (i == endIndex)
                    {
                        parititonList.Add(i - startIndex + 1);
                        startIndex = endIndex + 1;
                    }
                }

                return parititonList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Concat("PartitionLabels", ex.Message));
                throw;
            }
        }

        /*
      Question 6

      You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
      You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
      Return an array result of length 2 where:
           •	result[0] is the total number of lines.
           •	result[1] is the width of the last line in pixels.

      Example 1:
      Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
      Output: [3,60]
      Explanation: You can write s as follows:
                   abcdefghij  	 // 100 pixels wide
                   klmnopqrst  	 // 100 pixels wide
                   uvwxyz      	 // 60 pixels wide
                   There are a total of 3 lines, and the last line is 60 pixels wide.



       Example 2:
       Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
       s = "bbbcccdddaaa"
       Output: [2,4]
       Explanation: You can write s as follows:
                    bbbcccdddaa  	  // 98 pixels wide
                    a           	 // 4 pixels wide
                    There are a total of 2 lines, and the last line is 4 pixels wide.

       */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                var result = new List<int>();
                int maxWidth = 100;
                int line = 1;
                int widthLine = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    // if maxWidth is reached then reset the maxWidth and update the line.
                    if (maxWidth < widths[s[i] - 'a'])
                    {
                        maxWidth = 100;
                        line++;
                    }
                    // Else deduct the width of the character from the maxWidth and update the width of the character in the current widthLine.
                    else
                    {
                        maxWidth = maxWidth - widths[s[i] - 'a'];
                        widthLine = widths[s[i] - 'a'];
                    }
                }
                result.Add(line);
                result.Add(maxWidth);

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Concat("NumberOfLines", ex.Message));
                throw;
            }

        }

        /*
        
        Question 7:

        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true

        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true

        Example 3:
        Input: bulls_string  = "(]"
        Output: false

        */

        public static bool IsValid(string bulls_string10)
        {
            try
            {
                int n = -1;

                // Loop till the brackets are replaced.
                while (bulls_string10.Length != n)
                {
                    n = bulls_string10.Length;

                    // Replaces the brackets in the string
                    bulls_string10 = bulls_string10.Replace("()", "").Replace("{}", "").Replace("[]", "");
                }

                // if string is empty, all brackets got replaced.
                if (bulls_string10.Length == 0) return true;

                // else, the brackets which were not valid, not replaced.
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Concat("IsValid", ex.Message));
                throw;
            }
        }

        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.

        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".

        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                // morse code for each English Alphabet
                string[] lettersInMorseCode = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };

                var morseCodeSet = new HashSet<string>();

                // Loop through each word to find the morse code and add it to the morseCodeSet.
                foreach (var word in words)
                {
                    string morseCode = "";
                    for (int i = 0; i < word.Length; i++)
                    {
                        morseCode = morseCode + lettersInMorseCode[word[i] - 'a'];
                    }
                    morseCodeSet.Add(morseCode);
                }

                // Get the morseCodeSet sizr.
                return morseCodeSet.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Concat("UniqueMorseRepresentations", ex.Message));
                throw;
            }




        }

        /*

        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally 
        adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time.
        Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).
        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.
        */
        public static int findpath(int row, int col, int[,] grid, bool[,] path)
        {

            if (row < 0 || row >= (grid.Length / grid.GetLength(0)) || col < 0 || col >= grid.GetLength(0) ||
                         path[row, col] || grid[row, col] == 0)
                return 0;
            path[row, col] = true;
            return (1 + findpath(row + 1, col, grid, path) + findpath(row - 1, col, grid, path)
                      + findpath(row, col - 1, grid, path) + findpath(row, col + 1, grid, path));

        }
        public static int SwimInWater(int[,] grid)
        {
            try
            {
                int col = grid.GetLength(0);
                int row = grid.Length / grid.GetLength(0);
                bool[,] path = new bool[col, row];

                int time = 0;
                for (int i = 0; i < col; i++)
                {
                    for (int j = 0; j < row; j++)
                    {
                        time = Math.Max(time, findpath(i, j, grid, path));
                    }
                }
                return time;
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Concat("SwimInWater", ex.Message));
                throw;
            }
        }

        /*

        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:
        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.
        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')
        */
        public static int dfs(string word1, string word2, Dictionary<string, int> dict)
        {
           
            if (word1 == word2) return 0;
            if (word1 == "") return word2.Length;
            if (word2 == "") return word1.Length;

            string key = word1 + "#" + word2;
            if (dict.ContainsKey(key)) return dict[key];

            string s1 = (word1.Length > 1) ? word1.Substring(1) : "";
            string s2 = (word2.Length > 1) ? word2.Substring(1) : "";

            if (word1[0] == word2[0])
            {
                int ops = dfs(s1, s2, dict);
                dict.Add(key, ops);
            }
            else
            {
                int insert = 1 + dfs(word2[0] + word1, word2, dict);
                int delete = 1 + dfs(s1, word2, dict);
                int replace = 1 + dfs(s1, s2, dict);
                int ops = Math.Min(insert, Math.Min(delete, replace));
                dict.Add(key, ops);
            }
            return dict[key];
        }
        public static int MinDistance(string word1, string word2)
        {
            try
            {
                var dict  = new Dictionary<string, int>();
                int number_of_operations =  dfs(word1, word2, dict);

                return number_of_operations;

            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Concat("SwimInWater", ex.Message));
                throw;
            }
        }
    }
}
