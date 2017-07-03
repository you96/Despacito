using Despacito.Lib;
using System.Text;
using System.Web.Mvc;

namespace Despacito.Web.Extension
{
    public class BaseController : Controller
    {

        [LoginAuthorize]
        public ActionResult Index()
        {
            if (Session["FirstLogin"].ToString() == "1")
            {
                ViewBag.ServiceUrl = "";
                ServiceUrl = "";
                PubUrl = "";
            }
            else
                ViewBag.ServiceUrl = ServiceUrl;
            return View();
        }
        //公用的webservice地址
        protected static string PubUrl;
        protected static string ServiceUrl;
        //
        protected bool IsLogin;
        //
        public readonly int BasePageSize = 20;
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding,
            JsonRequestBehavior behavior)
        {
            return new JsonNetResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior
            };
        }

        /// <summary>
        /// 返回信息
        /// </summary>
        /// <param name="isSuccess">是否成功</param>
        /// <param name="code">编号</param>
        /// <param name="message">内容</param>
        /// <returns></returns>
        public ContentResult Result(bool isSuccess, string code, string message)
        {
            return Content(new JsonMessage { Success = isSuccess, Code = code, Message = message }.ToString());
        }

        public JsonResult JsonResult(bool isSuccess, string code, string message)
        {
            var jsonMessage = new JsonMessage {Success = isSuccess, Code = code, Message = message};
            return Json(jsonMessage, JsonRequestBehavior.AllowGet);
        }
        public void ExportExcel(string excelTable, string fileName)
        {

            byte[] fileContents = Encoding.UTF8.GetBytes(excelTable);
            string fileFolder = Server.MapPath("../Export/");
            if (!System.IO.Directory.Exists(fileFolder))
            {
                System.IO.Directory.CreateDirectory(fileFolder);
            }
            string filePath = Server.MapPath("../Export/" + fileName);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            System.IO.File.WriteAllBytes(filePath, fileContents);
        }
    }

}