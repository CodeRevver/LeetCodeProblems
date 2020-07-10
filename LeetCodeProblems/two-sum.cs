using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCodeProblems
{
    public class TwoSumProblem
    {
        /// https://leetcode.com/problems/two-sum/
        public int[] TwoSum(int[] nums, int target)
        {
            // THIS CAME BACK AS REALLY SLOW - THIS IS THE MOST INEFFICIENT WAY TO DO IT

            // Target = 9
            // for all numbers under 9
            // can you subtract the number and be above 0? if so do it
            // Then my thought process was like - shit what if it's not the happy path
            // Then I thought I could use a while loop to not be done until there was two elements in the array
            // Then changed that to a for loop once I new I needed to keep track of a startindex as well as an iterator.
            // Then it failed so I ended up hacking together the reset and removing item at last item if it doesnt make us 0
            // Then this totally spiraled out of control with negative numbers and duplicate identification
            var answer = new List<int>();
            for (var startIndex = 0; startIndex < nums.Length; startIndex++)
            {
                var currentTarget = target;
                for (var index = startIndex; index < nums.Length; index++)
                {
                    var currentNumberPositive = nums[index];
                    currentTarget = currentTarget - currentNumberPositive;
                    answer.Add(index);

                    if (currentTarget == 0 && answer.Count == 2)
                    {
                        return answer.ToArray();
                    }
                    else if (answer.Count == 2)
                    {
                        currentTarget = currentTarget + currentNumberPositive; // reset
                        answer.RemoveAt(1); // Remove the second item because it doesn't make us equal to 0
                    }
                }

                answer.Clear();
            }

            throw new Exception();
        }

        public int[] TwoSumFromDiscussion_NotMine(int[] nums, int target)
        {
            // This is pretty efficient
            int[] result = new int[2];
            var map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(target - nums[i]))
                {
                    result[0] = map[target - nums[i]];
                    result[1] = i;
                }
                else
                {
                    map[nums[i]] = i;
                }
            }

            return result;
        }

        [Theory]
        [InlineData(new [] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
        [InlineData(new[] { 5, 2, 7, 11, 15 }, 9, new[] { 1, 2 })]
        [InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
        [InlineData(new[] { 3, 2, 3 }, 6, new[] { 0, 2 })]
        [InlineData(new[] { 0, 4, 3, 0 }, 0, new[] { 0, 3 })]
        [InlineData(new[] { -1, -2, -3, -4, -5 }, -8, new[] { 2, 4 })]
        [InlineData(new[] { -3, 4, 3, 90 }, 0, new[] { 0, 2 })]
        public void Test1(int[] nums, int target, int[] expectedAnswer)
        {
            var answer = TwoSum(nums, target);
            Assert.Equal(expectedAnswer, answer);
        }

        [Theory]
        [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
        [InlineData(new[] { 5, 2, 7, 11, 15 }, 9, new[] { 1, 2 })]
        [InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
        [InlineData(new[] { 3, 2, 3 }, 6, new[] { 0, 2 })]
        [InlineData(new[] { 0, 4, 3, 0 }, 0, new[] { 0, 3 })]
        [InlineData(new[] { -1, -2, -3, -4, -5 }, -8, new[] { 2, 4 })]
        [InlineData(new[] { -3, 4, 3, 90 }, 0, new[] { 0, 2 })]
        public void Test2_NOT_MINE(int[] nums, int target, int[] expectedAnswer)
        {
            var answer = TwoSumFromDiscussion_NotMine(nums, target);
            Assert.Equal(expectedAnswer, answer);
        }
    }
}
