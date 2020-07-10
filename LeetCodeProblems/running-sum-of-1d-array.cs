using System;
using Xunit;

namespace LeetCodeProblems
{
    using System.Linq;

    public class RunningSumOf1DArray
    {
        /// <summary>
        /// https://leetcode.com/problems/running-sum-of-1d-array/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] RunningSum(int[] nums)
        {
            var newArr = new int[nums.Length];
            var runningSum = 0;

            for (var index = 0; index < nums.Length; index++)
            {
                runningSum = runningSum + nums[index];
                newArr[index] = runningSum;
            }

            return newArr;
        }

        [Theory]
        [InlineData(new [] { 1,2,3,4 }, new[] { 1, 3, 6, 10 })]
        [InlineData(new [] { 1, 1, 1, 1, 1 }, new[] { 1, 2, 3, 4, 5 })]
        [InlineData(new [] { 3, 1, 2, 10, 1 }, new[] { 3, 4, 6, 16, 17 })]
        public void Test1(int[] nums, int[] expectedAnswer)
        {
            var answer = RunningSum(nums);
            Assert.Equal(expectedAnswer, answer);
        }
    }
}
