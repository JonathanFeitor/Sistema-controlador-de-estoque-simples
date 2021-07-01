using Model.DAO;
using Model.Entity;
using System.Collections.Generic;

namespace Model.Neg
{
    public class MovementNeg
    {
        private MovementDAO objMovementDAO;

        public MovementNeg()
        {
            objMovementDAO = new MovementDAO();
        }

        public List<Movement> findAll()
        {
            return objMovementDAO.findAll();
        }

        public List<Movement> findByType(Movement objMovement)
        {
            return objMovementDAO.findByType(objMovement);
        }
    }
}
