using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;



public partial class Admin_Home : System.Web.UI.Page
{
    DALCustomer objcustomerdal = new DALCustomer();
    DALEventplan objeventplandal = new DALEventplan();
    DALEventService objeventservicedal = new DALEventService();
    DALEventType objeventtypedal = new DALEventType();
    DALFeedback objfeedbackdal = new DALFeedback();
    DALInquiry objinquirydal = new DALInquiry();
    DALServicepackage objservicepackagedal = new DALServicepackage();
    DALServiceProvider objserviceproviderdal = new DALServiceProvider();
    DALServiceProviderType objserviceprovidertypedal = new DALServiceProviderType();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            DataSet dscustomer = new DataSet();
            DataSet dseventplan = new DataSet();
            DataSet dseventservice = new DataSet();
            DataSet dseventtype = new DataSet();
            DataSet dsfeedback = new DataSet();
            DataSet dsinquiry = new DataSet();
            DataSet dsservicepackage = new DataSet();
            DataSet dsserviceprovider = new DataSet();
            DataSet dsserviceprovidertype = new DataSet();
            dscustomer = objcustomerdal.gettotalcustomer();
            dseventplan = objeventplandal.gettotaleventplan();
            dseventservice = objeventservicedal.gettotaleventservice();
            dseventtype = objeventtypedal.gettotaleventtype();
            dsfeedback = objfeedbackdal.gettotalfeedback();
            dsinquiry = objinquirydal.gettotalinquiry();
            dsservicepackage = objservicepackagedal.gettotalservicepackage();
            dsserviceprovider = objserviceproviderdal.gettotalserviceprovider();
            dsserviceprovidertype = objserviceprovidertypedal.gettotalserviceprovidertype();
            Literal1.Text = dscustomer.Tables[0].Rows[0][0].ToString();
            Literal2.Text = dseventplan.Tables[0].Rows[0][0].ToString();
            Literal3.Text = dseventservice.Tables[0].Rows[0][0].ToString();
            Literal4.Text = dseventtype.Tables[0].Rows[0][0].ToString();
            Literal5.Text = dsfeedback.Tables[0].Rows[0][0].ToString();
            Literal6.Text = dsinquiry.Tables[0].Rows[0][0].ToString();
            Literal7.Text = dsservicepackage.Tables[0].Rows[0][0].ToString();
            Literal8.Text = dsserviceprovider.Tables[0].Rows[0][0].ToString();
            Literal9.Text = dsserviceprovidertype.Tables[0].Rows[0][0].ToString();
        }
    }
}