using Model.Entity;
using Model.Neg;
using System.Web.Mvc;
using System.Collections.Generic;
using System;

namespace ProjMobisWeb.Controllers
{
    public class MovementController : Controller
    {
        private MovementNeg objMovementNeg;
        private MaterialsNeg objMaterialsNeg;

        public MovementController()
        {
            objMovementNeg = new MovementNeg();
            objMaterialsNeg = new MaterialsNeg();
        }

        [HttpGet]
        public ActionResult MaterialsObtain()
        {
            List<Materials> list = objMaterialsNeg.findAll();
            return View(list);
        }

        [HttpPost]
        public ActionResult MaterialsObtain(string txtNome, string txtModel)
        {
            if (txtNome == "")
            {
                txtNome = null;
            }

            if (txtModel == "")
            {
                txtModel = null;
            }

            Materials objMaterials = new Materials();
            objMaterials.MType = txtNome;
            objMaterials.MModel = txtModel;

            List<Materials> materials = objMaterialsNeg.findByType(objMaterials);
            return View(materials);
        }

        [HttpGet]
        public ActionResult IndexSearch()
        {
            List<Movement> list = objMovementNeg.findAll();
            return View(list);
        }

        [HttpPost]
        public ActionResult IndexSearch(string txtType, string txtModel, DateTime date1, DateTime date2)
        {
            string message = "";
            Movement objMovement = new Movement();

            if (Convert.ToString(date1) == "" || Convert.ToString(date2) == "" || txtType == "" || txtModel == "")
            {
                if (Convert.ToString(date1) == "") message = "Date error";
                if (Convert.ToString(date2) == "") message = "Date error";
                if (txtType == "") message = "Type error";
                if (txtModel == "") message = "Model error";
            }
            else
            {
                objMovement.MMType = txtType;
                objMovement.MMModel = txtModel;
                objMovement.MMDate1 = date1;
                objMovement.MMDate2 = date2;

                
            }

            List<Movement> list = objMovementNeg.findByType(objMovement);
            return View(list);
        }

    }
}
