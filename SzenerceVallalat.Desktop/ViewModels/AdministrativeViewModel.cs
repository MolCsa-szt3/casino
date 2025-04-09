using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SzenerceVallalat.Console.DbModels;
using SzenerceVallalat.Console.Models;

namespace SzenerceVallalat.Desktop.ViewModels
{
    public partial class AdministrativeViewModel :ObservableObject
    {
        private LottodbContext _context;
        [ObservableProperty]
        private string inputName;
        [ObservableProperty]
        private string inputEmail;
        [ObservableProperty]
        private string inputAmount;
        [ObservableProperty]
        private List<User> players;
        [ObservableProperty]
        private User selectedUser;
        public AdministrativeViewModel() 
        {
            _context = new LottodbContext();
            InputName = "";
            InputEmail = "";
            InputAmount = "";
            Players = _context.Players.ToList();
            SelectedUser = new("-", "-@-");
        }
        [RelayCommand]
        public void AddPlayer()
        {
            if(string.IsNullOrEmpty(InputEmail) || !InputEmail.Contains('@') || string.IsNullOrWhiteSpace(InputName))
            {
                MessageBox.Show("Hiányzó adatok!", "HIBA");
            }
            else
            {
                _context.Players.Add(new User(InputName, InputEmail));
                _context.SaveChanges();
                InputName = "";
                InputEmail = "";
            }
        }
        [RelayCommand]
        public void AlterPlayer()
        {
            if (SelectedUser.Equals(new User("-", "-@-"))) MessageBox.Show("Valakit ki kell választani!", "Hiba");
            else if (string.IsNullOrEmpty(InputEmail) || !InputEmail.Contains('@') || string.IsNullOrWhiteSpace(InputName))
            {
                MessageBox.Show("Hiányzó adatok!", "Hiba");
            }
            else
            {
                _context.Players.Update(new User(InputName, InputEmail) { Id = SelectedUser.Id});
                _context.SaveChanges();
                InputName = "";
                InputEmail = "";
                SelectedUser = new("-", "-@-");
            }
        }
        [RelayCommand]
        public void RemovePlayer()
        {
            if (SelectedUser.Equals(new User("-", "-@-"))) MessageBox.Show("Valakit ki kell választani!", "Hiba");
            else if (SelectedUser.Money != 0) MessageBox.Show("Csak azt lehet, akinek keretösszege 0Ft!", "HIBA");
            else
            {
                _context.Players.Remove(SelectedUser);
                _context.SaveChanges();
            }
            SelectedUser = new("-", "-@-");
        }
        [RelayCommand]
        public void AddMoney()
        {
            decimal amount = 0;
            if (SelectedUser.Equals(new User("-", "-@-"))) MessageBox.Show("Valakit ki kell választani!", "Hiba");
            else if (!decimal.TryParse(InputAmount, out amount)) MessageBox.Show("Helytelen szám van megadva!", "Hiba");
            else if(amount <= 0) MessageBox.Show("Csak pozitív szám lehet!","Hiba");
            else
            {
                _context.Players.Where(x =>x.Id == SelectedUser.Id).First().Money =+ amount;
            }
            _context.SaveChanges();
            SelectedUser = new("-", "-@-");
            InputAmount = "";
        }
    }
}
