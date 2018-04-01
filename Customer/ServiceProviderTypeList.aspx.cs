using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Customer_ServiceProviderTypeList : System.Web.UI.Page
{
    BALServiceProviderType objserviceprovidertypebal = new BALServiceProviderType();
    DALServiceProviderType objserviceprovidertypedal = new DALServiceProviderType();

    public void bindserviceprovidertype()
    {
        DataList1.DataSource = objserviceprovidertypedal.selectServiceProviderType();
        DataList1.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindserviceprovidertype();
        }
    }
}