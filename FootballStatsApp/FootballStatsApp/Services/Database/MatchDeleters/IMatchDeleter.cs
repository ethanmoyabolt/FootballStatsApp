using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatsApp.Services.MatchDeleters
{
    public interface IMatchDeleter
    {
        Task DeleteMatch(Guid MatchID);
    }
}
