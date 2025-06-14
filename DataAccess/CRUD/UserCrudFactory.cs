using DataAccess.DAOs;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class UserCrudFactory : CrudFactory
    {

        public UserCrudFactory()
        {
            _sqlDao = SQL_DAO.GetInstance();
        }


        public override void Create(BaseDTO baseDTO)
        {
            var user = baseDTO as User;
            var sqlOperation = new SQLOperation(){ProcedureName = "CRE_USER_PR"};

            sqlOperation.ProcedureName = "CRE_USER_PR";

            sqlOperation.AddStringParameter("P_UserCode", user.UserCode);
            sqlOperation.AddStringParameter("P_Name", user.Name);
            sqlOperation.AddStringParameter("P_Email", user.Email);
            sqlOperation.AddStringParameter("P_Password", user.Password);
            sqlOperation.AddStringParameter("P_Status", user.Status);
            sqlOperation.AddDateTimeParam("P_BirthDate", user.BirthDate);
       
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
            var lstUsers = new List<T>();

            var sqlOperation = new SQLOperation() { ProcedureName = "RET_ALL_USERS_PR" };

            var lstResult = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResult.Count > 0)
            {
                foreach (var row in lstResult)
                {
                    var user = BuildUser(row);
                    lstUsers.Add((T)(object)user);
                }
            }

            return lstUsers;
        }

        public T RetrieveByUserCode<T>(User user)
        {
            var sqlOperation = new SQLOperation() { ProcedureName = "RET_USER_BY_CODE_PR" };

            sqlOperation.AddStringParameter("P_Code", user.UserCode);

            var lstResult = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResult.Count > 0)
            {
                var row = lstResult[0];
                user = BuildUser(row);

                return (T)Convert.ChangeType(user, typeof(T));
            }

            return default(T);
        }

        public T RetrieveById<T>(int id)
        {
            var sqlOperation = new SQLOperation() { ProcedureName = "RET_USER_BY_ID_PR" };

            sqlOperation.AddIntParam("P_Id", id);

            var lstResult = _sqlDao.ExecuteQueryProcedure(sqlOperation);

            if (lstResult.Count > 0)
            {
                var row = lstResult[0];
                var user = BuildUser(row);
                return (T)(object)user;
            }

            return default(T);
        }

        public T RetrieveByEmail<T>(User user)
        {
            var sqlOperation = new SQLOperation() { ProcedureName = "RET_USER_BY_EMAIL_PR" };
            sqlOperation.AddStringParameter("P_Email", user.Email);
            var lstResult = _sqlDao.ExecuteQueryProcedure(sqlOperation);
            if (lstResult.Count > 0)
            {
                var row = lstResult[0];
                user = BuildUser(row);
                return (T)Convert.ChangeType(user, typeof(T));
            }
            return default(T);
        }

        public override void Update(BaseDTO baseDTO)
        {
            throw new NotImplementedException();
        }

        //Metodo que convierte diccionario en un usuario
        private User BuildUser(Dictionary<string, object> row)
        {
            return new User()
            {
                Id = (int)row["Id"],
                Created = row["Created"] == DBNull.Value ? DateTime.MinValue : (DateTime)row["Created"],
                Updated = row["Updated"] == DBNull.Value ? DateTime.MinValue : (DateTime)row["Updated"],
                UserCode = row["UserCode"].ToString(),
                Name = row["Name"].ToString(),
                Email = row["Email"].ToString(),
                Password = row["Password"].ToString(),
                BirthDate = row["BirthDate"] == DBNull.Value ? DateTime.MinValue : (DateTime)row["BirthDate"],
                Status = row["Status"].ToString()
            };
        }

        public override T RetrieveById<T>()
        {
            throw new NotImplementedException();
        }
    }
}
