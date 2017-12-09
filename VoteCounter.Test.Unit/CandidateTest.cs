using Xunit;

namespace VoteCounter.Test.Unit
{
    public class CandidateTest
    {
        private const string CandidateName = "Fred Bloggs";

        [Fact]
        public void CandidatesWithSameNameAreEqual()
        {
            var canditate1 = new Candidate(CandidateName);
            var canditate2 = new Candidate(CandidateName);
            
            Assert.Equal(canditate1, canditate2);
        }

        [Fact]
        public void CandidateHasCodeIsDeterminedByName()
        {
            var candidate = new Candidate(CandidateName);
            
            Assert.Equal(CandidateName.GetHashCode(), candidate.GetHashCode());
        }
        
        [Fact]
        public void CandidateToStringIsDeterminedByName()
        {
            var candidate = new Candidate(CandidateName);
            
            Assert.Equal(CandidateName.ToString(), candidate.ToString());
        }
    }
}