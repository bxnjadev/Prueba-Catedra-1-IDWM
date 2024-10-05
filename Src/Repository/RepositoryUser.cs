using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P_Cat_1_IDWM.data;
using P_Cat_1_IDWM.Dto;
using P_Cat_1_IDWM.Model;

namespace P_Cat_1_IDWM.Repository
{
    public class RepositoryUser : IRepositoryUser
    {
        private readonly DataProvider _dataProvider;
        private readonly DbSet<User> _users;

        public RepositoryUser(DataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            _users = _dataProvider.Users;
        }

        public IEnumerable<User> All(string? gender, string? sort)
        {
            IEnumerable<User> allUsers = _users;

            if (sort != null)
            {
                    if (sort == "asc")
                    {
                        allUsers = _users.OrderBy(userSearched => userSearched.name);
                    }
                    else if(sort == "desc")
                    {
                        allUsers = _users.OrderByDescending(userSearched => userSearched.name);
                    } else
                    {
                        throw new Exception("The ordering should be (asc,desc)");
                    }   
            }
            
            if (gender != null)
            {
                gender = gender.ToLower();
                if (!(gender == "masculino" 
                      || gender == "femenino"
                      || gender == "otro" 
                      || gender == "prefiero no decirlo"))
                {
                    throw new Exception("Filter gender is bad");
                }
                
                allUsers = _users.Where(userSearched => userSearched.gender == gender);
            }

            return allUsers;
        }

        public User? Delete(int id)
        {
            
            Console.WriteLine(id);
            
            var userSearched = _users.Where(userSearched =>
                    id == userSearched.Id)
                .FirstOrDefault();

            if (userSearched == null)
            {
                return null;
            }

            _users.Remove(userSearched);
            _dataProvider.SaveChanges();
            return userSearched;
        }

        public User? Edit(int id, UserDto user)
        {
            var userSearched = _users.Where(userSearched => userSearched.Id == id)
                .FirstOrDefault();

            if (userSearched == null)
            {
                return null;
            }

            userSearched.dateTime = user.dateTime;
            userSearched.email = user.email;
            userSearched.gender = user.gender;
            userSearched.name = user.email;
            userSearched.rut = user.rut;

            _dataProvider.SaveChanges();
            return userSearched;
        }

        public User? Store(UserDto userDto)
        {
            User? userSearched = _users.Where(userSearched =>
                    userDto.rut == userSearched.rut)
                .FirstOrDefault();

            if (userSearched != null)
            {
                return null;
            }

            var newUser = new User
            {
                rut = userDto.rut,
                gender = userDto.gender,
                dateTime = userDto.dateTime,
                name  = userDto.name,
                email = userDto.email
            };
            
            _users.Add(newUser);
            _dataProvider.SaveChanges();
            return newUser;
        }
    }
}