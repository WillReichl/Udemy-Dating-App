using System.Collections.Generic;
using DatingApp.API.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DatingApp.API.Data
{
    public class Seed
    {
        private readonly DataContext _dataContext;

        public Seed(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public void SeedUsers() {
            if (_dataContext.Users.Any(u => u.Id > 0))
                return;

            var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);

            foreach (var user in users)
            {
                byte [] passwordHash, passwordSalt;
                CreatePasswordHash("passwprd", out passwordHash, out passwordSalt);
                user.Username = user.Username.ToLower();

                _dataContext.Add(user);
            }
            _dataContext.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}