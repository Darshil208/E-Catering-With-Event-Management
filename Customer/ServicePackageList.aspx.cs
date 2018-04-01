
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_ServicePackageList : System.Web.UI.Page
{
    BALServicePackage objservicepackagebal = new BALServicePackage();
    DALServicepackage objservicepackagedal = new DALServicepackage();

    BALEventService objeventservicebal = new BALEventService();
    DALEventService objeventservicedal = new DALEventService();

    DALServiceProvider objserviceproviderdal = new DALServiceProvider();
    BALEventPlan objeventplanbal = new BALEventPlan();
    DALEventplan objeventplandal = new DALEventplan();

   public void bindservicepackage()
    {
        DataList1.DataSource = objservicepackagedal.selectServicePackageByProviderID(Convert.ToInt32(Request.QueryString["spid"].ToString()));
        DataList1.DataBind();
    }

    
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["spid"] == null)
        {
            Response.Redirect("Home.aspx");
        }
        if (!IsPostBack)
        {
            bindservicepackage();
        }
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "hlbaddtoplan")
        {
            DataSet dsotherevent = new DataSet();
            dsotherevent = objserviceproviderdal.CheckServiceProviderAvailability(Convert.ToInt32(Session["eventplanid"].ToString()), Convert.ToInt32(e.CommandArgument));

            DataSet dsmyevent = new DataSet();

            dsmyevent = objeventplandal.selectMyEventDateByEventPlanID(Convert.ToInt32(Session["eventplanid"].ToString()));
            bool status = false;

            if (dsotherevent.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsotherevent.Tables[0].Rows.Count; i++)
                {
                    if (((Convert.ToDateTime(dsmyevent.Tables[0].Rows[0]["estartdate"]) >= Convert.ToDateTime(dsotherevent.Tables[0].Rows[i]["estartdate"])) && (Convert.ToDateTime(dsmyevent.Tables[0].Rows[0]["estartdate"]) <= Convert.ToDateTime(dsotherevent.Tables[0].Rows[i]["eenddate"]))) && ((Convert.ToDateTime(dsmyevent.Tables[0].Rows[0]["eenddate"]) >= Convert.ToDateTime(dsotherevent.Tables[0].Rows[i]["estartdate"])) && (Convert.ToDateTime(dsmyevent.Tables[0].Rows[0]["eenddate"]) <= Convert.ToDateTime(dsotherevent.Tables[0].Rows[i]["eenddate"]))))
                    {
                        status = true;
                    }
                }
            }
            if (status == true)
            {
                Response.Write("<script>alert('Sorry, this provider is booked for the same date.');</script>");
            }
            else
            {
                DataSet ds = new DataSet();
                ds = objservicepackagedal.selectServicePackageByID(Convert.ToInt32(e.CommandArgument));

                objeventservicebal.EventPlanID = Convert.ToInt32(Session["eventplanid"].ToString());
                objeventservicebal.ServicePackageID = Convert.ToInt32(e.CommandArgument);
                objeventservicebal.ServicePackageQuantity = 1;
                objeventservicebal.ServicePackageAmount = Convert.ToInt32(ds.Tables[0].Rows[0]["servicepackageamount"].ToString());
                objeventservicebal.ServicePackageTotalAmount = Convert.ToInt32(ds.Tables[0].Rows[0]["servicepackageamount"].ToString());

                objeventservicedal.insertEventService(objeventservicebal);
                Response.Redirect("EventPlan.aspx");
            }




            //DataSet ds = new DataSet();
            //ds = objeventservicedal.selectEventServiceByEventPlanID(Convert.ToInt32(Session["eventplanid"].ToString()));
            
            //objeventservicebal.EventPlanID = Convert.ToInt32(ds.Tables [0].Rows[0]["eventplanid"].ToString ());
            //objeventservicebal.ServicePackageID = Convert.ToInt32( e.CommandArgument);
            //objeventservicebal.ServicePackageAmount = Convert.ToInt32(ds.Tables[0].Rows[0]["servicepackageamont"].ToString());
            //objeventservicebal.ServicePackageTotalAmount= Convert.ToInt32(ds.Tables[0].Rows[0]["servicepackageamont"].ToString());
            //objeventservicebal.ServicePackageQuantity = 1;

            //objeventservicedal.insertEventService(objeventservicebal);
            //Response.Redirect("EventPlan.aspx");
        }
    }
}