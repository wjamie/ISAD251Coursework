using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// using System.Data.SqlClient;

using DrinksAndSnacks.Models;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace DrinksAndSnacks.Controllers
{
    public class FindOrderController : Controller
    {

        private readonly ISAD251_JWalkerContext _context;

        public FindOrderController(ISAD251_JWalkerContext context)
        {
            _context = context;
        }





        //order id list

        public IActionResult Index()
        {

            IEnumerable<SelectListItem> OrderIdList = (from p in _context.Orders.AsEnumerable()
                                                           select new SelectListItem
                                                           {
                                                               Text = p.OrderId.ToString(),
                                                               Value = p.OrderId.ToString()
                                                           }).ToList();
            ViewBag.OrderIds = OrderIdList;

            return View();

        }

        // find order method when user clicks find order button

        [HttpGet]
        public IActionResult Find_Order(Find_Order find_Order)
        {
            var findOrders = _context.Database.ExecuteSqlRaw("EXEC Find_Order  @Order_Id",
                new SqlParameter("@Order_Id", find_Order.OrderId));
                
                ViewBag.Success = findOrders;

            return View("Index");

        }





    }

}