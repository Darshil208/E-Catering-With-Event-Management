using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.IO;
using System.Net;
using System.Net.Mail;

public partial class CustomerRegistration : System.Web.UI.Page
{
    BALCustomer objcustomerbal = new BALCustomer();
    DALCustomer objcustomerdal = new DALCustomer();


    BALCity objcitybal = new BALCity();
    DALCity objcitydal = new DALCity();

    BALState objstatebal = new BALState();
    DALState objstatedal = new DALState();

    BALLogin objloginbal = new BALLogin();
    DALLogin objlogindal = new DALLogin();

    public void resetcontrol()
    {
        txtaddress.Text = "";
        txtcpassword.Text = "";
        txtdob.Text = "";
        txtemail.Text = "";
        txtfirstname.Text = "";
        txtlastname.Text = "";
        txtmobile.Text = "";
        txtpassword.Text = "";
        txtpincode.Text = "";
        txtsecureanswer.Text = "";
        txtsecurityquestion.Text = "";
        txtusername.Text = "";
        drpcity.SelectedIndex = 0;
        drpgender.SelectedIndex = 0;
        drpstate.SelectedIndex = 0;
    }

    public void bindstate()
    {
        drpstate.DataSource = objstatedal.selectState();
        drpstate.DataTextField = "statename";
        drpstate.DataValueField = "stateid";
        drpstate.DataBind();
        drpstate.Items.Insert(0, "-Select State-");
    }
    public void bindcity(int id)
    {
        drpcity.DataSource = objcitydal.selectCityByStateID(id);
        drpcity.DataTextField = "cityname";
        drpcity.DataValueField = "cityid";
        drpcity.DataBind();
        drpcity.Items.Insert(0, "-Select City-");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        if (!IsPostBack)
        {
            bindstate();
            drpcity.Items.Insert(0, "-Select City-");
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
            objloginbal.UserName = txtusername.Text;
            objloginbal.Password = txtpassword.Text;
            objloginbal.SecurityQuestion = txtsecurityquestion.Text;
            objloginbal.SecureAnswer = txtsecureanswer.Text;
            objloginbal.UserRole = "Customer";
            objloginbal.AccountStatus = "Active";
            objloginbal.CreateDate = System.DateTime.Now;

            objlogindal.insertLogin(objloginbal);

            DataSet ds = new DataSet();
            ds = objlogindal.getMaxLoginID();

            objcustomerbal.FirstName =txtfirstname.Text;
           objcustomerbal.LastName=txtlastname.Text;
            objcustomerbal.Address = txtaddress.Text;
            objcustomerbal.CityID = Convert.ToInt32(drpcity.SelectedValue);
            objcustomerbal.Pincode = txtpincode.Text;
            objcustomerbal.Mobile = txtmobile.Text;
            objcustomerbal.Email = txtemail.Text;
            objcustomerbal.Gender = drpgender.SelectedValue;
            objcustomerbal.Dob= Convert.ToDateTime( txtdob.Text);
            objcustomerbal.LoginID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            objcustomerdal.insertCustomer (objcustomerbal);
            resetcontrol();

            try
            {
                string smtpAddress = "smtp.mail.yahoo.com";
                int portNumber = 587;
                bool enableSSL = true;

                string emailFrom = "page1event@yahoo.com";
                string password = "Page1234";
                string emailTo = txtemail.Text;
                string subject = "E-Catering Event: Account registring";
                string body = "Thank you for registering with <b>E-Catering Event Management System</b><br/>If have any query, please letus know.";
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
            Response.Redirect("Login.aspx");
    }
    protected void drpstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindcity(Convert.ToInt32(drpstate.SelectedValue));
    }
    protected void txtfirstname_TextChanged(object sender, EventArgs e)
    {
        
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}