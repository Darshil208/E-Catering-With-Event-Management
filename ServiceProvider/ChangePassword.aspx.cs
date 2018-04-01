using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


//for dataset to receive and store data in local
using System.Data;
public partial class ServiceProvider_ChangePassword : System.Web.UI.Page
{
    BALLogin objloginbal = new BALLogin();
    DALLogin objlogindal = new DALLogin();

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        objloginbal.UserName = Session["username"].ToString ();
        objloginbal.Password = txtopassword.Text;

        DataSet ds = new DataSet();

        ds = objlogindal.validateLogin(objloginbal);

        if (ds.Tables[0].Rows.Count > 0)
        {
            objloginbal.Password = txtnpassword.Text;
            objlogindal.changePassword(objloginbal);
            Response.Write("<script>alert('Password changed');</script>");
        }
        else
        {
            Response.Write("<script>alert('Invalid login detail');</script>");
        }
    }
}