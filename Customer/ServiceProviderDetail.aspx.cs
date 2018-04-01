using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_ServiceProviderDetail : System.Web.UI.Page
{
    BALServiceProvider objserviceproviderbal = new BALServiceProvider();
    DALServiceProvider objserviceproviderdal = new DALServiceProvider();

    BALFeedback objfeedbackbal = new BALFeedback();
    DALFeedback objfeedbackdal = new DALFeedback();

    public void bindfeedback()
    {
        DataList2.DataSource = objfeedbackdal.selectFeedbackByServiceProviderID(Convert.ToInt32(Request.QueryString["spid"].ToString()));
        DataList2.DataBind();
    }
    public void bindserviceprovider()
    {
        if (Request.QueryString["spid"] != null)
        {
            DataList1.DataSource = objserviceproviderdal.selectServiceProviderByID(Convert.ToInt32(Request.QueryString["spid"].ToString()));
            DataList1.DataBind();
        }
        else
        {
            DataList1.DataSource = objserviceproviderdal.selectServiceProvider();
            DataList1.DataBind();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindserviceprovider();
            bindfeedback();
        }
    }
}