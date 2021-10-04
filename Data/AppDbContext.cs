using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOAPP_DOTNETCOREMVC.Models;

namespace TODOAPP_DOTNETCOREMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<MyToDoList> MyToDoLists { get; set; }
        public DbSet<MyTodoTask> MyToDoTasks { get; set; }
    }
}
