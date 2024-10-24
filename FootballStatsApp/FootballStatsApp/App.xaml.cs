using FootballStatsApp.Handlers;
using FootballStatsApp.Models;
using FootballStatsApp.Services;
using FootballStatsApp.Services.MatchCreators;
using FootballStatsApp.Services.MatchDeleters;
using FootballStatsApp.Services.MatchProviders;
using FootballStatsApp.Services.PlayerCreators;
using FootballStatsApp.Services.PlayerDeleters;
using FootballStatsApp.Services.PlayerProviders;
using FootballStatsApp.Stores;
using FootballStatsApp.ViewModels;
using FootballStatsApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FootballStatsApp
{
    public partial class App : Application
    {
        private readonly Team _team;
        private readonly TeamStore _teamStore;
        private readonly FirebaseDBHandler _firebaseDBHandler;

        public App()
        {
            _firebaseDBHandler = new FirebaseDBHandler();
            IPlayerProvider playerProvider = new DatabasePlayerProvider(_firebaseDBHandler);
            IPlayerCreator playerCreator = new DatabasePlayerCreator(_firebaseDBHandler);
            IPlayerDeleter playerDeleter = new DatabasePlayerDeleter(_firebaseDBHandler);

            IMatchProvider matchProvider = new DatabaseMatchProvider(_firebaseDBHandler);
            IMatchCreator matchCreator = new DatabaseMatchCreator(_firebaseDBHandler);
            IMatchDeleter matchDeleter = new DatabaseMatchDeleter(_firebaseDBHandler);

            Squad squad = new Squad(playerProvider, playerCreator, playerDeleter);
            MatchesPlayed matchesPlayed = new MatchesPlayed(matchProvider, matchCreator, matchDeleter);

            _team = new Team("Holbrook Olympic FC", squad, matchesPlayed);
            _teamStore = new TeamStore(_team);
            DependencyService.RegisterSingleton(PlayerListViewModel.LoadViewModel(_teamStore));
            DependencyService.RegisterSingleton(HomeViewModel.LoadViewModel(_teamStore));
            DependencyService.RegisterSingleton(new AddMatchViewModel(_teamStore));
            DependencyService.RegisterSingleton(new AddPlayerViewModel(_teamStore));

            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
    }
}
