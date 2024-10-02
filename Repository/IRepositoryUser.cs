using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P_Cat_1_IDWM.Model;

namespace P_Cat_1_IDWM.Repository
{
    public interface IRepositoryUser
    {
        
        User? Store(User user);

        IEnumerable<User> All(bool isOrdered, 
        bool ascending, 
        string filterGender);

        User Edit(User user);

        bool Delete(string rut);

    }
}