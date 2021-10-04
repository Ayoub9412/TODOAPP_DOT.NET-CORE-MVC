using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODOAPP_DOTNETCOREMVC.Models.AppRepository
{
    public interface IMyTodoListRepository<TEntity>
    {
        void Add(TEntity entity);
        void Update(int? id, TEntity entity);
        void Delete(int id);
        TEntity Find(int id);
        List<TEntity> List();
    }
}
