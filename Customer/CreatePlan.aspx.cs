using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Customer_CreatePlan : System.Web.UI.Page
{
    BALEventPlan objeventplanbal = new BALEventPlan();
    DALEventplan objeventplandal = new DALEventplan();

    BALEventType objeventtypebal = new BALEventType();
    DALEventType objeventtypedal = new DALEventType();

    public void resetcontrol()
    {
        txtbudgetamount.Text = "";
        txtaboutplan.Text = "";
        txteventstartdate.Text = "";
            txttotaldays.Text = "";
        drpeventtype.SelectedIndex=0;
    }
    public void bindeventtype()
    {
        drpeventtype.DataSource = objeventtypedal.selectEventType();
        drpeventtype.DataTextField = "eventtypename";
        drpeventtype.DataValueField = "eventtypeid";
        drpeventtype.DataBind();
        drpeventtype.Items.Insert(0, "-Select Event Type-");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindeventtype();
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        objeventplanbal.EventTypeID = Convert.ToInt32(drpeventtype.SelectedValue);
        objeventplanbal.EventStartDate = Convert.ToDateTime(txteventstartdate.Text);
        objeventplanbal.TotalDays = Convert.ToInt32(txttotaldays.Text);
        objeventplanbal.BudgetAmount = Convert.ToInt32(txtbudgetamount.Text);
        objeventplanbal.AboutPlan = txtaboutplan.Text;
        objeventplanbal.CreateDate = System.DateTime.Now;
        objeventplanbal.CustomerID = Convert.ToInt32(Session["customerid"].ToString());
        objeventplanbal.PlanStatus = "Pending";
        objeventplandal.insertEventPlan(objeventplanbal);
        resetcontrol();
        Response.Redirect("EventPlan.aspx");
    }
}