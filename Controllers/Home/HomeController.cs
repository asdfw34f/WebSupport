﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Redmine.Net.Api.Types;
using RedmineLibrary.Servieces;
using System.Collections.Generic;
using System.Diagnostics;
using WebSupport.Controllers.Authentication;
using WebSupport.Models;
using System.Linq;
namespace WebSupport.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;


        public HomeController(ILogger<AuthenticationController> logger)
        {
            _logger = logger;
        }

        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string project, string tracker, string subject, string description)
        {
            if (string.IsNullOrEmpty(project)|| string.IsNullOrEmpty(tracker)) 
            {
                ViewBag.CreateResult = "Заполните все поля";
                return View("Index");
            }
            else
            {
                Manager.CreateIssue(project, tracker, subject, description);
                ViewBag.CreateResult = "Задание создано";
                return View("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}