using Model.DAO;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class MaterialsNeg
    {
        private MaterialsDAO objMaterialsDAO;

        public MaterialsNeg()
        {
            objMaterialsDAO = new MaterialsDAO();
        }

        public void create(Materials objMaterials)
        {
            bool checkInventory = true;

            //starting check Type
            string type = objMaterials.MType;
            if (type == null)
            {
                objMaterials.InfMessage = 10;
                return;
            }
            else
            {
                type = objMaterials.MType.Trim();
                checkInventory = type.Length <= 50 && type.Length > 0;
                if (!checkInventory)
                {
                    objMaterials.InfMessage = 20;
                    return;
                }

            }

            //starting check Model
            string model = objMaterials.MModel;
            if (model == null)
            {
                objMaterials.InfMessage = 11;
                return;
            }
            else
            {
                model = objMaterials.MModel.Trim();
                checkInventory = model.Length <= 50 && model.Length > 0;
                if (!checkInventory)
                {
                    objMaterials.InfMessage = 21;
                    return;
                }
            }

            //starting check Quantity
            int quantity = objMaterials.MQuantity;
            if (quantity < 0)
            {
                objMaterials.InfMessage = 12;
                return;
            }
            else
            {
                //case don't error
                objMaterials.InfMessage = 1000;
                objMaterialsDAO.create(objMaterials);
                return;
            }
        }

        public void update(Materials objMaterials)
        {
            try
            {
                if (objMaterials.MType == null)
                {
                    objMaterials.InfMessage = 50;
                    return;
                }
                else
                {
                    if (objMaterials.MModel == null)
                    {
                        objMaterials.InfMessage = 51;
                        return;
                    }
                    else
                    {
                       objMaterials.InfMessage = 1001;
                       objMaterialsDAO.update(objMaterials);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public void movement(Materials objMaterials)
        {
            try
            {
                if(objMaterials.MCheck == "Input")
                {
                    objMaterialsDAO.Input(objMaterials);
                }
                else
                if(objMaterials.MCheck == "Exit")
                {
                    objMaterialsDAO.Exit(objMaterials);
                }else
                {
                    objMaterials.InfMessage = 80;
                    return;
                }
                
            }
            catch
            {
                throw;
            }
        }

        public void delete(Materials objMaterials)
        {
            bool checkInventory = true;

            Materials objMaterialsAux = new Materials();
            objMaterialsAux.MCode = objMaterials.MCode;
            checkInventory = objMaterialsDAO.find(objMaterialsAux);
            if (!checkInventory)
            {
                objMaterials.InfMessage = 70;
                return;
            }

            objMaterials.InfMessage = 1002;
            objMaterialsDAO.delete(objMaterials);
            return;
        }

        public bool find(Materials objMaterials)
        {
            return objMaterialsDAO.find(objMaterials);
        }

        public List<Materials> findByType(Materials objMaterials)
        {
            return objMaterialsDAO.findByType(objMaterials);
        }

        public List<Materials> findAll()
        {
            return objMaterialsDAO.findAll();
        }
    }
}
