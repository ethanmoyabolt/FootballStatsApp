using FootballStatsApp.Commands;
using FootballStatsApp.Models;
using FootballStatsApp.Services;
using FootballStatsApp.Stores;
using FootballStatsApp.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace FootballStatsApp.ViewModels
{
    public class HomeViewModel : BindableObject
    {
        private ObservableCollection<MatchViewModel> _matches;

        public IEnumerable<MatchViewModel> Matches => _matches;

        public ICommand NavigateAddMatchCommand { get; }

        public ICommand NavigateIndividualMatchCommand { get; }

        public ICommand LoadMatchesCommand { get; }

        public ICommand RefreshMatchesCommand { get; }

        public ICommand DeleteMatchCommand { get; }


        public HomeViewModel(
            TeamStore teamStore)
        {
            _matches = new ObservableCollection<MatchViewModel>();

            LoadMatchesCommand = new LoadMatchesCommand(this, teamStore);

            NavigateAddMatchCommand = new NavigateCommand($"{nameof(AddMatchPage)}");

            RefreshMatchesCommand = new RefreshMatchesCommand(this, teamStore);

        }

        public static HomeViewModel LoadViewModel(
            TeamStore teamStore)
        {
            HomeViewModel viewModel = new HomeViewModel(
                teamStore);

            viewModel.LoadMatchesCommand.Execute(null);

            return viewModel;
        }
            
        public void UpdateMatches(IEnumerable<Match> matches)
        {
            _matches.Clear();

            foreach (Match match in matches)
            {
                MatchViewModel matchViewModel = new MatchViewModel(match);
                _matches.Add(matchViewModel);
            }
        }
    }
}
