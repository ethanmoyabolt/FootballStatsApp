using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using System.Windows;
using FootballStatsApp.Models;
using Newtonsoft.Json;

namespace FootballStatsApp.Handlers
{
    public class FirebaseDBHandler
    {
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "gjf30CccfuS94HrVTdwJ3lNyU5TkoquDlLNVzUy5",
            BasePath = "https://test-database-aa0d6-default-rtdb.europe-west1.firebasedatabase.app/"
        };

        public FirebaseDBHandler()
        {
        }

        IFirebaseClient client;

        public IFirebaseClient FireDBConnect()
        {
            try
            {
                IFirebaseClient client = new FirebaseClient(ifc);
                return client;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async void AddMatch(Match match)
        {
            client = FireDBConnect();
            SetResponse response = await client.SetAsync("Matches/" + match.MatchId, match);
            Match result = response.ResultAs<Match>();
            
        }

        public async void AddPlayer(Player player)
        {
            client = FireDBConnect();
            SetResponse response = await client.SetAsync("Squad/" + player.PlayerID, player);
            Player result = response.ResultAs<Player>();

        }

        public async Task<Player> GetPlayerFromDb(Player player)
        {
            client = FireDBConnect();
            FirebaseResponse response = await client.GetAsync("Squad/"+1);
            Player result = response.ResultAs<Player>();
            return result;
        }

        public async Task<List<Player>> GetSquadFromDb()
        {
            client = FireDBConnect();
            FirebaseResponse response = await client.GetAsync(@"Squad");
            Dictionary<string, Player> data = JsonConvert.DeserializeObject<Dictionary<string, Player>>(response.Body);
            List<Player> playerList = new List<Player>(data.Values);
            return playerList;
        }
    }
}
