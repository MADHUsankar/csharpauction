using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
using csharpbelt.Models;
using System.Collections.Generic;
using System.Linq;
 using System.Threading.Tasks;

namespace csharpbelt.Controllers
{
    public class UserController : Controller
    {
          private auctionContext _context;
         
        public UserController(auctionContext context) {
            _context = context;
        }
[HttpGet]
 
[Route("")]
        public IActionResult Index()
        {return View("Register");}

[HttpPost]
[Route("processuser")]
public IActionResult processuser(RegisterViewModel user)
{
     if(ModelState.IsValid)
     {
           
        List<Userrecord> existinguser = _context.user.Where(u=>u.Username==user.Username).ToList();
        if (existinguser.Count == 0)
        {
             Userrecord newUser = new Userrecord {FirstName = user.FirstName, LastName= user.LastName, Username = user.Username, };
            //  newUser.Password = Hasher.HashPassword(newUser, user.Password);
            newUser.Password =  user.Password;
            _context.Add(newUser);
            _context.SaveChanges();        
            Userrecord logUser = _context.user.SingleOrDefault(u => u.Username == user.Username);
            HttpContext.Session.SetInt32("UserId", logUser.UserId);
            System.Console.WriteLine("here");
            return RedirectToAction("Home","Auction");
        }
        else
        {
            ViewBag.status="regfailspecific";
            ViewBag.regerror = "User already exists";
            return View("Register");
        }

    }
    else{
        ViewBag.errors = ModelState.Values;
        ViewBag.status="regfail";
        return View("Register");

    }
}

[HttpPost]
[Route("processlogin")]
public IActionResult processlogin(string Username,string Password)
{
    Userrecord existingloginuser = _context.user.SingleOrDefault(user => user.Username == Username);
         
if (existingloginuser == null)
            {
                ViewBag.status="loginfailspecific";
                ViewBag.loginerror = "Please register!";
                return View("Register");
            }   
    else    
        {
            if(Password != null)
            {
            // var Hasher = new PasswordHasher<User>();
            // if(0 != Hasher.VerifyHashedPassword(existingloginuser, existingloginuser.Password, Password)){
            if(existingloginuser.Password==Password){
                HttpContext.Session.SetInt32("UserId",(int)existingloginuser.UserId);
                HttpContext.Session.SetString("username", (string)existingloginuser.FirstName);
                return RedirectToAction("Home","Auction");
                }
            else{
                        ViewBag.status="loginfailspecific";
                        ViewBag.loginerror = "Invalid Credentials!";
                    return View("Register");
                    }
            }
            else{
                ViewBag.status="loginfailspecific";
                        ViewBag.loginerror = "Provide password!";
                    return View("Register");
            }

        
    }
}

[HttpGet]
[Route("logout")]
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");}
                // return View("Register");}

}
}
