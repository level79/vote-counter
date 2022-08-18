using VoteCounter.Elections;
using Xunit;

namespace VoteCounter.Test.Unit.Elections
{
    public class GivenACandidate
    {
        private readonly Candidate _candidate;

        public GivenACandidate()
        {
            _candidate = new Candidate(CandidateName);
        }

        private const string CandidateName = "Fred Bloggs";

        [Fact]
        public void AnotherCandidatesWithSameNameWillBeEqual()
        {
            var candidate2 = new Candidate(CandidateName);

            Assert.Equal(_candidate, candidate2);
        }

        [Fact]
        public void TheHashCodeIsDeterminedByName()
        {
            Assert.Equal(CandidateName.GetHashCode(), _candidate.GetHashCode());
        }

        [Fact]
        public void ToStringWillReturnTheName()
        {
            Assert.Equal(CandidateName, _candidate.ToString());
        }
    }
}