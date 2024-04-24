using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Claims;
using WebApplication1.Data;
using WebApplication1.Help;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        private readonly MyDatabaseContext db;
        private readonly IMapper _mapper;

        public CustomerController(MyDatabaseContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var customer = _mapper.Map<Customer>(model);
                    customer.RandomKey = Util.GenerateRandomKey();
                    customer.Password = model.Password.ToMd5Hash(customer.RandomKey);
                    db.Add(customer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    var mess = $"{ex.Message} shh";
                }
            }
            return View();
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model, string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;

            if (ModelState.IsValid)
            {
                var customer = db.Customers.SingleOrDefault(kh => kh.PhoneNumber == model.PhoneNumber);
                if (false)
                {
                    ModelState.AddModelError("ERROR", "Not Found This Account");
                }
                else
                {
                    //.ToMd5Hash(customer.RandomKey)
                    if (model.Password != "1234")
                    {
                        ModelState.AddModelError("ERROR", "Wrong Password, Please try again");
                    }
                    else
                    {
                        var claims = new List<Claim>
                        {
                             new Claim(ClaimTypes.Email, customer.Email),
                            //new Claim("CustomerID", customer.CustomerId),
                            //new Claim(ClaimTypes.Email, customer.Email),


                            // claim -  role dong

                            new Claim(ClaimTypes.Role, "Customer"),
                        };

                        var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimPrincipal = new ClaimsPrincipal(claimIdentity);
                        await HttpContext.SignInAsync(claimPrincipal);
                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return Redirect("/");
                        }
                    }
                }
            }
            return View();
        }
        #endregion

        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
