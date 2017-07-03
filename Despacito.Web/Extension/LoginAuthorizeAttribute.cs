using System;
using System.Web;
using System.Web.Mvc;

namespace Despacito.Web.Extension
{

    public class LoginAuthorizeAttribute : AuthorizeAttribute //继承mvc自带的AuthorizeAttribute 
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = filterContext.HttpContext.Session["UserId"];
            if (user==null)//未登录情况
            {
                string gateUrl = GetWebRootPath()+"/Login/LoginIndex";
                filterContext.HttpContext.Response.Write("<script type='text/javascript'>if(window.confirm('登录超时重新登录')){top.location='" + gateUrl + "'; }else{top.location='" + gateUrl + "';}</script>");
                filterContext.Result = new ContentResult();
            }

        }
        public string GetWebRootPath()
        {
            string AppPath = "";
            HttpContext HttpCurrent = HttpContext.Current;
            HttpRequest Req;
            if (HttpCurrent != null)
            {
                Req = HttpCurrent.Request;

                string UrlAuthority = Req.Url.GetLeftPart(UriPartial.Authority);
                if (Req.ApplicationPath == null || Req.ApplicationPath == "/")
                    //直接安装在   Web   站点     
                    AppPath = UrlAuthority;
                else
                    //安装在虚拟子目录下     
                    AppPath = UrlAuthority + Req.ApplicationPath;
            }
            return AppPath;
        }
    }

}