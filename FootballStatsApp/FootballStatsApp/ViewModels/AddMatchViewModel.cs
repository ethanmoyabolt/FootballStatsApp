using Acr.UserDialogs;
using FootballStatsApp.Commands;
using FootballStatsApp.Enums;
using FootballStatsApp.Models;
using FootballStatsApp.Services;
using FootballStatsApp.Stores;
using FootballStatsApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Xamarin.Forms;

namespace FootballStatsApp.ViewModels
{
    public class AddMatchViewModel : ViewModelBase
    {
        private TeamStore _teamStore;
        private string _opposition;
        private DateTime _matchDate;
        ObservableCollection<Player> _matchDaySquad;
        public List<Player> _startingXI;
        public IEnumerable<Player> _allPlayers;
        public List<string> _matchDaySquadNames;
        public ObservableCollection<string> _playerNames;
        public ObservableCollection<MatchEvent> _eventsInMatch;
        public ObservableCollection<HomeOrAway> _displayHomeOrAway;
        public ObservableCollection<MatchEvents> _displayMatchEvents;
        private MatchEvents _matchEvent;
        private int _minute;
        public int _goalsScored;
        public int _goalsConceded;
        public string _score;
        public HomeOrAway _homeOrAway;
        public string _location;
        private string _playerName;
        private string _manOfTheMatch;
        private Stopwatch _stopwatch;
        private bool _isRunning;
        private string _time;

        public ICommand NavigateHomeCommand { get; }

        public ICommand OpenAddMatchEventCommand { get; }

        public ICommand AddMatchToDatabaseCommand { get; }

        public ICommand AddPlayerToMatchDaySquadCommand { get; }

        public ICommand AddMatchEventToMatchCommand { get; }

        public ICommand DecrementGoalsScoredCommand { get; }

        public ICommand IncrementGoalsScoredCommand { get; }

        public ICommand DecrementGoalsConcededCommand { get; }

        public ICommand IncrementGoalsConcededCommand { get; }

        public ICommand RemoveMatchEventCommand { get; }

        public ICommand NavigateAddMatchDaySquadCommand { get; }

        public ICommand NavigateAddMatchEventsCommand { get; }

        public ICommand NavigateAddManOfTheMatchCommand { get; }

        public ICommand StartStopWatchCommand { get; }

        public ICommand StopStopWatchCommand { get; }

        public string Opposition
        {
            get
            {
                return _opposition;
            }
            set
            {
                _opposition = value;
                OnPropertyChanged(nameof(Opposition));
            }
        }

        public DateTime MatchDate
        {
            get
            {
                return _matchDate;
            }
            set
            {
                _matchDate = value;
                OnPropertyChanged(nameof(MatchDate));
            }
        }

        public ObservableCollection<Player> MatchDaySquad
        {
            get
            {
                return _matchDaySquad;
            }
            set
            {
                _matchDaySquad = value;
                OnPropertyChanged(nameof(MatchDaySquad));
            }
        }

        public List<Player> StartingXI
        {
            get
            {
                return _startingXI;
            }
            set
            {
                _startingXI = value;
                OnPropertyChanged(nameof(StartingXI));
            }
        }

        public IEnumerable<Player> AllPlayers
        {
            get
            {
                return _allPlayers;
            }
            set
            {
                _allPlayers = value;
                OnPropertyChanged(nameof(AllPlayers));
            }
        }

        public ObservableCollection<MatchEvent> EventsInMatch
        {
            get
            {
                return _eventsInMatch;
            }
            set
            {
                _eventsInMatch = value;
                OnPropertyChanged(nameof(EventsInMatch));
            }
        }

        public string ManOfTheMatch
        {
            get
            {
                return _manOfTheMatch;
            }
            set
            {
                _manOfTheMatch = value;
                OnPropertyChanged(nameof(ManOfTheMatch));
            }
        }

        public int GoalsScored
        {
            get
            {
                return _goalsScored;
            }
            set
            {
                _goalsScored = value;
                OnPropertyChanged(nameof(GoalsScored));
            }
        }

        public int GoalsConceded
        {
            get
            {
                return _goalsConceded;
            }
            set
            {
                _goalsConceded = value;
                OnPropertyChanged(nameof(GoalsConceded));
            }
        }

