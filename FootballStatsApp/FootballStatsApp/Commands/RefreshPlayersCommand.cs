using FootballStatsApp.Stores;
using FootballStatsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FootballStatsApp.Commands
{
    public class RefreshPlayersCommand : AsyncCommandBase
    {
        private readonly PlayerListViewModel _playerListViewModel;
        private readonly TeamStore _teamStore;

        public RefreshPlayersCommand(PlayerListViewModel playerListViewModel, TeamStore teamStore)
        {
            _playerListViewModel = playerListViewModel;
            _teamStore = teamStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _teamStore.InitialiseMatchesAndPlayers();

                _playerListViewModel.UpdatePlayers(_teamStore.Players);
            }
            catch (Exception)
            {
                
            }
        }
    }
}
