using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_Profile : System.Web.UI.Page
{
    BALCustomer objcustomerbal = new BALCustomer();
    DALCustomer objcustomerdal = new DALCustomer();


    BALCity objcitybal = new BALCity();
    DALCity objcitydal = new DALCity();

    BALState objstatebal = new BALState();
    DALState objstatedal = new DALState();

    BALLogin objloginbal = new BALLogin();
    DALLogin objlogindal = new DALLogin();


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
        DataSet dscustomer = new DataSet();
        dscustomer = objcustomerdal.selectCustomerByLoginID(Convert.ToInt32(Session["loginid"].ToString()));

        DataSet dslogin = new DataSet();
        dslogin = objlogindal.selectLoginByID(Convert.ToInt32(Session["loginid"].ToString()));

        if(dscustomer.Tables[0].Rows.Count > 0 && dslogin.Tables[0].Rows.Count >0)
        {
            txtfirstname.Text = dscustomer.Tables[0].Rows[0]["firstname"].ToString();
            txtlastname.Text = dscustomer.Tables[0].Rows[0]["lastname"].ToString();
            txtaddress.Text = dscustomer.Tables[0].Rows[0]["address"].ToString();
            txtpincode.Text = dscustomer.Tables[0].Rows[0]["pincode"].ToString();
            txtmobile.Text = dscustomer.Tables[0].Rows[0]["mobile"].ToString();
            txtemail.Text = dscustomer.Tables[0].Rows[0]["email"].ToString();
            txtdob.Text = Convert.ToDateTime( dscustomer.Tables[0].Rows[0]["dob"].ToString()).ToString("yyyy-MM-dd");

            txtusername.Text = dslogin.Tables[0].Rows[0]["username"].ToString();
            txtsecurityquestion.Text = dslogin.Tables[0].Rows[0]["securityquestion"].ToString();
            txtsecureanswer.Text = dslogin.Tables[0].Rows[0]["secureanswer"].ToString();

            for (int i = 0; i < drpstate.Items.Count; i++)
            {
                if(drpstate.Items[i].Text == dscustomer.Tables[0].Rows[0]["statename"].ToString())
                {
                    drpstate.SelectedIndex = i;
                }
            }
            bindcity(Convert.ToInt32(drpstate.SelectedValue));
            for (int i = 0; i < drpcity.Items.Count; i++)
            {
                if (drpcity.Items[i].Text == dscustomer.Tables[0].Rows[0]["cityname"].ToString())
                {
                    drpcity.SelectedIndex = i;
                }
            }

            for (int i = 0; i < drpgender.Items.Count; i++)
            {
                if (drpgender.Items[i].Text == dscustomer.Tables[0].Rows[0]["gender"].ToString())
                {
                    drpgender.SelectedIndex = i;
                }
            }


        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindstate();
            drpcity.Items.Insert(0, "-Select City-");
            bindprofile();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        objloginbal.LoginID = Convert.ToInt32(Session["loginid"].ToString());
        objloginbal.UserName = txtusername.Text;
        objloginbal.SecurityQuestion = txtsecurityquestion.Text;
        objloginbal.SecureAnswer = txtsecureanswer.Text;

        objlogindal.updateLogin(objloginbal);

        objcustomerbal.FirstName = txtfirstname.Text;
        objcustomerbal.LastName = txtlastname.Text;
        objcustomerbal.Address = txtaddress.Text;
        objcustomerbal.CityID = Convert.ToInt32(drpcity.SelectedValue);
        objcustomerbal.Pincode = txtpincode.Text;
        objcustomerbal.Mobile = txtmobile.Text;
        objcustomerbal.Email = txtemail.Text;
        objcustomerbal.Gender = drpgender.SelectedValue;
        objcustomerbal.Dob = Convert.ToDateTime(txtdob.Text);
        objcustomerbal.LoginID = Convert.ToInt32(Session["loginid"].ToString());
        objcustomerdal.updateCustomer(objcustomerbal);
    }
    protected void drpstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindcity(Convert.ToInt32(drpstate.SelectedValue));
    }
}