using DTOs;
using DataAccess.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApp
{
    public class UserManager : BaseManager
    {

        public void Create(User user)
        {
            try
            {
                if(IsOver18(user))
                {
                    var uCrud = new UserCrudFactory();

                    var uExist = uCrud.RetrieveByUserCode<User>(user);

                    if(uExist == null)
                    {

                        uExist=uCrud.RetrieveByEmail<User>(user);

                        if (uExist == null)
                        {
                            uCrud.Create(user);
                        }
                        else
                        {
                            throw new Exception("El email ya esta registrado");
                        }
                    }
                    else
                    {
                        throw new Exception("El codigo de usuario no esta disponible");
                    }
                }
                else
                {
                    throw new Exception("No cumple con la edad minima");
                }
            }

            catch (Exception ex)
            {
                ManageException(ex);
            }
        }

        public List<User> RetrieveAll()
        {
            var uCrud = new UserCrudFactory();
            return uCrud.RetrieveAll<User>();

        }

        public User RetrieveById(User user)
        {
            var uCrud = new UserCrudFactory();
            return uCrud.RetrieveById<User>(user);
        }

        public User RetrieveByEmail(User user)
        {
            var uCrud = new UserCrudFactory();
            return uCrud.RetrieveByEmail<User>(user);
        }

        public User RetrieveByUserCode(string userCode)
        {
            var uCrud = new UserCrudFactory();
            var user = new User { UserCode = userCode };
            return uCrud.RetrieveByUserCode<User>(user);
        }

        public void Update(User user)
        {
            try
            {
                if (IsOver18(user))
                {
                    var uCrud = new UserCrudFactory();
                    var uExist = uCrud.RetrieveById<User>(user);
                    if (uExist != null)
                    {
                        uCrud.Update(user);
                    }
                    else
                    {
                        throw new Exception("No existe un usuario con ese ID");
                    }
                }
                else
                {
                    throw new Exception("No cumple con la edad minima");
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
                var uCrud = new UserCrudFactory();
                var user = new User { Id = id };
                var uExist = uCrud.RetrieveById<User>(user);
                if (uExist != null)
                {
                    uCrud.Delete(user);
                }
                else
                {
                    throw new Exception("No existe un usuario con ese ID");
                }
            }
            catch (Exception ex)
            {
                ManageException(ex);
            }
        }


        private bool IsOver18(User user)
        {
            var currentDate = DateTime.Now;
            int age = currentDate.Year - user.BirthDate.Year;

            if (user.BirthDate > currentDate.AddYears(-age).Date)
            {
                age--;
            }
            return age >= 18;
        }
    }
}
