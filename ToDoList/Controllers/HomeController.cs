using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class HomeController : Controller
  {
    [Route("/")]
    public ActionResult Index()
    {
      Item starterItem = new Item("add first item to To Do List");
      return View(starterItem);
    }

    [Route("/items/new")]
    public ActionResult CreateForm()
    {
      return View();
    }
  }
}