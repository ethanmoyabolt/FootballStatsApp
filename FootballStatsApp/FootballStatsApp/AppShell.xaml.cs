using FootballStatsApp.ViewModels;
using FootballStatsApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FootballStatsApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddMatchPage), typeof(AddMatchPage));
            Routing.RegisterRoute(nameof(AddMatchDaySquadPage), typeof(AddMatchDaySquadPage));
            Routing.RegisterRoute(nameof(AddMatchEventsPage), typeof(AddMatchEventsPage));
            Routing.RegisterRoute(nameof(AddManOfTheMatchPage), typeof(AddManOfTheMatchPage));
            Routing.RegisterRoute(nameof(AddPlayerPage), typeof(AddPlayerPage));
        }

    }
}
