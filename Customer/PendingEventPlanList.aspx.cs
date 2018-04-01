using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Customer_PendingEventPlanList : System.Web.UI.Page
{
    BALEventPlan objeventplanbal = new BALEventPlan();
    DALEventplan objeventplandal = new DALEventplan();

    public void bindpendingeventlist()
    {
        GridView1.DataSource = objeventplandal.selectPendingEventPlanByCustomerID(Convert.ToInt32(Session["customerid"].ToString()));
        GridView1.DataBind();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            bindpendingeventlist();
        }
    }
}