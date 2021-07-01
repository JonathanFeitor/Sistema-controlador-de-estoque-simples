using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.DAO
{
    public class MovementDAO : Required<Movement>
    {
        private ConnectionDB objConnectionDB;
        private SqlCommand command;

        public MovementDAO()
        {
            objConnectionDB = ConnectionDB.checkStatus();
        }

        public List<Movement> findByType(Movement objMovement)
        {
            List<Movement> movementList = new List<Movement>();

            if (objMovement.MMModel == "null")
            {
                int infMessage = 1;

                string findByType = "sp_MMovement_MaterialsReport '" + objMovement.MMType + "', '"
                    + objMovement.MMDate1 + "', '" + objMovement.MMDate2 + "', '" + infMessage + "'";
                try
                {
                    command = new SqlCommand(findByType, objConnectionDB.getCon());
                    objConnectionDB.getCon().Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Movement objMovement1 = new Movement();
                        objMovement1.MMType = reader[1].ToString();
                        objMovement1.MMModel = reader[2].ToString();
                        objMovement1.MMQtt = Convert.ToInt32(reader[3].ToString());
                        objMovement1.MMUseInf = reader[4].ToString();
                        objMovement1.MMIdOperator = reader[5].ToString();
                        objMovement1.MMDate1 = Convert.ToDateTime(reader[6].ToString());
                        movementList.Add(objMovement1);
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

                return movementList;
            }
            else if (objMovement.MMType == "null")
            {
                int infMessage = 0;

                string findByType = "sp_MMovement_MaterialsReport '" + objMovement.MMModel + "', '"
                    + objMovement.MMDate1 + "', '" + objMovement.MMDate2 + "', '" + infMessage + "'";
                try
                {
                    command = new SqlCommand(findByType, objConnectionDB.getCon());
                    objConnectionDB.getCon().Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Movement objMovement1 = new Movement();
                        objMovement1.MMType = reader[1].ToString();
                        objMovement1.MMModel = reader[2].ToString();
                        objMovement1.MMQtt = Convert.ToInt32(reader[3].ToString());
                        objMovement1.MMUseInf = reader[4].ToString();
                        objMovement1.MMIdOperator = reader[5].ToString();
                        objMovement1.MMDate1 = Convert.ToDateTime(reader[6].ToString());
                        movementList.Add(objMovement1);
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

            }

            return movementList;
        }

        public List<Movement> findAll()
        {
            List<Movement> movementList = new List<Movement>();
            string findAll = "sp_Movement_SearchAll";

            try
            {
                command = new SqlCommand(findAll, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Movement objMovement = new Movement();
                    objMovement.MMCode = Convert.ToInt32(reader[0].ToString());
                    objMovement.MMType = reader[1].ToString();
                    objMovement.MMModel = reader[2].ToString();
                    objMovement.MMQtt = Convert.ToInt32(reader[3].ToString());
                    objMovement.MMUseInf = reader[4].ToString();
                    objMovement.MMIdOperator = reader[5].ToString();
                    objMovement.MMDate1 = Convert.ToDateTime(reader[6].ToString());
                    objMovement.MCode = Convert.ToInt32(reader[7].ToString());
                    movementList.Add(objMovement);
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

            return movementList;
        }

        public void create(Movement obj)
        {
            throw new NotImplementedException();
        }

        public void delete(Movement obj)
        {
            throw new NotImplementedException();
        }

        public void Exit(Movement obj)
        {
            throw new NotImplementedException();
        }

        public bool find(Movement obj)
        {
            throw new NotImplementedException();
        }

        public bool findByESNumber(Movement obj)
        {
            throw new NotImplementedException();
        }

        public List<Movement> findByType()
        {
            throw new NotImplementedException();
        }

        public void Input(Movement obj)
        {
            throw new NotImplementedException();
        }

        public void update(Movement obj)
        {
            throw new NotImplementedException();
        }
    }
}