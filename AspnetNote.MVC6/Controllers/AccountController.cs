using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AspnetNote.MVC6.Models;
using AspnetNote.MVC6.DataContext;
using AspnetNote.MVC6.ViewModels;
using Microsoft.AspNetCore.Http;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspnetNote.MVC6.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModelView model)
        {
            // ID, 비밀번호 - 필수
            if (ModelState.IsValid)
            {
                using (var db = new AspnetNoteDbContext())
                {
                    // Linq - 메서드 체이닝
                    // => : A Go to B
                    //var user = db.Users.FirstOrDefault(u => u.UserID == model.UserID && u.UserPassword == model.UserPassword);
                    var user = db.Users.FirstOrDefault(u => u.UserID.Equals(model.UserID)
                                                         && u.UserPassword.Equals(model.UserPassword));

                    if (user != null)
                    {
                        // 로그인 성공
                        //HttpContext.Session.SetInt32(key, value);
                        //HttpContext.Session.SetInt32("LOGIN_KEY", user.UserNo);
                        HttpContext.Session.SetString("Name", "shson");
                        //return RedirectToAction("LoginSuccess", "Home");    //로그인 성공 페이지로 이동   
                        var name = HttpContext.Session.GetString("Name");
                        if (name == "shson")
                        {
                            return RedirectToAction("Register", "Account");    //로그인 성공 페이지로 이동
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");    //로그인 성공 페이지로 이동
                        }
                        
                    }
                }
                // 로그인 실패
                ModelState.AddModelError(string.Empty, "사용자 ID 혹인 비밀번호가 올바르지 않습니다.");
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            // 모든 세션 삭제
            //HttpContext.Session.Clear();

            // 세션 삭제
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 회원가입
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 회원 가입 전송
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(User Model)
        {
            if (ModelState.IsValid)
            {
                // C#
                using (var db = new AspnetNoteDbContext())
                {
                    db.Users.Add(Model);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            return View(Model);
        }
    }
}
