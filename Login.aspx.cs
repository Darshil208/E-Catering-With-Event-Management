using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//for dataset to receive and store data in local
using System.Data;

public partial class Login : System.Web.UI.Page
{
    BALLogin objloginbal = new BALLogin();
    DALLogin objlogindal = new DALLogin();

    BALServiceProvider objserviceproviderbal = new BALServiceProvider();
    DALServiceProvider objserviceproviderdal = new DALServiceProvider();

    BALCustomer objcustomerbal = new BALCustomer();
    DALCustomer objcustomerdal = new DALCustomer();

    protected void Page_Load(object sender, EventArgs e)
    {
        UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        objloginbal.UserName = txtusername.Text;
        objloginbal.Password = txtpassword.Text;

        DataSet ds = new DataSet();

        ds = objlogindal.validateLogin(objloginbal);

        if (ds.Tables[0].Rows.Count > 0)
        {
            if(ds.Tables [0].Rows[0]["accountstatus"].ToString () == "Active")
            {
                Session["username"] = ds.Tables[0].Rows[0]["username"].ToString();
                Session["loginid"] = ds.Tables[0].Rows[0]["loginid"].ToString();
                Session["userrole"] = ds.Tables[0].Rows[0]["userrole"].ToString();

                if (ds.Tables[0].Rows[0]["userrole"].ToString() == "Admin")
                {
                    Response.Redirect("Admin/Home.aspx");
                }
                else if (ds.Tables[0].Rows[0]["userrole"].ToString() == "ServiceProvider")
                {
                    DataSet dssp = new DataSet();
                    dssp = objserviceproviderdal.selectServiceProviderByLoginID(Convert.ToInt32(ds.Tables[0].Rows[0]["loginid"].ToString()));
                    Session["serviceproviderid"] = dssp.Tables[0].Rows[0][0].ToString();
                    Response.Redirect("ServiceProvider/Home.aspx");
                }
                else if (ds.Tables[0].Rows[0]["userrole"].ToString() == "Customer")
                {
                    DataSet dscustomer = new DataSet();
                    dscustomer = objcustomerdal.selectCustomerByLoginID(Convert.ToInt32(ds.Tables[0].Rows[0]["loginid"].ToString()));
                    Session["customerid"] = dscustomer.Tables[0].Rows[0][0].ToString();
                    Session["email"] = dscustomer.Tables[0].Rows[0]["email"].ToString ();
                    Response.Redirect("Customer/Home.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid login detail');</script>");
                }
            }
            else if (ds.Tables[0].Rows[0]["accountstatus"].ToString() == "Deactive")
            {
                Response.Write("<script>alert('Your account is deactivated by admin');</script>");
            }
            else if (ds.Tables[0].Rows[0]["accountstatus"].ToString() == "Pending")
            {
                Response.Write("<script>alert('Your account activation still in pending mode.');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Invalid login detail');</script>");
        }
    }
}