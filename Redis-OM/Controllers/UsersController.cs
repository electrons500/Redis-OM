using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Redis_OM.Data.Model;
using Redis_OM.Data.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Redis_OM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersService _UsersService;

        public UsersController(UsersService usersService)
        {
            _UsersService = usersService;
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult AddUsers([FromBody] Users user)    
        {
            bool result = _UsersService.AddUsers(user);
            if (result)
            {
                return StatusCode(StatusCodes.Status201Created, user);
            }

            return BadRequest();
        }
        // GET: api/<UsersController>
        [HttpGet("GetUsers")]
        public ActionResult GetUsers()
        {
            var users = _UsersService.GetUsers();
            return StatusCode(StatusCodes.Status200OK, users);
        }

        // GET api/<UsersController>/5
        [HttpGet("GetUserById/{id}")]
        public ActionResult GetUserById([FromRoute] string id)
        {
            var users = _UsersService.GetUsersById(id);
            return StatusCode(StatusCodes.Status200OK, users);
        }

        [HttpGet("filterByAge")]
        public ActionResult FilterByAge([FromQuery] int minAge, [FromQuery] int maxAge)
        {
            return StatusCode(StatusCodes.Status200OK, _UsersService.FilterByAge(minAge, maxAge));
        }

         [HttpGet("FilterByPostalCode")]
        public ActionResult FilterByPostalCode([FromQuery] string postalcode)
        {
            return StatusCode(StatusCodes.Status200OK, _UsersService.FilterByPostalCode(postalcode));
        }

         [HttpGet("Skills")]
        public ActionResult FilterBySkill([FromQuery] string skill) 
        {
            return StatusCode(StatusCodes.Status200OK, _UsersService.FilterBySkill(skill));
        }

          [HttpGet("StreetName")] 
        public ActionResult FilterByStreetName([FromQuery] string streetName)  
        {
            return StatusCode(StatusCodes.Status200OK, _UsersService.FilterByStreetName(streetName));
        }



        // PUT api/<UsersController>/5
        [HttpPatch("UpdateAge/{id}")]
        public ActionResult UpdateAge([FromRoute] string id, [FromBody] int age)  
        {
            bool result = _UsersService.UpdateAge(id,age);
            if (result)
            {
                return StatusCode(StatusCodes.Status202Accepted);
            }

            return BadRequest();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(string id) 
        {
            bool result = _UsersService.DeleteUser(id);
            if (result)
            {
                return StatusCode(StatusCodes.Status202Accepted);
            }

            return BadRequest();
        }
    }
}
