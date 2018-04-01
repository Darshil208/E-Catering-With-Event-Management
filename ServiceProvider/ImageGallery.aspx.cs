using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ServiceProvider_ImageGallery : System.Web.UI.Page
{
    BALImageGallery objimagebal = new BALImageGallery();
    DALImageGallery objimagedal = new DALImageGallery();

    public void bindlist()
    {
        int id = Convert.ToInt32(Session["serviceproviderid"].ToString ());
        DataSet ds = new DataSet();
        ds = objimagedal.selectImageByServiceProviderID(id);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataList1.DataSource = ds;
            DataList1.DataBind();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            bindlist();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (fuimagefile.HasFile)
        {
            string filename;
            string filepath;

            filename = fuimagefile.FileName;
            filepath = Server.MapPath("../Images/ImageGallery/");

            fuimagefile.SaveAs(filepath + filename);

            objimagebal.ServiceProviderID = Convert.ToInt32(Session["serviceproviderid"].ToString ());
            objimagebal.ImageFileName = filename;

            objimagedal.insertImage(objimagebal);

            bindlist();
        }
        else
        {
            Response.Write("<script>alert('Please select image');</script>");
        }
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "ibdeleteimage")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            objimagedal.deleteImage(id);
            bindlist();
            Response.Write("<script>alert('Image deleted');</script>");
            
        }
    }
}