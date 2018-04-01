using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class ServiceProvider_Profile : System.Web.UI.Page
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

    public void bindprofile()
    {
        DataSet dsprovider = new DataSet();
        dsprovider = objserviceproviderdal.selectServiceProviderByLoginID(Convert.ToInt32(Session["loginid"].ToString()));


        DataSet dslogin = new DataSet();
        dslogin = objlogindal.selectLoginByID(Convert.ToInt32(Session["loginid"].ToString()));

        txtserviceprovidername.Text = dsprovider.Tables[0].Rows[0]["serviceprovidername"].ToString();
        txtaddress.Text = dsprovider.Tables[0].Rows[0]["address"].ToString();
        txtpincode.Text = dsprovider.Tables[0].Rows[0]["pincode"].ToString();
        txtmobile.Text = dsprovider.Tables[0].Rows[0]["mobile"].ToString();
        txtemail.Text = dsprovider.Tables[0].Rows[0]["email"].ToString();
        txtwebsite.Text = dsprovider.Tables[0].Rows[0]["website"].ToString();
        txtaboutserviceprovider.Text = dsprovider.Tables[0].Rows[0]["aboutserviceprovider"].ToString();

        for (int i = 0; i < drpstate.Items.Count; i++)
        {
            if (drpstate.Items[i].Text == dsprovider.Tables[0].Rows[0]["statename"].ToString())
            {
                drpstate.SelectedIndex = i;
            }
        }
        bindcity(Convert.ToInt32(drpstate.SelectedValue));

        for (int i = 0; i < drpcity.Items.Count; i++)
        {
            if (drpcity.Items[i].Text == dsprovider.Tables[0].Rows[0]["cityname"].ToString())
            {
                drpcity.SelectedIndex = i;
            }
        }
        for (int i = 0; i < drpserviceprovidertype.Items.Count; i++)
        {
            if (drpserviceprovidertype.Items[i].Text == dsprovider.Tables[0].Rows[0]["serviceprovidertype"].ToString())
            {
                drpserviceprovidertype.SelectedIndex = i;
            }
        }
        

            txtusername.Text = dsprovider.Tables[0].Rows[0]["username"].ToString();
        txtsecurityquestion.Text = dsprovider.Tables[0].Rows[0]["securityquestion"].ToString();
        txtsecureanswer.Text = dsprovider.Tables[0].Rows[0]["secureanswer"].ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["userrole"] == null || Session["userrole"].ToString() != "ServiceProvider")
        {
            Response.Redirect("../Login.aspx");
        }
        if (!IsPostBack)
        {
            bindserviceprovidertype();
            bindstate();
            drpcity.Items.Insert(0, "-Select City-");
            bindprofile();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
            objloginbal.LoginID = Convert.ToInt32 (Session["loginid"].ToString());
            objloginbal.UserName = txtusername.Text;
            objloginbal.SecurityQuestion = txtsecurityquestion.Text;
            objloginbal.SecureAnswer = txtsecureanswer.Text;

            objlogindal.updateLogin(objloginbal);

        objserviceproviderbal.ServiceProviderID = Convert.ToInt32 (Session["serviceproviderid"].ToString());
            objserviceproviderbal.ServiceProviderName = txtserviceprovidername.Text;
            objserviceproviderbal.Address = txtaddress.Text;
            objserviceproviderbal.CityID = Convert.ToInt32(drpcity.SelectedValue);
            objserviceproviderbal.Pincode = txtpincode.Text;
            objserviceproviderbal.Mobile = txtmobile.Text;
            objserviceproviderbal.Email = txtemail.Text;
            objserviceproviderbal.Website = txtwebsite.Text;
            objserviceproviderbal.AboutServiceProvider = txtaboutserviceprovider.Text;
            objserviceproviderbal.ServiceProviderTypeID = Convert.ToInt32(drpserviceprovidertype.SelectedValue);
            objserviceproviderbal.LoginID = Convert.ToInt32(Session["loginid"].ToString());

            objserviceproviderdal.updateServiceProviderWithoutImage(objserviceproviderbal);

            Response.Write("<script>alert('Profile updated.');</script>");
            bindprofile();
    }
    

    protected void drpstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindcity(Convert.ToInt32(drpstate.SelectedValue));
    }
}