using Acr.UserDialogs;
using FootballStatsApp.Models;
using FootballStatsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStatsApp.Commands
{
    public class AddPlayerToMatchDaySquadCommand : CommandBase
    {
        private readonly AddMatchViewModel _viewModel;

        public AddPlayerToMatchDaySquadCommand(AddMatchViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
                _viewModel.AddPlayerToMatchDaySquad(_viewModel.PlayerName);
        }
    }
}
