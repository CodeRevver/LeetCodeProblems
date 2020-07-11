using Xunit;

namespace LeetCodeProblems
{
    using System.Collections.Generic;
    using System.Linq;

    public class KidsWithTheGreatestNumberOfCandies
    {
        /// https://leetcode.com/problems/kids-with-the-greatest-number-of-candies/
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            var maxNumberOfCandiesAnyoneHas = candies.Max();
            var answer = new List<bool>();

            foreach (int candy in candies)
            {
                var hasGreatestNumberOfCandies = candy + extraCandies >= maxNumberOfCandiesAnyoneHas;
                answer.Add(hasGreatestNumberOfCandies);
            }

            return answer;
        }

        [Theory]
        [InlineData(new [] { 2, 3, 5, 1, 3 }, 3, new bool[] { true, true, true, false, true })]
        [InlineData(new [] { 4, 2, 1, 1, 2 }, 1, new bool[] { true, false, false, false, false })]
        [InlineData(new [] { 12, 1, 12 }, 10, new bool[] { true, false, true })]
        public void Test1(int[] candies, int extraCandies, bool[] expectedAnswer)
        {
            var answer = KidsWithCandies(candies, extraCandies);
            Assert.Equal(expectedAnswer, answer);
        }
    }
}
