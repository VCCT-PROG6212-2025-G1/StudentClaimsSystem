using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentClaimsSystem.Views;

namespace StudentClaimsSystem.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private object currentPage = new object();

        // These are generated: ShowDashboardCommand, ShowModulesCommand, ...
        [RelayCommand]
        private void ShowDashboard() => CurrentPage = new DashboardView { DataContext = new DashboardViewModel() };

        [RelayCommand]
        private void ShowModules() => CurrentPage = new ModulesView { DataContext = new ModulesViewModel(this) };

        [RelayCommand]
        private void ShowAddModule() => CurrentPage = new AddModuleView { DataContext = new AddModuleViewModel(this) };

        [RelayCommand]
        private void ShowSubmitClaim() => CurrentPage = new SubmitClaimView { DataContext = new SubmitClaimViewModel(this) };

        public MainViewModel() => ShowDashboard();

        // Helper methods other ViewModels can call:
        public void RefreshModules() => ShowModulesCommand.Execute(null);
        public void NavigateToAddModule() => ShowAddModuleCommand.Execute(null);
        public void NavigateToDashboard() => ShowDashboardCommand.Execute(null);
        public void NavigateToSubmitClaim() => ShowSubmitClaimCommand.Execute(null);
    }
}
