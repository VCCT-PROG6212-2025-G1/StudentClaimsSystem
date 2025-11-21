using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using StudentClaimsSystem.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace StudentClaimsSystem.ViewModels
{
    public partial class SubmitClaimViewModel : ObservableObject
    {
        private readonly MainViewModel _mainVM;

        [ObservableProperty] private ObservableCollection<Module> modules = new();
        [ObservableProperty] private Module? selectedModule;
        [ObservableProperty] private double hoursClaimed;
        [ObservableProperty] private string description = "";
        [ObservableProperty] private string? fileName;

        private string? _filePath;

        public SubmitClaimViewModel(MainViewModel mainVM)
        {
            _mainVM = mainVM;
            LoadModules();
        }

        private void LoadModules()
        {
            using var db = new AppDbContext();
            Modules = new ObservableCollection<Module>(db.Modules.ToList());
        }

        [RelayCommand]
        private void UploadFile()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                _filePath = dialog.FileName;
                FileName = Path.GetFileName(_filePath);
            }
        }

        [RelayCommand]
        private void SubmitClaim()
        {
            if (SelectedModule == null || HoursClaimed <= 0)
            {
                MessageBox.Show("Please select a module and enter hours.");
                return;
            }

            var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Documents");
            Directory.CreateDirectory(folder);
            var destPath = Path.Combine(folder, FileName ?? "document.pdf");

            if (_filePath != null)
                File.Copy(_filePath, destPath, true);

            using var db = new AppDbContext();
            db.Claims.Add(new Claim
            {
                ModuleId = SelectedModule.Id,
                HoursClaimed = HoursClaimed,
                Description = Description,
                DocumentPath = destPath
            });
            db.SaveChanges();

            MessageBox.Show("Claim submitted successfully!");
            _mainVM.CurrentPage = new Views.ModulesView();
        }
    }
}