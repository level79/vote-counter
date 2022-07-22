using System.Linq;
using VoteCounter.Elections;
using VoteCounter.Elections.Preferential.Optional;
using VoteCounter.Test.Unit.Elections.Builders;
using Xunit;

namespace VoteCounter.Test.Unit.Elections.Preferential.Optional.Results
{
    public class GivenAnOptionalPreferentialElectionWith1000Votes
    {
        private readonly OptionalPreferentialElection _optionalPreferentialElection;
        private readonly Candidate[] _candidates;

        public GivenAnOptionalPreferentialElectionWith1000Votes()
        {
            _candidates = Enumerable.Range(0, 5).Select(i => new CandidateBuilder().Build()).ToArray();
            _optionalPreferentialElection =
                new OptionalPreferentialElectionBuilder().WithCandidates(_candidates).Build();

            for (var i = 0; i < 1000; i++)
            {
                _optionalPreferentialElection.AddBallot(
                    new OptionalPreferentialBallotBuilder()
                        .ForCandidates(_candidates)
                        .WithCandidates(_candidates)
                        .Build());
            }
        }

        [Fact]
        public void RedistributeVotesToFindWinner()
        {
            var electorateResult = _optionalPreferentialElection.CountVotes();
            Assert.Equal(2, electorateResult.NumberOfCandidates);
            Assert.Equal(_optionalPreferentialElection.TotalFormalBallots, electorateResult.TotalBallots);
            Assert.Equal(_candidates.Length - 1, electorateResult.PreferenceRoundsRequired);
        }
    }
}