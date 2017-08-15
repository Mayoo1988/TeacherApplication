using Education.Core.Admin;
using Education.Entity.Admin;
using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Education.WebApp.Areas.Admin.Controllers
{
    public class TestDetailController : Controller
    {
        ITestDetailsRepository _ITestDetailsRepository;

        public TestDetailController(ITestDetailsRepository TestDetailsRepository)
        {

            this._ITestDetailsRepository= TestDetailsRepository;
        }
        // GET: Admin/TestDetail
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HttpPostedFileBase uploadfile,TestDetails testdetails)
        {
            if (ModelState.IsValid)
            {
                if (uploadfile != null && uploadfile.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/Content/TestSheets"),
                    Path.GetFileName(uploadfile.FileName));
                    uploadfile.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                    //ExcelDataReader works on binary excel file
                    Stream stream = uploadfile.InputStream;
                    //We need to written the Interface.
                    IExcelDataReader reader = null;
                    if (uploadfile.FileName.EndsWith(".xls"))
                    {
                        //reads the excel file with .xls extension
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (uploadfile.FileName.EndsWith(".xlsx"))
                    {
                        //reads excel file with .xlsx extension
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else
                    {
                        //Shows error if uploaded file is not Excel file
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }
                    //treats the first row of excel file as Coluymn Names
                    reader.IsFirstRowAsColumnNames = true;
                    //Adding reader data to DataSet()
                    DataSet result = reader.AsDataSet();
                    reader.Close();
                    TestDetails TEST = new TestDetails();
                    TEST.TITLE = testdetails.TITLE;
                    TEST.SUBJECTID = testdetails.SUBJECTID;
                    TEST.PUBLISHDATE = testdetails.PUBLISHDATE;
                    TEST.GIVENBY = testdetails.GIVENBY;
                    _ITestDetailsRepository.CreateTestDetails(result, testdetails);
                    //Sending result data to View
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("File", "Please upload your file");
            }
            return View();
        }

    }
}