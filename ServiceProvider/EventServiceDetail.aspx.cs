using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class ServiceProvider_EventPlan : System.Web.UI.Page
{
    BALEventPlan objeventplanbal = new BALEventPlan();
    DALEventplan objeventplandal = new DALEventplan();

    BALServiceProvider objserviceproviderbal = new BALServiceProvider();
    DALServiceProvider objserviceproviderdal = new DALServiceProvider();

    BALEventService objeventservicebal = new BALEventService();
    DALEventService objeventservicedal = new DALEventService();

    DALCustomer objcustomerdal = new DALCustomer();


    public void bindeventplan()
    {
        DataSet ds = new DataSet();

        if (Request.QueryString["epid"] != null)
        {
            ds = objeventplandal.selectEventPlanByID(Convert.ToInt32(Request.QueryString["epid"].ToString()));
            Session["eventplanid"] = ds.Tables[0].Rows[0]["eventplanid"].ToString();
        }
        else
        {
            Response.Redirect("ConfirmEventPlan.aspx");
        }
        DataList1.DataSource = ds;
        DataList1.DataBind();
    }
    public void bindeventservice()
    {
        DataSet ds = new DataSet();
        ds = objeventservicedal.selectEventServiceByEventPlanID(Convert.ToInt32(Request.QueryString["epid"].ToString ()));
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    public void bindcustomer()
    {
        DataSet ds = new DataSet();
        ds = objcustomerdal.selectCustomerByEventPlanID(Convert.ToInt32(Request.QueryString["epid"].ToString()));
        DataList2.DataSource = ds;
        DataList2.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindeventplan();
            bindeventservice();
            bindcustomer();
        }
    }
}