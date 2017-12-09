using System;

namespace VoteCounter
{
    public class Candidate : TinyType<string>
    {
        public Candidate(string value) : base(value)
        {
        }
    }
}