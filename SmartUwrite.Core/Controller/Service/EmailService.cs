using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using System.IO;
using BIMTClassLibrary.Service;
using System.Windows.Forms;
using BIMTClassLibrary.LogIn;
using BIMTClassLibrary.Model;

namespace BIMTClassLibrary.Email
{
    public class EmailService
    {
        public static void TestEmail()
        {
            try
            {
                //smtp.163.com
                string senderServerIp = "smtp.163.com";
                //smtp.gmail.com
                //string senderServerIp = "74.125.127.109";
                //smtp.qq.com
                //string senderServerIp = "58.251.149.147";
                //string senderServerIp = "smtp.sina.com";
                string toMailAddress = "13126506430@163.com";
                string fromMailAddress = "13126506430@163.com";
                string subjectInfo = "Test sending e_mail";
                string bodyInfo = "Hello Eric, This is my first testing e_mail";
                string mailUsername = "mingmingruyuedlut";
                string mailPassword = "whl05043016"; //发送邮箱的密码（）
                string mailPort = "993";
                string attachPath = @"C:\Users\jishu12\Desktop\20160624.txt";

                EmailHelper email = new EmailHelper(senderServerIp, toMailAddress, fromMailAddress, subjectInfo, bodyInfo, mailUsername, mailPassword, mailPort, false, false);
                email.AddAttachments(attachPath);
                email.Send();
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(EmailService), ex.Message);
            }
        }

        public static void TestEmail2()
        {
            try
            {
                //确定smtp服务器地址。实例化一个Smtp客户端
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.163.com ");
                //生成一个发送地址
                string strFrom = string.Empty;
                strFrom = "bimt_send@163.com";
                //构造一个发件人地址对象
                MailAddress from = new MailAddress(strFrom, "BIMT写作助手", Encoding.UTF8);
                //构造一个收件人地址对象
                MailAddress to = new MailAddress("1255246777@qq.com", "wuhailong", Encoding.UTF8);
                //构造一个Email的Message对象
                MailMessage message = new MailMessage(from, to);
                //得到文件名
                string fileName = @"C:\Users\jishu12\Desktop\20160624.txt";
                //判断文件是否存在
                if (File.Exists(fileName))
                {
                    //构造一个附件对象
                    Attachment attach = new Attachment(fileName);
                    //得到文件的信息
                    ContentDisposition disposition = attach.ContentDisposition;
                    disposition.CreationDate = System.IO.File.GetCreationTime(fileName);
                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(fileName);
                    disposition.ReadDate = System.IO.File.GetLastAccessTime(fileName);
                    //向邮件添加附件
                    message.Attachments.Add(attach);
                }
                else
                {
                    Log4Net.LogHelper.WriteLog(typeof(EmailService), "文件" + fileName + "未找到！");
                }
                //添加邮件主题和内容
                message.Subject = "BIMT写作助手意见反馈";
                message.SubjectEncoding = Encoding.UTF8;
                message.Body = "BIMT写作助手意见反馈....";
                message.BodyEncoding = Encoding.UTF8;
                //设置邮件的信息
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = false;

                //gmail支持，163不支持，如果是gmail则一定要将其设为true
                client.EnableSsl = false;

                //设置用户名和密码。
                client.UseDefaultCredentials = false;
                string username = "bimt_send";
                string passwd = "whl05043016";
                //用户登陆信息
                NetworkCredential myCredentials = new NetworkCredential(username, passwd);
                client.Credentials = myCredentials;
                //发送邮件
                client.Send(message);
                //提示发送成功
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(EmailService), ex.Message);
            }
        }

        public static void TestEmail3(string p_strTitle, string p_strContent)
        {
            User user = User.GetInstance();
            string _strPostData = "{"
                                + "\"id\":\"" + user.Key.id + "\","
                                + "\"name\":\"用户名\","
                                + "\"email\":\"" + user.Detail.email + "\","
                                + "\"tel\":\"" + user.Detail.tel + "\","
                                + "\"subject\":\"" + p_strTitle + "\","
                                + "\"content\":\"" + p_strContent + "\""
                                + "}";
            string result = BIMTService.CallPostService(PublicVar.recommandBaseUrl + "/utils/sendEmail", _strPostData);
            var quotations = CommonFunction.JsonToDictionary(result);
            Dictionary<string, object> _dict = (Dictionary<string, object>)quotations;
            if ("TRUE" == _dict["response"].ToString().ToUpper())
            {
                MessageBox.Show("邮件发送成功！", "消息发送");
            }
        }
    }
}
