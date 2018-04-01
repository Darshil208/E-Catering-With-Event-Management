using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ServicePackageList : System.Web.UI.Page
{
    BALServicePackage objservicepackagebal = new BALServicePackage();
    DALServicepackage objservicepackagedal = new DALServicepackage();

   public void bindservicepackage()
    {
        DataList1.DataSource = objservicepackagedal.selectServicePackageByProviderID(Convert.ToInt32(Request.QueryString["spid"].ToString()));
        DataList1.DataBind();
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["spid"] == null)
        {
            Response.Redirect("Home.aspx");
        }
        if (!IsPostBack)
        {
            bindservicepackage();
        }
    }
}