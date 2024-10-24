using FootballStatsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatsApp.Services.MatchCreators
{
    public interface IMatchCreator
    {
        Task CreateMatch(Match match);
    }
}
