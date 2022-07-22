using System.Collections.Generic;
using System.Linq;
using VoteCounter.Elections;
using VoteCounter.Elections.FirstPastThePost;
using VoteCounter.Utilities;
using VoteCounter.Voting;

namespace VoteCounter.Test.Unit.Elections.Builders;

public class FirstPastThePostBallotFiller
{
    private readonly FirstPastThePostBallot _issueBallot;
    private IEnumerable<Candidate> _candidate;

    public FirstPastThePostBallotFiller(FirstPastThePostBallot issueBallot)
    {
        _issueBallot = issueBallot;
    }

    public FirstPastThePostBallotFiller FromCandidates(params Candidate[] candidates)
    {
        _candidate = candidates.Shuffle().Take(1);
        return this;
    }

    public FirstPastThePostBallot Fill()
    {
        var preferences = _candidate.Select((candidate, index) => new Preference(candidate, index + 1));
        _issueBallot.AddPreferences(preferences);
        return _issueBallot;
    }
}