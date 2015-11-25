using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using System.Text;

namespace webs_YueyxShop.Web.uploadify.scripts
{
    /// <summary>
    /// uploadify 的摘要说明
    /// </summary>
    public class uploadify : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.Charset = "utf-8";
            string fileFullName = string.Empty;
            string uploadPath = string.Empty;
            string fileContain = string.Empty;

            try
            {  
                ///控件名称
                string controlName = context.Request["controlName"];

                HttpPostedFile postedFile = context.Request.Files[controlName];
                uploadPath = context.Request.PhysicalApplicationPath + context.Request["folder"];

                if (postedFile != null)
                {
                    StringBuilder fileName = new StringBuilder(DateTime.Now.ToString("yyyyMMddHHmmss") + new DateTime().Millisecond.ToString() + Path.GetFileName(postedFile.FileName)); //清除中文
                    string oldname = postedFile.FileName;

                    fileFullName = uploadPath + fileName;

                    fileContain = Path.GetExtension(postedFile.FileName).ToLower();
                    if (fileFullName != "")
                    {
                        if (!Directory.Exists(uploadPath))
                        {
                            Directory.CreateDirectory(uploadPath);
                        }
                    }
                    postedFile.SaveAs(fileFullName);


                    //下面这句代码缺少的话，上传成功后上传队列的显示不会自动消失
                    //返回网络路径

                    context.Response.Write(context.Request["folder"] + fileName);
                }
                else
                {
                    context.Response.Write("false");//验证失败
                }
            }
            catch (Exception ex)
            {
                context.Response.Write("false");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}