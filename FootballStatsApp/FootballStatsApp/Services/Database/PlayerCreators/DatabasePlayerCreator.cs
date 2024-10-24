using FireSharp.Interfaces;
using FireSharp.Response;
using FootballStatsApp.Handlers;
using FootballStatsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatsApp.Services.PlayerCreators
{
    public class DatabasePlayerCreator : IPlayerCreator
    {
        private readonly FirebaseDBHandler _fireBaseDBHandler;

        public DatabasePlayerCreator(FirebaseDBHandler firebaseDBHandler)
        {
            _fireBaseDBHandler = firebaseDBHandler;
        }

        public async Task CreatePlayer(Player player)
        {
            IFirebaseClient client = _fireBaseDBHandler.FireDBConnect();
            SetResponse response = await client.SetAsync("Holbrook Olympic Fc/Squad/" + player.PlayerID, player);
            Player result = response.ResultAs<Player>();
        }
    }
}
