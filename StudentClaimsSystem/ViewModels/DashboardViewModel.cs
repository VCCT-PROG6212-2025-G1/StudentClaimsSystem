using CommunityToolkit.Mvvm.ComponentModel;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.EntityFrameworkCore;
using StudentClaimsSystem.Models;

namespace StudentClaimsSystem.ViewModels
{
    public partial class DashboardViewModel : ObservableObject
    {
        public SeriesCollection Series { get; set; } = new();
        public string[] Labels { get; set; } = [];

        public DashboardViewModel()
        {
            using var db = new AppDbContext();
            var data = db.Claims
                .Include(c => c.Module)
                .GroupBy(c => c.Module.Name)
                .Select(g => new { Name = g.Key ?? "Unknown", Total = g.Sum(c => c.HoursClaimed) })
                .ToList();

            Labels = data.Select(x => x.Name).ToArray();
            Series.Add(new ColumnSeries
            {
                Title = "Hours Claimed",
                Values = new ChartValues<double>(data.Select(x => x.Total)),
                Fill = System.Windows.Media.Brushes.CornflowerBlue
            });
        }
    }
}