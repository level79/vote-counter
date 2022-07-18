using VoteCounter.Elections;
using VoteCounter.Elections.Preferential.Optional;
using VoteCounter.Voting;
using Xunit;

namespace VoteCounter.Test.Unit.Elections.Preferential.Optional
{
    public class GivenABallotWithNonSequentialPreferences
    {
        private readonly Candidate _candidateBill;
        private readonly Candidate _candidateFred;
        private readonly OptionalPreferentialBallot _optionalPreferentialBallot;

        public GivenABallotWithNonSequentialPreferences()
        {
            _candidateBill = new Candidate("Bill Gates");
            _candidateFred = new Candidate("Fred Flinstone");
            _optionalPreferentialBallot = new OptionalPreferentialBallot(
                new[] {_candidateBill, _candidateFred},
                new[]
                {
                    new Preference(_candidateBill, 1),
                    new Preference(_candidateFred, 3)
                });
        }

        [Fact]
        public void ThenTheBallotIsNotFormal()
        {
            Assert.True(_optionalPreferentialBallot.IsInformal());
        }
    }
}