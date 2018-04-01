using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Customer_ImageGallery : System.Web.UI.Page
{
    BALImageGallery objimagebal = new BALImageGallery();
    DALImageGallery objimagedal = new DALImageGallery();

    public void bindlist()
    {
        int id = Convert.ToInt32(Request.QueryString["spid"].ToString());
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
        if (!IsPostBack)
        {
            bindlist();
        }
    }
}