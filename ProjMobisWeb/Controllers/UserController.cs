using Model.Entity;
using Model.Neg;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjMobisWeb.Controllers
{
    public class UserController : Controller
    {
        UserNeg objUserNeg;
        
        public UserController()
        {
            objUserNeg = new UserNeg();
        }
        
        //Show Users
        // GET: User
        public ActionResult Index()
        {
            List<User> userList = objUserNeg.findAll();
            return View(userList);
        }

        // GET: User/Create
        [HttpGet]
        public ActionResult Create()
        {
            messageInitialRegiter();
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User objUser)
        {
            messageInitialRegiter();
            objUserNeg.create(objUser);
            MessageErrorRegister(objUser);
            ModelState.Clear();
            return View("Create");
            
        }

        //Error Message
        public void MessageErrorRegister(User objUser)
        {

            switch (objUser.InfMessage)
            {
                case 1: // Database Error
                    ViewBag.MessageError = "An error occured while entering information into the database!";
                    break;

                case 20://empty field (ID)
                    ViewBag.MessageError = "Enter user ID!";
                    break;

                case 2://Name Error
                    ViewBag.MessageError = "Field must contain more than 1 character and less than 50 characters!";
                    break;

                case 50://empty field (Name)
                    ViewBag.MessageError = "Enter user name!";
                    break;

                case 33://ID Doesn't match
                    ViewBag.MessageError = "The ID entered wasn't found!";
                    break;

                case 60://empty field (Password)
                    ViewBag.MessageError = "Enter user password!";
                    break;

                case 8://duplicate error (ID)
                    ViewBag.MessageError = "The User [" + objUser.ID + "] is already registered in the system!";
                    break;

                case 99://Sucessfully
                    ViewBag.MessageSuccess = "The user [" + objUser.Name + "] has been successfully entered!";
                    break;

                case 100://Sucessfully
                    ViewBag.MessageSuccessfullUpdate = "The user [" + objUser.Name + "] has been successfully updated!";
                    break;

                case 101://Sucessfully
                    ViewBag.MessageSuccessfullDelete = "User [" + objUser.Name + "] deleted successfully!";
                    break;

                case 995://Error
                    ViewBag.MessageError = "Please fill in the ID or name field!";
                    break;

                case 996://Error
                    ViewBag.MessageError = "Only 1 of the fields must be filled in!";
                    break;
            }

        }

        public void messageInitialRegiter()
        {
            ViewBag.MessageInitial = "Insert user data and click save!";
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            messageInitialUpdate();
            User objUser = new User(id);
            objUserNeg.find(objUser);
            return View(objUser);
        }
        [HttpPost]
        public ActionResult Update(User objUser)
        {
            messageInitialUpdate();
            objUserNeg.update(objUser);
            MessageErrorRegister(objUser);
            return View();
            //return Redirect("~/User/Index/");
        }

        //Initial message update
        public void messageInitialUpdate()
        {
            ViewBag.MessageInitialUpdate = "Form to update user data";
        }

        public ActionResult Delete(string id)
        {
            messageInitialDelete();
            User objUser = new User(id);
            objUserNeg.find(objUser);
            return View(objUser);

        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            messageInitialDelete();
            User objUser = new User(id);
            objUserNeg.delete(objUser);
            MessageErrorRegister(objUser);
            return Redirect("~/User/Index/");
        }

        [HttpGet]
        public ActionResult Eliminate(string id)
        {
            messageInitialDelete();
            User objUser = new User(id);
            objUserNeg.find(objUser);
            return View(objUser);
        }

        [HttpPost]
        public ActionResult Eliminate(User objUser)
        {
            messageInitialDelete();
            objUserNeg.delete(objUser);
            MessageErrorRegister(objUser);
            User objUser2 = new User();
            return View(objUser2);
            //return RedirectToAction("Index");
        }

        public void messageInitialDelete()
        {
            ViewBag.MessageInitialEliminate = "Exclusion form";
        }

        public ActionResult Find(string id)
        {
            User objUser = new User(id);
            objUserNeg.find(objUser);

            return View(objUser);
        }

        [HttpGet]
        public ActionResult SearchUser()
        {
            List<User> list = objUserNeg.findAll();
            return View(list);
        }
        [HttpPost]
        public ActionResult SearchUser(string txtID, string txtName)
        {
            if(txtID == "")
            {
                txtID = "null";
            }
            if(txtName == "")
            {
                txtName = "null";
            }

            User objUser = new User();
            objUser.Name = txtName;
            objUser.ID = txtID;

            List<User> list = objUserNeg.findByType(objUser);
            return View(list);
        }
    }
}
