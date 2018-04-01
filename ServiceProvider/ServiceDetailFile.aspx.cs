using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ServiceProvider_ServiceDetailFile : System.Web.UI.Page
{
    BALServiceProvider objserviceproviderbal = new BALServiceProvider();
    DALServiceProvider objserviceproviderdal = new DALServiceProvider();

    public void bindservicedetailfile()
    {
        DataSet ds = new DataSet();
        ds = objserviceproviderdal.selectServiceProviderByID(Convert.ToInt32(Session["serviceproviderid"].ToString()));
        if (ds.Tables[0].Rows.Count > 0)
        {
            hlservicedetailfile.Text = ds.Tables[0].Rows[0]["servicedetailfile"].ToString();
            hlservicedetailfile.NavigateUrl = "../images/ServiceDetailFile/" + ds.Tables [0].Rows[0]["servicedetailfile"].ToString ();
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            bindservicedetailfile();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
       string filename;
        string filepath;

        if (fuservicedetailfile.HasFile)
        {
            filename = fuservicedetailfile.FileName;
            filepath = Server.MapPath("../images/ServiceDetailFile/");

            fuservicedetailfile.SaveAs(filepath + filename);

            objserviceproviderbal.ServiceProviderID = Convert.ToInt32(Session["serviceproviderid"].ToString());
            objserviceproviderbal.ServiceDetailFile = filename;

            objserviceproviderdal.updateServiceDetailFile(objserviceproviderbal);
            Response.Write("<script>alert('File updated');</script>");

        }
        else
        {
            Response.Write("<script>alert('Please select file');</script>");
        }
        bindservicedetailfile();
    }
}