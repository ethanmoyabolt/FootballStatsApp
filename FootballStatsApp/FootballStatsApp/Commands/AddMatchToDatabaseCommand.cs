
using Acr.UserDialogs;
using FootballStatsApp.Enums;
using FootballStatsApp.Models;
using FootballStatsApp.Services;
using FootballStatsApp.Stores;
using FootballStatsApp.ViewModels;
using FootballStatsApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xamarin.Forms;

namespace FootballStatsApp.Commands
{
    public class AddMatchToDatabaseCommand : AsyncCommandBase
    {
        private readonly TeamStore _teamStore;
        private readonly AddMatchViewModel _addMatchViewModel;

        public AddMatchToDatabaseCommand(TeamStore teamStore, AddMatchViewModel addMatchViewModel)
        {
            _teamStore = teamStore;
            _addMatchViewModel = addMatchViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            if (_addMatchViewModel.Opposition == ""
                || !_addMatchViewModel.MatchDaySquad.Any()
                || _addMatchViewModel.Location == ""
                || _addMatchViewModel.ManOfTheMatch == "")
            {
                UserDialogs.Instance.Alert("Please Input All Necessary Values", "Error", "OK");
            }
            else
            {
                ObservableCollection<MatchEvent> events = new ObservableCollection<MatchEvent>();
                if (!(_addMatchViewModel.EventsInMatch == null))
                {
                    events = _addMatchViewModel.EventsInMatch;
                }

                Guid matchID = Guid.NewGuid();
                string homeTeam = "";
                string awayTeam = "";
                string score = "";

                MatchOutcome matchOutcome = MatchOutcome.Draw;
                List<Player> StartingXI = new List<Player>();
                Player manOfTheMatch = _addMatchViewModel.AllPlayers.First(p => p.PlayerName == _addMatchViewModel.ManOfTheMatch);

                string date = _addMatchViewModel.MatchDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);


                if (_addMatchViewModel.GoalsScored > _addMatchViewModel.GoalsConceded)
                {
                    matchOutcome = MatchOutcome.Win;
                }
                else if (_addMatchViewModel.GoalsScored < _addMatchViewModel.GoalsConceded)
                {
                    matchOutcome = MatchOutcome.Lose;
                }
                else
                {
                    matchOutcome = MatchOutcome.Draw;
                }

                if (_addMatchViewModel.HomeOrAway == HomeOrAway.Home)
                {
                    homeTeam = "Holbrook Olympic FC";
                    awayTeam = _addMatchViewModel.Opposition;
                    score = $"{_addMatchViewModel.GoalsScored} - {_addMatchViewModel.GoalsConceded}";
                }
                else if (_addMatchViewModel.HomeOrAway == HomeOrAway.Away)
                {
                    homeTeam = _addMatchViewModel.Opposition;
                    awayTeam = "Holbrook Olympic FC";
                    score = $"{_addMatchViewModel.GoalsConceded} - {_addMatchViewModel.GoalsScored}";
                }

                Match match = new Match(matchID,
                    homeTeam,
                    awayTeam,
                    date,
                    _addMatchViewModel.MatchDaySquad,
                    StartingXI,
                    events,
                    _addMatchViewModel.GoalsScored,
                    _addMatchViewModel.GoalsConceded,
                    score,
                    _addMatchViewModel.HomeOrAway,
                    _addMatchViewModel.Location,
                    _addMatchViewModel.MatchDaySquad[0],
                    matchOutcome);

                _addMatchViewModel.Time = "00:00";

                await _teamStore.AddMatch(match);
                UserDialogs.Instance.Alert("Match Has Been Added", "Success", "OK");

                _teamStore.ClearMatchValues();

                DependencyService.RegisterSingleton(PlayerListViewModel.LoadViewModel(_teamStore));
                DependencyService.RegisterSingleton(HomeViewModel.LoadViewModel(_teamStore));
                DependencyService.RegisterSingleton(new AddMatchViewModel(_teamStore));
                DependencyService.RegisterSingleton(new AddPlayerViewModel(_teamStore));

                await Shell.Current.GoToAsync($"../../../..");
            }
        }
    }
}
