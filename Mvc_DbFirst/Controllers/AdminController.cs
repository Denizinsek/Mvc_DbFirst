using Mvc_DbFirst.Models;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;

namespace Mvc_DbFirst.Controllers
{
    public class AdminController : Controller
    {
        Mvc_dbFirstEntities db = new Mvc_dbFirstEntities();

        // GET: Admin
        public ActionResult Index() // listing
        {
            return View(db.Products.ToList());
        }

        // Kaydetme işlemleri için sayfa kontrolleri

        [HttpGet]
        public ActionResult Save()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Save(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            // return View();
            return RedirectToAction("Index");
        }

        // Güncelleme işlemi 
        public ActionResult Edit(int id)
        {
            var result = db.Products.Where(x => x.id == id).FirstOrDefault();
            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            db.Products.AddOrUpdate(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // View oluşturmadan direkt silme
        public ActionResult Delete(int id)
        {
            var result = db.Products.Where(x => x.id == id).FirstOrDefault();
            db.Products.Remove(result);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        // Silme İşlemi ActionResult
        //public ActionResult Delete(int id)
        //{
        //    var result = db.Products.Where(x => x.id == id).FirstOrDefault();
        //    return View(result);
        //}

        //[HttpPost]
        //public ActionResult Delete(int id, Product product)
        //{
        //    var result = db.Products.Where(x => x.id == id).FirstOrDefault();
        //    db.Products.Remove(result);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}