using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        public ApplicationDbContext _context { get; set; }

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customer = _context.Customers.Include(e => e.MembershipType).ToList();

            return View(customer);
        }

        [Route("customer/details/{index}")]
        public ActionResult Details(int index)
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();

            var customer = _context.Customers.SingleOrDefault(e => e.Id == index);

            if (customer == null)
                return HttpNotFound();

            customerViewModel.Name = customer.Name;

            return View(customerViewModel);
        }
    }
}