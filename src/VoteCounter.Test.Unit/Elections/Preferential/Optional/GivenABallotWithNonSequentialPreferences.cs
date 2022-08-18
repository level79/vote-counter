using VoteCounter.Elections;
using VoteCounter.Elections.Preferential.Optional;
using VoteCounter.Voting;
using Xunit;

namespace VoteCounter.Test.Unit.Elections.Preferential.Optional
{
    public class GivenABallotWithNonSequentialPreferences
    {
        private readonly OptionalPreferentialBallot _optionalPreferentialBallot;

        public GivenABallotWithNonSequentialPreferences()
        {
            var candidateBill = new Candidate("Bill Gates");
            var candidateFred = new Candidate("Fred Flinstone");
            var candidates = new[] {candidateBill, candidateFred};
            var preferences = new[]
            {
                new Preference(candidateBill, 1),
                new Preference(candidateFred, 3)
            };
            _optionalPreferentialBallot = OptionalPreferentialBallot.IssueBallot(candidates);
            _optionalPreferentialBallot.AddPreferences(preferences);
        }

        [Fact]
        public void ThenTheBallotIsNotFormal()
        {
            Assert.True(_optionalPreferentialBallot.IsInformal());
        }
    }
}