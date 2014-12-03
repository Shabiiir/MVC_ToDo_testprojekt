using MyFirstMVCProjekt.Models;
using MyFirstMVCProjekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;

namespace MyFirstMVCProjekt.Controllers
{
    public class ToDoItemController : Controller
    {
        private ToDoContext db = new ToDoContext();


        //
        // GET: /ToDoItem/
        public ActionResult Index(string Show,string SearchString)
        {
            var toDoItem = db.ToDoItem.ToList();

            if (!String.IsNullOrEmpty(Show))
            {
                if (!(Show=="Show all"))
                {

                    toDoItem = toDoItem.Where(a => a.Status.IndexOf(Show) >= 0).ToList();
                }
                
            }
            if (!String.IsNullOrEmpty(SearchString))
            {
               toDoItem.Where(a => a.Title.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
               //var toDoItem2 = toDoItem.Where(a => a.Description.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

               

            }
            
            return View(toDoItem);
        }

        // GET: 
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        public ActionResult Create(ToDoItem toDoItem)
        {
            try 
            {
                if(ModelState.IsValid)
                {
                    toDoItem.Date = DateTime.Now;
                    db.ToDoItem.Add(toDoItem);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(toDoItem);
            }
            catch 
            {
                return View();
            }
        }

        
        public ActionResult Details(int id=0)
        {
            var item = db.ToDoItem.Find(id);

            if (item == null)
            {
                var toDoItem = db.ToDoItem.ToList();
                return View("Index",toDoItem);
            }
           return View(item);
        }

        public ActionResult Edit (int id=0)
        {
            var item = db.ToDoItem.Find(id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }


        

        [HttpPost]
        public ActionResult Edit(ToDoItem toDoItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var ctx = new ToDoContext())
                    {
                        var item = (from s in ctx.ToDoItem
                                    where s.ID == toDoItem.ID
                                    select s).FirstOrDefault();

                        item.Title = toDoItem.Title;
                        item.Description = toDoItem.Description;
                        item.Status = toDoItem.Status;

                        ctx.SaveChanges();
                        return RedirectToAction("Edit",toDoItem);
                    }

                    
                }
                return View(toDoItem);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete (int id=0)
        {
            var item = db.ToDoItem.Find(id);
            if (item == null)
            {
                var toDoItem = db.ToDoItem.ToList();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpPost]
        public ActionResult Delete (ToDoItem item)
        {
            var item2 = db.ToDoItem.SingleOrDefault(x => x.ID == item.ID);
            db.ToDoItem.Remove(item2);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        //public ActionResult Test()
        //{
                      
          
        //    //Ta ut allt från databastabelen ToDo och stoppa i lista.
        //    ViewBag.Testar = "HAHAH skit kod";
        //    var toDo = db.ToDoItem.ToList();
        //    return View(toDo);
            
        //    //User U = new User();
        //    //U.ID = 2;
        //    //U.UserName = "Sharev131";

        //    //ToDoItem ToDo1 = new ToDoItem();
        //    //ToDo1.ID = 1;
        //    //ToDo1.Title = "Eat";
        //    //ToDoItem ToDo2 = new ToDoItem();
        //    //ToDo2.ID = 2;
        //    //ToDo2.Title = "Sleep";
        //    //ToDoItem ToDo3 = new ToDoItem();
        //    //ToDo3.ID = 3;
        //    //ToDo3.Title = "Play";
        //    //List<ToDoItem> ToDoList = new List<ToDoItem>();
        //    //ToDoList.Add(ToDo1);
        //    //ToDoList.Add(ToDo2);
        //    //ToDoList.Add(ToDo3);

        //    //User_ToDo UD = new User_ToDo();
        //    //UD.ToDo = ToDoList;
        //    //UD.User = U;
        //    //return View(UD);
        //}
	}
}