using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookLibrary_2._7._18_.Models;
using System.IO;

namespace BookLibrary_2._7._18_.Controllers
{
    public class BookController : Controller
    {
     
        LibraryEntities db = new LibraryEntities();

        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        public ActionResult AddBook()
        {
            return View();
        }
        string a = "";

        [HttpPost]
        public ActionResult AddBook([Bind (Exclude = "book_photo")] Book book,HttpPostedFileBase book_photo)
        {
            var file_name = Path.GetFileName(book_photo.FileName);
            if(Path.GetExtension(book_photo.FileName)== ".jpg" && book_photo.ContentLength <2100000)
            {
                Random gen_random = new Random();
                string r = gen_random.Next(11111, 99999).ToString();
                var file_path = Path.Combine(Server.MapPath("/Upload"), file_name);
                book_photo.SaveAs(file_path);
                book.book_photo = "/Upload/" + file_name;

                db.Books.Add(book);
                db.SaveChanges();

            }
            


            return RedirectToAction("Index");
        }


        public ActionResult Delete(int? id,Book book)
        {
             Book del =  db.Books.Find(id);
            db.Books.Remove(del);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

       
    }
}