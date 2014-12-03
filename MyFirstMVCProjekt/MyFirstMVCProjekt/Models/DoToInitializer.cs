using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyFirstMVCProjekt.Models
{
    public class DoToInitializer : DropCreateDatabaseIfModelChanges<ToDoContext>
    {
        protected override void Seed(ToDoContext context)
        {
            //måste köras varje gång klassen går igång så vi har data.
            //Set i Global.asax Database.SetInitializer<ToDoContext>(new DoToInitializer());
            var toDo = new List<ToDoItem>
            {
                new ToDoItem{Title="School", Description="Homework", Date=DateTime.Now},
                new ToDoItem{Title="home", Description="clean", Date=DateTime.Now}
            };
            foreach(var temp in toDo)
            {
                context.ToDoItem.Add(temp);
            }

            context.SaveChanges();
        }
    }
}