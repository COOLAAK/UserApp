using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserApp.Models;

namespace UserApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Register");
        }

        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (EFContext context = new EFContext())
                {
                    Address address = new Address()
                    {
                        Country = model.Country,
                        Apartement = model.Apartement,
                        City = model.City,
                        Street = model.Street,
                    };
                    User user = new User()
                    {
                        Email = model.Email,
                        Name = model.Name,
                        Password = model.Password,
                        Phone = model.Phone,
                        DateOfBirth = model.DateOfBirth,
                        AddressOf = address
                    };
                    Product product = new Product()
                    {
                        Name="Вермешель",
                        Price=13.99
                    };
                    context.Products.Add(product);
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                ViewBag.IsSuccessed = true;
                return View(new RegisterViewModel());
            }
            else
            {
                return View(model);
            }
        }
    }
}