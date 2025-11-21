using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentClaimsSystem.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
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

        public IRelayCommand UploadFileCommand { get; }
        public IRelayCommand SubmitCommand { get; }
        public int HoursClaimed { get; private set; }

        public SubmitClaimViewModel(MainViewModel mainVM)
        {
            _mainVM = mainVM;
            UploadFileCommand = new RelayCommand(_ => UploadFile());
            SubmitCommand = new RelayCommand(_ => SubmitClaim());
            LoadModules();
        }

        private void LoadModules()
        {
            using var db = new AppDbContext();
            Modules = new ObservableCollection<Module>(db.Modules.ToList());
        }

        private void UploadFile()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                _filePath = dialog.FileName;
                FileName = Path.GetFileName(_filePath);
            }
        }

        private void SubmitClaim()
        {
            if (SelectedModule == null || HoursClaimed <= 0) { MessageBox.Show("Invalid data"); return; }

            var destFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Documents");
            Directory.CreateDirectory(destFolder);
            var destPath = Path.Combine(destFolder, FileName ?? "document.pdf");
            if (_filePath != null) File.Copy(_filePath, destPath, true);

            using var db = new AppDbContext();
            db.Claims.Add(new Claim
            {
                ModuleId = SelectedModule.Id,
                HoursClaimed = HoursClaimed,
                Description = Description,
                DocumentPath = destPath
            });
            db.SaveChanges();

            MessageBox.Show("Claim submitted!");
            _mainVM.RefreshModules(); // navigate back to modules list
        }
    }
}
