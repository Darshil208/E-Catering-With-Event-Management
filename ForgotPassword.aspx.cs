using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Net;

public partial class ForgotPassword : System.Web.UI.Page
{
    BALLogin objloginbal = new BALLogin();
    DALLogin objlogindal = new DALLogin();


    protected void Page_Load(object sender, EventArgs e)
    {



    }
    protected void btnnext_Click(object sender, EventArgs e)
    {
        string username = txtusername.Text;

        DataSet dsuser = new DataSet();
        dsuser = objlogindal.getSecurityByUserName(username);

        if (dsuser.Tables[0].Rows.Count > 0)
        {
            MultiView1.ActiveViewIndex = 1;
            txtsecurityquestion.Text = dsuser.Tables[0].Rows[0]["securityquestion"].ToString();
        }
        else
        {
            Response.Write("<script>alert('Username does not exists.');</script>");
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        objloginbal.UserName = txtusername.Text;
        objloginbal.SecurityQuestion = txtsecurityquestion.Text;
        objloginbal.SecureAnswer = txtsecureanswer.Text;

        DataSet dsuser = new DataSet();
        dsuser = objlogindal.retrievePassword(objloginbal);

        if (dsuser.Tables[0].Rows.Count > 0)
        {
            try
            {
                string smtpAddress = "smtp.mail.yahoo.com";
                int portNumber = 587;
                bool enableSSL = true;

                string emailFrom = "page1event@yahoo.com";
                string password = "Page1234";
                string emailTo = dsuser.Tables[0].Rows[0]["email"].ToString();
                string subject = "E-Catering Event: Password recovery";
                string body = "";
                body += "<p>User Name:" + dsuser.Tables[0].Rows[0]["username"].ToString() + "</p>";
                body += "<br/><p>Password:" + dsuser.Tables[0].Rows[0]["password"].ToString() + "</p>";
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
                Response.Write("<script>alert('Password is sent to your registered email address.');</script>");
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        else
        {
            Response.Write("<script>alert('Invalid detail');</script>");
        }
    }
}