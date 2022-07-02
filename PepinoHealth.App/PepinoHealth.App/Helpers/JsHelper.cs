using PepinoHealth.CL.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace PepinoHealth.App.Helpers
{
    #region Business Methods

    public class JsHelper : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string[] filePaths = null;

            string
                localPath = Helper.GetRelativePath(context.Request.Url.LocalPath),
                fileName = context.Server.MapPath(localPath);

            StringBuilder stringBuilder = new StringBuilder();

            if (fileName.Contains(Helper.Master))
            {
                filePaths = File.ReadAllLines(fileName);

                filePaths.ToList().ForEach(filePath =>
                {
                    fileName = context.Server.MapPath(filePath);
                    stringBuilder.Append(File.ReadAllText(fileName));
                });
            }
            else
            {
                stringBuilder.Append(File.ReadAllText(fileName));
            }

            context.Response.ContentType = "text/javascript";
            context.Response.Write(stringBuilder.ToString());

#if !DEBUG
            context.Response.AddHeader("Last-Modified", DateTime.Now.ToUniversalTime().ToString("R"));
            context.Response.Cache.SetCacheability(HttpCacheability.Public);
            context.Response.Cache.SetExpires(DateTime.Now.AddSeconds(Helper.PageCacheTimeOut));
#endif

        }

        public bool IsReusable
        {
            get { return false; }
        }
    }

    #endregion
}