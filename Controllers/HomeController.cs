//Name: Patty Chow
//Date: September 25
//Description: HW2 – Bookstore Checkout 

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Chow_Patty_HW2.Models;

namespace Chow_Patty_HW2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IWebHostEnvironment _environment;
        public HomeController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult CheckoutWholesale()
        {
            return View();
        }

        public IActionResult WholesaleTotals(WholesaleOrder wholesaleOrder)
        {
            TryValidateModel(wholesaleOrder);
            if (ModelState.IsValid == false)
            {
                return View("CheckoutWholesale", wholesaleOrder);
            }
            wholesaleOrder.Customer_Type = CustomerType.Wholesale;
            try
            {
                wholesaleOrder.CalcTotals();
            }
            catch (Exception ex)
            {

                ViewBag.ErrorMessage = ex.Message;
                return View("CheckoutWholesale");
            }
            return View("WholesaleTotals", wholesaleOrder);

        }

        public IActionResult CheckoutDirect()
        {
            return View();
        }

        public IActionResult DirectTotals(DirectOrder directOrder)
        {
            TryValidateModel(directOrder);
            if (ModelState.IsValid == false)
            {
                return View("CheckoutDirect", directOrder);
            }
            directOrder.Customer_Type = CustomerType.Direct;
            try
            {
                directOrder.CalcTotals();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("CheckoutDirect");
            }
            return View("DirectTotals", directOrder);
        }


    }

}
