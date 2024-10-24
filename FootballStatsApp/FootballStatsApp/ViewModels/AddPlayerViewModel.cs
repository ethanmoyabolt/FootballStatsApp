using FootballStatsApp.Commands;
using FootballStatsApp.Enums;
using FootballStatsApp.Models;
using FootballStatsApp.Services;
using FootballStatsApp.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FootballStatsApp.ViewModels
{
    public class AddPlayerViewModel : ViewModelBase
    {
        private string _playerName;
        private PlayerPosition _playerPosition;
        private ObservableCollection<PlayerPosition> _displayPlayerPositions;

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

        public PlayerPosition PlayerPosition
        {
            get
            {
                return _playerPosition;
            }
            set
            {
                _playerPosition = value;
                OnPropertyChanged(nameof(PlayerPosition));
            }
        }

        public ObservableCollection<PlayerPosition> DisplayPlayerPositions
        {
            get
            {
                return _displayPlayerPositions;
            }
            set
            {
                _displayPlayerPositions = value;
                OnPropertyChanged(nameof(DisplayPlayerPositions));
            }
        }



        public ICommand NavigateBackCommand { get; }

        public ICommand AddPlayerToDatabaseCommand { get; }

        public AddPlayerViewModel(TeamStore teamStore)
        {
            AddPlayerToDatabaseCommand = new AddPlayerToDatabaseCommand(teamStore, this);
            _displayPlayerPositions = new ObservableCollection<PlayerPosition>(Enum.GetValues(typeof(PlayerPosition)).Cast<PlayerPosition>().ToList());
        }

    }
}
