using VoteCounter.Utilities;

namespace VoteCounter.Elections
{
    public class Candidate : TinyType<string>
    {
        public Candidate(string value) : base(value)
        {
        }
    }
}