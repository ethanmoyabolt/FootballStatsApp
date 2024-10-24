using Acr.UserDialogs;
using FootballStatsApp.Enums;
using FootballStatsApp.Models;
using FootballStatsApp.Services;
using FootballStatsApp.Services.Navigation;
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
    public class AddMatchEventToMatchCommand : CommandBase
    {
        private readonly AddMatchViewModel _viewModel;

        public AddMatchEventToMatchCommand(AddMatchViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if (_viewModel.PlayerName == null)
            {
                UserDialogs.Instance.Alert("Please Select Player", "Error", "OK");
            }
            else if (_viewModel.Time == "00:00")
            {
                UserDialogs.Instance.Alert("Please Start StopWatch", "Error", "OK");
            }
            else
            {
                Player player = _viewModel.MatchDaySquad.First(p => p.PlayerName.Contains(_viewModel.PlayerName));
                int minute = int.Parse(_viewModel.Time.Substring(0, 2)) + 1;
                MatchEvent matchEvent = new MatchEvent(_viewModel.MatchEvent, minute, player);
                _viewModel.EventsInMatch.Add(matchEvent);
            }
        }
    }
}
