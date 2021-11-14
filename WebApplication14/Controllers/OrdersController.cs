using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication14.Models;
using WebApplication14.Repositories;

namespace WebApplication14.Controllers
{
    public class OrdersController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult Index()
        {
            return View(unitOfWork.OrdersRepository.Get());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = unitOfWork.OrdersRepository.GetByID(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderID,OrderStatus,ShippingStatus")] Order order)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.OrdersRepository.Add(order);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = unitOfWork.OrdersRepository.GetByID(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderID,OrderStatus,ShippingStatus")] Order order)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.OrdersRepository.Edit(order);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = unitOfWork.OrdersRepository.GetByID(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = unitOfWork.OrdersRepository.GetByID(id);
            unitOfWork.OrdersRepository.Delete(order);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
