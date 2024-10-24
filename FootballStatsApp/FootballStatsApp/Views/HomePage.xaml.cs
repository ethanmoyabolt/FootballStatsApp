using FootballStatsApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FootballStatsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Get the ViewModel instance from the DependencyService
            var viewModel = DependencyService.Get<HomeViewModel>();
            BindingContext = viewModel;
        }

    }
}