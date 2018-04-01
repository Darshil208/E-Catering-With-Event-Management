using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

public partial class Admin_feedback : System.Web.UI.Page
{
    BALFeedback objfeedbackbal = new BALFeedback();
    DALFeedback objfeedbackdal = new DALFeedback();

    public void bindgrid()
    {
        int id = Convert.ToInt32(Session["serviceproviderid"].ToString());
        GridView1.DataSource = objfeedbackdal.selectFeedbackByServiceProviderID(id);
        GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrid();
        }
    }
}