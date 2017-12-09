namespace VoteCounter
{
    public class Preference
    {
        public Candidate Candidate { get; }
        public int Rank { get; }

        public Preference(Candidate candidate1, int rank)
        {
            Candidate = candidate1;
            Rank = rank;
        }
    }
}