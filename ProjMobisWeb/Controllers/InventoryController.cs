using Model.Entity;
using Model.Neg;
using System.Web.Mvc;
using System.Collections.Generic;

namespace ProjMobisWeb.Controllers
{
    public class InventoryController : Controller
    {
        InventoryNeg objInventoryNeg;

        public InventoryController()
        {
            objInventoryNeg = new InventoryNeg();
        }


        //Message Initial
        public void messageInitialRegiter()
        {
            ViewBag.MessageInitialRegister = "Insert Inventory data and click save!";
        }
        //Initial message update
        public void messageInitialUpdate()
        {
            ViewBag.MessageInitialUpdate = "Form to update Inventory data";
        }
        // Initial message Delete
        public void messageInitialDelete()
        {
            ViewBag.MessageInitialEliminate = "Exclusion form";
        }

        //MessageError
        public void MessageErrorRegister(Inventory objInventory)
        {
            switch (objInventory.InfMessage)
            {
                case 1: // Database Error
                    ViewBag.MessageError = "An error occured while entering information into the database!";
                    break;

                case 10:// empty field (Inventory Type)
                    ViewBag.MessageError = "Type field is mandatory!";
                    break;

                case 14:// empty field (Inventory EInventory)
                    ViewBag.MessageError = "Inventory number field is mandatory!";
                    break;

                case 20: // Type Error
                    ViewBag.MessageError = "Field must contain more than 1 character and less than 50 characters!";
                    break;

                case 24: // Type Error
                    ViewBag.MessageError = "Field must contain more than 1 character and less than 20 characters!";
                    break;

                case 11: // empty field (Inventory Model)
                    ViewBag.MessageError = "Model field is mandatory!";
                    break;

                case 21: // Model Error
                    ViewBag.MessageError = "Field must contain more than 1 character and less than 50 characters!";
                    break;

                case 12: // empty field (Inventory Serial Number)
                    ViewBag.MessageError = "Serial Number field is mandatory!";
                    break;

                case 22: // Serial Number Error
                    ViewBag.MessageError = "Field must contain more than 1 character and less than 50 characters!";
                    break;

                case 23: // Serial Number Error
                    ViewBag.MessageError = "Field must contain more than 1 character and less than 3 characters!";
                    break;

                case 13: // empty field (Status Equipament)
                    ViewBag.MessageError = "Status Equipament field is mandatory!";
                    break;

                case 200: // Duplicate Error (Inventory NUmber)
                    ViewBag.MessageError = "The Inventory Number [" + objInventory.EInventory + "] is already registered in the system!";
                    break;

                case 1000: // Create successfully
                    ViewBag.MessageSuccessfully = "The equipament [" + objInventory.EType + "] was inserted with successfully!";
                    break;

                case 50: // empty field (Inventory Type)
                    ViewBag.MessageError = "The field the type can't be null!";
                    break;

                case 51: // empty field  (Inventory Model)
                    ViewBag.MessageError = "The field the model can't be null!";
                    break;

                case 52: // empty field (Serial Number)
                    ViewBag.MessageError = "The field the serial number can't be null!";
                    break;

                case 53: // empty field (Status Equipament)
                    ViewBag.MessageError = "This field only accepts the YES or NO options!";
                    break;

                case 1001: // Create successfully
                    ViewBag.MessageSuccessfullyUpdate = "The equipament [" + objInventory.EType + "] was updated with successfully!";
                    break;

                case 70: // Duplicate Error (Inventory NUmber)
                    ViewBag.MessageError = "The Inventory Number [" + objInventory.EInventory + "] alread is registered in the system!";
                    break;

                case 1002://Sucessfully Delete
                    ViewBag.MessageSuccessfullDelete = "The Inventory [" + objInventory.EInventory + "] was deleted with successfully!";
                    break;

                case 1005://Error Delete
                    ViewBag.MessageErrorDelete = "Checked all field and try again!";
                    break;

                case 500: //Error Insert new Inventory
                    ViewBag.MessageErrorInsert = "This Inventory [" + objInventory.EInventory + "] can't be inserted in the system!";
                    break;

            }
        }

        public ActionResult Index()
        {
            List<Inventory> inventoryList = objInventoryNeg.findAll();
            return View(inventoryList);
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
        public ActionResult Create(Inventory objInventory)
        {
            UserNeg objUser = new UserNeg();
            List<User> data = objUser.findAll();
            SelectList list = new SelectList(data, "ID", "ID");
            ViewBag.UserList = list;
            messageInitialRegiter();
            objInventoryNeg.create(objInventory);
            MessageErrorRegister(objInventory);
            ModelState.Clear();
            return View("Create");
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            messageInitialUpdate();
            Inventory objInventory = new Inventory(id);
            objInventoryNeg.find(objInventory);
            return View(objInventory);
        }

        [HttpPost]
        public ActionResult Update(Inventory objInventory)
        {
            messageInitialUpdate();
            objInventoryNeg.update(objInventory);
            MessageErrorRegister(objInventory);
            return View();
        }

        public ActionResult Find(string id)
        {
            Inventory objInventory = new Inventory(id);
            objInventoryNeg.find(objInventory);

            return View(objInventory);
        }

        [HttpGet]
        public ActionResult SearchInventory()
        {
            List<Inventory> list = objInventoryNeg.findAll();
            return View(list);
        }
        [HttpPost]
        public ActionResult SearchInventory(string txtType, string txtModel)
        {
            if(txtType == "")
            {
                txtType = "null";
            }
            if(txtModel == "")
            {
                txtModel = "null";
            }
            Inventory objInventory = new Inventory();
            objInventory.EType = txtType;
            objInventory.EModel = txtModel;
            List<Inventory> list = objInventoryNeg.finByType(objInventory);
            return View(list);
        }

        public ActionResult Delete(string id)
        {
            messageInitialDelete();
            Inventory objInventory = new Inventory(id);
            objInventoryNeg.find(objInventory);
            return View(objInventory);

        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            messageInitialDelete();
            Inventory objInventory = new Inventory(id);
            objInventoryNeg.delete(objInventory);
            MessageErrorRegister(objInventory);
            return Redirect("~/Inventory/Index/");
        }

        [HttpGet]
        public ActionResult Eliminate(string id)
        {
            messageInitialDelete();
            Inventory objInventory = new Inventory(id);
            objInventoryNeg.find(objInventory);
            return View(objInventory);
        }

        [HttpPost]
        public ActionResult Eliminate(Inventory objInventory)
        {
            messageInitialDelete();
            objInventoryNeg.delete(objInventory);
            MessageErrorRegister(objInventory);
            Inventory objInventory2 = new Inventory();
            return View(objInventory2);
            //return RedirectToAction("Index");
        }
    }
}
