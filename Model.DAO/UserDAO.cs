using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.DAO
{
    public class UserDAO : Required<User>
    {
        private ConnectionDB objConnectionDB;
        private SqlCommand command;

        public UserDAO()
        {
            objConnectionDB = ConnectionDB.checkStatus();
        }

        public void create(User objUser)
        {
            UserPasswordDAO encrypt = new UserPasswordDAO();
            string encryptPassword = encrypt.EncryptPassword(objUser.Password);

            string create = "INSERT INTO Users (ID, UPassword, UName, UPosition, UPhone, UDate) " +
                "VALUES ('" + objUser.ID + "', '" + encryptPassword + "' , '" + objUser.Name + "', '" + objUser.Position + "', '" + objUser.Phone + "', '" + DateTime.Now + "' )";
            try
            {
                command = new SqlCommand(create, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                command.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                objConnectionDB.getCon().Close();
                objConnectionDB.closeDB();
            }
        }

        public void delete(User objUser)
        {
            string delete = "DELETE FROM Users WHERE ID = '" + objUser.ID + "' ";
            try
            {
                command = new SqlCommand(delete, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                command.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                objConnectionDB.getCon().Close();
                objConnectionDB.closeDB();
            }
        }

        public bool find(User objUser)
        {
            bool hasRegisters;
            string find = "SELECT * FROM Users WHERE ID = '" + objUser.ID + "'";
            try
            {
                command = new SqlCommand(find, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                SqlDataReader reader = command.ExecuteReader();
                hasRegisters = reader.Read();

                if (hasRegisters)
                {
                    objUser.ID = reader[0].ToString();
                    objUser.Name = reader[2].ToString();
                    objUser.Position = reader[3].ToString();
                    objUser.Phone = reader[4].ToString();
                    objUser.Date = Convert.ToDateTime(reader[5].ToString());
                }
                else
                {
                    objUser.InfMessage = 1;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                objConnectionDB.getCon().Close();
                objConnectionDB.closeDB();
            }

            return hasRegisters;
        }

        public List<User> findByType(User objUser)
        {
            List<User> userList = new List<User>();
            string findByType = "sp_User_SearchByInf '" + objUser.ID + "', '" + objUser.Name + "'";

            try
            {
                command = new SqlCommand(findByType, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User objFindUser = new User();
                    objFindUser.ID = reader[0].ToString();
                    objFindUser.Name = reader[2].ToString();
                    objFindUser.Position = reader[3].ToString();
                    objFindUser.Phone = reader[4].ToString();
                    objFindUser.Date = Convert.ToDateTime(reader[5].ToString());
                    userList.Add(objFindUser);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                objConnectionDB.getCon().Close();
                objConnectionDB.closeDB();
            }

            return userList;
        }

        public List<User> findAll()
        {
            List<User> userList = new List<User>();
            string findAll = "sp_User_SearchAll";

            try
            {
                command = new SqlCommand(findAll, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User objUser = new User();
                    objUser.ID = reader[0].ToString();
                    objUser.Name = reader[2].ToString();
                    objUser.Position = reader[3].ToString();
                    objUser.Phone = reader[4].ToString();
                    objUser.Date = Convert.ToDateTime(reader[5].ToString());
                    userList.Add(objUser);
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                objConnectionDB.getCon().Close();
                objConnectionDB.closeDB();
            }

            return userList;
        }

        public void update(User objUser)
        {
            UserPasswordDAO encrypt = new UserPasswordDAO();
            string encryptPassword = encrypt.EncryptPassword(objUser.Password);

            string update = "UPDATE Users SET UPassword='" + encryptPassword + "', UName ='" + objUser.Name +
                "', UPosition='" + objUser.Position + "', UPhone='" + objUser.Phone + "', UDate='" +
                DateTime.Now + "' WHERE ID='" + objUser.ID + "'";
            try
            {
                command = new SqlCommand(update, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                command.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                objUser.InfMessage = 1;
            }
            finally
            {
                objConnectionDB.getCon().Close();
                objConnectionDB.closeDB();
            }
        }

        void Required<User>.create(User obj)
        {
            throw new NotImplementedException();
        }

        void Required<User>.delete(User obj)
        {
            throw new NotImplementedException();
        }

        void Required<User>.update(User obj)
        {
            throw new NotImplementedException();
        }

        bool Required<User>.find(User obj)
        {
            throw new NotImplementedException();
        }

        bool Required<User>.findByESNumber(User obj)
        {
            throw new NotImplementedException();
        }

        List<User> Required<User>.findAll()
        {
            throw new NotImplementedException();
        }

        List<User> Required<User>.findByType()
        {
            throw new NotImplementedException();
        }

        public List<User> findByName()
        {
            throw new NotImplementedException();
        }

        public void update2(User obj)
        {
            throw new NotImplementedException();
        }

        public void Input(User obj)
        {
            throw new NotImplementedException();
        }

        public void Exit(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