        public string Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                OnPropertyChanged(nameof(Score));
            }
        }

        public HomeOrAway HomeOrAway
        {
            get
            {
                return _homeOrAway;
            }
            set
            {
                _homeOrAway = value;
                OnPropertyChanged(nameof(HomeOrAway));
            }
        }

        public ObservableCollection<HomeOrAway> DisplayHomeOrAway
        {
            get
            {
                return _displayHomeOrAway;
            }
            set
            {
                _displayHomeOrAway = value;
                OnPropertyChanged(nameof(DisplayHomeOrAway));
            }
        }

        public ObservableCollection<MatchEvents> DisplayMatchEvents
        {
            get
            {
                return _displayMatchEvents;
            }
            set
            {
                _displayMatchEvents = value;
                OnPropertyChanged(nameof(DisplayMatchEvents));
            }
        }

        public ObservableCollection<string> PlayerNames
        {
            get
            {
                return _playerNames;
            }
            set
            {
                _playerNames = value;
                OnPropertyChanged(nameof(PlayerNames));
            }
        }


        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        public string PlayerName
        {
            get
            {
                return _playerName;
            }
            set
            {
                _playerName = value;
                OnPropertyChanged(nameof(PlayerName));
            }
        }

        public List<string> MatchDaySquadNames
        {
            get
            {
                return _matchDaySquadNames;
            }
            set
            {
                _matchDaySquadNames = value;
                OnPropertyChanged(nameof(MatchDaySquadNames));
            }
        }

        public MatchEvents MatchEvent
        {
            get
            {
                return _matchEvent;
            }
            set
            {
                _matchEvent = value;
                OnPropertyChanged(nameof(MatchEvent));
            }
        }

        public int Minute
        {
            get
            {
                return _minute;
            }
            set
            {
                _minute = value;
                OnPropertyChanged(nameof(Minute));
            }
        }

        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

        public AddMatchViewModel(
            TeamStore teamStore)
        {
            _teamStore = teamStore;
            _stopwatch = new Stopwatch();

            AddPlayerToMatchDaySquadCommand = new AddPlayerToMatchDaySquadCommand(this);
            AddMatchEventToMatchCommand = new AddMatchEventToMatchCommand(this);
            AddMatchToDatabaseCommand = new AddMatchToDatabaseCommand(teamStore, this);
            IncrementGoalsScoredCommand = new IncrementGoalsScoredCommand(this);
            DecrementGoalsScoredCommand = new DecrementGoalsScoredCommand(this);
            IncrementGoalsConcededCommand = new IncrementGoalsConcededCommand(this);
            DecrementGoalsConcededCommand = new DecrementGoalsConcededCommand(this);
            RemoveMatchEventCommand = new RemoveMatchEventCommand(teamStore, this);
            NavigateAddMatchDaySquadCommand = new NavigateCommand($"{nameof(AddMatchDaySquadPage)}");
            NavigateAddMatchEventsCommand = new NavigateCommand($"{nameof(AddMatchEventsPage)}");
            NavigateAddManOfTheMatchCommand = new NavigateCommand($"{nameof(AddManOfTheMatchPage)}");
            StartStopWatchCommand = new StartStopWatchCommand(this);
            StopStopWatchCommand = new StopStopWatchCommand(this);

            _time = "00:00";
            _allPlayers = _teamStore.Players;
            _playerNames = new ObservableCollection<string>(_allPlayers.Select(player => player.PlayerName).ToList());
            _matchDaySquadNames = new List<string>();
            _matchDaySquad = new ObservableCollection<Player>(_teamStore.CurrentMatchDaySquad);
            _startingXI = new List<Player>();
            _eventsInMatch = new ObservableCollection<MatchEvent>(_teamStore.CurrentMatchEvents);

            _opposition = _teamStore.CurrentMatchOpposition;
            _goalsScored = _teamStore.CurrentMatchGoalsScored;
            _goalsConceded = _teamStore.CurrentMatchGoalsConceded;
            _location = _teamStore.CurrentMatchLocation;
            _homeOrAway = _teamStore.CurrentMatchHomeAway;
            _matchDate = _teamStore.CurrentMatchDate;

            _displayHomeOrAway = new ObservableCollection<HomeOrAway>(Enum.GetValues(typeof(HomeOrAway)).Cast<HomeOrAway>().ToList());
            _displayMatchEvents = new ObservableCollection<MatchEvents>(Enum.GetValues(typeof(MatchEvents)).Cast<MatchEvents>().ToList());
        }

        public void AddPlayerToMatchDaySquad(string playerName)
        {
            if (playerName == "")
            {
                UserDialogs.Instance.Alert("Please Input Player Name", "Error", "OK");
            }
            else if (!_allPlayers.Any())
            {
                UserDialogs.Instance.Alert("Player Not In Squad", "Error", "OK");
            }
            else if(_allPlayers.Any(player => player.PlayerName.Contains(playerName))
                && !_matchDaySquad.Any(player => player.PlayerName.Contains(playerName)))
            {
                Player player = AllPlayers.First(p => p.PlayerName.ToLower() == playerName.ToLower());
                _matchDaySquad.Add(player);
                _matchDaySquadNames.Add(player.PlayerName);
                ClearPlayerName();
            }
        }

        public void IncrementGoalsScored()
        {
            GoalsScored++;
        }

        public void DecrementGoalsScored()
        {
            if (GoalsScored > 0)
            {
                GoalsScored--;
            }
        }

        public void IncrementGoalsConceded()
        {
            GoalsConceded++;
        }

        public void DecrementGoalsConceded()
        {
            if (GoalsConceded > 0)
            {
                GoalsConceded--;
            }
        }

        public void ClearPlayerName()
        {
            PlayerName = "";
        }

        public void StartStopWatch()
        {
            if (_isRunning)
            {
                return;
            }

            _stopwatch.Start();
            _isRunning = true;

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Time = _stopwatch.Elapsed.ToString("mm\\:ss");
                return _isRunning;
            });
        }

        public void StopStopwatch()
        {
            if (!_isRunning)
            {
                return;
            }

            _stopwatch.Stop();
            _isRunning = false;
        }
    }
}
