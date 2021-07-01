using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Model.DAO
{
    public class InventoryDAO : Required<Inventory>
    {
        private ConnectionDB objConnectionDB;
        private SqlCommand command;

        public InventoryDAO()
        {
            objConnectionDB = ConnectionDB.checkStatus();
        }

        public void create(Inventory objInventory)
        {
            string create = "INSERT INTO Inventory (EInventory, EType, EModel, ESNumber, ESEquipament, EIp, ELocation, EDescription, EIdOperator) " +
                "VALUES ('" + objInventory.EInventory + "' , '" + objInventory.EType + "' , '"
                + objInventory.EModel + "' , '" + objInventory.ESNumber + "' , '" + objInventory.ESEquipament +
                "' , '" + objInventory.EIP + "' , '" + objInventory.ELocation + "' , '" + objInventory.EDescription +
                "' , '" + objInventory.EIdOperator + "')";
            try
            {
                command = new SqlCommand(create, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                command.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                objInventory.InfMessage = 1;
            }
            finally
            {
                objConnectionDB.getCon().Close();
                objConnectionDB.closeDB();
            }
        }

        public void delete(Inventory objInventory)
        {
            string delete = "DELETE FROM Inventory WHERE EInventory = '" + objInventory.EInventory + "'";
            try
            {
                command = new SqlCommand(delete, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                command.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                objInventory.InfMessage = 1;
            }
            finally
            {
                objConnectionDB.getCon().Close();
                objConnectionDB.closeDB();
            }
        }

        public bool find(Inventory objInventory)
        {
            bool hasRegisters;
            string find = "SELECT * FROM Inventory WHERE EInventory = '" + objInventory.EInventory + "'";
            try
            {
                command = new SqlCommand(find, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                SqlDataReader reader = command.ExecuteReader();
                hasRegisters = reader.Read();

                if (hasRegisters)
                {
                    objInventory.EInventory = reader[0].ToString();
                    objInventory.EType = reader[1].ToString();
                    objInventory.EModel = reader[2].ToString();
                    objInventory.ESNumber = reader[3].ToString();
                    objInventory.ESEquipament = reader[4].ToString();
                    objInventory.EIP = reader[5].ToString();
                    objInventory.ELocation = reader[6].ToString();
                    objInventory.EDescription = reader[7].ToString();
                    objInventory.EIdOperator = reader[8].ToString();
                }
                else
                {
                    objInventory.InfMessage = 1;
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

        public bool findByESNumber(Inventory objInventory)
        {
            bool hasRegisters;
            string findByESNumber = "SELECT * FROM Inventory WHERE ESNumber = '" + objInventory.ESNumber + "'";
            try
            {
                command = new SqlCommand(findByESNumber, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                SqlDataReader reader = command.ExecuteReader();
                hasRegisters = reader.Read();

                if (hasRegisters)
                {
                    objInventory.EInventory = reader[0].ToString();
                    objInventory.EType = reader[1].ToString();
                    objInventory.EModel = reader[2].ToString();
                    objInventory.ESNumber = reader[3].ToString();
                    objInventory.ESEquipament = reader[4].ToString();
                    objInventory.EIP = reader[5].ToString();
                    objInventory.ELocation = reader[6].ToString();
                    objInventory.EDescription = reader[7].ToString();
                    objInventory.EIdOperator = reader[8].ToString();
                }
                else
                {
                    objInventory.InfMessage = 1;
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

        public List<Inventory> findAll()
        {
            List<Inventory> inventoryList = new List<Inventory>();
            string findAll = "sp_Inventory_SearchAll";

            try
            {
                command = new SqlCommand(findAll, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Inventory objInventory = new Inventory();
                    objInventory.EInventory = reader[0].ToString();
                    objInventory.EType = reader[1].ToString();
                    objInventory.EModel = reader[2].ToString();
                    objInventory.ESNumber = reader[3].ToString();
                    objInventory.ESEquipament = reader[4].ToString();
                    objInventory.EIP = reader[5].ToString();
                    objInventory.ELocation = reader[6].ToString();
                    objInventory.EDescription = reader[7].ToString();
                    objInventory.EIdOperator = reader[8].ToString();
                    inventoryList.Add(objInventory);
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

            return inventoryList;
        }

        public void update(Inventory objInventory)
        {

            string update = "UPDATE Inventory SET EType = '" + objInventory.EType + "' , EModel = '" + objInventory.EModel +
                "' , ESNumber = '" + objInventory.ESNumber + "' , ESEquipament = '" + objInventory.ESEquipament + "' , EIp = '" +
                    objInventory.EIP + "' , ELocation = '" + objInventory.ELocation + "' , EDescription = '" +
                    objInventory.EDescription + "' , EIdOperator = '" + objInventory.EIdOperator + "' WHERE EInventory = '" +
                     objInventory.EInventory + "'";

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

        public List<Inventory> findByType(Inventory objInventory)
        {
            List<Inventory> inventoryList = new List<Inventory>();
            string findByType = "sp_Inventory_SearchByInf '" + objInventory.EType + "', '" + objInventory.EModel + "'";
            try
            {
                command = new SqlCommand(findByType, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Inventory objInventory1 = new Inventory();
                    objInventory1.EInventory = reader[0].ToString();
                    objInventory1.EType = reader[1].ToString();
                    objInventory1.EModel = reader[2].ToString();
                    objInventory1.ESNumber = reader[3].ToString();
                    objInventory1.ESEquipament = reader[4].ToString();
                    objInventory1.EIP = reader[5].ToString();
                    objInventory1.ELocation = reader[6].ToString();
                    objInventory1.EDescription = reader[7].ToString();
                    objInventory1.EIdOperator = reader[8].ToString();
                    inventoryList.Add(objInventory1);
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

            return inventoryList;
        }

        void Required<Inventory>.create(Inventory obj)
        {
            throw new NotImplementedException();
        }

        void Required<Inventory>.delete(Inventory obj)
        {
            throw new NotImplementedException();
        }

        void Required<Inventory>.update(Inventory obj)
        {
            throw new NotImplementedException();
        }

        bool Required<Inventory>.find(Inventory obj)
        {
            throw new NotImplementedException();
        }

        bool Required<Inventory>.findByESNumber(Inventory obj)
        {
            throw new NotImplementedException();
        }

        List<Inventory> Required<Inventory>.findAll()
        {
            throw new NotImplementedException();
        }

        List<Inventory> Required<Inventory>.findByType()
        {
            throw new NotImplementedException();
        }

        public List<Inventory> findByName()
        {
            throw new NotImplementedException();
        }

        public void update2(Inventory obj)
        {
            throw new NotImplementedException();
        }

        public void Input(Inventory obj)
        {
            throw new NotImplementedException();
        }

        public void Exit(Inventory obj)
        {
            throw new NotImplementedException();
        }
    }
}

