using GeneralStore.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeneralStore.MVC.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Transaction
        public ActionResult Index()
        {
            List<Transaction> transactionList = _db.Transactions.ToList();
            return View(transactionList);
        }

        //get: create
        public ActionResult Create()
        {
            return View();
        }

        //post: create
        [HttpPost]
        public ActionResult Create(Transaction transaction)
        {
            if (transaction is null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            if (ModelState.IsValid)
            {
                if (!ModelState.IsValid)
                   return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Product product = new Product();
           

            _db.Products.Find(product);

            //check if product is in stock
            if (product.InventoryCount > transaction.ItemCount)
            {
                int newItemCount = product.InventoryCount - transaction.ItemCount;
                product.InventoryCount = newItemCount;
                _db.SaveChanges();
            }

            if (ModelState.IsValid)
            {
                _db.Transactions.Add(transaction);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }
    }
}