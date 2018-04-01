using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
                try
        {
            string smtpAddress = "smtp.mail.yahoo.com";
            int portNumber = 587;
            bool enableSSL = true;

            string emailFrom = "page1event@yahoo.com";
            string password = "Page1234";
            string emailTo = "darshil208@gmail.com";
            string subject = "Testing";
            string body = "body of email";
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFrom);
                mail.To.Add(emailTo);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = false;
                // Can set to false, if you are sending pure text.

                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFrom, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }

        //try
        //{
        //    MailAddress to = new MailAddress("darshil208@gmail.com");
        //    MailAddress from = new MailAddress("page1event@yahoo.com");
        //    MailMessage mm = new MailMessage(from, to);

        //    mm.Body = "This is welcome email for your registration in ECateringEvent System.";
        //    mm.Subject = "Welcome to E-Catering Event Manage";
        //    SmtpClient client = new SmtpClient("smtp.gmail.com");
        //    client.Port = 587;
        //    client.EnableSsl = true;
        //    client.UseDefaultCredentials = false;
        //    NetworkCredential n = new NetworkCredential("page1event@gmail.com", "Page1234");
        //    client.Credentials = n;
        //    client.Send(mm);
        //}
        //catch (Exception ex)
        //{
        //    Response.Write(ex.Message);
        //}
    }
}