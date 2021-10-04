using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOAPP_DOTNETCOREMVC.Data;

namespace TODOAPP_DOTNETCOREMVC.Models.AppRepository
{
    public class DBToDoListRepository : IMyTodoListRepository<MyToDoList>
    {

        public AppDbContext db { get; }

        public DBToDoListRepository(AppDbContext _db)
        {
            db = _db;
        }

        public void Add(MyToDoList MyToDoList)
        {
            var newList = new MyToDoList
            {
                Name = MyToDoList.Name
            };
            db.MyToDoLists.Add(newList);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var todoList = Find(id);
            db.MyToDoLists.Remove(todoList);
            db.SaveChanges();
        }

        public MyToDoList Find(int id)
        {
            var todolist = db.MyToDoLists.SingleOrDefault(list => list.Id == id);
            return todolist;
        }

        public List<MyToDoList> List()
        {
            return db.MyToDoLists.ToList();
        }

        public void Update(int? id, MyToDoList myToDoList)
        {
            db.MyToDoLists.Update(myToDoList);
            db.SaveChanges();
        }
    }
}

