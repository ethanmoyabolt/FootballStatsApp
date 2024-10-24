using FootballStatsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatsApp.Commands
{
    public class StopStopWatchCommand : CommandBase
    {
        private readonly AddMatchViewModel _viewModel;

        public StopStopWatchCommand(AddMatchViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.StopStopwatch();
        }
    }
}
