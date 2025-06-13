using DataAccess.DAOs;
using DTOs;
using DataAccess.CRUD;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

public class Program {

    public static void Main(string[] args)
    {
        Console.WriteLine("Seleccione la opcion deseada: ");
        Console.WriteLine("1. Crear Usuario");
        Console.WriteLine("2. Consultar Usuario");
        Console.WriteLine("3. Actualizar Usuario");
        Console.WriteLine("4. Eliminar Usuario");
        Console.WriteLine("5. Crear Pelicula");
        Console.WriteLine("6. Consultar Pelicula");
        Console.WriteLine("7. Actualizar Pelicula");
        Console.WriteLine("8. Eliminar Pelicula");

        var option = Int32.Parse(Console.ReadLine());
        var sqlOperation = new SQLOperation();

        switch(option)
        {
            case 1:
                CRE_USER_PR();
                break;
            case 2:
                RET_USER_PR();
                break;
            case 3:
                UPD_USER_PR();
                break;
            case 4:
                DEL_USER_PR();
                break;
            case 5:
                CRE_MOVIE_PR();
                break;
            case 6:
                RET_MOVIES_PR();
                break;
            case 7:
                UPD_MOVIE_PR();
                break;
            case 8:
                DEL_MOVIE_PR();
                break;
            default:
                Console.WriteLine("Opcion no valida");
                break;
        }
    }

    public static void CRE_USER_PR()
    {

        Console.WriteLine("Digite el codigo del usuario: ");
        var userCode = Console.ReadLine();

        Console.WriteLine("Digite el nombre del usuario: ");
        var userName = Console.ReadLine();

        Console.WriteLine("Digite el email del usuario: ");
        var userEmail = Console.ReadLine();

        Console.WriteLine("Digite la contrasena del usuario: ");
        var userPassword = Console.ReadLine();

        Console.WriteLine("Digite el estado del usuario (AC, IN): ");
        var userStatus = Console.ReadLine();

        Console.WriteLine("Digite la fecha de nacimiento del usuario (yyyy-mm-dd): ");
        var userBirthDate = DateTime.Parse(Console.ReadLine());

        var user = new User()
        {
            UserCode = userCode,
            Name = userName,
            Email = userEmail,
            Password = userPassword,
            Status = userStatus,
            BirthDate = userBirthDate
        };

        var uCrud = new UserCrudFactory();
        uCrud.Create(user);

        var sqlOperation = new SQLOperation();
        sqlOperation.ProcedureName = "CRE_USER_PR";

        sqlOperation.AddStringParameter("P_UserCode", userCode);
        sqlOperation.AddStringParameter("P_Name", userName);
        sqlOperation.AddStringParameter("P_Email", userEmail);
        sqlOperation.AddStringParameter("P_Password", userPassword);
        sqlOperation.AddStringParameter("P_Status", userStatus);
        sqlOperation.AddDateTimeParam("P_BirthDate", userBirthDate);

        var sqlDao = SQL_DAO.GetInstance();

        sqlDao.ExecuteProcedure(sqlOperation);
    }

    public static void RET_USER_PR()
    {

        var uCrud = new UserCrudFactory();
        var listUsers = uCrud.RetrieveAll<User>();
        foreach (var user in listUsers)
        {
            Console.WriteLine(JsonConvert.SerializeObject(user));
        }

    }


    public static void CRE_MOVIE_PR()
    {

        Console.WriteLine("Digite el titulo de la película: ");
        var movieTitle = Console.ReadLine();

        Console.WriteLine("Digite la descripcion de la película: ");
        var movieDescription = Console.ReadLine();

        Console.WriteLine("Digite la fecha de lanzamiento de la película (yyyy-mm-dd): ");
        var movieReleaseDate = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Digite el genero de la película: ");
        var movieGenre = Console.ReadLine();

        Console.WriteLine("Digite el director de la película: ");
        var movieDirector = Console.ReadLine();

        var sqlOperation = new SQLOperation();
        sqlOperation.ProcedureName = "CRE_MOVIE_PR";

        sqlOperation.AddStringParameter("P_Title", movieTitle);
        sqlOperation.AddStringParameter("P_Description", movieDescription);
        sqlOperation.AddDateTimeParam("P_ReleaseDate", movieReleaseDate);
        sqlOperation.AddStringParameter("P_Genre", movieGenre);
        sqlOperation.AddStringParameter("P_Director", movieDirector);

        var sqlDao = SQL_DAO.GetInstance();

        sqlDao.ExecuteProcedure(sqlOperation);
    }

    public static void RET_MOVIES_PR()
    {

        var mCrud = new MovieCrudFactory();
        var listMovies = mCrud.RetrieveAll<Movie>();
        foreach (var movie in listMovies)
        {
            Console.WriteLine(JsonConvert.SerializeObject(movie));
        }

    }

    public static void UPD_USER_PR()
    {
        var sqlOperation = new SQLOperation();
        sqlOperation.ProcedureName = "UPD_USER_PR";



        var sqlDao = SQL_DAO.GetInstance();

        sqlDao.ExecuteProcedure(sqlOperation);

    }

    public static void UPD_MOVIE_PR()
    {
        var sqlOperation = new SQLOperation();
        sqlOperation.ProcedureName = "UPD_MOVIE_PR";



        var sqlDao = SQL_DAO.GetInstance();

        sqlDao.ExecuteProcedure(sqlOperation);


    }

    public static void DEL_USER_PR()
    {
        var sqlOperation = new SQLOperation();
        sqlOperation.ProcedureName = "DEL_USER_PR";



        var sqlDao = SQL_DAO.GetInstance();

        sqlDao.ExecuteProcedure(sqlOperation);

    }

    public static void DEL_MOVIE_PR()
    {
        var sqlOperation = new SQLOperation();
        sqlOperation.ProcedureName = "DEL_MOVIE_PR";



        var sqlDao = SQL_DAO.GetInstance();

        sqlDao.ExecuteProcedure(sqlOperation);

    }
}
