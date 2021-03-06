﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo_ConsoleApp.AlgorithmCrap
{
    public static class AlgorithmCrap
    {
        //Euclid's algorithm
        public static int GreatestCommonDivisor(int p, int q)
        {
            if (q == 0)
            {
                return p;
            }
            else
            {
                int remainder = p % q; //Mod
                return GreatestCommonDivisor(q, remainder);
            }
        }
        //This is a Binary Search algorithm, also known as the Divide and Conquer -  this is a "famous, effective and widely used" algorithm, according to Sedgwick, Chap1, p46
        public static int Rank(int key, int[] array)
        {
            int lo = 0;
            int hi = array.Length - 1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (key < array[mid])
                {
                    hi = mid - 1;
                }
                else if (key > array[mid])
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }
        public static int RaiseStackOverflowError(int someInt)
        {
            //If some int is 2147483648 or greater, then stack integer overflow gets raised.
            return Math.Abs(-someInt);

        }
        public class AmazonTestCase
        {
            public string[] blockArray;
            public int n;

        }
        public static int GetDoubleLastScore(int[] scoreArray)
        {
            int lastNonZeroIndex = Array.FindLastIndex(scoreArray, item => item != 0);
            return scoreArray[lastNonZeroIndex] * 2;
        }
        public static int GetSumOfLastTwoScores(int[] scoreArray)
        {
            int lastNonZeroIndex = Array.FindLastIndex(scoreArray, item => item != 0);
            return scoreArray[lastNonZeroIndex - 1] + scoreArray[lastNonZeroIndex];
        }
        public static int AmazonTotalScore(string[] blocks, int n)
        {
            int hitScore = 0;
            int[] scoreArray = new int[n];
            int totalScore = 0;
            int parsedScoreValue;
            int zHitCounter = 0;

            for (int i = 0; i < n; i++)
            {
                bool zHit = false;
                if (int.TryParse(blocks[i], out parsedScoreValue))
                {
                    //if a throw his a block marked with an integer, that throw is value of the integer
                    hitScore = parsedScoreValue;
                }
                else
                {
                    //if throw hits a block marked with x, the score is double the last score
                    if (blocks[i].ToLower() == "x")
                    {
                        if (i >= 1)
                        {                            
                            hitScore = GetDoubleLastScore(scoreArray);
                        }
                    }
                    //if throw hits block marked with +,  score is sum of last two scores
                    if (blocks[i] == "+")
                    {
                        if (i >= 2)
                        {                            
                            hitScore = GetSumOfLastTwoScores(scoreArray);
                        }
                    }
                    //if throw hits block marked with z, the last score is removed and subsequent throws ignore it
                    if (blocks[i].ToLower() == "z")
                    {
                        zHit = true;
                        zHitCounter++;
                        if (i >= 1)
                        {
                            var scoreArrayList = new List<int>(scoreArray);
                            scoreArrayList.RemoveAt(i);
                            scoreArrayList.RemoveAt(i - 1);
                            scoreArray = scoreArrayList.ToArray();
                        }
                    }
                }
                if (!zHit)
                {                    
                    int firstZeroIndex = Array.FindIndex(scoreArray, item => item == 0);
                    scoreArray[firstZeroIndex] = hitScore;
                }
            }
            //after it's all done, calculate final score by looping through calculated score array:
            for (int s = 0; s < scoreArray.Length; s++)
            {
                totalScore = totalScore + scoreArray[s];
            }
            return totalScore;

        }
        public static void QuoraPuzzler()
        {
            //QuroaPuzzler
            //TODO: sometime when you've got nothing else to do, try this:
            //Problem statement: “Define Zeroes(N) as the number of zeroes in the decimal expansion of the integer N.
            //A number N is ZeroSpecial if Zeroes(N) > Zeroes(N - 1).
            //Write a function that determines whether N is ZeroSpecial.”
            //https://www.quora.com/How-do-folks-interview-senior-software-engineers
            Console.WriteLine("Enter a number and I'll tell you if it is what I deem to be 'ZeroSpecial'");
            int numToCheck = int.Parse(Console.ReadLine());
            if(isZeroSpecial(numToCheck))
            {
                Console.WriteLine("Yep..... {0} is 'ZeroSpecial', babycakes.", numToCheck);                
            }
            else
            {
                Console.WriteLine("Nope. {0} ain't what I call a 'ZeroSpecial' number", numToCheck);
            }
            Console.WriteLine("That was a dumb excercise.  More evidence that Quora.com might be wack.");
        }
        public static bool isZeroSpecial(int n)
        {
            int nMinusOne = n - 1;
            bool isZeroSpecial = false;
            
            //A number N is ZeroSpecial if Zeroes(N) > Zeroes(N - 1), soooooo....
            if(Zeros(n) > Zeros(nMinusOne))
            {
                isZeroSpecial = true;
            }

            return isZeroSpecial;
        }
        public static int Zeros(int n)
        {
            int zeroCount=0;

            char[] nCharArray = n.ToString().ToArray();
            foreach(Char myChar in nCharArray)
            {
                if(myChar=='0')
                {
                    zeroCount++;
                }
            }
            return zeroCount; 
        }
        public static String findstem(String[] arr)
        {
            //https://www.geeksforgeeks.org/longest-common-substring-array-strings/
            //https://duckduckgo.com/?q=longest+common+substring+in+set&atb=v250-1&ia=web

            // C# program to find the stem of given list of word

            // function to find the stem (longest common
            // substring) from the string array

            // Determine size of the array
            int n = arr.Length;

            // Take first word from array as reference
            String s = arr[0];
            int len = s.Length;

            String res = "";

            for (int i = 0; i < len; i++)
            {
                for (int j = i + 1; j <= len; j++)
                {

                    // generating all possible substrings
                    // of our reference string arr[0] i.e s
                    String stem = s.Substring(i, j - i);
                    int k = 1;
                    for (k = 1; k < n; k++)

                        // Check if the generated stem is
                        // common to all words
                        if (!arr[k].Contains(stem))
                            break;

                    // If current substring is present in
                    // all strings and its length is greater
                    // than current result
                    if (k == n && res.Length < stem.Length)
                        res = stem;
                }
            }

            return res;

            // Driver Code
            //        public static void Main(String[] args)
            //        {
            //            String[] arr = { "grace", "graceful", "disgraceful",
            //                                            "gracefully" };
            //            // Function call
            //            String stems = findstem(arr);
            //            Console.WriteLine(stems);
            //        }
            //    }

            // This code contributed by Rajput-Ji
        }

    }
}
