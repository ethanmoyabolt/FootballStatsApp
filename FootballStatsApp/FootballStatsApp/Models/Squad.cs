using FootballStatsApp.Enums;
using FootballStatsApp.Services;
using FootballStatsApp.Services.PlayerCreators;
using FootballStatsApp.Services.PlayerDeleters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatsApp.Models
{
    public class Squad
    {
        private readonly IPlayerProvider _playerProvider;
        private readonly IPlayerCreator _playerCreator;
        private readonly IPlayerDeleter _playerDeleter;

        public Squad(IPlayerProvider playerProvider, IPlayerCreator playerCreator, IPlayerDeleter playerDeleter)
        {
            _playerProvider = playerProvider;
            _playerCreator = playerCreator;
            _playerDeleter = playerDeleter;
        }

        public async Task<IEnumerable<Player>> GetAllPlayers()
        {
            return await _playerProvider.GetAllPlayers();
        }

        public async Task AddPlayer(Player player)
        {
            await _playerCreator.CreatePlayer(player);
        }

        public async Task DeletePlayer(Guid playerID)
        {
            await _playerDeleter.DeletePlayer(playerID);
        }

        public async Task UpdatePlayerAppearances(Player player)
        {
            player.Appearances++;

            if (player.Goals > 0)
            {
                player.GoalsPerGame = player.Goals / player.Appearances;
            }

            if (player.Assists > 0)
            {
                player.AssistsPerGame = player.Assists / player.Appearances;
            }

            if(player.Tackles > 0)
            {
                player.TacklesPerGame = player.Tackles / player.Appearances;
            }

            await _playerCreator.CreatePlayer(player);
        }

        public async Task UpdatePlayerStats(MatchEvents matchEvent, Player player)
        {
            switch (matchEvent)
            {
                case MatchEvents.GoalScored:
                    player.Goals++;
                    player.GoalsPerGame = player.Goals / player.Appearances;
                    player.GoalsAndAssists++;
                    break;
                case MatchEvents.Assist:
                    player.Assists++;
                    player.AssistsPerGame = player.Assists / player.Appearances;
                    player.GoalsAndAssists++;
                    break;
                case MatchEvents.YellowCard:
                    player.YellowCards++;
                    break;
                case MatchEvents.RedCard:
                    player.RedCards++;
                    break;
                case MatchEvents.Shot:
                    player.ShotsTaken++;
                    player.ShotConversionRate = (player.Goals / player.ShotsTaken) * 100;
                    break;
                case MatchEvents.ShotOntarget:
                    player.ShotsTaken++;
                    player.ShotConversionRate = (player.Goals / player.ShotsTaken) * 100;
                    break;
                case MatchEvents.Tackle:
                    player.Tackles++;
                    player.TacklesPerGame = player.Tackles / player.Appearances;
                    break;
                default:
                    break;
            }

            await _playerCreator.CreatePlayer(player);
        }
    }
}
