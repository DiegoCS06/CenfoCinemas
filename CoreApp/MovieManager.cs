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

        public List<Movie> RetrieveAll()
        {
            var mCrud = new MovieCrudFactory();
            return mCrud.RetrieveAll<Movie>();

        }

        public Movie RetrieveById(Movie movie)
        {
            var mCrud = new MovieCrudFactory();
            return mCrud.RetrieveById<Movie>(movie);
        }

        public void Update(Movie movie)
        {
            try
            {
                    var mCrud = new MovieCrudFactory();
                    var mExist = mCrud.RetrieveById<Movie>(movie);
                    if (mExist != null)
                    {
                      mCrud.Update(movie);
                    }
                    else
                    {
                        throw new Exception("No existe una pelicula con ese ID");
                    }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                var mCrud = new MovieCrudFactory();
                var movie = new Movie { Id = id };
                var mExist = mCrud.RetrieveById<Movie>(movie);
                if (mExist != null)
                {
                    mCrud.Delete(movie);
                }
                else
                {
                    throw new Exception("No existe una pelicula con ese ID");
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

    }
}
