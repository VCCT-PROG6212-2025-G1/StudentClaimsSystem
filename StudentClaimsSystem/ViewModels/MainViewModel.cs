using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentClaimsSystem.Views;

namespace StudentClaimsSystem.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private object currentPage = new();

        public MainViewModel()
        {
            ShowDashboard();
        }

        [RelayCommand]
        private void ShowDashboard() => CurrentPage = new DashboardView { DataContext = new DashboardViewModel() };

        [RelayCommand]
        private void ShowModules() => CurrentPage = new ModulesView { DataContext = new ModulesViewModel(this) };

        [RelayCommand]
        public void ShowAddModule() => CurrentPage = new AddModuleView { DataContext = new AddModuleViewModel(this) };

        [RelayCommand]
        private void ShowSubmitClaim() => CurrentPage = new SubmitClaimView { DataContext = new SubmitClaimViewModel(this) };

        // Helper methods for other ViewModels to navigate
        public void RefreshModules() => ShowModules();
        public void NavigateToAddModule() => ShowAddModule();
        public void NavigateToSubmitClaim() => ShowSubmitClaim();
        public void NavigateToDashboard() => ShowDashboard();
    }
}