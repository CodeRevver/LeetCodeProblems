using System;
using Xunit;

namespace LeetCodeProblems
{
    using System.Collections.Generic;
    using System.Linq;

    public class ShuffleTheArray
    {
        /// <summary>
        /// https://leetcode.com/problems/shuffle-the-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] Shuffle(int[] nums, int n)
        {
            // Could split the array in half
            // Take the first array with index  and loop round each pushing them onto a new array
            var answers = new int[n * 2];
            
            var xAnswers = new int[n];
            
            for (var index = 0; index < n; index++)
            {
                xAnswers[index] = nums[index];
            }
            
            var yAnswers = new int[n];

            for (var index = 0; index < n; index++)
            {
                yAnswers[index] = nums[index + n];
            }

            var answerIndex = 0;
            for (int index = 0; index < n; index++)
            {
                answers[answerIndex] = xAnswers[index];
                answerIndex++;
                answers[answerIndex] = yAnswers[index];
                answerIndex++;
            }

            return answers;
        }

        public int[] Shuffle2(int[] nums, int n)
        {
            // one array, two pointers 
            var answers = new int[n * 2];
            
            var xValueIndex = 0;
            var yValueIndex = n;
            for (int index = 0; index < n*2; index += 2)
            {
                answers[index] = nums[xValueIndex];
                xValueIndex++;
                answers[index + 1] = nums[yValueIndex];
                yValueIndex++;
            }

            return answers;
        }

        public int[] Shuffle3(int[] nums, int n)
        {
            // Lists are easier than arrays
            var answers = new List<int>();

            for (int index = 0; index < n; index ++)
            {
                answers.Add(nums[index]);
                answers.Add(nums[index + n]);
            }

            return answers.ToArray();
        }

        [Theory]
        [InlineData(new [] { 2, 5, 1, 3, 4, 7 }, 3, new[] { 2, 3, 5, 4, 1, 7 })]
        [InlineData(new [] { 1, 2, 3, 4, 4, 3, 2, 1 }, 4,  new[] { 1, 4, 2, 3, 3, 2, 4, 1 })]
        [InlineData(new [] { 1, 1, 2, 2 }, 2, new[] { 1, 2, 1, 2 })]
        public void Test1(int[] nums, int n, int[] expectedAnswer)
        {
            var answer = Shuffle(nums, n);
            Assert.Equal(expectedAnswer, answer);
        }

        [Theory]
        [InlineData(new[] { 2, 5, 1, 3, 4, 7 }, 3, new[] { 2, 3, 5, 4, 1, 7 })]
        [InlineData(new[] { 1, 2, 3, 4, 4, 3, 2, 1 }, 4, new[] { 1, 4, 2, 3, 3, 2, 4, 1 })]
        [InlineData(new[] { 1, 1, 2, 2 }, 2, new[] { 1, 2, 1, 2 })]
        public void Test2(int[] nums, int n, int[] expectedAnswer)
        {
            var answer = Shuffle2(nums, n);
            Assert.Equal(expectedAnswer, answer);
        }

        [Theory]
        [InlineData(new[] { 2, 5, 1, 3, 4, 7 }, 3, new[] { 2, 3, 5, 4, 1, 7 })]
        [InlineData(new[] { 1, 2, 3, 4, 4, 3, 2, 1 }, 4, new[] { 1, 4, 2, 3, 3, 2, 4, 1 })]
        [InlineData(new[] { 1, 1, 2, 2 }, 2, new[] { 1, 2, 1, 2 })]
        public void Test3(int[] nums, int n, int[] expectedAnswer)
        {
            var answer = Shuffle3(nums, n);
            Assert.Equal(expectedAnswer, answer);
        }
    }
}
