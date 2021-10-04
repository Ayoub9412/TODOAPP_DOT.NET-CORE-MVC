using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODOAPP_DOTNETCOREMVC.Models.AppRepository
{
    public class MyToDoListRepository : IMyTodoListRepository<MyToDoList>
    {
        public List<MyToDoList> myToDoLists;
        public MyToDoListRepository()
        {
            myToDoLists = new List<MyToDoList>() {
                new MyToDoList{Id = 1, Name = "Youtube"},
                new MyToDoList{Id = 3, Name = "Food"},
                new MyToDoList{Id = 4, Name = "Prayer"},
                new MyToDoList{Id = 2, Name = "Gym"}
            };
        }

        public void Add(MyToDoList _MyToDoList)
        {
            int? id;
            try
            {
                id = myToDoLists.Max(todolist => todolist.Id);
            }
            catch
            {
                id = 0;
            }
            _MyToDoList.Id = (int)id + 1;
            myToDoLists.Add(_MyToDoList);
        }

        public void Delete(int id)
        {
            var todoList = Find(id);
            myToDoLists.Remove(todoList);
        }

        public MyToDoList Find(int id)
        {
            var todolist = myToDoLists.SingleOrDefault(list => list.Id == id);
            return todolist;
        }

        public List<MyToDoList> List()
        {
            return myToDoLists.ToList();
        }

        public void Update(int? id, MyToDoList myToDoList)
        {
            myToDoLists.Where(l => l.Id == id).Select(l => {
                l.Name = myToDoList.Name;
                return true;
                }
            );
        }
    }
}
