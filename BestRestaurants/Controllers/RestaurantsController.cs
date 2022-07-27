using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BestRestaurants.Models;

namespace BestRestaurants.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly BestRestaurantsContext _db;

    public RestaurantsController(BestRestaurantsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Restaurants> model = _db.Restaurants.ToList();
      return view(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Restaurants restaurants)
    {
      _db.Restaurants.Add(restaurants);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult Details(int id)
    {
      Restaurants thisRestaurants = _db.Restaurants.
      FirstOrDefault(restaurants => restaurants.RestaurantsId == id);
      return View(thisRestaurants);
    }
    
    public ActionResult Edit(int id)
    {
      var thisRestaurants = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantsId == id);
      return view(thisRestaurants);
    }
    
    [HttpPost]
    public ActionResult Edit(Restaurants restaurants)
    {
      _db.Entry(restaurants).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisRestaurants = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantsId == id);
      return View(thisRestaurants);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisRestaurants = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantsId == id);
      _db.Restaurants.Remove(thisRestaurants);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}