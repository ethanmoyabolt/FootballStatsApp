using FootballStatsApp.Handlers;
using FootballStatsApp.Models;
using FootballStatsApp.Stores;
using FootballStatsApp.Services;
using FootballStatsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FootballStatsApp.Views;
using Acr.UserDialogs;

namespace FootballStatsApp.Commands
{
    public class AddPlayerToDatabaseCommand : AsyncCommandBase
    {
        private readonly TeamStore _teamStore;
        private readonly AddPlayerViewModel _addPlayerViewModel;

        public AddPlayerToDatabaseCommand(TeamStore teamStore, AddPlayerViewModel addPlayerViewModel)
        {
            _teamStore = teamStore;
            _addPlayerViewModel = addPlayerViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {


            if (_addPlayerViewModel.PlayerName == "")
            {
                UserDialogs.Instance.Alert("Please Input Player Name", "Error", "OK");
            }
            else
            {
                Guid playerID = Guid.NewGuid();
                Player player = new Player(playerID,
                    _addPlayerViewModel.PlayerName.Trim(),
                    _addPlayerViewModel.PlayerPosition);

                await _teamStore.AddPlayer(player);

                DependencyService.RegisterSingleton(PlayerListViewModel.LoadViewModel(_teamStore));
                DependencyService.RegisterSingleton(HomeViewModel.LoadViewModel(_teamStore));
                DependencyService.RegisterSingleton(new AddMatchViewModel(_teamStore));
                DependencyService.RegisterSingleton(new AddPlayerViewModel(_teamStore));

                await Shell.Current.GoToAsync($"..");
            }

        }
    }
}
