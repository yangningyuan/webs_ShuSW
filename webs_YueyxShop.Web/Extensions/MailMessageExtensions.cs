using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace webs_YueyxShop.Web
{
    /// <summary>
    /// 邮件发送扩展类
    /// </summary>
    public class MailMessageExtensions
    {
        # region 创建邮件

        /// <summary>
        /// 创建收件人
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<MailAddress> CreateToAddress(string toAddress)
        {
            List<MailAddress> list = new List<MailAddress>();

            string[] mailNames = (toAddress + ";").Split(';');
            foreach (string name in mailNames)
            {
                if (name != string.Empty)
                {
                    //设置邮件的收件人
                    string address = "";
                    string displayName = "";
                    if (name.IndexOf('<') > 0)
                    {
                        //显示名
                        displayName = name.Substring(0, name.IndexOf('<'));
                        //地址
                        address = name.Substring(name.IndexOf('<') + 1).Replace('>', ' ');
                    }
                    else
                    {
                        displayName = string.Empty;
                        address = name.Substring(name.IndexOf('<') + 1).Replace('>', ' ');
                    }
                    list.Add(new MailAddress(address, displayName));
                }
            }

            return list;
        }

        /// <summary>
        /// 创建邮件
        /// </summary>
        /// <returns></returns>
        private static MailMessage CreateMail(string subject, string body, string fromAddress, string toAddress)
        {
            MailMessage mail = new MailMessage();
            try
            {
                //主题
                mail.Subject = subject;
                //内容是否是Html格式
                mail.IsBodyHtml = true;
                //内容的编码格式
                mail.SubjectEncoding = mail.BodyEncoding = Encoding.UTF8;
                //邮件内容
                mail.Body = ReplaceImgToAttachments(body, mail);
                //发送通知
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
                //设置邮件的发送级别
                mail.Priority = MailPriority.Normal;
                //发件人显示名
                mail.From = new MailAddress(fromAddress, ConfigurationManager.AppSettings["mailShowName"]); //可添加显示名

                //收件人(多人)
                foreach (var aim in CreateToAddress(toAddress))
                {
                    mail.To.Add(aim);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return mail;
        }

        /// <summary>
        /// 创建身份验证方案
        /// </summary>
        /// <returns></returns>
        private static NetworkCredential CreateNetworkCredential(string fromAddress, string fromPwd)
        {
            NetworkCredential nc = new NetworkCredential();
            nc.UserName = fromAddress;
            nc.Password = fromPwd;

            return nc;
        }

        # endregion

        # region 发送邮件

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="subject">邮件主题</param>
        /// <param name="body">邮件内容</param>
        /// <param name="fromAddress">发送邮箱</param>
        /// <param name="toAddress">收件人</param>
        /// <param name="fromPwd">发送邮箱密码</param>
        /// <returns>成功返回true</returns>
        public static bool SendMail(string subject, string body, string fromAddress, string toAddress, string fromPwd)
        {
            MailMessage mail = CreateMail(subject, body, fromAddress, toAddress);

            NetworkCredential nc = CreateNetworkCredential(fromAddress, fromPwd);

            return SendMessage(mail, nc);
        }

        /// <summary>
        /// 获取SMTP服务器地址
        /// </summary>
        /// <param name="fromAddress">发送邮件账户</param>
        /// <returns>返回地址</returns>
        private static string GetSmtpServer(string fromAddress)
        {
            //默认QQ
            string server = "smtp.qq.com";

            string rel = fromAddress.Substring(fromAddress.IndexOf('@') + 1);
            rel = rel.Substring(0, rel.IndexOf('.'));
            if (!string.IsNullOrWhiteSpace(rel))
            {
                server = "smtp." + rel + ".com";
            }

            return server;
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mail">邮件</param>
        /// <param name="nc">身份验证</param>
        /// <returns></returns>
        private static bool SendMessage(MailMessage mail, NetworkCredential nc)
        {
            try
            {
                SmtpClient sc = new SmtpClient();

                sc.UseDefaultCredentials = true;
                //电子邮件通过网络发送到SMTP服务器
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                //身份验证方案
                sc.Credentials = nc;
                //如果这里报mail from address must be same as authorization user这个错误，是你的QQ邮箱没有开启SMTP，
                //到你自己的邮箱设置一下就可以啦！在帐户下面,如果是163邮箱的话，下面该成smtp.163.com
                sc.Host = GetSmtpServer(nc.UserName);

                sc.Send(mail);
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        # endregion

        # region 扩展

        # region Base64

        /// <summary>
        /// 将图片转换成base64编码的字符串
        /// </summary>
        /// <param name="fileName">图片路径</param>
        /// <returns>转换结果</returns>
        private static string ImgToBase64String(string fileName)
        {
            string fullPath = System.Web.HttpContext.Current.Server.MapPath("~/" + fileName);

            Bitmap bmp = new Bitmap(fullPath);

            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] arr = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(arr, 0, (int)ms.Length);
            ms.Close();

            return Convert.ToBase64String(arr);
        }

        /// <summary>
        /// 将字符串中的图片么地址转换为Base64编码
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        private static string ReplaceImgToBase64(string body)
        {
            var listSrc = SelectImgSrc(body);

            foreach (var src in listSrc)
            {
                string imgBase64String = ImgToBase64String(src);

                body = body.Replace(src, "data:image/png;base64, " + imgBase64String);
            }

            return body;
        }

        # endregion

        # region Attachments

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        private static string ReplaceImgToAttachments(string body, MailMessage mail)
        {
            var listSrc = SelectImgSrc(body);
            int count = listSrc.Count;
            for (int i = 0; i < count; i++)
            {
                string file = listSrc[i];
                //文件名
                string name = file.Substring(file.LastIndexOf('/'));
                //文件绝对路径
                string fullPath = System.Web.HttpContext.Current.Server.MapPath("~/" + file);
                mail.Attachments.Add(new Attachment(fullPath, MediaTypeNames.Application.Octet));
                //mail.Attachments[i].ContentId = name;
                //mail.Attachments[i].ContentDisposition.Inline = true;
                //mail.Attachments[i].NameEncoding = Encoding.UTF8;
                //body = body.Replace(file, "cid:" + name);
                body = body.Replace(file, "cid:" + mail.Attachments[i].ContentId);
            }
            body = "<BODY style=\"MARGIN: 10px\"><DIV>" + body + "</DIV><DIV><hr><span>月月兴意见邮箱:" + ConfigurationManager.AppSettings["mailAccount"] + "</span></DIV></BODY>";
            return body;
        }

        # endregion

        /// <summary>
        /// 挑选出所有图片路径
        /// </summary>
        /// <param name="body">HTML字符串</param>
        /// <returns>返回挑选结果</returns>
        private static List<string> SelectImgSrc(string body)
        {
            //图片路径的前一部分
            const string beginString = "<img src=\"";
            //图片路径的后一部分
            const string endString = "\" alt=\"\" />";
            //开始索引
            int beginIndex = 0;
            //结束索引
            int endIndex = 0;

            List<string> list = new List<string>();
            while (true)
            {
                beginIndex = body.IndexOf(beginString, beginIndex);
                endIndex = body.IndexOf(endString, endIndex);
                if (beginIndex < 0 || endIndex < 0)
                {
                    break;
                }
                string path = body.Substring(beginIndex + beginString.Length , endIndex - beginIndex - beginString.Length);
                list.Add(path);
                endIndex++;
                if (endIndex >= body.Length)
                {
                    break;
                }
                beginIndex = endIndex;
            }

            return list;
        }

        # endregion
    }
}