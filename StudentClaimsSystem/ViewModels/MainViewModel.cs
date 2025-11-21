using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

public class MainViewModel : ObservableObject
{
    private object _currentPage;
    public object CurrentPage
    {
        get => _currentPage;
        set => SetProperty(ref _currentPage, value);
    }

    public ICommand ShowModules => new RelayCommand(_ => CurrentPage = new Views.ModulesView());
    public ICommand ShowAddModule => new RelayCommand(_ => CurrentPage = new Views.AddModuleView(this));
    public ICommand ShowClaims => new RelayCommand(_ => CurrentPage = new Views.ClaimsView());
    public ICommand ShowDashboard => new RelayCommand(_ => CurrentPage = new Views.DashboardView());

    public MainViewModel()
    {
        CurrentPage = new Views.DashboardView();
    }

    public void RefreshModules() => ShowModules.Execute(null);
}