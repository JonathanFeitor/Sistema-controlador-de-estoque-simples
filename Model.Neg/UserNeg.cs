using Model.DAO;
using Model.Entity;
using System;
using System.Collections.Generic;

namespace Model.Neg
{
    public class UserNeg
    {
        private UserDAO objUserDAO;

        public UserNeg()
        {
            objUserDAO = new UserDAO();
        }

        public void create(User objUser)
        {
            bool checkUser = true;

            string id = objUser.ID;
            if (id == null)
            {
                objUser.InfMessage = 20;
                return;
            }
            else
            {
                id = objUser.ID.Trim();
                checkUser = id.Length <= 50 && id.Length > 0;
                if (!checkUser)
                {
                    objUser.InfMessage = 2;
                    return;
                }
            }
            //end to check id

            //starting check name
            string name = objUser.Name;
            if (name == null)
            {
                objUser.InfMessage = 50;
                return;
            }
            else
            {
                name = objUser.Name.Trim();
                checkUser = name.Length <= 50 && name.Length > 0;
                if (!checkUser)
                {
                    objUser.InfMessage = 2;
                    return;
                }

            }

            string password = objUser.Password;
            if (password == null)
            {
                objUser.InfMessage = 60;
                return;
            }
            else
            {
                password = objUser.Password.Trim();
                checkUser = password.Length <= 50 && password.Length > 0;
                if (!checkUser)
                {
                    objUser.InfMessage = 2;
                    return;
                }

            }
            
            //begin check duplicated
            User objUserAux = new User();
            objUserAux.ID = objUser.ID;
            checkUser = !objUserDAO.find(objUserAux);
            if (!checkUser)
            {
                objUser.InfMessage = 8;
                return;
            }
            
            //case don't error
            objUser.InfMessage = 99;
            objUserDAO.create(objUser);
            return;
        }

        public void update(User objUser)
        {
            try
            {
                if(objUser.ID == null)
                {
                   objUser.InfMessage = 20;
                }
                else
                {
                    if(objUser.Name == null)
                    {
                        objUser.InfMessage = 50;
                    }
                    else
                    {
                        if(objUser.Password == null)
                        {
                            objUser.InfMessage = 60;
                        }
                        else
                        {
                            objUser.InfMessage = 99;
                            objUserDAO.update(objUser);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            
            return; 
        }

        public void delete(User objUser)
        {
            bool checkUser = true;
            
            User objUserAux = new User();
            objUserAux.ID = objUser.ID;
            checkUser = objUserDAO.find(objUserAux);
            if (!checkUser)
            {
                objUser.InfMessage = 33;
                return;
            }

            objUser.InfMessage = 99;
            objUserDAO.delete(objUser);
            return;
        }

        public bool find(User objUser)
        {
            return objUserDAO.find(objUser);
        }

        public List<User> findByType(User objUser)
        {
            return objUserDAO.findByType(objUser);
        }

        public List<User> findAll()
        {
            return objUserDAO.findAll();
        }
    }
}
