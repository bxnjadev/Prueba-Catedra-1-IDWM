using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P_Cat_1_IDWM.Model;
using P_Cat_1_IDWM.Repository;

namespace P_Cat_1_IDWM.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private IRepositoryUser _repository;
        public UserController(IRepositoryUser repository){
            _repository = repository;
        }

        [HttpPost]
        [Route("/create/")]
        public ActionResult<User> Create(User user) {
            var userCreated = _repository.Store(user);

            if(userCreated == null){
                return Conflict("El Rut ya existe");
            }

            return userCreated;
        }

        [HttpGet]
        [Route("/get/")]
        public IEnumerable<User> All(
            [FromQuery] bool isOrdered,
            [FromQuery] string typeOrdered,
            [FromQuery] string typeGender
        ) {
            
            
            return _repository.All(isOrdered,
            typeOrdered,
            typeGender);
        }

        [HttpDelete]
        [Route("/delete/{id}")]
        public ActionResult<User> Delete(
            [FromQuery] string id
        ) {
            var userDeleted = _repository.Delete(id);

            if(userDeleted == null){
                return NotFound("Uusario no encotnrado");
            }

            return userDeleted;
        }

        [HttpPut]
        [Route("/update/")]
        public ActionResult<User> Update(
            [FromBody] User user
        ) {
            
        }

    }

}