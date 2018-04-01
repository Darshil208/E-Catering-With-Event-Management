using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_ServiceProviderList : System.Web.UI.Page
{
    BALServiceProvider objserviceproviderbal = new BALServiceProvider();
    DALServiceProvider objserviceproviderdal = new DALServiceProvider();

    public void bindserviceprovider()
    {
        if (Request.QueryString["sptid"] != null)
        {
                    DataList1.DataSource = objserviceproviderdal.selectServiceProviderByServiceProviderTypeID(Convert.ToInt32(Request.QueryString["sptid"].ToString()));
        DataList1.DataBind();
        }
        else{
            DataList1.DataSource = objserviceproviderdal.selectServiceProvider();
            DataList1.DataBind();
        }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindserviceprovider();
        }
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {

    }
}