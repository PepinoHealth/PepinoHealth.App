using dotless.Core;
using dotless.Core.configuration;
using dotless.Core.Input;
using PepinoHealth.CL.Common;
using System.IO;
using System.Web;
using System.Web.Hosting;
using System.Web.SessionState;

namespace PepinoHealth.App.Helpers
{
    #region Business Methods

    public class LessHelper : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string
                localPath = Helper.GetRelativePath(context.Request.Url.LocalPath),
                fileName = context.Server.MapPath(localPath),
                fileContent = File.ReadAllText(fileName);

            DotlessConfiguration dotlessConfiguration = new DotlessConfiguration()
            {
                DisableVariableRedefines = true,
                MinifyOutput = true,
                CacheEnabled = true,
                LessSource = typeof(VirtualFileReader)
            };

            context.Response.ContentType = "text/css";
            context.Response.Write(LessWeb.Parse(fileContent, dotlessConfiguration));

#if !DEBUG
            context.Response.AddHeader("Last-Modified", DateTime.Now.ToUniversalTime().ToString("R"));
            context.Response.Cache.SetCacheability(HttpCacheability.Public);
            context.Response.Cache.SetExpires(DateTime.Now.AddSeconds(Utility.PageCacheTimeOut));
#endif

        }

        public bool IsReusable
        {
            get { return false; }
        }
    }

    #endregion

    #region Common Methods

    internal sealed class VirtualFileReader : IFileReader
    {
        public byte[] GetBinaryFileContents(string fileName)
        {
            fileName = GetFullPath(fileName);
            return File.ReadAllBytes(fileName);
        }

        public string GetFileContents(string fileName)
        {
            fileName = GetFullPath(fileName);
            return File.ReadAllText(fileName);
        }

        public bool DoesFileExist(string fileName)
        {
            fileName = GetFullPath(fileName);
            return File.Exists(fileName);
        }

        private static string GetFullPath(string path)
        {
            return HostingEnvironment.MapPath("~/Content/" + path.Replace("../", string.Empty));
        }

        public bool UseCacheDependencies
        {
            get { return false; }
        }
    }

    #endregion
}