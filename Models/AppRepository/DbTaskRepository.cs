using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOAPP_DOTNETCOREMVC.Data;

namespace TODOAPP_DOTNETCOREMVC.Models.AppRepository
{
    public class DbTaskRepository : IMyTodoListRepository<MyTodoTask>
    {
        public AppDbContext db { get; }

        public DbTaskRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Add(MyTodoTask myListTask)
        {
            db.MyToDoTasks.Add(myListTask);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var listTask = Find(id);
            db.MyToDoTasks.Remove(listTask);
            db.SaveChanges();
        }

        public MyTodoTask Find(int id)
        {
            return db.MyToDoTasks.SingleOrDefault(t => t.Id == id);
        }

        public List<MyTodoTask> List()
        {
            return db.MyToDoTasks.ToList();
        }

        public void Update(int? id, MyTodoTask myTask)
        {
            db.MyToDoTasks.Update(myTask);
            db.SaveChanges();

        }
    }
}
