using System.Collections.Generic;
using System.Linq;
using VoteCounter.Voting;

namespace VoteCounter.Elections.Preferential;

public abstract class PreferentialBallot
{
    protected Preference[] _preferences;
    protected IEnumerable<Candidate> _candidates;

    public PreferentialBallot(IEnumerable<Candidate> candidates, IEnumerable<Preference> preferences)
    {
        _candidates = candidates;
        _preferences = preferences.OrderBy(preference => preference.Rank).ToArray();
    }

    public Candidate Primary => _preferences.First().Candidate;
    public abstract bool IsInformal();

    public Candidate Preference(IEnumerable<Candidate> eliminatedCandidates)
    {
        return _preferences.First(preference => !eliminatedCandidates.Contains(preference.Candidate)).Candidate;
    }
}