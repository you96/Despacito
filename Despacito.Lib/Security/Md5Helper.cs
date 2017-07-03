namespace Despacito.Lib.Security
{
    /// <summary>
    /// MD5加密帮助类
    /// </summary>
    public class Md5Helper
    {
        #region "MD5加密"
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">加密字符</param>
        /// <param name="code">加密位数16/32</param>
        /// <returns></returns>
        public static string MD5(string str, int code)
        {
            string strEncrypt = string.Empty;
            if (code == 16)
            {
                strEncrypt = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").Substring(8, 16);
            }

            if (code == 32)
            {
                strEncrypt = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
            }

            return strEncrypt;
        }


        public static string MD5(string str)
        {
            string strEncrypt = string.Empty;
            strEncrypt =
                System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(
                    "@#%$AF@#%$ASDFC" + str + "^&(WDC!@R%", "MD5").ToLower();
            return strEncrypt;
        }



        #endregion
    }
}
