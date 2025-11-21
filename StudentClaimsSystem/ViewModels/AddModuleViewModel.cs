using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentClaimsSystem.Models;
// add this if your AppDbContext lives in a different namespace:
// using StudentClaimsSystem.Data;
using System.Windows;

namespace StudentClaimsSystem.ViewModels
{
    public partial class AddModuleViewModel : ObservableObject
    {
        private readonly MainViewModel _main;

        [ObservableProperty] private string code = "";
        [ObservableProperty] private string name = "";
        [ObservableProperty] private int credits;
        [ObservableProperty] private int classHoursPerWeek;

        public AddModuleViewModel(MainViewModel main)
        {
            _main = main;
        }

        [RelayCommand]
        private void Save()
        {
            if (string.IsNullOrWhiteSpace(Code) || string.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("Code and Name are required!");
                return;
            }

            // Use classic using-block (works with older C# versions)
            using (var db = new AppDbContext())
            {
                db.Modules.Add(new Module
                {
                    Code = Code,
                    Name = Name,
                    Credits = Credits,
                    ClassHoursPerWeek = ClassHoursPerWeek
                });

                db.SaveChanges();
            }

            MessageBox.Show("Module added successfully!");

            // MainViewModel.ShowModules is an ICommand — use the helper method instead
            _main.RefreshModules();
        }

        [RelayCommand]
        private void Cancel() => _main.RefreshModules();
    }
}
