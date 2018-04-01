using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Net;

public partial class ServiceProviderRegistration : System.Web.UI.Page
{
    BALServiceProvider objserviceproviderbal = new BALServiceProvider();
    DALServiceProvider objserviceproviderdal = new DALServiceProvider();

    BALCity objcitybal = new BALCity();
    DALCity objcitydal = new DALCity();

    BALState objstatebal = new BALState();
    DALState objstatedal = new DALState();

    BALLogin objloginbal = new BALLogin();
    DALLogin objlogindal = new DALLogin();

    BALServiceProviderType objserviceprovidertypebal = new BALServiceProviderType();
    DALServiceProviderType objserviceprovidertypedal = new DALServiceProviderType();

    public void resetcontrol()
    {
        txtaboutserviceprovider.Text = "";
        txtaddress.Text = "";
        txtcpassword.Text = "";
        txtemail.Text = "";
        txtmobile.Text = "";
        txtpassword.Text = "";
        txtpincode.Text = "";
        txtsecureanswer.Text = "";
        txtsecurityquestion.Text = "";
        txtserviceprovidername.Text = "";
        txtusername.Text = "";
        txtwebsite.Text = "";
        drpcity.SelectedIndex = 0;
        drpserviceprovidertype.SelectedIndex = 0;
        drpstate.SelectedIndex = 0;
    }
    public void bindserviceprovidertype()
    {
        drpserviceprovidertype.DataSource = objserviceprovidertypedal.selectServiceProviderType();
        drpserviceprovidertype.DataTextField = "serviceprovidertype";
        drpserviceprovidertype.DataValueField = "serviceprovidertypeid";
        drpserviceprovidertype.DataBind();
        drpserviceprovidertype.Items.Insert(0, "-Select Service Provider Type-");
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
            bindserviceprovidertype();
            bindstate();
            drpcity.Items.Insert(0, "-Select City-");
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string filename;
        string filepath;

        string servicefilename;
        string servicefilepath;


        if (fuimagefile.HasFile && fuservicedetailfile.HasFile)
        {
            filename = fuimagefile.FileName;
            filepath = Server.MapPath("images/ServiceProvider/");

            fuimagefile.SaveAs(filepath + filename);

            servicefilename = fuservicedetailfile.FileName;
            servicefilepath = Server.MapPath("images/ServiceDetailFile/");

            fuservicedetailfile.SaveAs(servicefilepath + servicefilename);

            objloginbal.UserName = txtusername.Text;
            objloginbal.Password = txtpassword.Text;
            objloginbal.SecurityQuestion = txtsecurityquestion.Text;
            objloginbal.SecureAnswer = txtsecureanswer.Text;
            objloginbal.UserRole = "ServiceProvider";
            objloginbal.AccountStatus = "Pending";
            objloginbal.CreateDate = System.DateTime.Now;

            objlogindal.insertLogin(objloginbal);

            DataSet ds = new DataSet();
            ds = objlogindal.getMaxLoginID();

            objserviceproviderbal.ServiceProviderName = txtserviceprovidername.Text;
            objserviceproviderbal.Address = txtaddress.Text;
            objserviceproviderbal.CityID = Convert.ToInt32(drpcity.SelectedValue);
            objserviceproviderbal.Pincode = txtpincode.Text;
            objserviceproviderbal.Mobile = txtmobile.Text;
            objserviceproviderbal.Email = txtemail.Text;
            objserviceproviderbal.Website = txtwebsite.Text;
            objserviceproviderbal.AboutServiceProvider = txtaboutserviceprovider.Text;
            objserviceproviderbal.ServiceProviderTypeID = Convert.ToInt32(drpserviceprovidertype.SelectedValue);
            objserviceproviderbal.ServiceProviderImage = filename;
            objserviceproviderbal.LoginID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            objserviceproviderbal.ServiceDetailFile = servicefilename;

            objserviceproviderdal.insertServiceProvider(objserviceproviderbal);
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
                string body = "Thank you for registering with <b>E-Catering Event Management System</b><br/>Your account will activated shortly.<br/>You will receive an email regaring your account activation.<br/>If your account takes too much time for activation, contact us";
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
        else
        {
            Response.Write("<script>alert('Please select image');</script>");
        }
    }

    protected void drpstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindcity(Convert.ToInt32(drpstate.SelectedValue));
    }
}