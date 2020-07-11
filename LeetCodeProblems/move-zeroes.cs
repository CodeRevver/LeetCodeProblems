using Xunit;

namespace LeetCodeProblems
{
    public class MoveZeros
    {
        /// https://leetcode.com/problems/move-zeroes/
        public int[] MoveZeroes(int[] nums)
        {
            var numberOfZeros = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    numberOfZeros++;
                    continue;
                }

                nums[i-numberOfZeros] = nums[i];
            }

            for (var i = 0; i < numberOfZeros; i++)
            {
                nums[nums.Length -1 - i] = 0;
            }
            
            return nums;
        }

        [Theory]
        [InlineData(new [] { 0, 1, 0, 3, 12 }, new[] { 1, 3, 12, 0, 0 })]
        public void Test1(int[] nums, int[] expectedAnswer)
        {
            var answer = MoveZeroes(nums);
            Assert.Equal(expectedAnswer, answer);
        }
    }
}
