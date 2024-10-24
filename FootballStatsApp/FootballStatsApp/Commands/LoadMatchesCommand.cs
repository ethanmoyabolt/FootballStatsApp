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
    public class LoadMatchesCommand : AsyncCommandBase
    {
        private readonly HomeViewModel _homeViewModel;
        private readonly TeamStore _teamStore;

        public LoadMatchesCommand(HomeViewModel homeViewModel, TeamStore teamStore)
        {
            _homeViewModel = homeViewModel;
            _teamStore = teamStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _teamStore.Load();

                _homeViewModel.UpdateMatches(_teamStore.Matches);
            }
            catch (Exception)
            {
            }
        }
    }
}
