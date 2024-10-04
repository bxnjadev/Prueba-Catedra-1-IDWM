using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P_Cat_1_IDWM.Dto;
using P_Cat_1_IDWM.Model;

namespace P_Cat_1_IDWM.Repository
{
    public interface IRepositoryUser
    {
        
        User? Store(UserDto userDto);

        IEnumerable<User> All(
        string? gender, 
        string? sort);

        User? Edit(int id, UserDto userDto);

        User? Delete(int id);

    }
}