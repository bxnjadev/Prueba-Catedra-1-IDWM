using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Microsoft.EntityFrameworkCore;
using P_Cat_1_IDWM.Model;
using P_Cat_1_IDWM.Util;

namespace P_Cat_1_IDWM.data
{
    public class DataSeeder
    {
        private static readonly Random _random = new Random();

        public static void Seed(DataProvider dataProvider)
        {
            var users = dataProvider.Users;

            if (users.Any())
            {
                return;
            }

            var faker = new Faker<User>()
                .RuleFor(u => u.rut, f => GenerateRut())
                .RuleFor(u => u.name, f => f.Internet.UserName())
                .RuleFor(u => u.email, f => f.Internet.Email())
                .RuleFor(u => u.dateTime, f => f.Date.Recent())
                .RuleFor(u => u.gender, f => RandomGender());

            faker.Generate(50).ForEach(user =>
            {
                Console.WriteLine("Addeing user, " + user.name);
                users.Add(user);
            });

            dataProvider.SaveChanges();
        }

        public static string RandomGender()
        {
            int value = _random.Next(0, 4);

            if (value == 0)
            {
                return "masculino";
            } if (value == 1)
            {
                return "femenino";
            }

            if (value == 2)
            {
                return "otro";
            }

            return "prefiero no decirlo"; 
        }

        public static string GenerateRut()
        {
            var number = RandomUtil.RandomNumbers(8);
            var lastDigit = GetVerificationCode(number);

            return number + "" + lastDigit;
        }
        
        
        private static int GetVerificationCode(int rut) 
        {
            int[] coefficients = [2, 3, 4, 5, 6, 7];
            var sum = 0;
            var index = 0;

            while (rut != 0) {
                sum += rut % 10 * coefficients[index];
                rut = rut / 10;
                index = (index + 1) % 6;
            }
            int verificador = 11 - (sum % 11);
            return verificador == 11 ? 0 : verificador;
        }
        
    }
    
    
    
    
}