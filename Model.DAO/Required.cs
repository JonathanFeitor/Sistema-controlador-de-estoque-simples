using System.Collections.Generic;

namespace Model.DAO
{
    public interface Required<AnyClass>
    {
        void create(AnyClass obj);
        void delete(AnyClass obj);
        void update(AnyClass obj);
        void Input(AnyClass obj);
        void Exit(AnyClass obj);
        bool find(AnyClass obj);
        bool findByESNumber(AnyClass obj);
        List<AnyClass> findAll();
        List<AnyClass> findByType();
    }
}