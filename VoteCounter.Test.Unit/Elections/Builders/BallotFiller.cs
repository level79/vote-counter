using System.Collections.Generic;
using System.Linq;
using VoteCounter.Elections;
using VoteCounter.Elections.FirstPastThePost;
using VoteCounter.Utilities;
using VoteCounter.Voting;

namespace VoteCounter.Test.Unit.Elections.Builders;

public class BallotFiller
{
    private IList<Candidate> _candidates;
    private int _numberOfCandidates = 1;

    public BallotFiller FromCandidates(params Candidate[] candidates)
    {
        _candidates = candidates;
        return this;
    }

    public void Fill(Ballot ballot)
    {
        var preferences = _candidates
            .Shuffle()
            .Take(_numberOfCandidates)
            .Select((candidate, index) => new Preference(candidate, index + 1));
        ballot.AddPreferences(preferences);
    }

    public BallotFiller PickCandidates(int numberOfCandidates)
    {
        _numberOfCandidates = numberOfCandidates;
        return this;
    }
}