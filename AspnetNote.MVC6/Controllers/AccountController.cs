﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetNote.MVC6.DataContext;
using AspnetNote.MVC6.Models;
using AspnetNote.MVC6.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
                        return RedirectToAction("LoginSuccess", "Home");    //로그인 성공 페이지로 이동   
                    }
                }
                // 로그인 실패
                ModelState.AddModelError(string.Empty, "사용자 ID 혹인 비밀번호가 올바르지 않습니다.");
            }
            return View(model);
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