﻿using FireSharp.Interfaces;
using FireSharp.Response;
using FootballStatsApp.Handlers;
using FootballStatsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatsApp.Services.MatchDeleters
{
    public class DatabaseMatchDeleter : IMatchDeleter
    {
        private readonly FirebaseDBHandler _fireBaseDBHandler;

        public DatabaseMatchDeleter(FirebaseDBHandler fireBaseDBHandler)
        {
            _fireBaseDBHandler = fireBaseDBHandler;
        }

        public async Task DeleteMatch(Guid matchID)
        {
            IFirebaseClient client = _fireBaseDBHandler.FireDBConnect();
            FirebaseResponse response = await client.DeleteAsync("Holbrook Olympic Fc/Matches/" + matchID);
            Match result = response.ResultAs<Match>();
        }
    }
}
