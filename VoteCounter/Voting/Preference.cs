using VoteCounter.Elections;

namespace VoteCounter.Voting
{
    public class Preference
    {
        public Candidate Candidate { get; }
        public int Rank { get; }

        public Preference(Candidate candidate, int rank)
        {
            Candidate = candidate;
            Rank = rank;
        }
    }
}