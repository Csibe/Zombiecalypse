using System;
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
    public class RegistrationViewModelsController2 : Controller
    {
        private DataContext db = new DataContext();



        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "RegistrationViewModels");
        }


        public ActionResult newRegistration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult newRegistration([Bind(Include = "RegistrationViewModelID,RegistrationDate,UserID,UserName,UserEmail,Password,ConfirmPassword,CharacterID,CharacterName,CharacterType,MaxEnergy,CurrentEnergy,CharacterXP,CharacterLevel")] RegistrationViewModel registrationViewModel)
        {
            if (ModelState.IsValid)
            {
                db.RegistrationViewModels.Add(registrationViewModel);
                db.SaveChanges();
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
            using (DataContext dc = new DataContext())
            {
                var v = dc.RegistrationViewModels.Where(a => a.UserEmail == login.UserEmail).FirstOrDefault();
                if (v != null)
                {
                    if (string.Compare(login.Password, v.Password) == 0)
                    {
                        int timeout = 525600; // 525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.UserEmail, true, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
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

        /*

                [NonAction]
                public bool IsEmailExist(string emailID)
                {
                    using (DataContext db = new DataContext())
                    {
                        var v = db.Users.Where(a => a.UserEmail == emailID).FirstOrDefault();
                        return v != null;
                    }
                }
                */
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(RegistrationViewModel registrationViewModel)
        {

            //RegistrationViewModel registrationViewModel = new RegistrationViewModel();

            bool Status = false;
            string message = "";
            //
            // Model Validation 
            if (ModelState.IsValid)
            {

            /*    #region //Email is already Exist 
                var isExist = IsEmailExist(user.UserEmail);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(user);
                }
                #endregion
                */
            var registration = new RegistrationViewModel()
            {
                UserID = registrationViewModel.RegistrationViewModelID,
                CharacterID = registrationViewModel.RegistrationViewModelID,
                RegistrationDate = DateTime.Now
            };

            var user = new User()
            {
                UserID = registration.RegistrationViewModelID,
                UserName = registrationViewModel.UserName,
                UserEmail = registrationViewModel.UserEmail,
                UserPassword = registrationViewModel.Password

            };
            
                var character = new Character()
                {
                    CharacterID = registration.RegistrationViewModelID,
                    CharacterName = registrationViewModel.CharacterName,
                    CharacterType = registrationViewModel.CharacterType,
                    MaxEnergy = 10,
                    CurrentEnergy = 10,
                    CharacterXP = 0,
                    CharacterLevel = 1,
                    IsOnAdventure = false
                };

                db.RegistrationViewModels.Add(registration);
                db.Users.Add(user);
                db.Characters.Add(character);
                db.SaveChanges();
                return RedirectToAction("Login");
                }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;
            return RedirectToAction("Login");
        }





     /*   [HttpPost]
        public ActionResult Registration([Bind(Exclude = "IsEmailVerified,ActivationCode")] User user)
        {

            RegistrationViewModel registrationViewModel = new RegistrationViewModel();

            bool Status = false;
            string message = "";
            //
            // Model Validation 
            if (ModelState.IsValid)
            {


                var registration = new RegistrationViewModel()
            {
                UserID = registrationViewModel.RegistrationViewModelID,
                CharacterID = registrationViewModel.RegistrationViewModelID,
                RegistrationDate = DateTime.Now
            };

            var user = new User()
            {
                UserID = registration.RegistrationViewModelID,
                UserName = registrationViewModel.UserName,
                UserEmail = registrationViewModel.UserEmail,
                UserPassword = registrationViewModel.UserPassword

            };

            var character = new Character()
            {
                CharacterID = registration.RegistrationViewModelID,
                CharacterName = registrationViewModel.CharacterName,
                CharacterType = registrationViewModel.CharacterType,
                MaxEnergy = 10,
                CurrentEnergy = 10,
                CharacterXP = 0,
                CharacterLevel = 1,
                IsOnAdventure = false
    };



                db.RegistrationViewModels.Add(registration);
                db.Users.Add(user);
                db.Characters.Add(character);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    */

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
