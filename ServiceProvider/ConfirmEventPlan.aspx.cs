using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ServiceProvider_ConfirmEventPlan : System.Web.UI.Page
{
    BALEventPlan objeventplanbal = new BALEventPlan();
    DALEventplan objeventplandal = new DALEventplan();


    public void bindconfirmeventplan()
    {
        int id = Convert.ToInt32(Session["serviceproviderid"].ToString());
        DataSet ds = new DataSet();
        ds = objeventplandal.SelectConfirmEventPlanByServiceProviderID(id);

        if(ds.Tables [0].Rows.Count > 0 )
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {

        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            bindconfirmeventplan();
        }
    }
}