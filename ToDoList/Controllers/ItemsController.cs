using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
//___________________________________________________
//Body in response: The last line of code in a controller route indicates the resource that should be returned in the body of the response. In this case it is a View().
//___________________________________________________
namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    [HttpGet("/items")]
    public ActionResult Index()
    {
     List<Item> allItems = Item.GetAll();
      return View(allItems);
      // Item starterItem = new Item("add first item to To Do List");
      // return View(starterItem);
    }

    [HttpGet("/items/new")]
    public ActionResult New()
    {
      return View();
    }

//[Route("/items)] Create() is only for creating new items. No need to create Create.cshtml 
  [HttpPost("/items")]
    public ActionResult Create(string description)
    {
      Item myItem = new Item(description);
      return RedirectToAction("Index");
      //RedirectToAction takes a route method as an argument. It redirects to the route that is passed as an argument.

      // return View("Index", myItem);
      //"Index" specifies the view that should be returned because we are no longer routing to a view with the same exact name as our route method.
    }

    [HttpPost("/items/delete")]
    public ActionResult DeleteAll()
    {
      Item.ClearAll();
      return View();
    }

    [HttpGet("/items/{id}")]
    public ActionResult Show(int id)
    {
      Item foundItem = Item.Find(id);
      return View(foundItem);
    }
  }
}