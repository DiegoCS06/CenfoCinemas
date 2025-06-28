using DTOs;
using CoreApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(User user)
        {
            try
            {
                var um = new UserManager();
                um.Create(user);
                return Ok(user);
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveAll")]
        public ActionResult RetrieveAll()
        {
            try
            {
                var um = new UserManager();
                var listResults = um.RetrieveAll();

                return Ok(listResults);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveById")]
        public ActionResult RetrieveById(int id)
        {
            try
            {
                var um = new UserManager();
                var retrievedUser = um.RetrieveById(new User { Id = id });
                if (retrievedUser == null)
                {
                    return NotFound("Usuario no encontrado.");
                }
                return Ok(retrievedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveByEmail")]
        public ActionResult RetrieveByEmail(string email)
        {
            try
            {
                var um = new UserManager();
                var user = um.RetrieveByEmail(new User { Email = email });
                if (user == null)
                {
                    return NotFound("Usuario no encontrado.");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("RetrieveByUserCode")]
        public ActionResult RetrieveByUserCode(string userCode)
        {
            try
            {
                var um = new UserManager();
                var user = um.RetrieveByUserCode(userCode);
                if (user == null)
                {
                    return NotFound("Usuario no encontrado.");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult Update(User user)
        {
            try
            {
                var um = new UserManager();
                um.Update(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(User user)
        {
            try
            {
                var um = new UserManager();
                um.Delete(user.Id);
                return Ok($"Usuario con ID {user.Id} eliminado correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
