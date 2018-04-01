using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Net.Mail;
using System.Net;

public partial class Admin_serviceprovider : System.Web.UI.Page
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

    public void bindserviceprovidertype()
    {
        drpserviceprovidertype.DataSource = objserviceprovidertypedal.selectServiceProviderType();
        drpserviceprovidertype.DataTextField = "serviceprovidertype";
        drpserviceprovidertype.DataValueField = "serviceprovidertypeid";
        drpserviceprovidertype.DataBind();
        drpserviceprovidertype.Items.Insert(0, "-Select Service Provider Type-");
    }
    public void bindfilterserviceprovidertype()
    {
        drpfilterprovidertype.DataSource = objserviceprovidertypedal.selectServiceProviderType();
        drpfilterprovidertype.DataTextField = "serviceprovidertype";
        drpfilterprovidertype.DataValueField = "serviceprovidertypeid";
        drpfilterprovidertype.DataBind();
        drpfilterprovidertype.Items.Insert(0, "-Select Service Provider Type-");
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
        drpcityid.DataSource = objcitydal.selectCityByStateID(id);
        drpcityid.DataTextField = "cityname";
        drpcityid.DataValueField = "cityid";
        drpcityid.DataBind();
        drpcityid.Items.Insert(0, "-Select City-");
    }

    public void bindlogin()
    {
        string role = "ServiceProvider";
        drploginid.DataSource = objlogindal.selectLoginByUserRole(role);
        drploginid.DataTextField = "username";
        drploginid.DataValueField = "loginid";
        drploginid.DataBind();
        drploginid.Items.Insert(0, "-Select User Name-");
    }

    public void resetconrol()
    {
        btnsubmit.Text = "Submit";
    }
    public void bindgrid()
    {
        GridView1.DataSource = objserviceproviderdal.selectServiceProvider();
        GridView1.DataBind();
    }
    public void bindgrid(int id)
    {
        GridView1.DataSource = objserviceproviderdal.selectServiceProviderByServiceProviderTypeID(id);
        GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userrole"] == null || Session["userrole"].ToString() != "Admin" || Session["username"] == null || Session["username"].ToString() == "")
        {
            Response.Redirect("../Login.aspx");
        }
        if (!IsPostBack)
        {
            bindgrid();
            bindserviceprovidertype();
            bindlogin();
            bindstate();
            drpcityid.Items.Insert(0, "-Select City-");
            bindfilterserviceprovidertype();
        }
    }
    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 1;
    }
    protected void btnselectall_Click(object sender, EventArgs e)
    {
        CheckBox cb = new CheckBox();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            cb = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");

            if (!cb.Checked)
            {
                cb.Checked = true;
            }
        }
    }
    protected void btndelete_Click(object sender, EventArgs e)
    {
        CheckBox cb = new CheckBox();
        bool flag = false;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            cb = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");

            if (cb.Checked)
            {
                int id = Convert.ToInt32(GridView1.Rows[i].Cells[3].Text);
                objserviceproviderdal.deleteServiceProvider(id);
                flag = false;
            }
        }
        if (flag)
        {
            bindgrid();
            Response.Write("<script>alert('Record deleted');</script>");
        }
        else
        {
            Response.Write("<script>alert('Please select record to delete');</script>");
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        objserviceproviderbal.ServiceProviderName = txtserviceprovidername.Text;
        objserviceproviderbal.Address = txtaddress.Text;
        objserviceproviderbal.CityID = Convert.ToInt32(drpserviceprovidertype.SelectedValue);
        objserviceproviderbal.Pincode = txtpincode.Text;
        objserviceproviderbal.Mobile = txtmobile.Text;
        objserviceproviderbal.Email = txtemail.Text;
        objserviceproviderbal.Website = txtwebsite.Text;
        objserviceproviderbal.AboutServiceProvider = txtaboutserviceprovider.Text;
        objserviceproviderbal.ServiceProviderTypeID = Convert.ToInt32(drpserviceprovidertype.SelectedValue);
        objserviceproviderbal.LoginID = Convert.ToInt32(drploginid.SelectedValue);
        
        string filename;
        string filepath;

        if (btnsubmit.Text == "Submit")
        {
            if (fuserviceproviderimage.HasFile)
            {
                filename = fuserviceproviderimage.FileName;
                filepath = Server.MapPath("../images/ServiceProvider/");

                fuserviceproviderimage.SaveAs(filepath + filename);

                objserviceproviderbal.ServiceProviderImage = filename;
                objserviceproviderdal.insertServiceProvider(objserviceproviderbal);
                Response.Write("<script>alert('Record inseted');</script>");
            }
            else
            {
                Response.Write("<script>alert('Please select image');</script>");
            }
        }
        else
        {

            objserviceproviderbal.ServiceProviderID = Convert.ToInt32(GridView1.SelectedRow.Cells[3].Text);
            if (fuserviceproviderimage.HasFile)
            {
                filename = fuserviceproviderimage.FileName;
                filepath = Server.MapPath("../images/ServiceProvider/");

                fuserviceproviderimage.SaveAs(filepath + filename);

                objserviceproviderbal.ServiceProviderImage = filename;
                objserviceproviderdal.updateServiceProvider(objserviceproviderbal);
                Response.Write("<script>alert('Record updated');</script>");
            }
            else
            {
                objserviceproviderdal.updateServiceProviderWithoutImage(objserviceproviderbal);
                Response.Write("<script>alert('Record updated');</script>");
            }


            try
            {
                string smtpAddress = "smtp.mail.yahoo.com";
                int portNumber = 587;
                bool enableSSL = true;

                string emailFrom = "page1event@yahoo.com";
                string password = "Page1234";
                string emailTo = objserviceproviderbal.Email;
                string subject = "E-Catering Event: Account activation";
                string body = "Thank you for registring in our website <b>E-Catering Event Management System</b><br/>Your account is successfully activated.<br/>Now you can work with us.<br/>If you have any query, please letus know.";
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

        }
        bindgrid();
        resetconrol();
        MultiView1.ActiveViewIndex = 0;
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        resetconrol();
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        resetconrol();
        MultiView1.ActiveViewIndex = 0;
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(GridView1.SelectedRow.Cells[3].Text);

        DataSet ds = new DataSet();
        ds = objserviceproviderdal.selectServiceProviderByID(id);

        if (ds.Tables[0].Rows.Count > 0)
        {
            txtaboutserviceprovider.Text = ds.Tables[0].Rows[0]["aboutserviceprovider"].ToString();
            txtaddress.Text = ds.Tables[0].Rows[0]["address"].ToString();
            txtemail.Text = ds.Tables[0].Rows[0]["email"].ToString();
            txtmobile.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
            txtpincode.Text = ds.Tables[0].Rows[0]["pincode"].ToString();
            txtserviceprovidername.Text = ds.Tables[0].Rows[0]["serviceprovidername"].ToString();
            txtwebsite.Text = ds.Tables[0].Rows[0]["website"].ToString();

            for (int i = 0; i < drpstate.Items.Count; i++)
            {
                if(drpstate.Items[i].Text == ds.Tables [0].Rows[0]["statename"].ToString())
                {
                    drpstate.SelectedIndex = i;
                }
            }
            bindcity(Convert.ToInt32(drpstate.SelectedValue));
            for (int i = 0; i < drpcityid.Items.Count; i++)
            {
                if (drpcityid.Items[i].Text == ds.Tables[0].Rows[0]["cityname"].ToString())
                {
                    drpcityid.SelectedIndex = i;
                }
            }

            for (int i = 0; i < drploginid.Items.Count; i++)
            {
                if (drploginid.Items[i].Text == ds.Tables[0].Rows[0]["username"].ToString())
                {
                    drploginid.SelectedIndex = i;
                }
            }
            for (int i = 0; i < drpserviceprovidertype.Items.Count; i++)
            {
                if (drpserviceprovidertype.Items[i].Text == ds.Tables[0].Rows[0]["serviceprovidertype"].ToString())
                {
                    drpserviceprovidertype.SelectedIndex = i;
                }
            }





                btnsubmit.Text = "Update";
            MultiView1.ActiveViewIndex = 1;
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[3].Text);
        objserviceproviderdal.deleteServiceProvider(id);
        bindgrid();
        Response.Write("<script>alert('Record deleted');</script>");
    }
    protected void drpstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindcity(Convert.ToInt32(drpstate.SelectedValue));
    }
    protected void btnfilter_Click(object sender, EventArgs e)
    {
//        Response.Write(drpfilterprovidertype.SelectedValue);
        bindgrid(Convert.ToInt32(drpfilterprovidertype.SelectedValue));
    }
}