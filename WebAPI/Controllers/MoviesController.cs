using DTOs;
using CoreApp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(Movie movie)
        {
            try
            {
                var mm = new MovieManager();
                mm.Create(movie);
                return Ok(movie);

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
                var mm = new MovieManager();
                var listResults = mm.RetrieveAll();

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
                var mm = new MovieManager();
                var retrievedMovie = mm.RetrieveById(new Movie { Id = id });
                if (retrievedMovie == null)
                {
                    return NotFound("Pelicula no encontrada.");
                }
                return Ok(retrievedMovie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public ActionResult Update(Movie movie)
        {
            try
            {
                var mm = new MovieManager();
                mm.Update(movie);
                return Ok(movie);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                var mm = new MovieManager();
                mm.Delete(id);
                return Ok($"Pelicula con ID {id} eliminada correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
