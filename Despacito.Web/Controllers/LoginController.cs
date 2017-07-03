using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Despacito.Lib.Security;
using Despacito.Web.Extension;

namespace Despacito.Web.Controllers
{
    public class LoginController : BaseController
    {
        //
        // GET: /Login/

        public ActionResult LoginIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IndexPost(string account, string password)
        {
            Session["UserId"] = null;
            string msg = "";
            try
            {
                var vPwd = Md5Helper.MD5("111", 32);
                var pwd = Md5Helper.MD5(password, 32);
                if (string.IsNullOrEmpty(account))
                {
                    msg = "请输入用户名！";
                }
                else if (string.IsNullOrEmpty(password))
                {
                    msg = "请输入密码！";
                }
                else if (!account.Equals("tjty", StringComparison.CurrentCultureIgnoreCase))
                {
                    msg = "无此用户！";
                }
                else if (!pwd.Equals(vPwd, StringComparison.CurrentCultureIgnoreCase))
                {
                    msg = "密码不正确！";
                }
                else
                {
                    msg = "登录成功";
                    Session["UserId"] = account;
                    Session["FirstLogin"] = "1";
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);
                msg = ex.Message;
            }

            return Content(msg);
        }

    }
}
