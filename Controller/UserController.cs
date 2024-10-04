using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P_Cat_1_IDWM.Dto;
using P_Cat_1_IDWM.Model;
using P_Cat_1_IDWM.Repository;

namespace P_Cat_1_IDWM.Controller
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IRepositoryUser _repository;
        public UserController(IRepositoryUser repository){
            _repository = repository;
        }

        [HttpPost]
        [Route("/create")]
        public ActionResult<User> Create(UserDto user) {
            var userCreated = _repository.Store(user);

            if(userCreated == null){
                return Conflict("El Rut ya existe");
            }

            return Ok(userCreated);
        }

        [HttpGet]
        [Route("/get/")]
        public IEnumerable<User> All(
            [FromQuery] string? gender,
            [FromQuery] string? sort
        ) {
            return _repository.All(gender,
            sort);
        }

        [HttpDelete]
        [Route("/delete/{id}")]
        public ActionResult<User> Delete(
           int id
        ) {
            var userDeleted = _repository.Delete(id);

            if(userDeleted == null){
                return NotFound("Uusario no encontrado");
            }

            return userDeleted;
        }

        [HttpPut]
        [Route("/edit/{id}")]
        public ActionResult<User> Update(
            int id,
            [FromBody] UserDto user
        ) {
            
            var userUpdated = _repository.Edit(id, user);
            if(userUpdated == null){
                return NotFound("El usuario no existe");
            }

            return userUpdated;
        }

    }

}