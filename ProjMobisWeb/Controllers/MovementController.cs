using Model.Entity;
using Model.Neg;
using System.Web.Mvc;
using System.Collections.Generic;
using System;

namespace ProjMobisWeb.Controllers
{
    public class MovementController : Controller
    {
        MovementNeg objMovementNeg;

        public MovementController()
        {
            objMovementNeg = new MovementNeg();
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
            if (txtType == "")
            {
                txtType = "null";
            }
            if (txtModel == "")
            {
                txtModel = "null";
            }

            Movement objMovement = new Movement();
            objMovement.MMType = txtType;
            objMovement.MMModel = txtModel;
            objMovement.MMDate1 = date1;
            objMovement.MMDate2 = date2;

            List<Movement> list = objMovementNeg.findByType(objMovement);
            return View(list);
        }

    }
}
