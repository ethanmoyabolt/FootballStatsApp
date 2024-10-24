using FootballStatsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatsApp.Services.PlayerDeleters
{
    public interface IPlayerDeleter
    {
        Task DeletePlayer(Guid playerID);
    }
}
