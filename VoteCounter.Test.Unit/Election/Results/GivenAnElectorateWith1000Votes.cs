using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using VoteCounter.Election;
using VoteCounter.Test.Unit.Election.Builders;
using VoteCounter.Test.Unit.Voting.Builders;
using VoteCounter.Voting;
using Xunit;

namespace VoteCounter.Test.Unit.Election.Results
{
    public class GivenAnElectorateWith1000Votes
    {
        private readonly Electorate _electorate;
        private readonly Candidate[] _candidates;

        public GivenAnElectorateWith1000Votes()
        {
            _electorate = new Electorate();
            _candidates = Enumerable.Range(0, 5).Select(i => new CandidateBuilder().Build()).ToArray();
            foreach (var candidate in _candidates)
            {
                _electorate.AddCandidate(candidate);
            }

            for (var i = 0; i < 1000; i++)
            {
                _electorate.AddBallot(new BallotBuilder().WithCandidates(_candidates).Build());
            }
        }

        [Fact]
        public void RedistributeVotesToFindWinner()
        {
            var electorateResult = _electorate.CountVotes();
            Assert.Equal(2, electorateResult.Candidates);
            Assert.Equal(1000, electorateResult.TotalVotes);
            Assert.Equal(_candidates.Length - 1, electorateResult.PreferenceRoundsRequired);
        }
    }
}