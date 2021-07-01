using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.DAO
{
    public class MaterialsDAO : Required<Materials>
    {
        private ConnectionDB objConnectionDB;
        private SqlCommand command;

        public MaterialsDAO()
        {
            objConnectionDB = ConnectionDB.checkStatus();
        }

        public void create(Materials objMaterials)
        {
            string create = "INSERT INTO Materials (MType, MModel, MQuantity, MObservation, MIdOperator, MDate) VALUES " +
                " ('" + objMaterials.MType + "' , '" + objMaterials.MModel + "' , '" + objMaterials.MQuantity + "' , '"
                + objMaterials.MObservation + "' , '" + objMaterials.MIdOperator + "' , '" + DateTime.Now + "')";
            try
            {
                command = new SqlCommand(create, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                command.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                objMaterials.InfMessage = 1;
            }
            finally
            {
                objConnectionDB.getCon().Close();
                objConnectionDB.closeDB();
            }
        }

        public void delete(Materials objMaterials)
        {
            string delete = "DELETE FROM Materials WHERE MCode = '" + objMaterials.MCode + "'";
            try
            {
                command = new SqlCommand(delete, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                command.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                objMaterials.InfMessage = 1;
            }
            finally
            {
                objConnectionDB.getCon().Close();
                objConnectionDB.closeDB();
            }
        }

        public bool find(Materials objMaterials)
        {
            bool hasRegisters;
            string find = "SELECT * FROM Materials WHERE MCode = '" + objMaterials.MCode + "'";
            try
            {
                command = new SqlCommand(find, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                SqlDataReader reader = command.ExecuteReader();
                hasRegisters = reader.Read();

                if (hasRegisters)
                {
                    objMaterials.MCode = Convert.ToInt32(reader[0].ToString());
                    objMaterials.MType = reader[1].ToString();
                    objMaterials.MModel = reader[2].ToString();
                    objMaterials.MQuantity = Convert.ToInt32(reader[3].ToString());
                    objMaterials.MObservation = reader[4].ToString();
                    objMaterials.MIdOperator = reader[5].ToString();
                    objMaterials.MDate = Convert.ToDateTime(reader[6].ToString());
                }
                else
                {
                    objMaterials.InfMessage = 1;
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

        public List<Materials> findByType(Materials objMaterials)
        {
            List<Materials> materialsList = new List<Materials>();
            string findByType = "sp_Materials_SearchByInf '" + objMaterials.MType + "', '" + objMaterials.MModel + "'";
            try
            {
                command = new SqlCommand(findByType, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Materials objMaterials1 = new Materials();
                    objMaterials1.MCode = Convert.ToInt32(reader[0].ToString());
                    objMaterials1.MType = reader[1].ToString();
                    objMaterials1.MModel = reader[2].ToString();
                    objMaterials1.MQuantity = Convert.ToInt32(reader[3].ToString());
                    objMaterials1.MObservation = reader[4].ToString();
                    objMaterials1.MIdOperator = reader[5].ToString();
                    objMaterials1.MDate = Convert.ToDateTime(reader[6].ToString());
                    materialsList.Add(objMaterials1);
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

            return materialsList;
        }

        public List<Materials> findAll()
        {
            List<Materials> materialsList = new List<Materials>();
            string findAll = "sp_Materials_SearchAll";

            try
            {
                command = new SqlCommand(findAll, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Materials objMaterials = new Materials();
                    objMaterials.MCode = Convert.ToInt32(reader[0].ToString());
                    objMaterials.MType = reader[1].ToString();
                    objMaterials.MModel = reader[2].ToString();
                    objMaterials.MQuantity = Convert.ToInt32(reader[3].ToString());
                    objMaterials.MObservation = reader[4].ToString();
                    objMaterials.MIdOperator = reader[5].ToString();
                    objMaterials.MDate = Convert.ToDateTime(reader[6].ToString());
                    materialsList.Add(objMaterials);
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

            return materialsList;
        }

        public void update(Materials objMaterials)
        {
            string update = "UPDATE Materials SET MType = '" + objMaterials.MType + "' , MModel = '" + objMaterials.MModel +
                "' , MQuantity = '" + objMaterials.MQuantity + "' , MObservation = '" + objMaterials.MObservation +
                "' , MIdOperator = '" + objMaterials.MIdOperator + "' , MDate = '" + DateTime.Now + "' WHERE MCode = '" + objMaterials.MCode + "'";

            try
            {
                command = new SqlCommand(update, objConnectionDB.getCon());
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

        public void Input(Materials objMaterials)
        {
            int number = 1;
            string useInf = "Input";

            string update = "sp_MMovement_Create " + objMaterials.MCode + ", '" + objMaterials.MType +"', '" + objMaterials.MModel
                +"', " + objMaterials.MQAlter + ", " + number + ", '" + useInf + "', '" + objMaterials.MIdOperator2 
                + "', '" + DateTime.Now + "'";

            try
            {
                command = new SqlCommand(update, objConnectionDB.getCon());
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

        public void Exit(Materials objMaterials)
        {
            int number = 0;
            string useInf = "Output";

            string update = "sp_MMovement_Create " + objMaterials.MCode + ", '" + objMaterials.MType + "', '" + objMaterials.MModel
                + "', " + objMaterials.MQAlter + ", " + number + ", '" + useInf + "', '" + objMaterials.MIdOperator2
                + "', '" + DateTime.Now + "'";

            try
            {
                command = new SqlCommand(update, objConnectionDB.getCon());
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

        void Required<Materials>.create(Materials obj)
        {
            throw new NotImplementedException();
        }

        void Required<Materials>.delete(Materials obj)
        {
            throw new NotImplementedException();
        }

        void Required<Materials>.update(Materials obj)
        {
            throw new NotImplementedException();
        }

        bool Required<Materials>.find(Materials obj)
        {
            throw new NotImplementedException();
        }

        bool Required<Materials>.findByESNumber(Materials obj)
        {
            throw new NotImplementedException();
        }

        List<Materials> Required<Materials>.findAll()
        {
            throw new NotImplementedException();
        }

        List<Materials> Required<Materials>.findByType()
        {
            throw new NotImplementedException();
        }

        public List<Materials> findByName()
        {
            throw new NotImplementedException();
        }
    }
}
