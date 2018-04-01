using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ServiceProvider_ProviderImage : System.Web.UI.Page
{
    BALServiceProvider objserviceproviderbal = new BALServiceProvider();
    DALServiceProvider objserviceproviderdal = new DALServiceProvider();

    public void bindimage()
    {
        DataSet ds = new DataSet();
        ds = objserviceproviderdal.selectServiceProviderByLoginID(Convert.ToInt32(Session["loginid"].ToString()));
        imgserviceproviderimage.ImageUrl = "../images/ServiceProvider/"+ds.Tables [0].Rows[0]["serviceproviderimage"].ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            bindimage();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
       string filename;
        string filepath;

        if (fuserviceproviderimage.HasFile)
        {
            filename = fuserviceproviderimage.FileName;
            filepath = Server.MapPath("images/ServiceProvider/");

            fuserviceproviderimage.SaveAs(filepath + filename);
            objserviceproviderbal.ServiceProviderID = Convert.ToInt32(Session["serviceproviderid"].ToString());
            objserviceproviderbal.ServiceProviderImage = filename;
            objserviceproviderdal.updateServiceProviderImage(objserviceproviderbal);
            Response.Write("<script>alert('Image changed');</script>");

        }
        else
        {
            Response.Write("<script>alert('Please select image');</script>");
        }
        bindimage();
    }
}