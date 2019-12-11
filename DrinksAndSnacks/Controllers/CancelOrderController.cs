using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
//using System.Data.SqlClient;
using DrinksAndSnacks.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DrinksAndSnacks.Controllers
{
    public class CancelOrderController : Controller
    {
        private readonly ISAD251_JWalkerContext _context;

        public CancelOrderController(ISAD251_JWalkerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            IEnumerable<SelectListItem> OrderIdList = (from p in _context.Orders.AsEnumerable()
                                                           select new SelectListItem
                                                           {
                                                               Text = p.OrderId.ToString(),
                                                               Value = p.OrderId.ToString(),
                                                           }).ToList();
            ViewBag.OrderIds = OrderIdList;

            return View();

        }

        [HttpPost]
        public IActionResult Cancel_Order(Cancel_Order cancel_Order)
        {
            var cancelOrder = _context.Database.ExecuteSqlRaw("EXEC Cancel_Order @Order_Id",
               new SqlParameter("@Order_Id", cancel_Order.OrderId));
              




            ViewBag.Success = cancelOrder;

            return View("Index");

        }

    }
}