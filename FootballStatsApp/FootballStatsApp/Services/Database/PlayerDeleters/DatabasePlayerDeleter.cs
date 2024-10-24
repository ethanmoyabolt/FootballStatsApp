using FireSharp.Interfaces;
using FireSharp.Response;
using FootballStatsApp.Handlers;
using FootballStatsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatsApp.Services.PlayerDeleters
{
    public class DatabasePlayerDeleter : IPlayerDeleter
    {
        private readonly FirebaseDBHandler _fireBaseDBHandler;

        public DatabasePlayerDeleter(FirebaseDBHandler fireBaseDBHandler)
        {
            _fireBaseDBHandler = fireBaseDBHandler;
        }

        public async Task DeletePlayer(Guid playerID)
        {
            IFirebaseClient client = _fireBaseDBHandler.FireDBConnect();
            FirebaseResponse response = await client.DeleteAsync("Holbrook Olympic Fc/Squad/" + playerID);
            Player result = response.ResultAs<Player>();
        }
    }
}
