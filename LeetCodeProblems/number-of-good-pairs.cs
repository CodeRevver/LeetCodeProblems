using Xunit;

namespace LeetCodeProblems
{

    public class NumberOfGoodPairs
    {
        /// https://leetcode.com/problems/number-of-good-pairs/
        public int NumIdenticalPairs(int[] nums)
        {
            // I think this is O(n^2)
            var numberOfGoodPairs = 0;
            
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        numberOfGoodPairs++;
                    }
                }
            }

            return numberOfGoodPairs;
        }

        [Theory]
        [InlineData(new [] { 1, 2, 3, 1, 1, 3 }, 4)]
        [InlineData(new [] { 1, 1, 1, 1 }, 6)]
        [InlineData(new [] { 1, 2, 3 }, 0)]
        public void Test1(int[] nums, int expectedAnswer)
        {
            var answer = NumIdenticalPairs(nums);
            Assert.Equal(expectedAnswer, answer);
        }
    }
}
