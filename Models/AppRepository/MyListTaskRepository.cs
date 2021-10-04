using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TODOAPP_DOTNETCOREMVC.Models.AppRepository
{
    public class MyListTaskRepository : IMyTodoListRepository<MyTodoTask>
    {

        public List<MyTodoTask> myListTasks;
        public MyListTaskRepository( )
        {
            myListTasks = new List<MyTodoTask>() {
                new MyTodoTask{ Id = 1, TaskDetails = "Youtube task 1", TodoListId = 1 },
                new MyTodoTask{ Id = 2, TaskDetails = "Youtube task 2", TodoListId = 1 },
                new MyTodoTask{ Id = 3, TaskDetails = "Youtube task 3", TodoListId = 1 },
                new MyTodoTask{ Id = 4, TaskDetails = "Food task 4", TodoListId = 3 },
                new MyTodoTask{ Id = 5, TaskDetails = "Food task 5", TodoListId = 3 },
                new MyTodoTask{ Id = 6, TaskDetails = "Food task 6", TodoListId = 3 },
                new MyTodoTask{ Id = 7, TaskDetails = "Prayer task 1", TodoListId = 4 },
                new MyTodoTask{ Id = 8, TaskDetails = "Prayer task 2", TodoListId = 4 },
                new MyTodoTask{ Id = 9, TaskDetails = "Prayer task 3", TodoListId = 4 },
                new MyTodoTask{ Id = 10, TaskDetails = "Prayer task 4", TodoListId = 4 },
                new MyTodoTask{ Id = 11, TaskDetails = "Prayer task 5", TodoListId = 4 },
                new MyTodoTask{ Id = 12, TaskDetails = "Gym task 1", TodoListId = 2 }
            };
        }


        public void Add(MyTodoTask myListTask)
        {
            int? id;
            try
            {
                id = myListTasks.Max(t => t.Id);
            }
            catch
            {
                id = 0;
            }
            myListTask.Id = (int)id + 1;
            myListTasks.Add(myListTask);
        }

        public void Delete(int id)
        {
            var listTask = Find(id);
            myListTasks.Remove(listTask);
        }

        public MyTodoTask Find(int id)
        {
            return myListTasks.SingleOrDefault( t => t.Id == id);
        }

        public List<MyTodoTask> List()
        {
            return myListTasks.ToList();
        }

        public void Update(int? id, MyTodoTask entity)
        {
            myListTasks.Where(t => t.Id == id).Select(t => {
                t.TaskDetails = entity.TaskDetails;
                return true;
            });

        }
    }
}
