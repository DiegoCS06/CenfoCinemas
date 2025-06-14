using DataAccess.CRUD;
using DTOs;

namespace CoreApp
{
    public class MovieManager : BaseManager
    {

        public void Create(Movie movie)
        {
            try
            {
                var mCrud = new MovieCrudFactory();
                var mExist = mCrud.RetrieveById<Movie>(movie.Id);

                if (mExist == null)
                {
                    mCrud.Create(movie);
                }
                else
                {
                    throw new Exception("La pelicula ya esta registrada");
                }
            }

            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

    }
}
