using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Customer_Feedback : System.Web.UI.Page
{
    BALFeedback objfeedbackbal = new BALFeedback();
    DALFeedback objfeedbackdal = new DALFeedback();

    BALServiceProvider objserviceproviderbal = new BALServiceProvider();
    DALServiceProvider objserviceproviderdal = new DALServiceProvider();

    public void bindserviceprovider()
    {
        DataSet ds = new DataSet();
        ds = objserviceproviderdal.selectServiceProviderByID(Convert.ToInt32(Request.QueryString["spid"].ToString ()));
        if(ds.Tables [0].Rows.Count > 0)
        {
            ltserviceprovidername.Text = ds.Tables[0].Rows[0]["serviceprovidername"].ToString();
            ltemail.Text = ds.Tables[0].Rows[0]["email"].ToString();
            ltmobile.Text = ds.Tables[0].Rows[0]["mobile"].ToString();
        }
        else
        {
            Response.Redirect("Home.aspx");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["spid"]==null)
        {
            Response.Redirect("Home.aspx");
        }
        if(!IsPostBack)
        {
            bindserviceprovider();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        objfeedbackbal.FeedbackContent = txtfeedbackcontent.Text;
        objfeedbackbal.CustomerID = Convert.ToInt32(Session["customerid"].ToString());
        objfeedbackbal.ServiceProviderId = Convert.ToInt32(Request.QueryString["spid"].ToString ());
        objfeedbackbal.FeedbackDate = System.DateTime.Now;
        objfeedbackdal.insertFeedback(objfeedbackbal);
        Response.Write("<script>alert('Thank you for your valuable feedback.');</script>");
        resetcontrol();
    }
    public void resetcontrol()
    {
        txtfeedbackcontent.Text = "";
        
    }
}