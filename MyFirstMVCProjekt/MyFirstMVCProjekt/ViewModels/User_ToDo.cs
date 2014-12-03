using MyFirstMVCProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstMVCProjekt.ViewModels
{
    // This classes i caled ViewModels
    public class User_ToDo
    {
        public List<ToDoItem> ToDo { get; set; }
        public User User { get; set; }
    }
}
