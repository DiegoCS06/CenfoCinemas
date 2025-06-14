using DataAccess.DAOs;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class MovieCrudFactory : CrudFactory
    {
        public MovieCrudFactory()
        {
            _sqlDao = SQL_DAO.GetInstance();
        }

        public override void Create(BaseDTO baseDTO)
        {
            var movie = baseDTO as Movie;
            var sqlOperation = new SQLOperation() { ProcedureName = "CRE_MOVIE_PR" };

            sqlOperation.ProcedureName = "CRE_MOVIE_PR";

            sqlOperation.AddIntParam("P_Id", movie.Id);
            sqlOperation.AddStringParameter("P_Title", movie.Title);
            sqlOperation.AddStringParameter("P_Description", movie.Description);
            sqlOperation.AddDateTimeParam("P_ReleaseDate", movie.ReleaseDate);
            sqlOperation.AddStringParameter("P_Genre", movie.Genre);
            sqlOperation.AddStringParameter("P_Director", movie.Director);

            _sqlDao.ExecuteProcedure(sqlOperation);
        }

        public override void Delete(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        public override T Retrieve<T>()
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var lstMovies = new List<T>();

            var sqlOperation = new SQLOperation() { ProcedureName = "RET_ALL_MOVIES_PR" };

            var lstResult = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResult.Count > 0)
            {
                foreach (var row in lstResult)
                {
                    var movie = BuildMovie(row);
                    lstMovies.Add((T)(object)movie);
                }
            }

            return lstMovies;
        }

        public T RetrieveById<T>(int id)
        {
            var sqlOperation = new SQLOperation() { ProcedureName = "RET_MOVIE_BY_ID_PR" };

            sqlOperation.AddIntParam("P_Id", id);

            var lstResult = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResult.Count > 0)
            {
                var row = lstResult[0];
                var movie = BuildMovie(row);
                return (T)(object)movie;
            }

            return default(T);
        }

        public override T RetrieveById<T>()
        {
            throw new NotImplementedException();
        }

        public override void Update(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }
        private Movie BuildMovie(Dictionary<string, object> row)
        {
            return new Movie()
            {
                Id = (int)row["Id"],
                Created = row["Created"] == DBNull.Value ? DateTime.MinValue : (DateTime)row["Created"],
                Updated = row["Updated"] == DBNull.Value ? DateTime.MinValue : (DateTime)row["Updated"],
                Title = row["Title"].ToString(),
                Description = row["Description"].ToString(),
                ReleaseDate = row["ReleaseDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)row["ReleaseDate"],
                Genre = row["Genre"].ToString(),
                Director = row["Director"].ToString()
            };
        }
    }
}
