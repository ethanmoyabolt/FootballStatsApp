using FootballStatsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FootballStatsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMatchDaySquadPage : ContentPage
    {
        public AddMatchDaySquadPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Get the ViewModel instance from the DependencyService
            var viewModel = DependencyService.Get<AddMatchViewModel>();
            BindingContext = viewModel;
        }

    }
}