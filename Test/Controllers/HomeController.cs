using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Services.Data;
using Core.Services.Rest;
using Microsoft.AspNetCore.Mvc;
using Test.Helpers;
using Test.Models;
using Test.Resources;

namespace Test.Controllers
{
    public class HomeController : Controller
    {
        private IFileservice _fileService;
        private ICloudinaryService _cloudinary;
        private IEmailService _emailService;
        public HomeController(IFileservice fileservice,ICloudinaryService cloudinaryService,IEmailService emailService)
        {
            _fileService = fileservice;
            _cloudinary = cloudinaryService;
            _emailService = emailService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(FileDTO file)
        {
            string path = FileManager.IFormSave(file.File,"temp");
            string id = _cloudinary.Store(path);

            File newFile = new File
            {
                FilePath = id,
                FileName = file.File.Name
            };
            _fileService.Create(newFile);
            object data = new
            {
                senderEmail = file.From,
                fileCount = "1",
                fileSize = file.File.Length / 1000000,
                date = DateTime.UtcNow.ToString("dd-MM-yyyy"),
                message = file.Message
            };
            _emailService.Send(file.To, "SenderMan", "d-489e8c077adb4797be48273d349760cf", data);

            return RedirectToAction("index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
