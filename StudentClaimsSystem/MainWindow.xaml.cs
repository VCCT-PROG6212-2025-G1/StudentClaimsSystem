using System.Windows;
using StudentClaimsSystem.ViewModels;

namespace StudentClaimsSystem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}