using System.Data.SqlClient;

namespace Model.DAO
{
    class ConnectionDB
    {
        private static ConnectionDB objCoonnectionDB = null;
        private SqlConnection con;

        private ConnectionDB()
        {
            con = new SqlConnection("Data Source = DESKTOP-VNLPIKS\\SQLEXPRESS; Initial Catalog = MobisWeb; Integrated Security = True");
        }

        public static ConnectionDB checkStatus()
        {
            if (objCoonnectionDB == null)
            {
                objCoonnectionDB = new ConnectionDB();
            }
            return objCoonnectionDB;
        }

        public SqlConnection getCon()
        {
            return con;
        }

        public void closeDB()
        {
            objCoonnectionDB = null;
        }
    }
}

