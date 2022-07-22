using System.Collections.Generic;

namespace VoteCounter.Voting;

public interface IBallot
{
    bool IsInformal();
    void AddPreferences(IEnumerable<Preference> preferences);
}