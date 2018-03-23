﻿using System;
using System.Activities.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Zombiecalypse.DAL;
using Zombiecalypse.Models;
using Zombiecalypse.ViewModels;

namespace Zombiecalypse.Controllers
{
    public class RegistrationViewModelsController : Controller
    {
        private DataContext db = new DataContext();


        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Include = "RegistrationViewModelID,RegistrationDate,UserID,UserName,UserEmail,Password,ConfirmPassword,CharacterID,CharacterName,CharacterType,MaxEnergy,CurrentEnergy,CharacterXP,CharacterLevel")] RegistrationViewModel registrationViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var RegID = registrationViewModel.RegistrationViewModelID;
                    RegID++;
                    var registration = new RegistrationViewModel()
                    {
                        RegistrationDate = DateTime.Now,
                        UserID = RegID,
                        CharacterID = RegID,
                        CharacterName = registrationViewModel.CharacterName,
                        CharacterLevel = 1,
                        CharacterType = registrationViewModel.CharacterType,
                        Password = registrationViewModel.Password,
                        ConfirmPassword = registrationViewModel.ConfirmPassword,
                        UserEmail = registrationViewModel.UserEmail,
                        UserName = registrationViewModel.UserName

                    };

                    var user = new User()
                    {
                        UserEmail = registrationViewModel.UserEmail,
                        UserName = registrationViewModel.UserName,
                        UserPassword = registrationViewModel.Password,

                    };
                    
                    var character = new Character()
                    {
                        CharacterLevel = 1,
                        CharacterName = registrationViewModel.CharacterName,
                        CharacterType = registrationViewModel.CharacterType,
                        CharacterXP = 0,
                        CurrentEnergy = 10,
                        MaxEnergy = 10,
                        FinishAdventure = DateTime.MaxValue,
                        IsOnAdventure = false

                    };




                    db.RegistrationViewModels.Add(registration);
                    db.Users.Add(user);
                    db.Characters.Add(character);
                    db.SaveChanges();

                }

                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }


                return RedirectToAction("Index");
            }

            return View(registrationViewModel);
        }



        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(RegistrationViewModel login, string ReturnUrl = "")
        {
            string message = "";
            using (DataContext db = new DataContext())
            {
                var v = db.RegistrationViewModels.Where(a => a.UserEmail == login.UserEmail).FirstOrDefault();
                if (v != null)
                {
                    if (string.Compare(login.Password, v.Password) == 0)
                    {
                        int timeout = 525600; // 525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.UserEmail, true, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        Session["id"] = v.CharacterID;
                        Session["UserName"] = v.UserName;
                        Session["CharacterName"] = v.CharacterName;
                        Session["UserEmail"] = v.UserEmail;
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);
                        

                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        message = "Invalid credential provided";
                    }
                }
                else
                {
                    message = "Invalid credential provided";
                }
            }
            ViewBag.Message = message;
            return View();
        }


        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Remove("id");
            Session.Remove("UserName");
            Session.Remove("CharacterName");
            Session.Remove("UserEmail");
            return RedirectToAction("Login", "RegistrationViewModels");
        }

        // GET: RegistrationViewModels
        public ActionResult Index()
        {
            return View(db.RegistrationViewModels.ToList());
        }

        // GET: RegistrationViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationViewModel registrationViewModel = db.RegistrationViewModels.Find(id);
            if (registrationViewModel == null)
            {
                return HttpNotFound();
            }
            return View(registrationViewModel);
        }

        // GET: RegistrationViewModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistrationViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegistrationViewModelID,UserID,UserName,UserEmail,UserPassword,CharacterName,CharacterType")] RegistrationViewModel registrationViewModel)
        {
            if (ModelState.IsValid)
            {
                db.RegistrationViewModels.Add(registrationViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registrationViewModel);
        }

        // GET: RegistrationViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationViewModel registrationViewModel = db.RegistrationViewModels.Find(id);
            if (registrationViewModel == null)
            {
                return HttpNotFound();
            }
            return View(registrationViewModel);
        }

        // POST: RegistrationViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegistrationViewModelID,UserID,UserName,UserEmail,UserPassword,CharacterName,CharacterType")] RegistrationViewModel registrationViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registrationViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registrationViewModel);
        }

        // GET: RegistrationViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistrationViewModel registrationViewModel = db.RegistrationViewModels.Find(id);
            if (registrationViewModel == null)
            {
                return HttpNotFound();
            }
            return View(registrationViewModel);
        }

        // POST: RegistrationViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistrationViewModel registrationViewModel = db.RegistrationViewModels.Find(id);
            db.RegistrationViewModels.Remove(registrationViewModel);
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
