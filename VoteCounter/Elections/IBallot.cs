using System.Collections.Generic;
using VoteCounter.Voting;

namespace VoteCounter.Elections;

public interface IBallot
{
    bool IsInformal();
    void AddPreferences(IEnumerable<Preference> preferences);
}