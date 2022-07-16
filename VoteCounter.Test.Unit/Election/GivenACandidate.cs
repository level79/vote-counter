using VoteCounter.Election;
using Xunit;

namespace VoteCounter.Test.Unit.Election
{
    public class GivenACandidate
    {
        private readonly Candidate _canditate;

        public GivenACandidate()
        {
            _canditate = new Candidate(CandidateName);
        }
        private const string CandidateName = "Fred Bloggs";

        [Fact]
        public void AnotherCandidatesWithSameNameWillBeEqual()
        {
            var candidate2 = new Candidate(CandidateName);
            
            Assert.Equal(_canditate, candidate2);
        }

        [Fact]
        public void TheHashCodeIsDeterminedByName()
        {
            Assert.Equal(CandidateName.GetHashCode(), _canditate.GetHashCode());
        }
        
        [Fact]
        public void ToStringWillReturnTheName()
        {
            Assert.Equal(CandidateName, _canditate.ToString());
        }
    }
}