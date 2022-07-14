using Xunit;

namespace VoteCounter.Test.Unit
{
    public class DistributePreferences
    {
        private readonly Electorate _electorate;

        public DistributePreferences()
        {
            _electorate = new Electorate();
        }

        [Fact]
        public void OneVoteWinner()
        {

            var madKatter = new Candidate("Mad Katter");
            var vote = new Ballot(new []{new Preference(madKatter, 1)});
            _electorate.AddBallot(vote);
            
            var electorateResult = _electorate.DistributeVotes();
            Assert.False(electorateResult.IsRedistributionRequired);
            Assert.Equal(madKatter, electorateResult.Winner); 
        }
        
        [Fact]
        public void OneVoteFormalVoteWinner()
        {
            var madKatter = new Candidate("Mad Katter");
            _electorate.AddBallot(new Ballot(new []{new Preference(madKatter, 1)}));
            _electorate.AddBallot(new Ballot(new []{new Preference(new Candidate("Not Mad Katter"), 2)}));
            _electorate.AddBallot(new Ballot(new []{new Preference(new Candidate("Not Mad Katter"), 3)}));
            
            var electorateResult = _electorate.DistributeVotes();
            Assert.False(electorateResult.IsRedistributionRequired);
            Assert.Equal(madKatter, electorateResult.Winner); 
        }

        [Fact]
        public void RedistributeVotesToFindWinner()
        {
            _electorate.AddBallot(new Ballot(new []{"Mad Katter", "Queen of Spades"}));
            _electorate.AddBallot(new Ballot(new []{"Mad Katter", "Queen of Spades"}));
            _electorate.AddBallot(new Ballot(new []{"Alice", "Queen of Spades"}));
            _electorate.AddBallot(new Ballot(new []{"Alice", "Queen of Spades"}));
            _electorate.AddBallot(new Ballot(new []{"Bill", "Alice"}));
            
            Assert.Equal(new Candidate("Alice"), _electorate.DistributeVotes().Winner);
        }
    }
}