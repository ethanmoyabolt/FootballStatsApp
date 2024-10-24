using FootballStatsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatsApp.Commands
{
    public class StartStopWatchCommand : CommandBase
    {
        private readonly AddMatchViewModel _viewModel;

        public StartStopWatchCommand(AddMatchViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _viewModel.StartStopWatch();
        }
    }
}
