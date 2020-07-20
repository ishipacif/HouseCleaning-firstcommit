using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HouseCleanersApi.Interfaces
{
    public interface IRepositoryBase <T> // T signifie type generique qui sera precisé dans les classes qui implementeront cet l'interface
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> query); // expression qui aura une fonction qui retourne un boolean (pour le find by ID, name,... ".where))
        T Create(T model);  // on utilise le bool pour qu'il retourne ok ou pas et creer un modet (post)
        bool CreateMany(IEnumerable<T> models);
        bool Update(T model);
        bool UpdateMany(IEnumerable<T> models);
        bool Delete(T model);
        bool DeleteMany(IEnumerable<T> models);
        T FindById(Expression<Func<T, bool>> query);
    }
}