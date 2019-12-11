using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DrinksAndSnacks.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace DrinksAndSnacks.Controllers
{
    public class CreateOrderController : Controller
    {
        private readonly ISAD251_JWalkerContext _context;

        public CreateOrderController(ISAD251_JWalkerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            IEnumerable<SelectListItem> ProductNameList = (from p in _context.Products.AsEnumerable()
                                                      select new SelectListItem
                                                      {
                                                          Text = p.ProductName,
                                                          Value = p.ProductName.ToString()
                                                      }).ToList();
            ViewBag.ProductNames = ProductNameList;

            return View();

        }


        [HttpPost]
        public IActionResult Create_Order(Add_Order add_Order)
        {
            var createdOrder = _context.Database.ExecuteSqlRaw("EXEC Add_Order @Table_Number, @Product_Name, @Quantity",
               new SqlParameter("@Table_Number", add_Order.TableNumber),
               new SqlParameter("@Product_Name", add_Order.ProductName),
               new SqlParameter("@Quantity", add_Order.Quantity));
          
              


            ViewBag.Success = createdOrder;

            return View("Index");

        }






    }
}