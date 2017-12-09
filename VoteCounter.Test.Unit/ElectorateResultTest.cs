using Xunit;

namespace VoteCounter.Test.Unit
{
    public class ElectorateResultTest
    {
        [Fact]
        public void DistributionRequiredWhenFirstPlaceNotEnoughVotes()
        {
            var results = new ElectorateResult(new[]
            {
                new Tally(new Candidate("Candidate1"), 2),
                new Tally(new Candidate("Candidate2"), 2),
            });
            
            Assert.True(results.IsRedistributionRequired);
        }

        [Fact]
        public void WinnerIsCandidateWithMostVotes()
        {
            var winner = new Candidate("Candidate1");
            var results = new ElectorateResult(new[]
            {
                new Tally(winner, 3),
                new Tally(new Candidate("Candidate2"), 2),
            });
            Assert.False(results.IsRedistributionRequired);            
            Assert.Equal(winner, results.Winner);
        }
    }
}