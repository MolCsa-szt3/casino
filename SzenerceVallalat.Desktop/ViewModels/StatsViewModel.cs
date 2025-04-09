using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzenerceVallalat.Console.DbModels;
using SzenerceVallalat.Console.Repos;

namespace SzenerceVallalat.Desktop.ViewModels
{
    public partial class StatsViewModel : ObservableObject
    {
        private LottodbContext _context;
        [ObservableProperty]
        private int playerCount;
        [ObservableProperty]
        private int brokeCount;
        [ObservableProperty]
        private int over10kCount;
        [ObservableProperty]
        private string moneySum;
        private StatsViewModel() 
        {
            _context = new();
            PlayerCount = _context.Players.Count();
            BrokeCount = _context.Players.Count(x =>x.Money == 0);
            Over10kCount = _context.Players.Count(x => x.Money >= 10000);
            MoneySum = _context.Players.Sum(x => x.Money).ToString("c0");
        }
    }
}
