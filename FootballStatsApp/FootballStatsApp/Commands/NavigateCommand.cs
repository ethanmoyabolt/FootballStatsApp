using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FootballStatsApp.Commands
{
    public class NavigateCommand : AsyncCommandBase
    {
        private readonly string _route;

        public NavigateCommand(string route)
        {
            _route = route;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await Shell.Current.GoToAsync(_route);
        }
    }
}
