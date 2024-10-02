using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P_Cat_1_IDWM.data;
using P_Cat_1_IDWM.Model;

namespace P_Cat_1_IDWM.Repository
{
    public class RepositoryUser : IRepositoryUser
    {

        private readonly DataProvider _dataProvider;
        private readonly DbSet<User> _users;

        public RepositoryUser(DataProvider dataProvider) {
            _dataProvider = dataProvider;
            _users = _dataProvider.Users;
        }

        public IEnumerable<User> All(bool isOrdered, bool ascending, string filterGender)
        {
            IEnumerable<User> allUsers = _users;

            if(isOrdered) {
                if(ascending) {
                    allUsers = _users.OrderBy(userSearched => userSearched.name);
                } else {
                    allUsers = _users.OrderByDescending(userSearched => userSearched.name);
                }
            }

            if(filterGender != ""){
                allUsers = _users.Where(userSearched => userSearched.gender == filterGender);                
            }

            return allUsers;
        }

        public bool Delete(string rut)
        {
          var userSearched = _users.Where(userSearched => 
            rut == userSearched.rut)
            .First();

            if(userSearched == null){
                return false;
            }

            _users.Remove(userSearched);
            return true;
        }

        public User Edit(User user)
        {
            throw new NotImplementedException();
        }

        public User? Store(User user)
        {
            var userSearched = _users.Where(userSearched => 
            user.rut == userSearched.rut)
            .First();

            if(userSearched != null){
                return null;
            }

            _users.Add(user);
            _dataProvider.SaveChanges();
            return user;
        }
    }

}