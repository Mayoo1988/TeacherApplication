using Education.Core.Admin;
using Education.Entity.Admin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.WebApp.Areas.Admin.Controllers
{
    public class VideoUploadController : Controller
    {
        IVideoUpload _VideoUpload;

        public VideoUploadController(IVideoUpload VideoUploaddetails)
        {
            this._VideoUpload = VideoUploaddetails;
        }
        public ActionResult Index()
        {
            // return View();
            return View(GetFiles());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile, VideoUploaddetails objvideo)
        {
            if (ModelState.IsValid)
            {
                if (postedFile != null && postedFile.ContentLength > 0)
                    try
                    {
                        string path = Path.Combine(Server.MapPath("~/Content/files"),
                        Path.GetFileName(postedFile.FileName));
                        postedFile.SaveAs(path);
                        ViewBag.Message = "File uploaded successfully";
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                else
                {
                    ViewBag.Message = "You have not specified a file.";
                }

                VideoUploaddetails objvideoupload = new VideoUploaddetails();
                objvideoupload.DIGITALDOCTYPEID = 1;
                objvideoupload.DOCUMENTNAME = Path.GetFileName(postedFile.FileName);
                objvideoupload = _VideoUpload.CreateVideoDetails(objvideoupload);

            }

            return View(GetFiles());





            //return View(GetFiles());
        }

        [HttpGet]
        public FileResult DownloadFile(int? DIGITALDOCTYPEID)
        {
            byte[] bytes;
            string fileName, contentType;
            List<VideoUploaddetails> objvideoupload = new List<VideoUploaddetails>();
            objvideoupload = _VideoUpload.GetFileName(Convert.ToInt32(DIGITALDOCTYPEID));
            fileName = objvideoupload.SingleOrDefault().DOCUMENTNAME;
            //foreach (var item in objvideoupload)
            //{
            //    fileName = item.DOCUMENTNAME;
            //}

           

            string path = Path.Combine(Server.MapPath("~/Content/files"), fileName);

            bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "video/mp4", fileName);
        }

        public List<VideoUploaddetails> GetFiles()
        {
            List<VideoUploaddetails> objvideoupload = new List<VideoUploaddetails>();
            objvideoupload = _VideoUpload.GetVideoUploaddetails();
            return objvideoupload;
        }
    }
}