using Xunit;

namespace LeetCodeProblems
{
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;

    /// <summary>
    /// Didn't figure this out the first time - need to look into Depth first search -https://www.hackerearth.com/practice/algorithms/graphs/depth-first-search/tutorial/
    /// </summary>
    public class PermutationsProblem
    {
        /// https://leetcode.com/problems/permutations/
        public IList<IList<int>> Permute(int[] nums)
        {
            // nums length is the length of all permutes
            // loop through each of the numbers by their index
            //   loop through the list a again by their index and record the values
            //   if it's not already in the answers list, add the combo 

            IList<IList<int>> answers = new List<IList<int>>();
            //for (int index = 0; index < nums.Length; index++)
            //{
            //    var startNumber = nums[index];
            //    var loopAnswer = new List<int> { startNumber };

            //    // what are the possible options for the second number?  loop round them
            //    // we have 1, possible options are every other number at any other index
            //    // 
            //    for (int inner = 0; inner < nums.Length && inner != index; inner++)
            //    {
            //        loopAnswer.Add(nums[inner]);
            //    }

            //    answers.Add(loopAnswer);
            //}

            var complete = false;
            var startNumberIndex = 0;
            while (!complete)
            {
                var iterations = 0; // when the iterations for the start number is the length of the array -1 we know we're done with the permutations
                for (int index = 0; index < nums.Length; index++)
                {
                    var startNumber = nums[index];
                    var loopAnswer = new List<int> { startNumber };

                    // what are the possible options for the second number?  loop round them
                    // we have 1, possible options are every other number at any other index
                    // 
                    for (int inner = 0; inner < nums.Length && inner != index; inner++)
                    {
                        loopAnswer.Add(nums[inner]);
                    }

                    answers.Add(loopAnswer);
                }
            }


            return answers;
        }

        [Fact]
        public void Test1()
        {
            var nums = new[] {1, 2, 3};
            var expectedAnswer = new List<List<int>> {
                new List<int>
                {
                    1,2,3
                },
                new List<int>
                {
                    1,3,2,
                },
                new List<int>
                {
                    2,1,3,
                },
                new List<int>
                {
                    2,3,1,
                },
                new List<int>
                {
                    3,1,2,
                },
                new List<int>
                {
                    3,2,1
                }
            };

            var answer = Permute(nums);
            foreach (var answerItem in answer)
            {
                expectedAnswer.Should().ContainEquivalentOf(answerItem);
            }

            answer.Count.Should().Be(expectedAnswer.Count);
        }
    }
}
