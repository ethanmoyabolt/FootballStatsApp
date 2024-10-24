using FootballStatsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatsApp.Services
{
    public interface IPlayerProvider
    {
        Task<IEnumerable<Player>> GetAllPlayers();
    }
}
