using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EventTypeList : System.Web.UI.Page
{
    BALEventType objeventtypebal = new BALEventType();
    DALEventType objeventtypedal = new DALEventType();
    public void bindeventtype()
    {
        DataList1.DataSource = objeventtypedal.selectEventType();
        DataList1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindeventtype();
        }
    }
}