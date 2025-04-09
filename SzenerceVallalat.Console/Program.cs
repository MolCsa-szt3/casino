using SzenerceVallalat.Console.Repos;
//testing if repo works
Console.WriteLine("test");

UserRepo repo = new UserRepo();
Console.WriteLine(repo.GetAllUsers().Count());
Console.WriteLine(repo.GetTotalMoneyUsersHave());
