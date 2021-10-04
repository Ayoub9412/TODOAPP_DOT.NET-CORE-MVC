using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOAPP_DOTNETCOREMVC.Models;

namespace TODOAPP_DOTNETCOREMVC.ViewModels
{
    public class ListDetailsViewModel
    {
        public int SelectedListId { get; set; }

        public List<MyToDoList> AllLists { get; set; }

        public List<MyTodoTask> AllListTasks { get; set; }


    }
}
