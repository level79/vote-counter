namespace VoteCounter.Election.Results
{
    public class Tally
    {
        public Candidate Candidate { get; }
        public int Count { get; }

        public Tally(Candidate candidate, int count)
        {
            Candidate = candidate;
            Count = count;
        }
    }
}