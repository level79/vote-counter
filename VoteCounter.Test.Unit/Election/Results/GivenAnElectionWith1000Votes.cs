using System.Linq;
using VoteCounter.Elections;
using VoteCounter.Test.Unit.Election.Builders;
using VoteCounter.Test.Unit.Voting.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Election.Results
{
    public class GivenAnElectionWith1000Votes
    {
        private readonly VoteCounter.Elections.OptionalPreferentialElection _optionalPreferentialElection;
        private readonly Candidate[] _candidates;

        public GivenAnElectionWith1000Votes()
        {
            _optionalPreferentialElection = new VoteCounter.Elections.OptionalPreferentialElection();
            _candidates = Enumerable.Range(0, 5).Select(i => new CandidateBuilder().Build()).ToArray();
            foreach (var candidate in _candidates)
            {
                _optionalPreferentialElection.AddCandidate(candidate);
            }

            for (var i = 0; i < 1000; i++)
            {
                _optionalPreferentialElection.AddBallot(new OptionalPreferentialBallotBuilder().WithCandidates(_candidates).Build());
            }
        }

        [Fact]
        public void RedistributeVotesToFindWinner()
        {
            var electorateResult = _optionalPreferentialElection.CountVotes();
            Assert.Equal(2, electorateResult.Candidates);
            Assert.Equal(1000, electorateResult.TotalVotes);
            Assert.Equal(_candidates.Length - 1, electorateResult.PreferenceRoundsRequired);
        }
    }
}