using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyFirstMVCProjekt.Models
{
    public class ToDoContext : DbContext
    {
        //Vilka klassfiler ska den skapa databas av? 
        //alla sånna klasser ska finnas här.
        //Alltså all klasser nedan får en databas.
        //enables CRUD Funcs create,read,Update,Delete
        //Du bestämmer var teblellen ska skapas med hjälp av Web.Config
        //ConectionsStrings.com
        public DbSet<ToDoItem> ToDoItem { get; set; }
        public DbSet<User> User { get; set; }
    }
}