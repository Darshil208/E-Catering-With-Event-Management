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


    public void bindeventplan()
    {
        DataSet ds = new DataSet();

        if (Request.QueryString["epid"] != null)
        {
            ds = objeventplandal.selectEventPlanByID(Convert.ToInt32(Request.QueryString["epid"].ToString()));
            Session["eventplanid"] = ds.Tables[0].Rows[0]["eventplanid"].ToString();

            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {
            Response.Redirect("ConfirmEventPlan.aspx");
        }
        
    }
    //public void bindeventservice()
    //{
        
    //    DataSet dseventservice = new DataSet();
    //    dseventservice = objeventservicedal.selectEventServiceByEventPlanID(Convert.ToInt32(Session["eventplanid"]));
    //    lteventservice.Text = "";
    //    if(dseventservice.Tables[0].Rows.Count > 0 )
    //    {
    //        lteventservice.Text = "<h2 class='title2'>Event Service Package</h2>";
    //        GridView1.DataSource = dseventservice;
    //        GridView1.DataBind();
            
    //        int total = 0;
    //        int budgetamount = Convert.ToInt32(ViewState["eventbudget"].ToString());

    //        for(int i=0;i<dseventservice.Tables[0].Rows.Count ;i++)
    //        {
    //            total += Convert.ToInt32(dseventservice.Tables[0].Rows[0]["servicepackageamount"]);
    //        }

    //        if (budgetamount < total)
    //        {
    //            ltservicepackagetotal.Text += "<table style='color:red;' class='datatable'>";
    //        }
    //        else
    //        {
    //            ltservicepackagetotal.Text += "<table style='color:green;' class='datatable'>";
    //        }
    //        ltservicepackagetotal.Text += "<tr>";
    //        ltservicepackagetotal.Text += "<td>";
    //        ltservicepackagetotal.Text += "<p style='font-size:18px;'>Budget Amount: </p>";
    //        ltservicepackagetotal.Text += "</td>";
    //        ltservicepackagetotal.Text += "<td style='font-size:18px; text-align:right; width:20%;'>";
    //        ltservicepackagetotal.Text += ""+ budgetamount.ToString() + "/- Rs.";
    //        ltservicepackagetotal.Text += "</td>";
    //        ltservicepackagetotal.Text += "</tr>";
    //        ltservicepackagetotal.Text += "<tr>";
    //        ltservicepackagetotal.Text += "<td>";
    //        ltservicepackagetotal.Text += "<p style='font-size:18px;'>Package Amount:</p>";
    //        ltservicepackagetotal.Text += "</td>";
    //        ltservicepackagetotal.Text += "<td style='font-size:18px; text-align:right; width:20%;'>";
    //        ltservicepackagetotal.Text += ""+total.ToString() + "/- Rs.";
    //        ltservicepackagetotal.Text += "</td>";
    //        ltservicepackagetotal.Text += "</tr>";
    //        ltservicepackagetotal.Text += "</table>";
    //    }
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindeventplan();
        }
    }
    //protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    int id = Convert.ToInt32(GridView1.Rows[e.RowIndex].Cells[1].Text);
    //    objeventservicedal.deleteEventService(id);
    //    bindeventservice();
    //    Response.Write("<script>alert('You have delete one service from event plan.');</script>");
    //}
    //protected void btnconfirm_Click(object sender, EventArgs e)
    //{
    //    objeventplanbal.EventPlanID = Convert.ToInt32(Session["eventplanid"].ToString ());
    //    objeventplanbal.PlanStatus = "Confirm";
    //    objeventplandal.updateEventStatus(objeventplanbal);
    //}
}