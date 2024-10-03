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

        public IEnumerable<User> All(bool isOrdered, string typeOrdering, string filterGender)
        {
            IEnumerable<User> allUsers = _users;

            if(!(filterGender == "Masculino" || filterGender == "Femenino" 
            || filterGender == "Otro")){
                throw new Exception("Filter gender is bad");
            }

            if(isOrdered) {

                if(!(typeOrdering == "asc" || typeOrdering == "desc")) {
                    throw new Exception("Filter by ordering is bad");
                }

                if(typeOrdering == "asc") {
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

        public User? Delete(string rut)
        {
          var userSearched = _users.Where(userSearched => 
            rut == userSearched.rut)
            .First();

            if(userSearched == null){
                return null;
            }

            _users.Remove(userSearched);
            _dataProvider.SaveChanges();
            return userSearched;
        }

        public User Edit(User user)
        {

            var userSearched = _users.Where(userSearched => userSearched.Id == user.Id)
            .First();

            if(userSearched == null){
                return null;
            }

            userSearched.dateTime = user.dateTime;
            userSearched.email = user.email;
            userSearched.gender = user.gender;
            userSearched.name = user.email;
            userSearched.rut = user.rut;

            _dataProvider.SaveChanges();
            return user;
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