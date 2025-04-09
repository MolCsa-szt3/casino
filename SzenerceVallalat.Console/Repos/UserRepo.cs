using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzenerceVallalat.Console.Models;
using SzenerceVallalat.Console.DbModels;

namespace SzenerceVallalat.Console.Repos
{
    public class UserRepo
    {
        
        private LottodbContext _context;
        
        public UserRepo() 
        {
            _context = new LottodbContext();
        }
        public List<User> GetAllUsers() 
        {
            return _context.Players.ToList(); 
        }
        public List<User> GetUsersAboveAmount(decimal minMoney) 
        { 
            return _context.Players.Where(x => x.Money > minMoney).ToList();
        }
        public decimal GetTotalMoneyUsersHave()
        {
            return _context.Players.Sum(x => x.Money);
        }
        
    }
}
