using DatabaseCommunicator;
using Woodstore.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DatabaseCommunicator.Classes;

namespace Woodstore.Controllers
{
    public class AccountController : Controller
    {
        #region Public Methods

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {           
            if (ModelState.IsValid)
            {
                // TODO checks for Nr , zipcode , bank ....
                Country country = new Country(model.Country);
                City city = new City(model.City, Convert.ToInt32(model.Zipcode), country);
                Address address = new Address(model.Street, model.Number, model.Box, city);

                try
                {
                    string confirmationToken = (Guid.NewGuid().ToString()).Replace("-", "");

                    Account account = new Account(model.Firstname, model.Lastname, address, model.Phone, model.BankAccountNumber, model.Username, model.Password, model.Email, false, confirmationToken);
                    // split up username check and email
                    if (!DataBaseHandler.UsernameExist(account) || !DataBaseHandler.EmailExist(model.Email))
                    {
                        DataBaseHandler.InsertAccount(account);
                        string callbackUrl = Url.Action("RegisterConfirmation", "Account", new { Id = confirmationToken }, protocol: Request.Url.Scheme);
                        string body = @"<h4>Welcome , </h4><p></p><p>To get started, please click <a href=""" + callbackUrl + @""">here</a> to activate your account.</p>";

                        try
                        {
                            Mailer.Mail(model.Email, "Email Confirmation", string.Format(body), null, "Sincerely yours");
                            return View("ConfirmEmail");
                        }
                        catch { return View("ConfirmEmailError"); }
                    }
                    else { return View("EmailExist"); }
                }
                catch(Exception e){ int i = 0; return View(); }
            }
            else { return View(); }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult RegisterConfirmation(string id)
        {
            if (id != null && id != string.Empty)
            {
                if (DataBaseHandler.ConfirmAccount(id))
                {
                    return RedirectToAction("Login", "Account");
                }
                else { return View("ConfirmEmailError"); }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {            
            //var username = Request.Form["username"];
            //var password = Request.Form["password"];
            var remember = Request.Form["checkbox"];
            if (model.Username != string.Empty && model.Password != string.Empty)
            {
                Account account = new Account(model.Username, model.Password);

                if (DataBaseHandler.UsernameExist(account))
                { account = DataBaseHandler.GetAccount(account); }
                else { return View("AccountDoesNotExist"); }

                Session["accountID"] = account.AccountID;
                FormsAuthentication.SetAuthCookie(model.Username, true);
                if (remember != null && remember.Equals("checked"))
                {
                    Response.Cookies["username"].Value = model.Username;
                    Response.Cookies["username"].Expires = DateTime.MaxValue;
                    Response.Cookies["password"].Value = model.Password;
                    Response.Cookies["password"].Expires = DateTime.MaxValue;
                }
                return RedirectToAction("Index", "Home");
            }
            return View();      
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Logout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            if (Request.Cookies["username"] != null)
            {
                HttpCookie user = new HttpCookie("username")
                {
                    Expires = DateTime.Now.AddDays(-1),
                    Value = null
                };
                HttpCookie pass = new HttpCookie("password")
                {
                    Expires = DateTime.Now.AddDays(-1),
                    Value = null
                };
                Response.Cookies.Remove("username");
                Response.Cookies.Remove("password");
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult LostPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult LostPassword(LostPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                Account user = DataBaseHandler.GetAccountByEmail(model.Email);

                if (user != null)
                {
                    string passwordToken = (Guid.NewGuid().ToString()).Replace("-", "");
                    DataBaseHandler.InsertToken(passwordToken, user.AccountID);

                    string callbackUrl = Url.Action("ResetPassword", "Account", new { Id = passwordToken }, protocol: Request.Url.Scheme);
                    string body = @"<h4>Request for resetting your password accepted.</h4><p></p><p>To reset password please click <a href=""" + callbackUrl + @""">here</a>.</p>";

                    try
                    {
                        Mailer.Mail(model.Email, "Lost Password", string.Format(body), null, "Sincerely yours");
                        return RedirectToAction("Login", "Account");
                    }
                    catch { return View("ConfirmEmailError"); }
                }
                else { return View("AccountDoesNotExist"); }
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult AccountPage()
        {
            if (Session["accountID"] != null)
            {
                AccountPageModel apm = new AccountPageModel(Convert.ToInt32(Session["accountID"]));
                return View(apm);
            }
            else { return RedirectToAction("Login", "Account"); }
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult ResetPassword(string Id)
        {
            ResetPasswordModel model = new ResetPasswordModel();
            model.PasswordToken = Id;
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            if (DataBaseHandler.ChangePassword(model.PasswordToken, model.Password))
            {
                return RedirectToAction("Login", "Account");
            }
            return View("PasswordResetError");
        }

        #endregion Public Methods
    }
}