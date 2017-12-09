using Xunit;

namespace VoteCounter.Test.Unit
{
    public class DistributePreferences
    {
        private Electorate _electorate;

        public DistributePreferences()
        {
            _electorate = new Electorate();
        }

        [Fact]
        public void OneVoteWinner()
        {

            var madKatter = new Candidate("Mad Katter");
            var vote = new Vote(new []{new Preference(madKatter, 1)});
            _electorate.AddVote(vote);
            
            var electorateResult = _electorate.DistributeVotes();
            Assert.False(electorateResult.IsRedistributionRequired);
            Assert.Equal(madKatter, electorateResult.Winner); 
        }
        
        [Fact]
        public void OneVoteFormalVoteWinner()
        {
            var madKatter = new Candidate("Mad Katter");
            _electorate.AddVote(new Vote(new []{new Preference(madKatter, 1)}));
            _electorate.AddVote(new Vote(new []{new Preference(new Candidate("Not Mad Katter"), 2)}));
            _electorate.AddVote(new Vote(new []{new Preference(new Candidate("Not Mad Katter"), 3)}));
            
            var electorateResult = _electorate.DistributeVotes();
            Assert.False(electorateResult.IsRedistributionRequired);
            Assert.Equal(madKatter, electorateResult.Winner); 
        }

        [Fact]
        public void RedistributeVotesToFindWinner()
        {
            _electorate.AddVote(new Vote(new []{"Mad Katter", "Queen of Spades"}));
            _electorate.AddVote(new Vote(new []{"Mad Katter", "Queen of Spades"}));
            _electorate.AddVote(new Vote(new []{"Alice", "Queen of Spades"}));
            _electorate.AddVote(new Vote(new []{"Alice", "Queen of Spades"}));
            _electorate.AddVote(new Vote(new []{"Bill", "Alice"}));
            
            Assert.Equal(new Candidate("Alice"), _electorate.DistributeVotes().Winner);
        }
    }
}