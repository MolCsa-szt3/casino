using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzenerceVallalat.Console.Models
{
    public class User
    {
        private string _email;
        private string _name;
        private decimal _money;
        private int _id;
        

        public User(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new InvalidDataException("Név nem lehet üres!");
            if (!email.Contains('@')) throw new InvalidDataException("Helytelen az Email formátuma!");
            _name = name;
            _email = email;
            _money = 0;
        }
        public bool HasMoney()
        {
            return _money != 0;
        }
        public void AddMoney(decimal amount)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException("Csak pozitív mennyiségű pénzt lehet hozzáadni!");
            _money += amount;
        }

        public string Email { get => _email; set => _email = value; }
        public string Name { get => _name; set => _name = value; }
        public decimal Money { get => _money; set => _money = value; }
        public int Id { get => _id; set => _id = value; }

        public void Bet(decimal amount)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException("Csak pozitív mennyiségű pénzt lehet fogadni!");
            if (_money < amount) throw new ArgumentException("Nincs elég pénze a felhaználónak!");
            _money -= amount;
        }
        public override string ToString()
        {
            return $"{_name} ({_email}) {_money:c0}";
        }
    }
}
