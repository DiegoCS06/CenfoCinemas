using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    /*
     * Clase u objeto que se encarga de la comunicacion con la BD
     * Solo ejecuta Stored Procedures
     * 
     * Esta clase implementa el patron de Singleton
     * para asegurar la existencia de una unica instancia de este objeto
     */
    public class SQL_DAO
    {
        //Paso 1: Crear instancia privada de la misma clase
        private static SQL_DAO instance;

        private string _connectionString;

        //Paso 2: Redefinir el constructor default y convertirlo en privado
        private SQL_DAO() 
        {
            _connectionString = string.Empty;
        }

        //Paso 3: Definir el mëtodo que expone la instancia
        public static SQL_DAO getInstance()
        {
            if (instance == null)
            {
                instance = new SQL_DAO();
            }
            return instance;
        }

        //Metodo para la ejecucion de SP sin retorno
        public void ExecuteProcedure(SQLOperation operation) 
            //Conectar a BD
            //Ejecutar el SP
        {
            
        }

        //Metodo para la ejecucion de SP con retorno de data
        public List<Dictionary<string, object>> ExecuteQueryProcedure(SQLOperation operation)
        {
            //Conectarse a DB
            //Ejecutar el SP
            //Capturar el resultado
            //Convertirla en DTOs

            var list = new List<Dictionary<string, object>>();

            return list;
        }
    }
}
