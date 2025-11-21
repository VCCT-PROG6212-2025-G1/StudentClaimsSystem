using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentClaimsSystem.Models;
using StudentClaimsSystem.Views;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;

namespace StudentClaimsSystem.ViewModels
{
    public partial class ModulesViewModel : ObservableObject
    {
        private readonly MainViewModel _main;

        [ObservableProperty] private ObservableCollection<Module> modules = [];

        public ModulesViewModel(MainViewModel main)
        {
            _main = main;
            LoadModules();
        }

        [RelayCommand]
        private void AddNew() => _main.ShowAddModule();

        [RelayCommand]
        private void Delete(Module? module)
        {
            if (module == null) return;
            if (MessageBox.Show($"Delete {module.Code}?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using var db = new AppDbContext();
                db.Modules.Remove(module);
                db.SaveChanges();
                LoadModules();
            }
        }

        private void LoadModules()
        {
            using var db = new AppDbContext();
            Modules = new ObservableCollection<Module>(db.Modules.ToList());
        }
    }
}