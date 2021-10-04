using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOAPP_DOTNETCOREMVC.Models;
using TODOAPP_DOTNETCOREMVC.Models.AppRepository;
using TODOAPP_DOTNETCOREMVC.ViewModels;

namespace TODOAPP_DOTNETCOREMVC.Controllers
{
    public class MyToDoListController : Controller
    {

        public IMyTodoListRepository<MyToDoList> myTodoListRepository { get; }
        public IMyTodoListRepository<MyTodoTask> myTasksRepository { get; }

        public MyToDoListController(IMyTodoListRepository<MyToDoList> _myTodoListRepository,
                                    IMyTodoListRepository<MyTodoTask> _myListTasksRepository)
        {
            myTodoListRepository = _myTodoListRepository;
            myTasksRepository = _myListTasksRepository;
        }
        [HttpGet]
        [Route("/")]
        public IActionResult Index(int? id)
        {
            if (id != null)
            {
                var ToDoLists = myTodoListRepository.List();
                if (ToDoLists.SingleOrDefault(l => l.Id == id) == null)
                {
                    return View();
                }
                var SelectedListTasks = myTasksRepository.List().Where(t => t.TodoListId == id).ToList();
                var SelectdTodoList = new ListDetailsViewModel {
                    SelectedListId = (int)id,
                    AllLists = ToDoLists,
                    AllListTasks = SelectedListTasks };
                return View(SelectdTodoList);
            }
            return View(getAllOrNull());
        }


        [HttpPost]
        public IActionResult AddToDoList(string newList)
        {
            if (newList == null)
            {
                return RedirectToAction("Index");
            }
            myTodoListRepository.Add(new MyToDoList { Name = newList });
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddTaskToList(int? ListId, string NewTask)
        {
            if (string.IsNullOrEmpty(NewTask) || ListId == null || NewTask.Count() < 1)
            {
                return RedirectToAction("Index");
            }

            var newTask = new MyTodoTask {
                TaskDetails = NewTask,
                TodoListId = (int)ListId
            };
            myTasksRepository.Add(newTask);
            return RedirectToAction("Index", new { id = ListId });
        }

        public IActionResult DeleteTask(int? ListId,int? TaskId)
        {
            if (ListId == null || TaskId == null)
            {
                RedirectToAction("Index");
            }
            myTasksRepository.Delete((int)TaskId);

            return RedirectToAction("Index", new { id = ListId });
        }

        public IActionResult DeleteList(int? ListId)
        {
            if (ListId == null)
            {
                RedirectToAction("Index");
            }
            myTodoListRepository.Delete((int)ListId);
            foreach (var myTask in myTasksRepository.List())
            {
                if (myTask.TodoListId == ListId)
                {
                    myTasksRepository.Delete(myTask.Id);
                }
            }

            return RedirectToAction("Index");
        }

        public ListDetailsViewModel getAllOrNull()
        {
            var allToDoLists = myTodoListRepository.List();
            var SelectedToDoList = allToDoLists.SingleOrDefault(listId => listId.Id == allToDoLists.Max(l => l.Id));
            if (SelectedToDoList == null)
            {
                return null;
            }
            var defaultSelectedListTasks = myTasksRepository.List().Where(t => t.TodoListId == SelectedToDoList.Id).ToList() ?? new List<MyTodoTask>();
            if (allToDoLists.Count == 0 || SelectedToDoList == null)
            {
                return null;
            }
            return new ListDetailsViewModel { SelectedListId = allToDoLists.Min(l => l.Id), AllLists = allToDoLists, AllListTasks = defaultSelectedListTasks };
        }
    }
}
