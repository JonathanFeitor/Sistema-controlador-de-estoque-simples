using System;
using System.Collections.Generic;
using System.Text;
using Model.DAO;
using Model.Entity;

namespace Model.Neg
{
    public class InventoryNeg
    {
        private InventoryDAO objInventoryDAO;

        public InventoryNeg()
        {
            objInventoryDAO = new InventoryDAO();
        }

        public void create(Inventory objInventory)
        {
            bool checkInventory = true;

            //starting check Type
            string inventory = objInventory.EInventory;
            if (inventory == null)
            {
                objInventory.InfMessage = 14;
                return;
            }
            else
            {
                inventory = objInventory.EInventory.Trim();
                checkInventory = inventory.Length <= 20 && inventory.Length > 0;
                if (!checkInventory)
                {
                    objInventory.InfMessage = 24;
                    return;
                }

            }

            //starting check Type
            string type = objInventory.EType;
            if (type == null)
            {
                objInventory.InfMessage = 10;
                return;
            }
            else
            {
                type = objInventory.EType.Trim();
                checkInventory = type.Length <= 50 && type.Length > 0;
                if (!checkInventory)
                {
                    objInventory.InfMessage = 20;
                    return;
                }

            }

            //starting check Model
            string model = objInventory.EModel;
            if (model == null)
            {
                objInventory.InfMessage = 11;
                return;
            }
            else
            {
                model = objInventory.EModel.Trim();
                checkInventory = model.Length <= 50 && model.Length > 0;
                if (!checkInventory)
                {
                    objInventory.InfMessage = 21;
                    return;
                }

            }

            //starting check Serial Number
            string sNumber = objInventory.ESNumber;
            if (sNumber == null)
            {
                objInventory.InfMessage = 12;
                return;
            }
            else
            {
                sNumber = objInventory.ESNumber.Trim();
                checkInventory = sNumber.Length <= 50 && sNumber.Length > 0;
                if (!checkInventory)
                {
                    objInventory.InfMessage = 22;
                    return;
                }

            }

            // starting check status equipament
            string sEquipament = objInventory.ESEquipament;
            if(sEquipament == null)
            {
                objInventory.InfMessage = 13;
                return;
            }
            else 
            if(sEquipament == "YES" || sEquipament == "NO")
            {
                sEquipament = objInventory.ESEquipament.Trim();
                checkInventory = sEquipament.Length <= 3 && sEquipament.Length > 0;
                if (!checkInventory)
                {
                    objInventory.InfMessage = 23;
                    return;
                }

                //begin check duplicated
                Inventory objInventoryAux = new Inventory();
                objInventoryAux.EInventory = objInventory.EInventory;
                checkInventory = !objInventoryDAO.find(objInventoryAux);
                if (!checkInventory)
                {
                    objInventory.InfMessage = 200;
                    return;
                }

                //case don't error
                objInventory.InfMessage = 1000;
                objInventoryDAO.create(objInventory);
                return;
            }
            else
            {
                objInventory.InfMessage = 53;
                return;
            }
        }

        public void update(Inventory objInventory)
        {
            try
            {
                if (objInventory.EType == null)
                {
                    objInventory.InfMessage = 50;
                    return;
                }
                else
                {
                    if (objInventory.EModel == null)
                    {
                        objInventory.InfMessage = 51;
                        return;
                    }
                    else
                    {
                        if (objInventory.ESNumber == null)
                        {
                            objInventory.InfMessage = 52;
                            return;
                        }
                        else
                        if(objInventory.ESEquipament == "YES" || objInventory.ESEquipament == "NO")
                        {
                            objInventory.InfMessage = 1001;
                            objInventoryDAO.update(objInventory);
                            return;
                        }
                        else
                        {
                            objInventory.InfMessage = 53;
                            return;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

        }

        public void delete(Inventory objInventory)
        {
            bool checkInventory = true;

            Inventory objInventoryAux = new Inventory();
            objInventoryAux.EInventory = objInventory.EInventory;
            checkInventory = objInventoryDAO.find(objInventoryAux);
            if (!checkInventory)
            {
                objInventory.InfMessage = 70;
                return;
            }

            objInventory.InfMessage = 1002;
            objInventoryDAO.delete(objInventory);
            return;
        }

        public bool find(Inventory objInventory)
        {
            return objInventoryDAO.find(objInventory);
        }

        public bool findByfindByESNumber(Inventory objInventory)
        {
            return objInventoryDAO.findByESNumber(objInventory);
        }

        public List<Inventory> finByType(Inventory objInventory)
        {
            return objInventoryDAO.findByType(objInventory);
        }

        public List<Inventory> findAll()
        {
            return objInventoryDAO.findAll();
        }
    }
}

