using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
namespace review_1.BL.helper
{
    public static class Mail
    {
        public static string SendMail(string title,string body,string to)
        {

            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com",587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("mostafaahmed123339@gmail.com", "mostafamostafa123");
                smtp.Send("mostafaahmed123339@gmail.com", to, title, body);
                return "send successfully";
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
        public static string SendMail(string title, string body)
        {

            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("mostafaahmed123339@gmail.com", "mostafamostafa123");
                smtp.Send("mostafaahmed123339@gmail.com", "mostafaamir339@gmail.com", title, body);
                return "send successfully";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
