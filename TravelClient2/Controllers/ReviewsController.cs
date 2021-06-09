using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelClient2.Models;

namespace TravelClient2.Controllers
{
  public class ReviewsController : Controller
  {
    public IActionResult Index()
    {
      var allReviews = Review.GetReviews();
      return View(allReviews);
    }
    public IActionResult Search(string searchString)
    {
      var allReviews = Review.GetReviews();
      var reviews = allReviews.Where(s => s.City == searchString);
      return View(reviews);
    }
    public IActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public IActionResult Create(Review review)
    {
      Review.Post(review);
      return RedirectToAction("Index");
    }
    public IActionResult Details(int id)
    {
      var review = Review.GetDetails(id);
      return View(review);
    }

    public IActionResult Edit(int id)
    {
      var review = Review.GetDetails(id);
      return View(review);
    }

    [HttpPost]
    public IActionResult Details(int id, Review review)
    {
      review.ReviewId = id;
      Review.Put(review);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Review.Delete(id);
      return RedirectToAction("Index");
    }
  }
}