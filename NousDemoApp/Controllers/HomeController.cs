using NousDemoApp.Models;
using NousDemoApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NousDemoApp.Controllers
{
    public class HomeController : Controller
    {
        UploadImage uploadImage = new UploadImage();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Upload(HttpPostedFileBase photo)
        {
            var imageUrl = await uploadImage.UploadImageAsync(photo);
            HttpClient awaitclient = new HttpClient();
            var uploadInfo = new ImageUploadInfo() { ImageNo = 1, ImageName = imageUrl };

            HttpResponseMessage response = await awaitclient.PostAsJsonAsync("http://nousdemo-staging.azurewebsites.net/api/ImageUploadInfoes", uploadInfo);
            TempData["LatestImage"] = imageUrl.ToString();
            return RedirectToAction("LatestImage");
        }

        public ActionResult LatestImage()
        {
            var latestImage = string.Empty;
            if (TempData["LatestImage"] != null)
            {
                ViewBag.LatestImage = Convert.ToString(TempData["LatestImage"]);
            }

            return View();
        }
    }
}

