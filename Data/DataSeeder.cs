using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;
using P_Cat_1_IDWM.Model;

namespace P_Cat_1_IDWM.data
{
    public class DataSeeder
    {

        public static void Seed(DataProvider dataProvider) {
            var users = dataProvider.Users;

            if(users.Any()){
                return;
            }
            
            var faker = new Faker<User>()
            .RuleFor(u => u.name, f => f.Internet.UserName())
            .RuleFor(u => u.email, f => f.Internet.Email())
            .RuleFor(u => u.dateTime, f => f.Date.Recent())
            .RuleFor(u => u.gender, f => "Other");

            faker.Generate(50).ForEach(user => {
                Console.WriteLine("Addeing user, " + user.name);
                users.Add(user);
            });

            dataProvider.SaveChanges();
        }

    }

}