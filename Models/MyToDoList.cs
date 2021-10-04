using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TODOAPP_DOTNETCOREMVC.Models
{
    public class MyToDoList
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
