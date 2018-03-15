using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zombiecalypse.DAL;
using Zombiecalypse.Models;

namespace Zombiecalypse.Controllers
{
    public class FileUploadersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: FileUploaders
        public ActionResult Index()
        {
            return View(db.FileUploaders.ToList());
        }

        // GET: FileUploaders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileUploader fileUploader = db.FileUploaders.Find(id);
            if (fileUploader == null)
            {
                return HttpNotFound();
            }
            return View(fileUploader);
        }

        // GET: FileUploaders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FileUploaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FileUploaderID")] FileUploader fileUploader, HttpPostedFileBase  upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var avatar = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Avatar,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    fileUploader.Files = new List<File> { avatar };
                }
                db.FileUploaders.Add(fileUploader);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fileUploader);
        }

        // GET: FileUploaders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileUploader fileUploader = db.FileUploaders.Find(id);
            if (fileUploader == null)
            {
                return HttpNotFound();
            }
            return View(fileUploader);
        }

        // POST: FileUploaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FileUploaderID")] FileUploader fileUploader)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fileUploader).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fileUploader);
        }

        // GET: FileUploaders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FileUploader fileUploader = db.FileUploaders.Find(id);
            if (fileUploader == null)
            {
                return HttpNotFound();
            }
            return View(fileUploader);
        }

        // POST: FileUploaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FileUploader fileUploader = db.FileUploaders.Find(id);
            db.FileUploaders.Remove(fileUploader);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
