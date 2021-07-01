using Model.Entity;
using Model.Neg;
using System.Web.Mvc;
using System.Collections.Generic;
using System;

namespace ProjMobisWeb.Controllers
{
    public class MaterialsController : Controller
    {
        MaterialsNeg objMaterialsNeg;
        
        public MaterialsController()
        {
            objMaterialsNeg = new MaterialsNeg();
        }

        //Message Initial
        public void messageInitialRegiter()
        {
            ViewBag.MessageInitialRegister = "Insert Materials data and click save!";
        }
        //Initial message update
        public void messageInitialUpdate()
        {
            ViewBag.MessageInitialUpdate = "Update Form";
        }
        //Initial message update
        public void messageInitialInputExit()
        {
            ViewBag.MessageInitialInputExit = "Materials input and output form";
        }

        // Initial message Delete
        public void messageInitialDelete()
        {
            ViewBag.MessageInitialEliminate = "Exclusion form";
        }

        public void MessageErrorRegister(Materials objMaterials)
        {
            switch (objMaterials.InfMessage)
            {
                case 1: // Database Error
                    ViewBag.MessageError = "An error occured while entering information into the database!";
                    break;

                case 10:// empty field (Inventory Type)
                    ViewBag.MessageError = "Type field is mandatory!";
                    break;

                case 20: // Type Error
                    ViewBag.MessageError = "Field must contain more than 1 character and less than 50 characters!";
                    break;

                case 11: // empty field (Inventory Model)
                    ViewBag.MessageError = "Model field is mandatory!";
                    break;

                case 21: // Model Error
                    ViewBag.MessageError = "Field must contain more than 1 character and less than 50 characters!";
                    break;

                case 12: // Quantity Error
                    ViewBag.MessageError = "This field cannot be added with negative number!";
                    break;

                case 50: // empty field (Inventory Type)
                    ViewBag.MessageError = "The field the type can't be null!";
                    break;

                case 51: // empty field  (Inventory Model)
                    ViewBag.MessageError = "The field the model can't be null!";
                    break;

                case 70: // Duplicate Error (Materials)
                    ViewBag.MessageError = "The Materials code [" + objMaterials.MCode + "] alread is registered in the system!";
                    break;

                case 80: // Error Movement (Materials)
                    ViewBag.MessageError = "Select an Input or Exit";
                    break;

                case 1000: // Create successfully
                    ViewBag.MessageSuccessfully = "The Materials [" + objMaterials.MType + "] has been successfully entered!";
                    break;

                case 1001: // Update successfully
                    ViewBag.MessageSuccessfullyUpdate = "The Materials [" + objMaterials.MType + "] has been successfully updated!";
                    break;

                case 1002:// Delete Successfully 
                    ViewBag.MessageSuccessfullDelete = "The Materials [" + objMaterials.MType + "] has been successfully deleted!";
                    break;

                case 1003: //Input / Exit Successfully
                    ViewBag.MessageSuccessfullyInputExit = "Inpu/ output of materials [" + objMaterials.MType + "] was successful!";
                    break;
            }
        }

        public ActionResult Index()
        {
            List<Materials> materialsList = objMaterialsNeg.findAll();
            return View(materialsList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            UserNeg objUser = new UserNeg();
            List<User> data = objUser.findAll();
            SelectList list = new SelectList(data, "ID", "ID");
            ViewBag.UserList = list;
            messageInitialRegiter();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Materials objMaterials)
        {
            UserNeg objUser = new UserNeg();
            List<User> data = objUser.findAll();
            SelectList list = new SelectList(data, "ID", "ID");
            ViewBag.UserList = list;
            messageInitialRegiter();
            objMaterialsNeg.create(objMaterials);
            MessageErrorRegister(objMaterials);
            ModelState.Clear();
            return View("Create");
        }

        public ActionResult Find(string id)
        {
            Materials objMaterials = new Materials(Convert.ToInt32(id));
            objMaterialsNeg.find(objMaterials);

            return View(objMaterials);
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            messageInitialUpdate();
            Materials objMaterials = new Materials(Convert.ToInt32(id));
            objMaterialsNeg.find(objMaterials);
            return View(objMaterials);
        }

        [HttpPost]
        public ActionResult Update(Materials objMaterials)
        {
            messageInitialUpdate();
            objMaterialsNeg.update(objMaterials);
            MessageErrorRegister(objMaterials);
            return View();
        }

        [HttpGet]
        public ActionResult SearchMaterials()
        {
            List<Materials> list = objMaterialsNeg.findAll();
            return View(list);
        }
        [HttpPost]
        public ActionResult SearchMaterials(string txtType, string txtModel)
        {
            if(txtType == "")
            {
                txtType = "null";
            }
            if(txtModel == "")
            {
                txtModel = "null";
            }

            Materials objMaterials = new Materials();
            objMaterials.MType = txtType;
            objMaterials.MModel = txtModel;

            List<Materials> list = objMaterialsNeg.findByType(objMaterials);
            return View(list);
        }

        public ActionResult Delete(string id)
        {
            messageInitialDelete();
            Materials objMaterials = new Materials(Convert.ToInt32(id));
            objMaterialsNeg.find(objMaterials);
            return View(objMaterials);

        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            messageInitialDelete();
            Materials objMaterials = new Materials(Convert.ToInt32(id));
            objMaterialsNeg.delete(objMaterials);
            MessageErrorRegister(objMaterials);
            return Redirect("~/Inventory/Index/");
        }

        [HttpGet]
        public ActionResult Eliminate(string id)
        {
            messageInitialDelete();
            Materials objMaterials = new Materials(Convert.ToInt32(id));
            objMaterialsNeg.find(objMaterials);
            return View(objMaterials);
        }

        [HttpPost]
        public ActionResult Eliminate(Materials objMaterials)
        {
            messageInitialDelete();
            objMaterialsNeg.delete(objMaterials);
            MessageErrorRegister(objMaterials);
            Materials objMaterials2 = new Materials();
            return View(objMaterials2);
            //return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Movement(string id)
        {
            UserNeg objUser = new UserNeg();
            List<User> data = objUser.findAll();
            SelectList list = new SelectList(data, "ID", "ID");
            ViewBag.UserList = list;
            messageInitialInputExit();
            Materials objMaterials = new Materials(Convert.ToInt32(id));
            objMaterialsNeg.find(objMaterials);
            return View(objMaterials);
        }

        [HttpPost]
        public ActionResult Movement(Materials objMaterials)
        {
            UserNeg objUser = new UserNeg();
            List<User> data = objUser.findAll();
            SelectList list = new SelectList(data, "ID", "ID");
            ViewBag.UserList = list;
            objMaterialsNeg.movement(objMaterials);
            MessageErrorRegister(objMaterials);
            ModelState.Clear();
            return View("Movement");
        }
    }
}
