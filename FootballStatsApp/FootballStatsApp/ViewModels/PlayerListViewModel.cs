using FootballStatsApp.Commands;
using FootballStatsApp.Models;
using FootballStatsApp.Services;
using FootballStatsApp.Stores;
using FootballStatsApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FootballStatsApp.ViewModels
{
    public class PlayerListViewModel : ViewModelBase
    {
        private ObservableCollection<PlayerViewModel> _players;
        public IEnumerable<PlayerViewModel> Players => _players;

        public ICommand LoadPlayersCommand { get; }

        public ICommand RefreshPlayersCommand { get; }

        public ICommand NavigateAddPlayerCommand { get; }

        public ICommand DeletePlayerCommand { get; }

        public ICommand ViewPlayerCommand { get; }

        public PlayerListViewModel(
            TeamStore teamStore)
        {
            _players = new ObservableCollection<PlayerViewModel>();

            LoadPlayersCommand = new LoadPlayersCommand(this, teamStore);

            NavigateAddPlayerCommand = new NavigateCommand(nameof(AddPlayerPage));

            RefreshPlayersCommand = new RefreshPlayersCommand(this, teamStore);

        }

        public static PlayerListViewModel LoadViewModel(
            TeamStore teamStore)
        {
            PlayerListViewModel viewModel = new PlayerListViewModel(
                teamStore);

            viewModel.LoadPlayersCommand.Execute(null);

            return viewModel;

        }

        public void UpdatePlayers(IEnumerable<Player> players)
        {
            _players.Clear();

            foreach (Player player in players)
            {
                PlayerViewModel playerViewModel = new PlayerViewModel(player);
                _players.Add(playerViewModel);
            }
            
            var ordered = _players.OrderBy(p => p.Position).ToList();
            _players.Clear();
            foreach (PlayerViewModel player in ordered)
            {
                _players.Add(player);
            }
        }
    }
}
