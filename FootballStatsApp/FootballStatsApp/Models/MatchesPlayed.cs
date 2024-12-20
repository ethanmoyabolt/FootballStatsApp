﻿using FootballStatsApp.Services.MatchCreators;
using FootballStatsApp.Services.MatchDeleters;
using FootballStatsApp.Services.MatchProviders;
using FootballStatsApp.Services.PlayerDeleters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatsApp.Models
{
    public class MatchesPlayed
    {
        private readonly IMatchProvider _matchProvider;
        private readonly IMatchCreator _matchCreator;
        private readonly IMatchDeleter _matchDeleter;

        public MatchesPlayed(IMatchProvider matchProvider, IMatchCreator matchCreator, IMatchDeleter matchDeleter)
        {
            _matchProvider = matchProvider;
            _matchCreator = matchCreator;
            _matchDeleter = matchDeleter;
        }

        public async Task<IEnumerable<Match>> GetAllMatches()
        {
            return await _matchProvider.GetAllMatches();
        }

        public async Task AddMatch(Match match)
        {
            await _matchCreator.CreateMatch(match);
        }

        public async Task DeleteMatch(Guid matchID)
        {
            await _matchDeleter.DeleteMatch(matchID);
        }
    }
}
